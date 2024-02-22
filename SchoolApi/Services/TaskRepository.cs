using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;
using Task = SchoolData.Entities.Task;

namespace SchoolApi.Services;

public class TaskRepository: ITaskRepository
{
    private readonly SchoolDbContext _context;

    public TaskRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Task>?> GetAllTasks()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<Task> GetTaskById(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        return task;
    }

    public async Task<Task> AddTask(Task task)
    {
        _context.Tasks.Add(task);
         await _context.SaveChangesAsync();
         return task;
    }

    public async Task<Task> UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task> DeleteTask(Task task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }
}