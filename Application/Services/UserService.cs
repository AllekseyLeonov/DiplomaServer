using Application.Interfaces.Services;
using Application.Models.User;
using Core;
using Persistence.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMaterialsRepository _materialsRepository;
    
    public UserService(IUserRepository userRepository, IMaterialsRepository materialsRepository)
    {
        _userRepository = userRepository;
        _materialsRepository = materialsRepository;
    }
    
    public async Task<LoginResponse> TryToLogin(LoginRequest request)
    {
        var user = await _userRepository.GetUserByCredentials(request.Login, request.Password);
        var response = new LoginResponse
        {
            IsSucceed = user != null,
            User = user,
        };
        return response;
    }
    
    public async Task<CreateAccountResponse> TryToCreateAccount(CreateAccountRequest request)
    {
        var response = new CreateAccountResponse();
        var user = await _userRepository.GetUserByLogin(request.Login);
        if (user is not null)
        {
            response.User = null;
            response.IsSucceed = false;
            return response;
        }

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password,
            Name = request.Name,
            Role = "Regular"
        };
        await _userRepository.AddUser(newUser);

        response.IsSucceed = true;
        response.User = newUser;
        return response;
    }

    public async Task<List<Guid>> GetCompletedMaterials(Guid userId)
    {
        var materials = await _userRepository.GetCompletedMaterials(userId);
        return materials;
    }

    public async Task ConfirmCompletedTask(ConfirmCompletedTaskRequest request)
    {
        await _userRepository.ConfirmCompletedTask(request.UserId, request.PracticeId);
    }
}