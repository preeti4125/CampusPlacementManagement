using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public JobsController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => 
        Ok(await _context.JobOpenings.Include(j => j.Company).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateJobOpeningDto dto)
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
        _context.JobOpenings.Add(job);
        await _context.SaveChangesAsync();
        return Ok(job);
    }

    [HttpPost("apply")]
    public async Task<IActionResult> Apply(ApplyJobDto dto)
    {
        var exists = await _context.JobApplications
            .AnyAsync(a => a.JobId == dto.JobId && a.StudentId == dto.StudentId);
        if (exists) return BadRequest("Student has already applied to this job opening.");

        var application = new JobApplication
        {
            JobId = dto.JobId,
            StudentId = dto.StudentId,
            Status = (ApplicationStatus)1
        };

        _context.JobApplications.Add(application);
        await _context.SaveChangesAsync();
        return Ok(application);
    }
}
