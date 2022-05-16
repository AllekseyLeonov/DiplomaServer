using Core;

namespace Application.Interfaces.Services;

public interface ITechnologyService
{
    public Task<Technology> GetTechnology(Guid id);
}