namespace Core;

public class Theory
{
    public Guid Id { get; set; }
    public string Filename { get; set; }
    
    public Material? Material { get; set; }
    
    public Practice? Practice { get; set; }
}