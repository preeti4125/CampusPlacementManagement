namespace CampusPlacementManagement.Core.Entities;

public class CompanyHR
{
    public int CompanyHRId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public string? Designation { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }

    // Navigation properties
    public ApplicationUser User { get; set; } = null!;
    public Company Company { get; set; } = null!;
    public ICollection<JobOpening> CreatedJobs { get; set; } = new List<JobOpening>();
}
