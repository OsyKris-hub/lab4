namespace ItsRandomLife.Domain.Models;

public class UserAction
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public string ActionDescription { get; set; } = string.Empty;
    public DateTime ActionTime { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
}