using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Core.Interfaces.Repositories;

namespace CampusPlacementManagement.Application.Services;

public class CollegeService : ICollegeService
{
    private readonly ICollegeRepository _collegeRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CollegeService(ICollegeRepository collegeRepo, IUnitOfWork unitOfWork)
    {
        _collegeRepo = collegeRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<College>> GetAllCollegesAsync() => await _collegeRepo.GetAllAsync();

    public async Task<College> CreateCollegeAsync(CreateCollegeDto dto)
    {
        var college = new College
        {
            CollegeName = dto.CollegeName,
            CollegeCode = dto.CollegeCode,
            UniversityName = dto.UniversityName,
            OfficialEmail = dto.OfficialEmail,
            Address = dto.Address,
            Website = dto.Website
        };
        await _collegeRepo.AddAsync(college);
        await _unitOfWork.CompleteAsync();
        return college;
    }
}

public class JobService : IJobService
{
    private readonly IJobOpeningRepository _jobRepo;
    private readonly IJobApplicationRepository _applicationRepo;
    private readonly IUnitOfWork _unitOfWork;

    public JobService(IJobOpeningRepository jobRepo, IJobApplicationRepository applicationRepo, IUnitOfWork unitOfWork)
    {
        _jobRepo = jobRepo;
        _applicationRepo = applicationRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<JobOpening>> GetAllJobsAsync() => await _jobRepo.GetActiveJobsWithDetailsAsync();

    public async Task<JobOpening> CreateJobAsync(CreateJobOpeningDto dto)
    {
        var job = new JobOpening
        {
            CompanyId = dto.CompanyId,
            CreatedByHRId = dto.CreatedByHRId,
            JobTitle = dto.JobTitle,
            JobDescription = dto.JobDescription,
            JobType = dto.JobType,
            Location = dto.Location,
            SalaryPackage = dto.SalaryPackage,
            MinimumCGPA = dto.MinimumCGPA,
            MaximumBacklogs = dto.MaximumBacklogs,
            ApplicationDeadline = dto.ApplicationDeadline,
            IsOpenToAllColleges = dto.IsOpenToAllColleges,
            Status = (JobStatus)1
        };
        await _jobRepo.AddAsync(job);
        await _unitOfWork.CompleteAsync();
        return job;
    }

    public async Task<JobApplication> ApplyForJobAsync(ApplyJobDto dto)
    {
        if (await _applicationRepo.HasStudentAppliedAsync(dto.JobId, dto.StudentId))
            throw new InvalidOperationException("Student has already applied to this job opening.");

        var app = new JobApplication
        {
            JobId = dto.JobId,
            StudentId = dto.StudentId,
            Status = (ApplicationStatus)1
        };
        await _applicationRepo.AddAsync(app);
        await _unitOfWork.CompleteAsync();
        return app;
    }
}

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

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyService(ICompanyRepository companyRepo, IUnitOfWork unitOfWork)
    {
        _companyRepo = companyRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<Company>> GetAllCompaniesAsync() => await _companyRepo.GetAllAsync();

    public async Task<Company> CreateCompanyAsync(CreateCompanyDto dto)
    {
        var company = new Company
        {
            CompanyName = dto.CompanyName,
            CompanyEmail = dto.CompanyEmail,
            Website = dto.Website,
            Industry = dto.Industry,
            Address = dto.Address,
            Description = dto.Description,
            Status = (AccountStatus)1
        };
        await _companyRepo.AddAsync(company);
        await _unitOfWork.CompleteAsync();
        return company;
    }
}
