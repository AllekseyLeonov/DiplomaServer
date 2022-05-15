namespace Core;

public class Material
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsSectionParent { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsCompleted { get; set; }
    public List<Material>? Children { get; set; }
}