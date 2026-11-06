using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Application.Interfaces;

public interface ICompanyService
{
    Task<IReadOnlyList<Company>> GetAllCompaniesAsync();
    Task<Company> CreateCompanyAsync(CreateCompanyDto dto);
}
