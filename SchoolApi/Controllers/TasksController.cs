using Microsoft.AspNetCore.Mvc;
using SchoolApi.Exceptions;
using SchoolApi.Managers;
using SchoolData.Models.TaskModels;

namespace SchoolApi.Controllers;

[Route("api/[controller]/{subjectId}")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly TaskManager _taskManager;

    public TasksController(TaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks(int subjectId)
    {
        try
        {
            var tasks = await _taskManager.GetAllTasks(subjectId);
            return Ok(tasks);
        }
        catch(TaskNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("/{taskId}")]
    public async Task<IActionResult> GetTaskById(int subjectId, int taskId)
    {
        try
        {
            var task = await _taskManager.GetTaskById(subjectId, taskId);
            return Ok(task);
        }
        catch (TaskNotFoundException )
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddTask(int subjectId, [FromBody]  CreateTaskModel model)
    {
        var task = await _taskManager.AddTask(subjectId, model);
        return Ok(task);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask(int subjectId, int taskId, [FromBody] UpdateTaskModel model)
    {
        try
        {
            var task = await _taskManager.UpdateTask(subjectId,taskId, model);
            return Ok(task);
        }
        catch (TaskNotFoundException )
        {
            return NotFound();
        }
    }

    [HttpPut("/updateDate")]
    public async Task<IActionResult> UpdateTaskEndDate(int subjectId, int taskId, [FromBody] UpdateTaskDateModel model)
    {
        try
        {
            var task = await _taskManager.UpdateTaskEndDate(subjectId, taskId, model);
            return Ok(task);
        }
        catch (TaskNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTask(int subjectId, int taskId)
    {
        try
        {
            var response = await _taskManager.DeleteTask(subjectId, taskId);
            return Ok(response);
        }
        catch (TaskNotFoundException e)
        {
            return NotFound();
        }
    }

}