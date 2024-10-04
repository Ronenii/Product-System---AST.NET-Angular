using Backend.DTO.User;
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
}