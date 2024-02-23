using Mapster;
using School.Common.Models;
using School.Common.Models.SubjectModels;
using School.Common.Models.TaskModels;
using SchoolData.Entities;
using Task = SchoolData.Entities.Task;

namespace SchoolApi.Extensions;

public static class ParseCollectionExtensions
{
    public static UserModel ParseModel(this User user)
    {
        return user.Adapt<UserModel>();
    }

    public static SubjectModelByAdmin ParseModel(this Subject? subject)
    {
        return subject.Adapt<SubjectModelByAdmin>();
    }

    public static List<SubjectModelByAdmin> ParseList(List<Subject>? subjects)
    {
        if (subjects == null || subjects.Count == 0)
        {
            return new List<SubjectModelByAdmin>();
        }
        return subjects.Select(subject => subject.ParseModel()).ToList();
    }

    public static TaskModel ParseModel(this Task task)
    {
        return task.Adapt<TaskModel>();
    }

    public static List<TaskModel> ParseList(List<Task>? tasks)
    {
        if (tasks == null || tasks.Count == 0)
        {
            return new List<TaskModel>();
        }
        return tasks.Select(task => task.ParseModel()).ToList();
    }

    public static UserSubjectModel ParseModel(this UserSubject subject)
    {
        return subject.Adapt<UserSubjectModel>();
    }

    public static List<UserSubjectModel> ParseList(List<UserSubject>? userSubjects)
    {
        if (userSubjects == null || userSubjects.Count == 0)
        {
            return new List<UserSubjectModel>();
        }
        return userSubjects.Select(userSubject => userSubject.ParseModel()).ToList();
    }

    public static SubjectRequestModel ParseModel(this SubjectRequest subject)
    {
        return subject.Adapt<SubjectRequestModel>();
    }

    public static List<SubjectRequestModel> ParseList(List<SubjectRequest>? requests)
    {
        if (requests == null || requests.Count == 0)
        {
            return new List<SubjectRequestModel>();
        }
        return requests.Select(request => request.ParseModel()).ToList();
    }

    public static TaskResponseModel ParseModel(this TaskResponse? taskResponse)
    {
        return taskResponse.Adapt<TaskResponseModel>();
    }

    public static List<TaskResponseModel> ParseList(this List<TaskResponse>? responses)
    {
        if (responses == null || responses.Count == 0)
        {
            return new List<TaskResponseModel>();
        }
        return responses.Select(response => response.ParseModel()).ToList();
    }

    public static TaskResponseResultModel ParseModel(this TaskResponseResult result)
    {
        return result.Adapt<TaskResponseResultModel>();
    }

    public static List<TaskResponseResultModel> ParseList(this List<TaskResponseResult>? results)
    {
        if (results == null || results.Count == 0)
        {
            return new List<TaskResponseResultModel>();
        }
        return results.Select(response => response.ParseModel()).ToList();
    }

}