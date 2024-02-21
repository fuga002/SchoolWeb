using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services.Interfaces;

public interface IUserSubjectRepository
{
    Task<List<UserSubject>> GetAllSubject();
    Task<UserSubject?> GetSubjectById(int id);
    Task<UserSubject?> GetSubjectByIds(Guid userId, int subjectId);
    Task AddUserSubject(UserSubject model);
    Task UpdateUserSubject(UserSubject model);
    Task DeleteUserSubject(UserSubject model);
}