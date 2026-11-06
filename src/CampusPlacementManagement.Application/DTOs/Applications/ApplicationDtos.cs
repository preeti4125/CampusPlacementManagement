namespace CampusPlacementManagement.Application.DTOs.Applications;
public record ApplyJobDto(int JobId, int StudentId);
public record ApplicationResponseDto(int ApplicationId, int JobId, int StudentId, string Status);
