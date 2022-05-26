using Application.Models.Dialog;
using Core;

namespace Application.Interfaces.Services;

public interface IDialogService
{
    public Task<List<Dialog>> GetDialogs(Guid userId);
    public Task<Dialog> GetDialogById(Guid id);
    public Task AddMessage(AddMessageRequest request);
    public Task AddMessageFromPractice(AddMessageFromPracticeRequest request);
}