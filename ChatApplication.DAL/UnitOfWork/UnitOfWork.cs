using ChatApplication.DAL.Context;
using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IUserRepository UserRepository { get; }
    public IMessageRepository MessageRepository { get; }
    public IGroupRepository GroupRepository { get; }
    public IConversationRepository ConversationRepository { get; }
    public IUserConversationRepository UserConversationRepository { get; }
    
    public UnitOfWork( ApplicationDbContext context, IUserRepository userRepository, IMessageRepository messageRepository, IGroupRepository groupRepository, IConversationRepository conversationRepository, IUserConversationRepository userConversationRepository)
    {
        _context = context;
        UserRepository = userRepository;
        MessageRepository = messageRepository;
        GroupRepository = groupRepository;
        ConversationRepository = conversationRepository;
        UserConversationRepository = userConversationRepository;
    }
    
    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}