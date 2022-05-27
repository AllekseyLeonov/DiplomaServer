namespace Application.Models.User;

public class ConfirmCompletedTaskRequest
{
    public Guid UserId { get; set; }
    public Guid PracticeId { get; set; }
}