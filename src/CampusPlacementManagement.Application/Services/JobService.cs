using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Core.Interfaces.Repositories;

namespace CampusPlacementManagement.Application.Services;

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
