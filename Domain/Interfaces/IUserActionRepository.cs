using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IUserActionRepository
{
    /// <summary>
    /// Возвращает список всех действий пользователя
    /// </summary>
    Task<IEnumerable<UserAction>> GetAllAsync();

    /// <summary>
    /// Добавляет действие пользователя
    /// </summary>
    Task<int> AddUserAction(UserAction action);

    /// <summary>
    /// Удаляет действие пользователя по идентификатору
    /// </summary>
    Task<bool> DeleteUserAction(int id);
}