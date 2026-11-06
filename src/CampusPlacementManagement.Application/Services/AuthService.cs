using CampusPlacementManagement.Application.DTOs.Auth;
using CampusPlacementManagement.Application.Exceptions;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
namespace CampusPlacementManagement.Application.Services;
public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            throw new BadRequestException("Invalid credentials.");

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.GenerateAccessToken(user, roles);
        var refresh = _tokenService.GenerateRefreshToken();
        return new TokenResponseDto(token, refresh, roles.FirstOrDefault() ?? "Student", user.Id);
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        var existing = await _userManager.FindByEmailAsync(dto.Email);
        if (existing != null) throw new BadRequestException("Email already registered.");
        if (!await _roleManager.RoleExistsAsync(dto.Role)) throw new BadRequestException("Invalid role.");

        var user = new ApplicationUser { UserName = dto.Email, Email = dto.Email, FullName = dto.FullName, Status = AccountStatus.Approved, EmailConfirmed = true };
        var res = await _userManager.CreateAsync(user, dto.Password);
        if (!res.Succeeded) throw new BadRequestException(string.Join(", ", res.Errors.Select(e => e.Description)));
        await _userManager.AddToRoleAsync(user, dto.Role);
        return user.Id;
    }
}
