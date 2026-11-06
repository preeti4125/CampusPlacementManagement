namespace CampusPlacementManagement.Application.DTOs;

public record RegisterDto(string Email, string Password, string FullName, string Role);
public record LoginDto(string Email, string Password);
public record AuthResponseDto(string Token, string Email, string Role, string UserId);
public record CreateCollegeDto(string CollegeName, string CollegeCode, string? UniversityName, string OfficialEmail, string Address, string? Website);
public record CreateJobOpeningDto(int CompanyId, int CreatedByHRId, string JobTitle, string JobDescription, string JobType, string Location, decimal SalaryPackage, decimal MinimumCGPA, int MaximumBacklogs, DateTime ApplicationDeadline, bool IsOpenToAllColleges);
public record ApplyJobDto(int JobId, int StudentId);
