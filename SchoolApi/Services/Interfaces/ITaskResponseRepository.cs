using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services.Interfaces;

public interface ITaskResponseRepository
{
    Task<List<TaskResponse>> GetTaskResponsesAsync();
    Task<TaskResponse?> GetTaskResponseAsync(int taskResponseId);
    Task AddTaskResponse(TaskResponse taskResponse);

    Task UpdateTaskResponseStatus(TaskResponse taskResponse);

    Task DeleteTaskResponse(TaskResponse taskResponse);

}