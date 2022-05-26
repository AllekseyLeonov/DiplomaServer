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
}