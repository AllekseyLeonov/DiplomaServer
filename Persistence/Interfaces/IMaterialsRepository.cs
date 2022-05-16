using Core;

namespace Persistence.Interfaces;

public interface IMaterialsRepository
{
    public Task<Material> GetMaterial(Guid id);
}