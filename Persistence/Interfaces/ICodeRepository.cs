using Core;

namespace Persistence.Interfaces;

public interface ICodeRepository
{
    public Task<Code> GetCodeById(Guid id);
    public Task<Code> GetCodeByPracticeId(Guid id);
}