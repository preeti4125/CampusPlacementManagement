using CampusPlacementManagement.Core.Entities;
namespace CampusPlacementManagement.Core.Interfaces.Repositories;
public interface ICompanyHRRepository : IGenericRepository<CompanyHR> { Task<CompanyHR?> GetByUserIdAsync(string userId); }
