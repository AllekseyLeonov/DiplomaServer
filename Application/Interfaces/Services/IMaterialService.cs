using Core;

namespace Application.Interfaces.Services;

public interface IMaterialService
{
    public Task<Material> GetMaterialsTree(Guid technologyId);
}