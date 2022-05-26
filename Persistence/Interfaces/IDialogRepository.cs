using Core;

namespace Persistence.Interfaces;

public interface IDialogRepository
{
    public Task<List<Dialog>> GetUsersDialogs(Guid userId);
    public Task<Dialog> GetDialogById(Guid id);
    public Task<Dialog?> GetDialogByPersons(Guid userId, Guid moderatorId);
    public Task<Guid> CreateDialog(Guid userId, Guid moderatorId);
    public Task AddMessage(Message message);
}