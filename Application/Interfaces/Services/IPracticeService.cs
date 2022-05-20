using Application.Models.Practice;

namespace Application.Interfaces.Services;

public interface IPracticeService
{
    public Task<PracticeResponse> GetPracticeById(Guid id);
}