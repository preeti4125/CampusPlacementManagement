using CampusPlacementManagement.Application.DTOs.Auth;
using CampusPlacementManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto) => Ok(await _auth.LoginAsync(dto));

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto) => Ok(new { UserId = await _auth.RegisterAsync(dto) });
}
