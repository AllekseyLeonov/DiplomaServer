using Application.Interfaces.Services;
using Application.Models.Practice;
using Core;
using Persistence.Interfaces;

namespace Application.Services;

public class PracticeService : IPracticeService
{
    private readonly IPracticeRepository _repository;
    
    public PracticeService(IPracticeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<PracticeResponse> GetPracticeById(Guid id)
    {
        var practice = await _repository.GetPractice(id);
        var response = new PracticeResponse
        {
            Id = practice.Id,
            Title = practice.Title,
            Description = practice.Description,
            TheoryId = practice.TheoryId,
            StaticCode = practice.Code.StaticPart,
        };
        return response;
    }
}