namespace Application.Models.CheckCode;

public class CheckCodeResult
{
    public bool IsValid { get; set; }
    public List<string> Messages { get; set; } = new();
}