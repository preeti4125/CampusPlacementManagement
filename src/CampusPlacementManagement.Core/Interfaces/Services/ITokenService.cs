using System.Security.Claims;
using CampusPlacementManagement.Core.Entities;
namespace CampusPlacementManagement.Core.Interfaces.Services;
public interface ITokenService
{
    string GenerateAccessToken(ApplicationUser user, IList<string> roles, int? collegeId = null, int? companyId = null);
    string GenerateRefreshToken();
}
