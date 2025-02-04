using ChatApplication.DAL.Context;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.Repository.Implementation;

public class ConversationRepository : Repository<Conversation>, IConversationRepository
{
    public ConversationRepository(ApplicationDbContext context) : base(context)
    {
    }
}