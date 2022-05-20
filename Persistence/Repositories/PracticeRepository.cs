using Core;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class PracticeRepository : IPracticeRepository
{
    private readonly Context _context;
    
    public PracticeRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<Practice> GetPractice(Guid id)
    {
        var practice = await _context.Practices
            .Include(practice => practice.Code)
            .FirstAsync(practice => practice.Id == id);
        return practice;
    }
}