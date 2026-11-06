using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Core.Interfaces.Repositories;

namespace CampusPlacementManagement.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IStudentRepository studentRepo, IUnitOfWork unitOfWork)
    {
        _studentRepo = studentRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<Student>> GetAllStudentsAsync() => await _studentRepo.GetAllAsync();
    public async Task<Student?> GetStudentByIdAsync(int id) => await _studentRepo.GetByIdAsync(id);

    public async Task<Student> CreateStudentAsync(CreateStudentDto dto)
    {
        var student = new Student
        {
            UserId = dto.UserId,
            CollegeId = dto.CollegeId,
            PlacementOfficerId = dto.PlacementOfficerId,
            Department = dto.Department,
            Degree = dto.Degree,
            GraduationYear = dto.GraduationYear,
            CGPA = dto.CGPA,
            ActiveBacklogs = dto.ActiveBacklogs,
            ResumeUrl = dto.ResumeUrl,
            Status = (AccountStatus)1
        };
        await _studentRepo.AddAsync(student);
        await _unitOfWork.CompleteAsync();
        return student;
    }
}
