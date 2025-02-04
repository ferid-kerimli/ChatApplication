using ChatApplication.DAL.Context;
using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IUserRepository UserRepository { get; }
    public IMessageRepository MessageRepository { get; }
    public IConversationRepository ConversationRepository { get; }
    public UnitOfWork( ApplicationDbContext context, IUserRepository userRepository, IMessageRepository messageRepository, IConversationRepository conversationRepository)
    {
        _context = context;
        UserRepository = userRepository;
        MessageRepository = messageRepository;
        ConversationRepository = conversationRepository;
    }
    
    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}