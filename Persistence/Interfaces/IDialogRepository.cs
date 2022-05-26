using Core;

namespace Persistence.Interfaces;

public interface IDialogRepository
{
    public Task<List<Dialog>> GetUsersDialogs(Guid userId);
}