using Application.Interfaces.Services;
using Application.Models.Dialog;
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
    
    [HttpGet]
    public async Task<IActionResult> GetDialogById(Guid id)
    {
        var dialog = await _dialogService.GetDialogById(id);
        return Ok(dialog);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMessage(AddMessageRequest request)
    {
        await _dialogService.AddMessage(request);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddMessageFromPractice(AddMessageFromPracticeRequest request)
    {
        await _dialogService.AddMessageFromPractice(request);
        return Ok();
    }
}