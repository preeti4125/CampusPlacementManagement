using System.Security.Claims;
namespace CampusPlacementManagement.Core.Interfaces.Services;
public interface ICurrentUserService
{
    string? UserId { get; }
    string? Email { get; }
    string? Role { get; }
    int? CollegeId { get; }
    int? CompanyId { get; }
}
