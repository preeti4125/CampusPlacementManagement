using System.Security.Claims;
using CampusPlacementManagement.Core.Interfaces.Services;

namespace CampusPlacementManagement.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _accessor;
    public CurrentUserService(IHttpContextAccessor accessor) => _accessor = accessor;
    public string? UserId => _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    public string? Email => _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
    public string? Role => _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
    public int? CollegeId => int.TryParse(_accessor.HttpContext?.User.FindFirstValue("CollegeId"), out var cid) ? cid : null;
    public int? CompanyId => int.TryParse(_accessor.HttpContext?.User.FindFirstValue("CompanyId"), out var compId) ? compId : null;
}
