using CampusPlacementManagement.Core.Entities;
namespace CampusPlacementManagement.Core.Interfaces.Repositories;
public interface IPlacementOfficerRepository : IGenericRepository<PlacementOfficer> { Task<PlacementOfficer?> GetByUserIdAsync(string userId); }
