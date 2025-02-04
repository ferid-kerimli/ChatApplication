using ChatApplication.DAL.Context;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.Repository.Implementation;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(ApplicationDbContext context) : base(context)
    {
    }
}