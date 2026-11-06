using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Infrastructure.Repositories;

public class CollegeRepository : GenericRepository<College>, ICollegeRepository
{
    public CollegeRepository(ApplicationDbContext context) : base(context) { }
    public async Task<College?> GetByCodeAsync(string collegeCode) =>
        await _dbSet.FirstOrDefaultAsync(c => c.CollegeCode == collegeCode);
}
