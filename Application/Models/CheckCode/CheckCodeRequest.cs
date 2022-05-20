namespace Application.Models.CheckCode;

public class CheckCodeRequest
{
    public string InnerCode { get; set; }
    public string OuterCode { get; set; }
    public Guid PracticeId { get; set; }
}