using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllUser();
    Task<User> GetByUserName(string userName);

    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);

}

