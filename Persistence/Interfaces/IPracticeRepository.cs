using Core;

namespace Persistence.Interfaces;

public interface IPracticeRepository
{
    public Task<Practice> GetPractice(Guid id);
}