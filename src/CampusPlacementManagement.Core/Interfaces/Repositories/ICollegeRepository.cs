using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Core.Interfaces.Repositories;

public interface ICollegeRepository : IGenericRepository<College>
{
    Task<College?> GetByCodeAsync(string collegeCode);
}
