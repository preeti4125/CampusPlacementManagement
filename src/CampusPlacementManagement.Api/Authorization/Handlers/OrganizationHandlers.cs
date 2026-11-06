using CampusPlacementManagement.Api.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace CampusPlacementManagement.Api.Authorization.Handlers;

public class SameCollegeHandler : AuthorizationHandler<SameCollegeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameCollegeRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == "CollegeId")) context.Succeed(requirement);
        return Task.CompletedTask;
    }
}

public class SameCompanyHandler : AuthorizationHandler<SameCompanyRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameCompanyRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == "CompanyId")) context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
