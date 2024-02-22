using SchoolApi.Exceptions;
using SchoolApi.Extensions;
using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using SchoolData.Models.TaskModels;
using SchoolData.StaticServices;
using Task = SchoolData.Entities.Task;

namespace SchoolApi.Managers;

public class TaskManager
{
    private readonly ITaskRepository _taskRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUserSubjectRepository _userSubjectRepository;

    public TaskManager(ITaskRepository taskRepository, ISubjectRepository subjectRepository, IUserSubjectRepository userSubjectRepository)
    {
        _taskRepository = taskRepository;
        _subjectRepository = subjectRepository;
        _userSubjectRepository = userSubjectRepository;
    }

    public async Task<List<TaskModel>> GetAllTasks(int subjectId)
    {
        var tasks = await _taskRepository.GetAllTasks();
        if (tasks is null) throw new TaskNotFoundException(subjectId); ;
        var relatedTasks = tasks.Where(t => t.SubjectId == subjectId).ToList();
        return ParseCollectionExtensions.ParseList(relatedTasks);

    }

    public async Task<TaskModel> GetTaskById(int subjectId,int id)
    {
        var task = await _taskRepository.GetTaskById(id);
        return task.SubjectId == subjectId ? task.ParseModel() : throw new TaskNotFoundException(subjectId); ;
    }

    public async Task<TaskModel> AddTask(int subjectId,CreateTaskModel model)
    {
        var task = new Task()
        {
            TaskTitle = model.TaskTitle,
            TaskDescription = model.TaskDescription,
            TaskStatus = StaticNames.TaskContinues,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            MaxGrade = model.MaxGrade,
            SubjectId = subjectId,
            EndDayOfGrade = model.EndDate.AddDays(3)
        };
        await _taskRepository.AddTask(task);
        return task.ParseModel();
    }

    public async Task<TaskModel> UpdateTask(int subjectId,int taskId,UpdateTaskModel model)
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if (task.SubjectId != subjectId) throw new TaskNotFoundException(subjectId);
        task.TaskTitle = model.TaskTitle;
        task.TaskDescription = model.TaskDescription;
        task.MaxGrade = model.MaxGrade;
        await _taskRepository.UpdateTask(task);
        return task.ParseModel();

    }

    public async Task<TaskModel> UpdateTaskEndDate(int subjectId,int taskId, UpdateTaskDateModel model)
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if (task.SubjectId != subjectId) throw new TaskNotFoundException(subjectId);
        task.EndDate = model.EndDate;
        task.EndDayOfGrade = model.EndDate.AddDays(3);
        await _taskRepository.UpdateTask(task);
        return task.ParseModel();
    }

    public async Task<string> DeleteTask(int subjectId, int taskId)
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if(task.SubjectId != subjectId)
            throw new TaskNotFoundException(subjectId);
        await _taskRepository.DeleteTask(task);
        return "Deleted";
    }


    public async Task<List<TaskModel>> GetTaskRelatedToStudent(Guid userId)
    {
        var userSubjects = await _userSubjectRepository.GetAllSubject();
        var relatedUserSubjects = userSubjects
            .Where(u => u.UserId == userId && u.SubjectStatus == StaticNames.SubjectApproved).ToList();
        var relatedSubjects = new List<Subject>();
        foreach (var userSubject in relatedUserSubjects)
        {
            var subject = await _subjectRepository.GetSubjectById(userSubject.SubjectId);
            relatedSubjects.Add(subject);
        }

        var tasks = new List<Task>();
        foreach (var subject in relatedSubjects)
        {
            if (subject.Tasks != null)
            {
                tasks.AddRange(subject.Tasks);
            }
        }

        return ParseCollectionExtensions.ParseList(tasks);
    }

}