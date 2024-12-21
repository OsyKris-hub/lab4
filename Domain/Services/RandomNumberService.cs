using ItsRandomLife.Domain.Interfaces;

namespace ItsRandomLife.Domain.Services;

public class RandomNumberService : IRandomNumberService
{
    private readonly ILogger<RandomNumberService> _logger;

    public RandomNumberService(ILogger<RandomNumberService> logger)
    {
        _logger = logger;
    }

    public int GetRandomNumberInRange(int min, int max)
    {
        if (min > max)
        {
            _logger.LogWarning("Invalid range: min {min} > max {max}. Swapping values.", min, max);
            (min, max) = (max, min);
        }
        
        var random = new Random();
        var result = random.Next(min, max + 1);
        _logger.LogInformation("Generated random number {result} in range {min}-{max}", result, min, max);
        return result;
    }
}