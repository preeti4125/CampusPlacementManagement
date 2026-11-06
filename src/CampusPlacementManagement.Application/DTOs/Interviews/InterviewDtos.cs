namespace CampusPlacementManagement.Application.DTOs.Interviews;
public record ScheduleInterviewDto(int ApplicationId, int RoundId, DateTime ScheduledAt, string MeetingLinkOrVenue, string? Feedback);
public record InterviewResponseDto(int ScheduleId, int ApplicationId, DateTime ScheduledAt, string Status);
