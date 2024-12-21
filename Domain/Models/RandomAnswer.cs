namespace ItsRandomLife.Domain.Models;

public class RandomAnswer
{
    public int Id { get; set; }
    public string Answer { get; set; } = string.Empty;
    public Guid? UserId { get; set; }

    public User User { get; set; }
}