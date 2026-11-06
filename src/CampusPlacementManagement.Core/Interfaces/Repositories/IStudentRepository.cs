using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Core.Interfaces.Repositories;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student?> GetByUserIdAsync(string userId);
}
