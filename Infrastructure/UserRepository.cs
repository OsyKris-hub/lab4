using Npgsql;
using ItsRandomLife.Domain.Interfaces;
using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly string _connectionStringName = "MainConnectionString";
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = new List<User>();
        var query = "SELECT * FROM users";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new User
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            CreatedAt = DateTime.Parse(reader["createdat"].ToString())
                        });
                    }
                }
            }
        }

        return users;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        User user = null;
        var query = "SELECT * FROM users WHERE id = @Id";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        user = new User
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            CreatedAt = DateTime.Parse(reader["createdat"].ToString())
                        };
                    }
                }
            }
        }

        return user;
    }

    public async Task<Guid> AddUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var id = Guid.NewGuid();
        var query =
            "INSERT INTO users (id, username, password, createdat) VALUES (@Id, @Username, @Password, @CreatedAt) RETURNING id";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                var result = await command.ExecuteScalarAsync();
                return Guid.Parse(result.ToString());
            }
        }
    }

    public async Task<bool> UpdateUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var query =
            "UPDATE users SET username = @Username, password = @Password WHERE id = @Id";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
        }
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var query = "DELETE FROM users WHERE id = @Id";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                var affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
        }
    }

    private async Task ExecuteNonQueryAsync(string query, Dictionary<string, object> parameters = null)
    {
        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
