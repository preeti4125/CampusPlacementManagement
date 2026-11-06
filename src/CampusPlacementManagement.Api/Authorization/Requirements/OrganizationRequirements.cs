using Microsoft.AspNetCore.Authorization;

namespace CampusPlacementManagement.Api.Authorization.Requirements;

public class SameCollegeRequirement : IAuthorizationRequirement { }
public class SameCompanyRequirement : IAuthorizationRequirement { }
