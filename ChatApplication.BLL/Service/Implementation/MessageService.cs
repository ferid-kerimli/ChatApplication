using ChatApplication.BLL.Dto.Message;
using ChatApplication.BLL.Response;
using ChatApplication.BLL.Service.Abstraction;
using ChatApplication.BLL.Utility;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.UnitOfWork;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.BLL.Service.Implementation;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHubContext<ChatHub> _hubContext;

    public MessageService(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext)
    {
        _unitOfWork = unitOfWork;
        _hubContext = hubContext;
    }

    public async Task<ApiResponse<MessageDto>> SendMessage(SendMessageDto dto)
    {
        var response = new ApiResponse<MessageDto>();
        var sender = await _unitOfWork.UserRepository.GetById(dto.SenderId);
        var conversation = await _unitOfWork.ConversationRepository.GetById(dto.ConversationId);

        if (sender == null || conversation == null)
        {
            response.Failure("Sender or conversation not found", 404);
            return response;
        }
        
        var message = new Message
        {
            SenderId = dto.SenderId,
            ConversationId = dto.ConversationId,
            Content = dto.Content,
            SentAt = DateTime.UtcNow
        };

        await _unitOfWork.MessageRepository.Create(message);
        await _unitOfWork.SaveChanges();

        await _hubContext.Clients.Group($"conversation_{dto.ConversationId}")
            .SendAsync("ReceiveMessage", dto.SenderId, dto.Content, DateTime.UtcNow);

        response.Success("Message sent", 200);
        return response;
    }
}