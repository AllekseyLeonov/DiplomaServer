using Application.Models.User;

namespace Application.Interfaces.Services;

public interface IUserService
{
    public Task<LoginResponse> TryToLogin(LoginRequest request);
    public Task<CreateAccountResponse> TryToCreateAccount(CreateAccountRequest request);
    public Task<List<Guid>> GetCompletedMaterials(Guid userId);
    public Task ConfirmCompletedTask(ConfirmCompletedTaskRequest request);
}