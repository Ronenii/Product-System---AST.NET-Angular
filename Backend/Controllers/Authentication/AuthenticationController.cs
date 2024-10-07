using Backend.DTO.User;
using Backend.DTO.User.Login;
using Backend.Services.Token;
using Backend.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Authentication;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController: Controller
{
    private readonly UserService _userService;
    private readonly TokenService _tokenService;

    public AuthenticationController(UserService i_UserService, TokenService i_TokenService)
    {
        _userService = i_UserService;
        _tokenService = i_TokenService;
    }
    
    [HttpPost("Login")]
    [AllowAnonymous]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        Models.User user = await _userService.Authenticate(loginDTO);

        if(user == null)
        {
            return Unauthorized();
        }
        
        string token = _tokenService.GenerateToken(user);

        return Ok(token);
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    [ProducesResponseType(201, Type = typeof(string))]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Register([FromBody] CreateUserDTO createUserDTO)
    {
        try
        {
            await _userService.CreateUser(createUserDTO);
            return await Login(new LoginDTO(createUserDTO.Username, createUserDTO.Password));
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}