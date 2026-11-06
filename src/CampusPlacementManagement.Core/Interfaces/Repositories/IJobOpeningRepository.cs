using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Core.Interfaces.Repositories;

public interface IJobOpeningRepository : IGenericRepository<JobOpening>
{
    Task<IReadOnlyList<JobOpening>> GetActiveJobsWithDetailsAsync();
}
