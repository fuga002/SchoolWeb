using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using SchoolData.Entities;
using SchoolData.StaticServices;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services;

public class SubjectRepository: ISubjectRepository
{
    private readonly SchoolDbContext _context;

    public SubjectRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Subject>> GetAllSubjects()
    {
        var subjects = await _context.Subjects.ToListAsync();
        return subjects;
    }

    public async Task<Subject> GetSubjectById(int subjectId)
    {
        var subject = await _context.Subjects.FirstAsync(s => s.Id == subjectId );
        return subject;
    }

    public async Task AddSubject(Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubject(Subject subject)
    {
        _context.Subjects.Update(subject);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSubject(Subject subject)
    {
        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
    }
}