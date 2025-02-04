namespace ChatApplication.BLL.Dto.Message;

public class SendMessageDto
{
    public int SenderId { get; set; }
    public int ConversationId { get; set; }
    public string Content { get; set; } = string.Empty;
}