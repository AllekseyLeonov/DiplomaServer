using Core;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly Context _context;
    
    public TechnologyRepository(Context context)
    {
        _context = context;
    }

    public async Task<Technology> GetTechnology(Guid id)
    {
        var technology = await _context.Technologies
            .FirstAsync(technology => technology.Id == id);
        return technology;
    }
}