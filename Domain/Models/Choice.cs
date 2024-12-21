namespace ItsRandomLife.Domain.Models;

public class Choice
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string ChoiceText { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ChoiceGroup Group { get; set; }
}