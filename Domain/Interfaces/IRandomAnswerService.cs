namespace ItsRandomLife.Domain.Interfaces;

public interface IRandomAnswerService
{
    Task<string> GetRandomYesNoAsync();
}