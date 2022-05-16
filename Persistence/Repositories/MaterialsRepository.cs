using Core;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class MaterialsRepository : IMaterialsRepository
{
    private readonly Context _context;
    
    public MaterialsRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<Material> GetMaterial(Guid id)
    {
        var material = await _context.Materials
            .FirstAsync(material => material.Id == id);
        
        await IncludeAllChildren(material);
        
        return material;
    }

    private async Task IncludeAllChildren(Material material)
    {
        var children = await _context.Materials
            .Where(m => m.ParentId == material.Id)
            .ToListAsync();
        
        material.Children = new List<Material>();
        foreach (var child in children)
        {
            material.Children.Add(child);
            await IncludeAllChildren(child);
        }
    }
}