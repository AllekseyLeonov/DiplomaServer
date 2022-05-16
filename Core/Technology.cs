namespace Core;

public class Technology
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid RootMaterialId { get; set; }
    public Material RootMaterial { get; set; }
    
}