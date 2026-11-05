namespace CampusPlacementManagement.Core.Entities;

public class JobTargetCollege
{
    public int JobTargetCollegeId { get; set; }
    public int JobId { get; set; }
    public int CollegeId { get; set; }

    // Navigation properties
    public JobOpening JobOpening { get; set; } = null!;
    public College College { get; set; } = null!;
}
