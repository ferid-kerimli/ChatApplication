using ChatApplication.BLL.Dto.Message;
using ChatApplication.BLL.Response;

namespace ChatApplication.BLL.Service.Abstraction;

public interface IMessageService
{
    Task<ApiResponse<MessageDto>> SendMessage(SendMessageDto dto);
}