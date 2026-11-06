using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
namespace CampusPlacementManagement.Infrastructure.Repositories;
public class RecruitmentDriveRepository : GenericRepository<RecruitmentDrive>, IRecruitmentDriveRepository
{
    public RecruitmentDriveRepository(ApplicationDbContext context) : base(context) { }
}
