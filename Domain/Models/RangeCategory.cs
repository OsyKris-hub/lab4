namespace ItsRandomLife.Domain.Models;

public class RangeCategory
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public User? User { get; set; } // nullable
    public ICollection<UserRange> UserRanges { get; set; } = new List<UserRange>();
}