using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Возвращает список всех пользователей
    /// </summary>
    Task<IEnumerable<User>> GetAllAsync();

    /// <summary>
    /// Возвращает пользователя по его идентификатору
    /// </summary>
    Task<User> GetByIdAsync(Guid id);

    /// <summary>
    /// Добавляет нового пользователя
    /// </summary>
    Task<Guid> AddUser(User user);

    /// <summary>
    /// Обновляет данные пользователя
    /// </summary>
    Task<bool> UpdateUser(User user);

    /// <summary>
    /// Удаляет пользователя по его идентификатору
    /// </summary>
    Task<bool> DeleteUser(Guid id);
}