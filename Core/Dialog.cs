namespace Core;

public class Dialog
{
    public Guid Id { get; set; } 
    
    public Guid ModeratorId { get; set; } 
    public User Moderator { get; set; } 
    public Guid UserId { get; set; } 
    public User User { get; set; }
    
    public List<Message> Messages { get; set; }
}