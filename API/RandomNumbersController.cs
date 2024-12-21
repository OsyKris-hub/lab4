using ItsRandomLife.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItsRandomLife.API;

[Route("api/[controller]")]
[ApiController]
public class RandomNumbersController : ControllerBase
{
    private readonly IRandomNumberService _randomNumberService;
    private readonly ILogger<RandomNumbersController> _logger;

    public RandomNumbersController(IRandomNumberService randomNumberService, ILogger<RandomNumbersController> logger)
    {
        _randomNumberService = randomNumberService;
        _logger = logger;
    }

    [HttpGet("inrange")]
    public IActionResult GetNumberInRange([FromQuery] int min, [FromQuery] int max)
    {
        try
        {
            _logger.LogInformation("Request for random number in range {min}-{max}", min, max);
            var number = _randomNumberService.GetRandomNumberInRange(min, max);
            return Ok(number);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while generating random number in range");
            return StatusCode(500, "Internal server error");
        }
    }
}