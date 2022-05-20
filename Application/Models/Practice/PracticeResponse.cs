namespace Application.Models.Practice;

public class PracticeResponse
{
    public Guid Id { get; set; }
    public Guid? TheoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public string StaticCode { get; set; }
}