using ItsRandomLife.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItsRandomLife.API;

[Route("api/[controller]")]
[ApiController]
public class RandomAnswersController : ControllerBase
{
    private readonly IRandomAnswerService _randomAnswerService;
    private readonly ILogger<RandomAnswersController> _logger;

    public RandomAnswersController(IRandomAnswerService randomAnswerService, ILogger<RandomAnswersController> logger)
    {
        _randomAnswerService = randomAnswerService;
        _logger = logger;
    }

    [HttpGet("yesno")]
    public async Task<IActionResult> GetYesNoAnswer()
    {
        try
        {
            _logger.LogInformation("Request for random yes/no answer");
            var answer = await _randomAnswerService.GetRandomYesNoAsync();
            return Ok(answer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting yes/no answer");
            return StatusCode(500, "Internal server error");
        }
    }
}