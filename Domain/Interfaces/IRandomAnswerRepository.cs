using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IRandomAnswerRepository
{
    /// <summary>
    /// Возвращает список всех случайных ответов
    /// </summary>
    Task<IEnumerable<RandomAnswer>> GetAllAsync();

    /// <summary>
    /// Добавляет новый случайный ответ
    /// </summary>
    Task<int> AddRandomAnswer(RandomAnswer answer);

    /// <summary>
    /// Удаляет случайный ответ по идентификатору
    /// </summary>
    Task<bool> DeleteRandomAnswer(int id);
}