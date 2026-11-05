namespace CampusPlacementManagement.Core.Entities;

public class InterviewRound
{
    public int RoundId { get; set; }
    public int JobId { get; set; }
    public int? DriveId { get; set; }
    public int RoundNumber { get; set; }
    public string RoundName { get; set; } = string.Empty;
    public string? Description { get; set; }

    // Navigation properties
    public JobOpening JobOpening { get; set; } = null!;
    public RecruitmentDrive? RecruitmentDrive { get; set; }
    public ICollection<InterviewSchedule> InterviewSchedules { get; set; } = new List<InterviewSchedule>();
}
