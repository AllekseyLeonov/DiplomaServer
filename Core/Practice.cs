namespace Core;

public class Practice
{
    public Guid Id { get; set; }
    public Material Material { get; set; }
    
    public Guid? TheoryId { get; set; }
    public Theory? Theory { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    
    public Code Code { get; set; }
}