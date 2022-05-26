namespace Core;

public class Message
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    
    public Guid SenderId { get; set; }
    public User Sender { get; set; }
    
    public Guid DialogId { get; set; }
    
    public DateTime DateTime { get; set; }
}