using Application.Interfaces.Services;
using Application.Models.User;
using Core;
using Persistence.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<LoginResponse> TryToLogin(LoginRequest request)
    {
        var user = await _repository.GetUserByCredentials(request.Login, request.Password);
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
        var user = await _repository.GetUserByLogin(request.Login);
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
        };
        await _repository.AddUser(newUser);

        response.IsSucceed = true;
        response.User = newUser;
        return response;
    }

    public async Task<List<Guid>> GetCompletedMaterials(Guid userId)
    {
        var materials = await _repository.GetCompletedMaterials(userId);
        return materials;
    }
}