using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public StudentsController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _context.Students.Include(s => s.College).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _context.Students.Include(s => s.College).FirstOrDefaultAsync(s => s.StudentId == id);
        return student == null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDto dto)
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
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, student);
    }
}
