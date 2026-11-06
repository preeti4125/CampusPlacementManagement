using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace CampusPlacementManagement.Infrastructure.Identity;
public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config) => _config = config;

    public string GenerateAccessToken(ApplicationUser user, IList<string> roles, int? collegeId = null, int? companyId = null)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new("FullName", user.FullName)
        };
        foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));
        if (collegeId.HasValue) claims.Add(new Claim("CollegeId", collegeId.Value.ToString()));
        if (companyId.HasValue) claims.Add(new Claim("CompanyId", companyId.Value.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "super_secret_placement_management_key_2026_at_least_32_chars_long!"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"] ?? "CampusPlacementAPI",
            audience: _config["Jwt:Audience"] ?? "CampusPlacementClients",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(4),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var bytes = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}
