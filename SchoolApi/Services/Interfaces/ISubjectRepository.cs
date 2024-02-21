using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services.Interfaces;

public interface ISubjectRepository
{
    Task<List<Subject>> GetAllSubjects();
    Task<Subject> GetSubjectById(int subjectId);
    Task AddSubject(Subject subject);
    Task UpdateSubject(Subject subject);
    Task DeleteSubject(Subject subject);
}