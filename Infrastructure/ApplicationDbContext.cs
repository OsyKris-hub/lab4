using ItsRandomLife.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ItsRandomLife.Infrastructure;

public class ApplicationDbContext : DbContext
{
    
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<DailyPhrase> DailyPhrases { get; set; }
    public DbSet<RandomAnswer> RandomAnswers { get; set; }
    public DbSet<UserRange> UserRanges { get; set; }
    public DbSet<RangeCategory> RangeCategories { get; set; }
    
    
    
    
    
}
