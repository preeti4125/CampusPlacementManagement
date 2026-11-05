using CampusPlacementManagement.Core.Enums;

namespace CampusPlacementManagement.Core.Entities;

public class RecruitmentDrive
{
    public int DriveId { get; set; }
    public int JobId { get; set; }
    public string DriveName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string VenueOrPlatform { get; set; } = string.Empty;
    public DriveStatus Status { get; set; } = DriveStatus.Scheduled;

    // Navigation properties
    public JobOpening JobOpening { get; set; } = null!;
    public ICollection<InterviewRound> InterviewRounds { get; set; } = new List<InterviewRound>();
}
