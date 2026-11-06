using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace CampusPlacementManagement.Infrastructure.Repositories;
public class CompanyHRRepository : GenericRepository<CompanyHR>, ICompanyHRRepository
{
    public CompanyHRRepository(ApplicationDbContext context) : base(context) { }
    public async Task<CompanyHR?> GetByUserIdAsync(string userId) =>
        await _dbSet.FirstOrDefaultAsync(h => h.UserId == userId);
}
