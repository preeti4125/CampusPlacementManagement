using CampusPlacementManagement.Core.Enums;

namespace CampusPlacementManagement.Core.Entities;

public class College
{
    public int CollegeId { get; set; }
    public string CollegeName { get; set; } = string.Empty;
    public string CollegeCode { get; set; } = string.Empty;
    public string? UniversityName { get; set; }
    public string OfficialEmail { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Website { get; set; }
    public AccountStatus Status { get; set; } = AccountStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<PlacementOfficer> PlacementOfficers { get; set; } = new List<PlacementOfficer>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<JobTargetCollege> TargetColleges { get; set; } = new List<JobTargetCollege>();
}
