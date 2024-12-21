using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IUserRangeRepository
{
    /// <summary>
    /// Возвращает список всех диапазонов пользователя
    /// </summary>
    Task<IEnumerable<UserRange>> GetAllAsync();

    /// <summary>
    /// Добавляет новый диапазон для пользователя
    /// </summary>
    Task<int> AddUserRange(UserRange range);

    /// <summary>
    /// Обновляет диапазон пользователя
    /// </summary>
    Task<bool> UpdateUserRange(UserRange range);

    /// <summary>
    /// Удаляет диапазон пользователя по идентификатору
    /// </summary>
    Task<bool> DeleteUserRange(int id);
}