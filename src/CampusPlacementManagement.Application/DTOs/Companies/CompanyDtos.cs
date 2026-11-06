namespace CampusPlacementManagement.Application.DTOs.Companies;
public record CompanyRegisterDto(string CompanyName, string CompanyEmail, string? Website, string Industry, string Address, string? Description);
public record CompanyResponseDto(int CompanyId, string CompanyName, string CompanyEmail, string Industry);
