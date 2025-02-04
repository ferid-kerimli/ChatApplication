namespace ChatApplication.DAL.Entity;

public class Conversation
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsGroup { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<User>? Participants { get; set; }
    public ICollection<Message>? Messages { get; set; }
}