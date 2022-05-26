using Application.Interfaces.Services;
using Application.Models.Dialog;
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

    public async Task<Dialog> GetDialogById(Guid id)
    {
        var dialog = await _repository.GetDialogById(id);
        return dialog;
    }

    public async Task AddMessage(AddMessageRequest request)
    {
        var message = new Message
        {
            Id = Guid.NewGuid(),
            DateTime = DateTime.Now,
            DialogId = request.DialogId,
            SenderId = request.SenderId,
            Text = request.Text,
        };
        await _repository.AddMessage(message);
    }

    public async Task AddMessageFromPractice(AddMessageFromPracticeRequest request)
    {
        var dialog = await _repository.GetDialogByPersons(request.UserId, request.ModeratorId);
        Guid dialogId;
        
        dialogId = dialog is null
            ? await _repository.CreateDialog(request.UserId, request.ModeratorId)
            : dialog.Id;
        
        var message = new Message
        {
            Id = Guid.NewGuid(),
            DateTime = DateTime.Now,
            DialogId = dialogId,
            SenderId = request.UserId,
            Text = request.MessageText,
        };
        await _repository.AddMessage(message);
    }
}