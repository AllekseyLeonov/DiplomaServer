using Application.Interfaces.Services;
using Core;
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
    public IActionResult CheckCode()
    {
        var testCode = new Code
        {
            StaticPart = "bool functionThatReturnsTrue(){<inner>} <outer>",
            UsersInnerPart = "return someOuterFunction();",
            UsersOuterPart = "bool someOuterFunction(){return true;}",
            Tests = new List<string>{"functionThatReturnsTrue() == true"}
        };

        return Ok(_codeService.IsCodeValid(testCode));
    }
}