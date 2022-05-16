using Core;

namespace Persistence.Interfaces;

public interface ITechnologyRepository
{
    public Task<Technology> GetTechnology(Guid id);
}