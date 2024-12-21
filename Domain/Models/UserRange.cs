namespace ItsRandomLife.Domain.Models;

public class UserRange
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int CategoryId { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public RangeCategory Category { get; set; }
}