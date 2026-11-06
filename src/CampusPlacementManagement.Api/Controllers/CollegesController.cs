using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollegesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CollegesController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Colleges.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateCollegeDto dto)
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
        _context.Colleges.Add(college);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = college.CollegeId }, college);
    }
}
