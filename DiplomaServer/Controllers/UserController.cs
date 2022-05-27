using Application.Interfaces.Services;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaServer.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _userService.TryToLogin(request);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount(CreateAccountRequest request)
    {
        var response = await _userService.TryToCreateAccount(request);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> ConfirmCompletedTask(ConfirmCompletedTaskRequest request)
    {
        await _userService.ConfirmCompletedTask(request);
        return Ok();
    }
}