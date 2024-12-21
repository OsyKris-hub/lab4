namespace ItsRandomLife.Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<RangeCategory> RangeCategories { get; set; } = new List<RangeCategory>();
    public ICollection<UserRange> UserRanges { get; set; } = new List<UserRange>();
    public ICollection<NotificationCategory> NotificationCategories { get; set; } = new List<NotificationCategory>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<ChoiceGroup> ChoiceGroups { get; set; } = new List<ChoiceGroup>();
    public ICollection<UserAction> UserActions { get; set; } = new List<UserAction>();
    public ICollection<DailyActivity> DailyActivities { get; set; } = new List<DailyActivity>();
    public ICollection<RandomAnswer> RandomAnswers { get; set; } = new List<RandomAnswer>();
}