namespace ItsRandomLife.Domain.DTO;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
}