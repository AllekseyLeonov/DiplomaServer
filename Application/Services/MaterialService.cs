using Application.Interfaces.Services;
using Core;
using Persistence.Interfaces;

namespace Application.Services;

public class MaterialService : IMaterialService
{
    private readonly IMaterialsRepository _repository;
    
    public MaterialService(IMaterialsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Material> GetMaterialsTree(Guid materialId)
    {
        var material = await _repository.GetMaterial(materialId);
        return material;
    }
}