using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Application.Interfaces;

public interface ICollegeService
{
    Task<IReadOnlyList<College>> GetAllCollegesAsync();
    Task<College> CreateCollegeAsync(CreateCollegeDto dto);
}
