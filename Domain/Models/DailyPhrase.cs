namespace ItsRandomLife.Domain.Models;

public class DailyPhrase
{
    public int Id { get; set; }
    public string Phrase { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}