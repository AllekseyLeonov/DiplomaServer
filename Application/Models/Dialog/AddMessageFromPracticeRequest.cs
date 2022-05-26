namespace Application.Models.Dialog;

public class AddMessageFromPracticeRequest
{
    public string MessageText { get; set; }
    public Guid UserId { get; set; }
    public Guid ModeratorId { get; set; }
}