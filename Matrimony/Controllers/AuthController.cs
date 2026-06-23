using Matrimony.Models.DTOs;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        var response = await _userService.RegisterAsync(dto);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var response = await _userService.LoginAsync(dto);

        if (!response.Success)
            return Unauthorized(response);

        return Ok(response);
    }
}