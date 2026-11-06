using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
namespace CampusPlacementManagement.Infrastructure.Repositories;
public class InterviewRepository : GenericRepository<InterviewSchedule>, IInterviewRepository
{
    public InterviewRepository(ApplicationDbContext context) : base(context) { }
}
