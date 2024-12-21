using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IDailyPhraseRepository
{
    /// <summary>
    /// Возвращает список всех фраз-пожеланий
    /// </summary>
    Task<IEnumerable<DailyPhrase>> GetAllAsync();

    /// <summary>
    /// Добавляет новую фразу-пожелание
    /// </summary>
    Task<int> AddPhrase(DailyPhrase phrase);

    /// <summary>
    /// Удаляет фразу-пожелание по идентификатору
    /// </summary>
    Task<bool> DeletePhrase(int id);
}