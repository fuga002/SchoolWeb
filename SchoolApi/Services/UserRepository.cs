using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services;

public class UserRepository: IUserRepository
{
    private readonly SchoolDbContext _context;

    public UserRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUser()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User?> GetByUserName(string userName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user;
    }

    public async Task<User?> GetUserById(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> IsUserNameExist(string userName)
    {
        var isExists = await _context.Users.
            Where(i => i.UserName == userName).AnyAsync();
        return isExists;
    }
}