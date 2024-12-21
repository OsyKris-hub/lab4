namespace ItsRandomLife.Domain.Models;

public class ChoiceGroup
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public ICollection<Choice> Choices { get; set; } = new List<Choice>();
}