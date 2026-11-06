namespace CampusPlacementManagement.Application.DTOs.Jobs;
public record CreateJobDto(int CompanyId, int CreatedByHRId, string JobTitle, string JobDescription, string JobType, string Location, decimal SalaryPackage, decimal MinimumCGPA, int MaximumBacklogs, DateTime ApplicationDeadline, bool IsOpenToAllColleges);
public record JobResponseDto(int JobId, string JobTitle, string Location, decimal SalaryPackage, decimal MinimumCGPA);
