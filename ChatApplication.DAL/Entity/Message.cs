namespace ChatApplication.DAL.Entity;

public class Message
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ConversationId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    
    public Conversation? Conversation { get; set; }
}