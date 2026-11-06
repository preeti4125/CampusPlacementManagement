using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _service;
    public JobsController(IJobService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllJobsAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateJobOpeningDto dto) =>
        Ok(await _service.CreateJobAsync(dto));

    [HttpPost("apply")]
    public async Task<IActionResult> Apply(ApplyJobDto dto)
    {
        try
        {
            var application = await _service.ApplyForJobAsync(dto);
            return Ok(application);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
