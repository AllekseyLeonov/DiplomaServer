using Core;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class CodeRepository : ICodeRepository
{
    private readonly Context _context;
    
    public CodeRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<Code> GetCodeById(Guid id)
    {
        var code = await _context.Codes.FirstAsync(code => code.Id == id);
        return code;
    }

    public async Task<Code> GetCodeByPracticeId(Guid id)
    {
        var code = await _context.Codes.FirstAsync(code => code.PracticeId == id);
        return code;
    }
}