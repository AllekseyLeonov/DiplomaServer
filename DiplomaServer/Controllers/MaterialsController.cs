using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MaterialsController : ControllerBase
{
    private readonly IMaterialService _materialService;
    private readonly ITechnologyService _technologyService;
    public MaterialsController(IMaterialService materialService, ITechnologyService technologyService)
    {
        _materialService = materialService;
        _technologyService = technologyService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMaterialsTree(Guid technologyId)
    {
        var technology = await _technologyService.GetTechnology(technologyId);
        var material = await _materialService.GetMaterialsTree(technology.RootMaterialId);
        return Ok(material);
    }
}