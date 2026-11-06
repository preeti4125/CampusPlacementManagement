using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Application.Interfaces;

public interface ICollegeService
{
    Task<IReadOnlyList<College>> GetAllCollegesAsync();
    Task<College> CreateCollegeAsync(CreateCollegeDto dto);
}

public interface IJobService
{
    Task<IReadOnlyList<JobOpening>> GetAllJobsAsync();
    Task<JobOpening> CreateJobAsync(CreateJobOpeningDto dto);
    Task<JobApplication> ApplyForJobAsync(ApplyJobDto dto);
}

public interface IStudentService
{
    Task<IReadOnlyList<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task<Student> CreateStudentAsync(CreateStudentDto dto);
}

public interface ICompanyService
{
    Task<IReadOnlyList<Company>> GetAllCompaniesAsync();
    Task<Company> CreateCompanyAsync(CreateCompanyDto dto);
}
