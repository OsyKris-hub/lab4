namespace ItsRandomLife.Domain.Models;

public class NotificationCategory
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}