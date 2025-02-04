using ChatApplication.DAL.Entity;

namespace ChatApplication.DAL.Repository.Abstraction;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email);
}