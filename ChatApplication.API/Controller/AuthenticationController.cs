using ChatApplication.BLL.Dto.Authentication;
using ChatApplication.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.API.Controller;

[Route("api")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto, IConfiguration configuration)
    {
        var result = await _authenticationService.Login(loginDto, configuration);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _authenticationService.Register(registerDto);
        return StatusCode(result.StatusCode, result);
    }
}