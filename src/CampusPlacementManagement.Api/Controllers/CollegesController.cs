using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollegesController : ControllerBase
{
    private readonly ICollegeService _service;
    public CollegesController(ICollegeService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllCollegesAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateCollegeDto dto)
    {
        var created = await _service.CreateCollegeAsync(dto);
        return Ok(created);
    }
}
