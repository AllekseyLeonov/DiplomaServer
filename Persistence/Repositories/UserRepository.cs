using Core;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Context _context;
    
    public UserRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserByCredentials(string login, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Login == login && user.Password == password);
        return user;
    }
    
    public async Task<User?> GetUserByLogin(string login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Login == login);
        return user;
    }
    
    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Guid>> GetCompletedMaterials(Guid userId)
    {
        var user = await _context.Users
            .Include(user => user.CompletedMaterials)
            .FirstAsync(user => user.Id == userId);
        return user.CompletedMaterials.Select(material => material.Id).ToList();
    }

    public async Task ConfirmCompletedTask(Guid userId, Guid practiceId)
    {
        var material = await _context.Materials.FirstAsync(material => material.PracticeId == practiceId);
        var user = await _context.Users.Include(u=>u.CompletedMaterials).FirstAsync(user => user.Id == userId);

        if (user.CompletedMaterials.FirstOrDefault(completedMaterial => completedMaterial.Id == material.Id) == null)
        {
            user.CompletedMaterials.Add(material);
            await _context.SaveChangesAsync();
        }
    }
}