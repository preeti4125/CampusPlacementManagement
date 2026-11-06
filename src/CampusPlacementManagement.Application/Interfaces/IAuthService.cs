using CampusPlacementManagement.Application.DTOs.Auth;
namespace CampusPlacementManagement.Application.Interfaces;
public interface IAuthService
{
    Task<TokenResponseDto> LoginAsync(LoginDto dto);
    Task<string> RegisterAsync(RegisterDto dto);
}
