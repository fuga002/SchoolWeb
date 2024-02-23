using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services;

public class TaskResponseResultRepository: ITaskResponseResultRepository
{
    private readonly SchoolDbContext _context;

    public TaskResponseResultRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskResponseResult>> GetResponseResults()
    {
       return await _context.TaskResponsesResult.ToListAsync();
    }

    public async Task<TaskResponseResult?> GetResponseResultsById(int resultId)
    {
        return await _context.TaskResponsesResult.FirstOrDefaultAsync(r => r.Id == resultId);
    }

    public Task UpdateResponseResult(TaskResponseResult result)
    {
        _context.TaskResponsesResult.Update(result);
        return Task.CompletedTask;
    }
}