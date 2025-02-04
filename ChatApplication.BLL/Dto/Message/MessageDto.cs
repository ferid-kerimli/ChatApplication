namespace ChatApplication.BLL.Dto.Message;

public class MessageDto
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ConversationId { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }

    public MessageDto(DAL.Entity.Message message)
    {
        Id = message.Id;
        SenderId = message.SenderId;
        ConversationId = message.ConversationId;
        Content = message.Content;
        SentAt = message.SentAt;
    }
}