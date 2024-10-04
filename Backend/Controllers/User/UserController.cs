using Backend.DTO.User;
using Backend.DTO.User.Login;
using Backend.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController: Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
    public async Task<IActionResult> GetAllUsers()
    {
        IEnumerable<UserDTO> users = await _userService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(UserDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetUserById(int id)
    {
        UserDTO user = await _userService.GetUserById(id);
        if(user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(UserDTO))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDTO createUserDTO)
    {
        try
        {
            UserDTO user = await _userService.CreateUser(createUserDTO);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}