using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MaterialsController : ControllerBase
{
    private readonly IMaterialService _materialService;
    private readonly ITechnologyService _technologyService;
    private readonly IUserService _userService;
    public MaterialsController(
        IMaterialService materialService, 
        ITechnologyService technologyService,
        IUserService userService)
    {
        _materialService = materialService;
        _technologyService = technologyService;
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMaterialsTree(Guid technologyId)
    {
        var technology = await _technologyService.GetTechnology(technologyId);
        var material = await _materialService.GetMaterialsTree(technology.RootMaterialId);
        return Ok(material);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCompletedMaterials(Guid userId)
    {
        var response = await _userService.GetCompletedMaterials(userId);
        return Ok(response);
    }
}