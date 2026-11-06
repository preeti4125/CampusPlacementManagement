using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;
    public CompaniesController(ICompanyService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllCompaniesAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyDto dto) =>
        Ok(await _service.CreateCompanyAsync(dto));
}
