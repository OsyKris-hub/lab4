using ItsRandomLife.Domain.Interfaces;
using ItsRandomLife.Domain.Models;
using ItsRandomLife.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace;

public class RandomAnswerRepository : IRandomAnswerRepository
{
    private readonly ApplicationDbContext _context;

    public RandomAnswerRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<RandomAnswer>> GetAllAsync()
    {
        return await _context.RandomAnswers.ToListAsync();
    }

    public async Task<int> AddRandomAnswer(RandomAnswer answer)
    {
        _context.RandomAnswers.Add(answer);
        await _context.SaveChangesAsync();
        return answer.Id;
    }

    public async Task<bool> DeleteRandomAnswer(int id)
    {
        var entity = await _context.RandomAnswers.FindAsync(id);
        if (entity == null)
            return false;
        _context.RandomAnswers.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}