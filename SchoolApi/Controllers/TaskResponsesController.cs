using Microsoft.AspNetCore.Mvc;
using School.Common.Models.TaskModels;
using SchoolApi.Attributes;
using SchoolApi.Exceptions;
using SchoolApi.Managers;
using SchoolApi.Providers;

namespace SchoolApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TaskResponsesController : ControllerBase
{
    private readonly TaskResponseManager _taskResponseManager;
    private readonly UserProvider _userProvider;

    public TaskResponsesController(TaskResponseManager taskResponseManager, UserProvider userProvider)
    {
        _taskResponseManager = taskResponseManager;
        _userProvider = userProvider;
    }
    [CustomAuthorize("Admin", "Teacher", "Student")]
    [HttpGet("{taskId}")]
    public async Task<IActionResult> GetAllTaskResponse(int taskId)
    {
        return Ok(await _taskResponseManager.GetAllTaskResponse(taskId));
    }

    [CustomAuthorize("Admin", "Teacher", "Student")]
    [HttpGet("{taskResponseId}")]
    public async Task<IActionResult> GetTaskResponseById(int taskId, int taskResponseId)
    {
        try
        {
            return Ok(await _taskResponseManager.GetTaskResponseById(taskId, taskResponseId));
        }
        catch (NotFoundTaskResponse e)
        {
            return NotFound();
        }
    }

    [CustomAuthorize("Admin", "Teacher", "Student")]
    [HttpPost]
    public async Task<IActionResult> AddTaskResponse(CreateTaskResponseModel model)
    {
        var userId = _userProvider.UserId;
        return Ok(await _taskResponseManager.AddTaskResponse(model, userId));
    }

    [CustomAuthorize("Admin", "Teacher")]
    [HttpPut]
    public async Task<IActionResult> UpdateTaskResponseStatus(UpdateTaskResponseStatus model)
    {
        return Ok(await _taskResponseManager.UpdateTaskResponseStatusByAdmin(model));
    }

    [CustomAuthorize("Admin")]
    [HttpDelete("{takResponseId}")]
    public async Task<IActionResult> DeleteTaskResponseId(int taskId, int taskResponseId)
    {
        try
        {
            return Ok(await _taskResponseManager.DeleteTaskResponse(taskId, taskResponseId));
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
}