using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services;

public class TaskResponseRepository: ITaskResponseRepository
{
    private readonly SchoolDbContext _context;

    public TaskResponseRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskResponse>> GetTaskResponsesAsync()
    {
        var taskResponses = await _context.TaskResponses.ToListAsync();
        return taskResponses;
    }

    public async Task<TaskResponse?> GetTaskResponseAsync(int taskResponseId)
    {
        var taskResponse = await _context.TaskResponses.FirstOrDefaultAsync(t => t.Id == taskResponseId);
        return taskResponse;
    }

    public async Task AddTaskResponse(TaskResponse taskResponse)
    {
        _context.TaskResponses.Add(taskResponse);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaskResponseStatus(TaskResponse taskResponse)
    {
        _context.TaskResponses.Update(taskResponse);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskResponse(TaskResponse taskResponse)
    {
        _context.TaskResponses.Remove(taskResponse);
        await _context.SaveChangesAsync();
    }
}