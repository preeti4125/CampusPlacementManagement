using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace CampusPlacementManagement.Infrastructure.Repositories;
public class PlacementOfficerRepository : GenericRepository<PlacementOfficer>, IPlacementOfficerRepository
{
    public PlacementOfficerRepository(ApplicationDbContext context) : base(context) { }
    public async Task<PlacementOfficer?> GetByUserIdAsync(string userId) =>
        await _dbSet.FirstOrDefaultAsync(p => p.UserId == userId);
}
