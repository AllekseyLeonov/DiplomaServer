namespace Core;

public class Code
{
    public Guid Id { get; set; }
    public string StaticPart { get; set; }
    public string Tests { get; set; }
    
    public Guid PracticeId { get; set; }
    public Practice Practice { get; set; }
}