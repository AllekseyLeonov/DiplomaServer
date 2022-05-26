using DiplomaServer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[Route("api/[controller]/[action]")]
public class TheoryPagesController : ControllerBase
{
    private const string PagesFolder = @"C:\MyFiles\MyOwn\diploma\DiplomaServer\Pages\";
    
    [HttpGet]
    public IActionResult Page()
    {
        var path = PagesFolder + "theory1.html";
        var html = System.IO.File.ReadAllText(path);
        var theory = new TheoryDto
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Content = html
        };
        return Ok(theory);
    }
}