namespace SchoolApi.Services.Interfaces;
using Task = SchoolData. Entities.Task;
public interface ITaskRepository
{
    Task<List<Task>?> GetAllTasks();
    Task<Task> GetTaskById(int id);
    Task<Task> AddTask(Task task);
    Task<Task> UpdateTask( Task task);
    Task<Task> DeleteTask(Task task);
}