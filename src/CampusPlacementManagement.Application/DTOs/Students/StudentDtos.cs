namespace CampusPlacementManagement.Application.DTOs.Students;
public record StudentEnrollDto(string UserId, int CollegeId, int PlacementOfficerId, string Department, string Degree, int GraduationYear, decimal CGPA, int ActiveBacklogs, string? ResumeUrl);
public record StudentResponseDto(int StudentId, string Department, string Degree, decimal CGPA, int ActiveBacklogs);
