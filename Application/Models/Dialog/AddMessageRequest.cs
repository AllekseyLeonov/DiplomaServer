namespace Application.Models.Dialog;

public class AddMessageRequest
{
    public string Text { get; set; }
    public Guid SenderId { get; set; }
    public Guid DialogId { get; set; }
}