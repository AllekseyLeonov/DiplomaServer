using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DialogsController : ControllerBase
{
    private readonly IDialogService _dialogService;
    
    public DialogsController(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDialogs(Guid userId)
    {
        var dialogs = await _dialogService.GetDialogs(userId);
        return Ok(dialogs);
    }
}