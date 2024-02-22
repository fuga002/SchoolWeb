using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using SchoolData.Entities;

namespace SchoolApi.Services;

public class SubjectRequestRepository: ISubjectRequestRepository
{
    private readonly SchoolDbContext _context;

    public SubjectRequestRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubjectRequest>> GetAllRequests()
    {
        return await _context.SubjectRequests.ToListAsync();
    }

    public async Task<SubjectRequest> GetRequestById(int id)
    {
        var subjectRequest = await _context.SubjectRequests.FindAsync(id);
        return subjectRequest;
    }

    public async Task<SubjectRequest> AddSubjectRequest(SubjectRequest subjectRequest)
    {
        _context.SubjectRequests.Add(subjectRequest);
        await _context.SaveChangesAsync();
        return subjectRequest;
    }

    public async Task<SubjectRequest> UpdateSubjectRequest(SubjectRequest subjectRequest)
    {
        _context.SubjectRequests.Update(subjectRequest);
        await _context.SaveChangesAsync();
        return subjectRequest;
    }

    public async Task<SubjectRequest> DeleteSubjectRequest(SubjectRequest subjectRequest)
    {
        _context.SubjectRequests.Remove(subjectRequest);
        await _context.SaveChangesAsync();
        return subjectRequest;
    }
}