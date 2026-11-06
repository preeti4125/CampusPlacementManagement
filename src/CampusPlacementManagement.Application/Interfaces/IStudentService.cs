using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Application.Interfaces;

public interface IStudentService
{
    Task<IReadOnlyList<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task<Student> CreateStudentAsync(CreateStudentDto dto);
}
