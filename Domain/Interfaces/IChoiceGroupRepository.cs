using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IChoiceGroupRepository
{
    /// <summary>
    /// Возвращает список всех групп выбора
    /// </summary>
    Task<IEnumerable<ChoiceGroup>> GetAllAsync();

    /// <summary>
    /// Добавляет новую группу выбора
    /// </summary>
    Task<int> AddGroup(ChoiceGroup group);

    /// <summary>
    /// Обновляет группу выбора
    /// </summary>
    Task<bool> UpdateGroup(ChoiceGroup group);

    /// <summary>
    /// Удаляет группу выбора по идентификатору
    /// </summary>
    Task<bool> DeleteGroup(int id);
}