using Application.Interfaces.Services;
using Core;
using Persistence.Interfaces;

namespace Application.Services;

public class DialogService : IDialogService
{
    private readonly IDialogRepository _repository;
    
    public DialogService(IDialogRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<Dialog>> GetDialogs(Guid userId)
    {
        var dialogs = await _repository.GetUsersDialogs(userId);
        return dialogs;
    }
}