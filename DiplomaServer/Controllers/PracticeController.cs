using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PracticeController : ControllerBase
{
    private readonly IPracticeService _practiceService;
    
    public PracticeController(IPracticeService practiceService)
    {
        _practiceService = practiceService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPractice(Guid id)
    {
        var practice = await _practiceService.GetPracticeById(id);
        return Ok(practice);
    }
}