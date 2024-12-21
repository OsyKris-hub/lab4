using ItsRandomLife.Domain.Models;

namespace ItsRandomLife.Domain.Interfaces;

public interface IRangeCategoryRepository
{
    /// <summary>
    /// Возвращает список всех категорий диапазонов
    /// </summary>
    Task<IEnumerable<RangeCategory>> GetAllAsync();

    /// <summary>
    /// Добавляет новую категорию диапазонов
    /// </summary>
    Task<int> AddCategory(RangeCategory category);

    /// <summary>
    /// Обновляет категорию диапазонов
    /// </summary>
    Task<bool> UpdateCategory(RangeCategory category);

    /// <summary>
    /// Удаляет категорию диапазонов по идентификатору
    /// </summary>
    Task<bool> DeleteCategory(int id);
}