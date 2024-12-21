using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IChoiceRepository
{
    /// <summary>
    /// Возвращает список всех вариантов выбора
    /// </summary>
    Task<IEnumerable<Choice>> GetAllAsync();

    /// <summary>
    /// Добавляет новый вариант выбора
    /// </summary>
    Task<int> AddChoice(Choice choice);

    /// <summary>
    /// Удаляет вариант выбора по идентификатору
    /// </summary>
    Task<bool> DeleteChoice(int id);
}