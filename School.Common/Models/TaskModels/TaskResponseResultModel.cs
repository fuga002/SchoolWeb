namespace School.Common.Models.TaskModels;

public class TaskResponseResultModel
{
    public int Id { get; set; }

    public float Grade { get; set; }

    public Guid UserId { get; set; }
    public  UserModel? User { get; set; }

    public int TaskId { get; set; }
    public  TaskResponseModel? TaskResponse { get; set; }
}