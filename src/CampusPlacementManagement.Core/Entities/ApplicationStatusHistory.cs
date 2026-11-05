using CampusPlacementManagement.Core.Enums;

namespace CampusPlacementManagement.Core.Entities;

public class ApplicationStatusHistory
{
    public int HistoryId { get; set; }
    public int ApplicationId { get; set; }
    public ApplicationStatus OldStatus { get; set; }
    public ApplicationStatus NewStatus { get; set; }
    public string? Remarks { get; set; }
    public string ChangedByUserId { get; set; } = string.Empty;
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public JobApplication JobApplication { get; set; } = null!;
}
