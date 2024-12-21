using ItsRandomLife.Domain.DTO;
using ItsRandomLife.Domain.Interfaces;
using ItsRandomLife.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItsRandomLife.API;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var users = await _userRepository.GetAllAsync();
        var userDtos = users.Select(user => new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            CreatedAt = user.CreatedAt
        });

        return Ok(userDtos);
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return NotFound($"User with id={id} not found");

        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            CreatedAt = user.CreatedAt
        };

        return Ok(userDto);
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserCreateDto userDto)
    {
        if (userDto == null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password))
            return BadRequest("User data is invalid");

        var user = new User
        {
            Username = userDto.Username,
            Password = userDto.Password
        };

        var userId = await _userRepository.AddUser(user);
        return CreatedAtAction(nameof(Get), new { id = userId }, null);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UserUpdateDto userDto)
    {
        if (userDto == null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password))
            return BadRequest("User data is invalid");

        var user = new User
        {
            Id = id,
            Username = userDto.Username,
            Password = userDto.Password
        };

        var result = await _userRepository.UpdateUser(user);

        if (!result)
            return NotFound($"User with id={id} not found");

        return Ok();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _userRepository.DeleteUser(id);

        if (!result)
            return NotFound($"User with id={id} not found");

        return Ok();
    }
}
