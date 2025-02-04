using ChatApplication.BLL.Dto.Conversation;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.API.Controller;

[Route("api")]
[ApiController]
public class ConversationController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ConversationController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<ActionResult> CreateConversation([FromBody] CreateConversationDto dto)
    {
        var conversation = new Conversation
        {
            User1Id = dto.User1Id,
            User2Id = dto.User2Id,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.ConversationRepository.Create(conversation);
        await _unitOfWork.SaveChanges();

        return Ok(conversation);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Conversation>> GetConversation(int id)
    {
        var conversation = await _unitOfWork.ConversationRepository.GetById(id);
        if (conversation == null)
            return NotFound();

        return Ok(conversation);
    }
}