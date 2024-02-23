using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Attributes;
using SchoolApi.Managers;
using SchoolData.Models.SubjectModels;

namespace SchoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SubjectsController : ControllerBase
{
    private readonly SubjectManager _subjectManager;
    private readonly TaskManager _taskManager; 

    public SubjectsController(SubjectManager subjectManager, TaskManager taskManager)
    {
        _subjectManager = subjectManager;
        _taskManager = taskManager;
    }

    [CustomAuthorize("Admin", "Teacher", "Student")]
    [HttpGet]
    public async Task<IActionResult> GetAllSubjects()
    {
        return Ok(await _subjectManager.GetAllSubjectsByAdmin());
    }

    [CustomAuthorize("Admin", "Teacher", "Student")]
    [HttpGet("getSubject/{subjectId}")]
    public async Task<IActionResult> GetSubjectById(int subjectId)
    {
        return Ok(await _subjectManager.GetSubjectByAdmin(subjectId));
    }

    [CustomAuthorize("Admin")]
    [HttpPost]
    public async Task<IActionResult> AddSubject(CreateSubjectModel model)
    {
        return Ok(await _subjectManager.AddSubject(model));
    }

    [CustomAuthorize("Admin")]
    [HttpPut("/{subjectId}")]
    public async Task<IActionResult> UpdateSubject(int subjectId, UpdateSubjectModel model)
    {
        return Ok(await _subjectManager.UpdateSubject(subjectId, model));
    }

    [CustomAuthorize("Admin")]
    [HttpPut("addTeacher/{subjectId}")]
    public async Task<IActionResult> AddTeacherToSubject(AddTeacherModel model)
    {
        return Ok(await _subjectManager.AddTeacherToSubject(model.SubjectId, model.TeacherUsername));
    }

    [CustomAuthorize("Admin")]
    [HttpPut("updatePhoto/{subjectId}")]
    public async Task<IActionResult> UpdateSubjectPhoto( int subjectId, IFormFile file)
    {
        return Ok(await _subjectManager.UpdateSubjectPhoto(subjectId, file));
    }

    [CustomAuthorize("Admin")]
    [HttpDelete("/{subjectId}")]
    public async Task<IActionResult> DeleteSubject(int subjectId)
    {
        await _subjectManager.DeleteSubject(subjectId);
        return Ok("Done");
    }

    [CustomAuthorize("Admin", "Teacher", "Student")]
    [HttpPost("getRelatedTasks/{userId}")]
    public async Task<IActionResult> GetTaskRelatedToStudent(Guid userId)
    {
        var tasks = await _taskManager.GetTaskRelatedToStudent(userId);
        return Ok(tasks);
    }

}