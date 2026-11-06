using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CompaniesController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Companies.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyDto dto)
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
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return Ok(company);
    }
}
