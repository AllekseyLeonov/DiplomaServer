using Core;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class DialogRepository : IDialogRepository
{
    private readonly Context _context;
    
    public DialogRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<Dialog>> GetUsersDialogs(Guid userId)
    {
        var dialogs = await _context.Dialogs
            .Include(dialog => dialog.Messages)
            .Include(dialog => dialog.Moderator)
            .Include(dialog => dialog.User)
            .Where(dialog => dialog.ModeratorId == userId || dialog.UserId == userId)
            .ToListAsync();
        return dialogs;
    }

    public async Task<Dialog> GetDialogById(Guid id)
    {
        var dialog = await _context.Dialogs
            .Include(dialog => dialog.Messages)
            .Include(dialog => dialog.Moderator)
            .Include(dialog => dialog.User)
            .FirstAsync(dialog => dialog.Id == id);
        dialog.Messages.Sort((m1, m2) => m1.DateTime > m2.DateTime? 1:-1);
        return dialog;
    }

    public async Task<Dialog?> GetDialogByPersons(Guid userId, Guid moderatorId)
    {
        var dialog = await _context.Dialogs
            .FirstOrDefaultAsync(dialog => dialog.UserId == userId && dialog.ModeratorId == moderatorId);
        return dialog;
    }

    public async Task<Guid> CreateDialog(Guid userId, Guid moderatorId)
    {
        var dialogId = Guid.NewGuid();
        var dialog = new Dialog
        {
            Id = dialogId,
            ModeratorId = moderatorId,
            UserId = userId,
        };
        
        await _context.Dialogs.AddAsync(dialog);
        await _context.SaveChangesAsync();

        return dialogId;
    }

    public async Task AddMessage(Message message)
    {
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
    }
}