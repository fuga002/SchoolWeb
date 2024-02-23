using SchoolApi.Exceptions;
using SchoolApi.Extensions;
using SchoolApi.Services;
using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using SchoolData.Models.TaskModels;
using SchoolData.StaticServices;

namespace SchoolApi.Managers;

public class TaskResponseManager
{
    private readonly ITaskResponseRepository _taskResponseRepository;
    private readonly IUserRepository _userRepository;

    public TaskResponseManager(ITaskResponseRepository taskResponseRepository, IUserRepository userRepository)
    {
        _taskResponseRepository = taskResponseRepository;
        _userRepository = userRepository;
    }

    public async Task<List<TaskResponseModel>> GetAllTaskResponse(int taskId)
    {
        var taskResponses = await _taskResponseRepository.GetTaskResponsesAsync();
        var relatedResponses =  taskResponses.Where(r => r.TaskId == taskId).ToList();
        return relatedResponses.ParseList();
    }

    public async Task<TaskResponseModel> GetTaskResponseById(int taskId, int taskResponseId)
    {
        var taskResponse = await _taskResponseRepository.GetTaskResponseAsync(taskResponseId);
        if (taskResponse != null && taskResponse.TaskId == taskId)
        {
            return taskResponse.ParseModel();
        }

        throw new NotFoundTaskResponse();
    }

    public async Task<TaskResponseModel> AddTaskResponse(CreateTaskResponseModel model,Guid userId)
    {
        var taskResponse = new TaskResponse()
        {
            ResponseFilePath = model.File != null ? await FileService.SaveFile(model.File) : null,
            ResponseText = model.ResponseText,
            Status = StaticNames.ResponsePending,
            UserId = userId,
            TaskId = model.TaskId,
            StudentName = (await _userRepository.GetUserById(userId)).FirstName
        };
        await _taskResponseRepository.AddTaskResponse(taskResponse);
        return taskResponse.ParseModel();
    }

    public async Task<TaskResponseModel> UpdateTaskResponseStatusByAdmin(UpdateTaskResponseStatus model)
    {
        var taskResponse = await _taskResponseRepository.GetTaskResponseAsync(model.TaskResponseId);
        taskResponse.Status = model.Status;

        await _taskResponseRepository.UpdateTaskResponseStatus(taskResponse);
        return taskResponse.ParseModel();
    }

    public async Task<string> DeleteTaskResponse(int taskId, int taskResponseId)
    {
        var taskResponse = await _taskResponseRepository.GetTaskResponseAsync(taskResponseId);
        if (taskResponse != null && taskResponse.TaskId == taskId)
        {
            await _taskResponseRepository.DeleteTaskResponse(taskResponse);
        }

        throw new NotFoundTaskResponse();
    }
}