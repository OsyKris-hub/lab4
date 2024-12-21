using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface INotificationCategoryRepository
{
    /// <summary>
    /// Возвращает список всех категорий уведомлений
    /// </summary>
    Task<IEnumerable<NotificationCategory>> GetAllAsync();

    /// <summary>
    /// Добавляет новую категорию уведомлений
    /// </summary>
    Task<int> AddCategory(NotificationCategory category);

    /// <summary>
    /// Обновляет категорию уведомлений
    /// </summary>
    Task<bool> UpdateCategory(NotificationCategory category);

    /// <summary>
    /// Удаляет категорию уведомлений по идентификатору
    /// </summary>
    Task<bool> DeleteCategory(int id);
}