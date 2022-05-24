using Core;

namespace Persistence.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetUserByCredentials(string login, string password);
    public Task<User?> GetUserByLogin(string login);
    public Task AddUser(User user);
    public Task<List<Guid>> GetCompletedMaterials(Guid userId);
}