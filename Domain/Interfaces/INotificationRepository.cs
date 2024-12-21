using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface INotificationRepository
{
    /// <summary>
    /// Возвращает список всех уведомлений
    /// </summary>
    Task<IEnumerable<Notification>> GetAllAsync();

    /// <summary>
    /// Добавляет новое уведомление
    /// </summary>
    Task<int> AddNotification(Notification notification);

    /// <summary>
    /// Обновляет уведомление
    /// </summary>
    Task<bool> UpdateNotification(Notification notification);

    /// <summary>
    /// Удаляет уведомление по идентификатору
    /// </summary>
    Task<bool> DeleteNotification(int id);
}