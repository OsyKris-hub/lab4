using ItsRandomLife.Domain.Interfaces;

namespace ItsRandomLife.Domain.Services;

public class RandomAnswerService : IRandomAnswerService
{
    private readonly IRandomAnswerRepository _randomAnswerRepository;
    private readonly ILogger<RandomAnswerService> _logger;

    public RandomAnswerService(IRandomAnswerRepository randomAnswerRepository, ILogger<RandomAnswerService> logger)
    {
        _randomAnswerRepository = randomAnswerRepository;
        _logger = logger;
    }

    public async Task<string> GetRandomYesNoAsync()
    {
        _logger.LogInformation("Getting all random answers from repository...");
        var answers = await _randomAnswerRepository.GetAllAsync();
        var list = answers.ToList();
        if (!list.Any())
        {
            _logger.LogWarning("No answers found in DB, returning default 'нет'");
            return "нет";
        }
        
        var random = new Random();
        var index = random.Next(list.Count);
        var chosenAnswer = list[index].Answer;
        _logger.LogInformation("Chosen random answer: {answer}", chosenAnswer);
        return chosenAnswer;
    }
}