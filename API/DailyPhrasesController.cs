using ItsRandomLife.Domain.Interfaces;
using ItsRandomLife.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItsRandomLife.API;

[Route("api/[controller]")]
[ApiController]
public class DailyPhrasesController : ControllerBase
{
    private readonly IDailyPhraseRepository _dailyPhraseRepository;

    public DailyPhrasesController(IDailyPhraseRepository dailyPhraseRepository)
    {
        _dailyPhraseRepository =
            dailyPhraseRepository ?? throw new ArgumentNullException(nameof(dailyPhraseRepository));
    }

    // GET: api/DailyPhrases
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var phrases = await _dailyPhraseRepository.GetAllAsync();
        return Ok(phrases);
    }

    // POST: api/DailyPhrases
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DailyPhrase phrase)
    {
        if (phrase == null || string.IsNullOrWhiteSpace(phrase.Phrase))
            return BadRequest("Phrase is not provided or empty");

        var phraseId = await _dailyPhraseRepository.AddPhrase(phrase);
        return CreatedAtAction(nameof(Get), new { id = phraseId }, null);
    }

    // DELETE: api/DailyPhrases/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _dailyPhraseRepository.DeletePhrase(id);

        if (!result)
            return NotFound($"Phrase with id={id} not found");

        return Ok();
    }
}