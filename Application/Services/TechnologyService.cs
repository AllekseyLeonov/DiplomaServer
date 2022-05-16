using Application.Interfaces.Services;
using Core;
using Persistence.Interfaces;

namespace Application.Services;

public class TechnologyService : ITechnologyService
{
    private readonly ITechnologyRepository _repository;
    
    public TechnologyService(ITechnologyRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Technology> GetTechnology(Guid technologyId)
    {
        var technology = await _repository.GetTechnology(technologyId);
        return technology;
    }
}