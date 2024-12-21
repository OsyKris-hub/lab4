using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IDailyActivityRepository
{
    /// <summary>
    /// Возвращает список всех ежедневных активностей
    /// </summary>
    Task<IEnumerable<DailyActivity>> GetAllAsync();

    /// <summary>
    /// Добавляет новую ежедневную активность
    /// </summary>
    Task<int> AddActivity(DailyActivity activity);

    /// <summary>
    /// Удаляет ежедневную активность по идентификатору
    /// </summary>
    Task<bool> DeleteActivity(int id);
}