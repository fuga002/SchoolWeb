using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUser();
    Task<User?> GetByUserName(string userName);
    Task<User?> GetUserById(Guid  id);

    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
    Task<bool> IsUserNameExist(string userName);

}

