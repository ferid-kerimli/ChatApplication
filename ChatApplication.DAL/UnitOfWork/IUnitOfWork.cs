using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }
    IGroupRepository GroupRepository { get; }
    IConversationRepository ConversationRepository { get; }
    IUserConversationRepository UserConversationRepository { get; }
    Task<int> SaveChanges();
}   