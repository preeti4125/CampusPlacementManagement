using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Infrastructure.Repositories;

public class JobOpeningRepository : GenericRepository<JobOpening>, IJobOpeningRepository
{
    public JobOpeningRepository(ApplicationDbContext context) : base(context) { }
    public async Task<IReadOnlyList<JobOpening>> GetActiveJobsWithDetailsAsync() =>
        await _dbSet.Include(j => j.Company).ToListAsync();
}
