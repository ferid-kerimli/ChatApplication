namespace ChatApplication.DAL.Entity;

public class Group
{
    public int Id { get; set; }
    public string GroupName { get; set; } = string.Empty;
    public int AdminId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<User>? Members { get; set; }
}