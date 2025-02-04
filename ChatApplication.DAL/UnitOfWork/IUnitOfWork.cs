using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }
    IConversationRepository ConversationRepository { get; }
    Task<int> SaveChanges();
}   