using Microsoft.AspNetCore.Identity;
using CampusPlacementManagement.Core.Enums;

namespace CampusPlacementManagement.Core.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public AccountStatus Status { get; set; } = AccountStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public PlacementOfficer? PlacementOfficer { get; set; }
    public CompanyHR? CompanyHR { get; set; }
    public Student? Student { get; set; }
}
