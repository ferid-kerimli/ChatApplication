using ChatApplication.DAL.Context;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.Repository.Implementation;

public class UserConversationRepository : Repository<UserConservation>, IUserConversationRepository
{
    public UserConversationRepository(ApplicationDbContext context) : base(context)
    {
    }
}