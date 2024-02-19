using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services;

public class UserService: IUserService
{
    public Task<List<User>> GetAllUser()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUserName(string userName)
    {
        throw new NotImplementedException();
    }

    public Task AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}