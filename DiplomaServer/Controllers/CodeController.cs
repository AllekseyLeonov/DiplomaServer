using Application.Interfaces.Services;
using Application.Models.CheckCode;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CodeController : ControllerBase
{
    private readonly ICodeService _codeService;
    
    public CodeController(ICodeService codeService)
    {
        _codeService = codeService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CheckCode(CheckCodeRequest model)
    {
        return Ok(await _codeService.IsCodeValid(model));
    }
}