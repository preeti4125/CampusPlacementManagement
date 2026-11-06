using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Infrastructure.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context) : base(context) { }
    public async Task<Student?> GetByUserIdAsync(string userId) =>
        await _dbSet.Include(s => s.College).FirstOrDefaultAsync(s => s.UserId == userId);
}
