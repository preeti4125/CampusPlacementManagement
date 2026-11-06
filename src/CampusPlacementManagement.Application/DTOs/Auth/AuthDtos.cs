namespace CampusPlacementManagement.Application.DTOs.Auth;
public record LoginDto(string Email, string Password);
public record RegisterDto(string Email, string Password, string FullName, string Role);
public record TokenResponseDto(string AccessToken, string RefreshToken, string Role, string UserId);
