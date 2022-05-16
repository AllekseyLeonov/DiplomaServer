namespace Core;

public class Material
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsSectionParent { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsCompleted { get; set; }
    
    public Guid? PracticeId { get; set; }
    public Practice? Practice { get; set; }
    
    public Guid? TheoryId { get; set; }
    public Theory? Theory { get; set; }
    
    public Guid? ParentId { get; set; }
    public List<Material>? Children { get; set; }
}