using ChatApplication.DAL.Context;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.Repository.Abstraction;

namespace ChatApplication.DAL.Repository.Implementation;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext context) : base(context)
    {
    }
}