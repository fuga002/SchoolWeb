using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services;

public class UserSubjectRepository: IUserSubjectRepository
{
    private readonly SchoolDbContext _context;

    public UserSubjectRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserSubject>> GetAllSubject()
    {
        var userSubjects = await _context.UsersSubjects.ToListAsync();
        return userSubjects;
    }

    public async Task<UserSubject?> GetSubjectById(int id)
    {
        var userSubject = await _context.UsersSubjects.FirstOrDefaultAsync(x => x.Id == id);
        return userSubject;
    }

    public async Task<UserSubject?> GetSubjectByIds(Guid userId, int subjectId)
    {
        var userSubject =
            await _context.UsersSubjects.FirstOrDefaultAsync(u => u.UserId == userId && u.SubjectId == subjectId);
        return userSubject;
    }

    public async Task AddUserSubject(UserSubject model)
    {
        _context.UsersSubjects.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserSubject(UserSubject model)
    {
        _context.UsersSubjects.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserSubject(UserSubject model)
    {
        _context.UsersSubjects.Remove(model);
        await _context.SaveChangesAsync();
    }
}