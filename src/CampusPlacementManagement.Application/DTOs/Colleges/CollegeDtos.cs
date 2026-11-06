namespace CampusPlacementManagement.Application.DTOs.Colleges;
public record CollegeRegisterDto(string CollegeName, string CollegeCode, string? UniversityName, string OfficialEmail, string Address, string? Website);
public record CollegeResponseDto(int CollegeId, string CollegeName, string CollegeCode, string OfficialEmail, string Address);
