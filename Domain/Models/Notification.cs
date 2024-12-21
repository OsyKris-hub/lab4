namespace ItsRandomLife.Domain.Models;

public class Notification
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int? CategoryId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime? ScheduledTime { get; set; }
    public bool IsSent { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public NotificationCategory Category { get; set; }
}