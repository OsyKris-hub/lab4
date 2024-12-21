namespace ItsRandomLife.Domain.Models;

public class DailyActivity
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int? NotificationId { get; set; }
    public int? PhraseId { get; set; }
    public DateTime ActivityDate { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public Notification Notification { get; set; }
    public DailyPhrase DailyPhrase { get; set; }
}