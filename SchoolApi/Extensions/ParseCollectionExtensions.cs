using SchoolData.Entities;
using SchoolData.Models;
using SchoolData.Models.SubjectModels;
using SchoolData.Models.TaskModels;
using System.Threading.Tasks;
using Task = SchoolData.Entities.Task;

namespace SchoolApi.Extensions;

public static class ParseCollectionExtensions
{
    public static UserModel ParseModel(this User user)
    {
        return new UserModel()
        {
            UserId = user.Id,
            Firstname = user.FirstName,
            Lastname = user.LastName,
            Username = user.UserName,
            UserRole = user.UserRole,
            BornDate = user.BornDate,
            CreateDateTime = user.CreatedDateTime
        };
    }

    public static SubjectModelByAdmin ParseModel(this Subject? subject)
    {
        if (subject == null)
        {
            return new SubjectModelByAdmin();
        }
        return new SubjectModelByAdmin()
        {
            Id = subject.Id,
            SubjectName = subject.SubjectName,
            SubjectDescription = subject.SubjectDescription,
            TeacherIds = subject.TeacherIds,
            SubjectPhotoUrl = subject.SubjectPhotoUrl,
            Tasks = ParseList(subject.Tasks!),
            UserSubjects = ParseList(subject.UserSubjects!),
            Requests = ParseList(subject.Requests)
        };
    }

    public static List<SubjectModelByAdmin> ParseList(List<Subject>? subjects)
    {
        if (subjects == null)
        {
            return new List<SubjectModelByAdmin>();
        }
        return subjects.Select(subject => subject.ParseModel()).ToList();
    }

    public static TaskModel ParseModel(this Task task)
    {
        return new TaskModel()
        {
            Id = task.Id,
            TaskTitle = task.TaskTitle,
            TaskDescription = task.TaskDescription,
            TaskStatus = task.TaskStatus,
            TaskResponses = ParseList(task.TaskResponses!),
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            MaxGrade = task.MaxGrade,
            EndDayOfGrade = task.EndDayOfGrade,
            SubjectId = task.SubjectId,
            Subject = task.Subject!.ParseModel()
        };
    }

    public static List<TaskModel> ParseList(List<Task>? tasks)
    {
        if (tasks == null)
        {
            return new List<TaskModel>();
        }
        return tasks.Select(task => task.ParseModel()).ToList();
    }

    public static UserSubjectModel ParseModel(this UserSubject subject)
    {
        return new UserSubjectModel()
        {
            Id = subject.Id,
            SubjectStatus = subject.SubjectStatus,
            SubjectId = subject.SubjectId,
            Subject = subject.Subject!.ParseModel(),
            UserId = subject.UserId,
            User = subject.User!.ParseModel()
        };
    }

    public static List<UserSubjectModel> ParseList(List<UserSubject>? userSubjects)
    {
        if (userSubjects == null)
        {
            return new List<UserSubjectModel>();
        }
        return userSubjects.Select(userSubject => userSubject.ParseModel()).ToList();
    }

    public static SubjectRequestModel ParseModel(this SubjectRequest subject)
    {
        return new SubjectRequestModel()
        {
            Id = subject.Id,
            Text = subject.Text,
            UserId = subject.UserId,
            User = subject.User.ParseModel(),
            SubjectId = subject.SubjectId,
            Subject = subject.Subject.ParseModel()
        };
    }

    public static List<SubjectRequestModel> ParseList(List<SubjectRequest> requests)
    {
        if (requests == null )
        {
            return new List<SubjectRequestModel>();
        }
        return requests.Select(request => request.ParseModel()).ToList();
    }

    public static TaskResponseModel ParseModel(this TaskResponse taskResponse)
    {
        return new TaskResponseModel()
        {
            Id = taskResponse.Id,
            ResponseFilePath = taskResponse.ResponseFilePath,
            ResponseText = taskResponse.ResponseText,
            CreatedAt = taskResponse.CreatedAt,
            UserId = taskResponse.UserId,
            User = taskResponse.User!.ParseModel(),
            TaskId = taskResponse.TaskId,
            Task = taskResponse.Task!.ParseModel()
        };
    }

    public static List<TaskResponseModel> ParseList(List<TaskResponse>? responses)
    {
        if (responses == null || responses.Count == 0)
        {
            return new List<TaskResponseModel>();
        }
        return responses.Select(response => response.ParseModel()).ToList();
    }

}