using Core;

namespace Application.Interfaces.Services;

public interface IDialogService
{
    public Task<List<Dialog>> GetDialogs(Guid userId);
}