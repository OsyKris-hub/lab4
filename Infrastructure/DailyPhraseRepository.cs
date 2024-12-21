using Npgsql;
using ItsRandomLife.Domain.Interfaces;
using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Infrastructure;

public class DailyPhraseRepository : IDailyPhraseRepository
{
    private readonly string _connectionStringName = "MainConnectionString";
    private readonly IConfiguration _configuration;

    public DailyPhraseRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<IEnumerable<DailyPhrase>> GetAllAsync()
    {
        var phrases = new List<DailyPhrase>();
        var query = "SELECT * FROM DailyPhrases";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    phrases.Add(new DailyPhrase
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Phrase = reader.GetString(reader.GetOrdinal("Phrase")),
                        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                    });
                }
            }
        }

        return phrases;
    }

    public async Task<int> AddPhrase(DailyPhrase phrase)
    {
        if (phrase == null)
            throw new ArgumentNullException(nameof(phrase));

        var query =
            "INSERT INTO DailyPhrases (Phrase, CreatedAt) VALUES (@Phrase, @CreatedAt) RETURNING Id";

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString(_connectionStringName)))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Phrase", phrase.Phrase);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }
    }

    public async Task<bool> DeletePhrase(int id)
    {
        var query = "DELETE FROM DailyPhrases WHERE Id = @Id";

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
