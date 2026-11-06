namespace CampusPlacementManagement.Application.DTOs;

public record CreateStudentDto(string UserId, int CollegeId, int PlacementOfficerId, string Department, string Degree, int GraduationYear, decimal CGPA, int ActiveBacklogs, string? ResumeUrl);
public record CreateCompanyDto(string CompanyName, string CompanyEmail, string? Website, string Industry, string Address, string? Description);
public record CreateInterviewRoundDto(int JobId, int DriveId, int RoundNumber, string RoundName, string? Description);
public record ScheduleInterviewDto(int ApplicationId, int RoundId, DateTime ScheduledAt, string MeetingLinkOrVenue, string? Feedback);
