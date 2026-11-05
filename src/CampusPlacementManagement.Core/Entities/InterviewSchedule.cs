using CampusPlacementManagement.Core.Enums;

namespace CampusPlacementManagement.Core.Entities;

public class InterviewSchedule
{
    public int ScheduleId { get; set; }
    public int ApplicationId { get; set; }
    public int RoundId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string MeetingLinkOrVenue { get; set; } = string.Empty;
    public InterviewStatus Status { get; set; } = InterviewStatus.Scheduled;
    public string? Feedback { get; set; }

    // Navigation properties
    public JobApplication JobApplication { get; set; } = null!;
    public InterviewRound InterviewRound { get; set; } = null!;
}
