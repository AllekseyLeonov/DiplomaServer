using Core;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MaterialsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMaterials()
    {
        Material mat6 = new Material {Name = "Цикл while", IsAvailable = true};
        Material mat5 = new Material {Name = "Цикл foreach"};
        Material mat4 = new Material 
        {
            Name = "Цикл for",
            Children = new List<Material>{mat5},
            IsAvailable = true
        };
        Material mat3 = new Material
        {
            Name = "Циклы",
            Children = new List<Material>{mat4, mat6},
            IsSectionParent = true,
            IsAvailable = true
        };
        Material mat2 = new Material
        {
            Name = "Массивы",
            Children = new List<Material>{mat3},
            IsCompleted = true,
            IsAvailable = true
        };
        Material mat1 = new Material
        {
            Name = "Переменные",
            Children = new List<Material>{mat2},
            IsCompleted = true,
            IsAvailable = true
        };

        return Ok(mat1);
    }
}