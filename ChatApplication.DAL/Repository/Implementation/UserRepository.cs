using ChatApplication.DAL.Context;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.DAL.Repository.Implementation;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}