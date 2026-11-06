using CampusPlacementManagement.Application.DTOs.Interviews;
using CampusPlacementManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InterviewsController : ControllerBase
{
    private readonly IInterviewService _service;
    public InterviewsController(IInterviewService service) => _service = service;

    [HttpGet("schedules")]
    public async Task<IActionResult> GetSchedules() => Ok(await _service.GetSchedulesAsync());

    [HttpPost("schedule")]
    public async Task<IActionResult> Schedule(ScheduleInterviewDto dto) => Ok(await _service.ScheduleAsync(dto));
}
