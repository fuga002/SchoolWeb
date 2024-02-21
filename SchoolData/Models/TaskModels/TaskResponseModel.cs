namespace SchoolData.Models.TaskModels;

public class TaskResponseModel
{
    public int Id { get; set; }
    public string? ResponseFilePath { get; set; }
    public string? ResponseText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Status { get; set; }


    public Guid UserId { get; set; }
    public UserModel? User { get; set; }
    public int TaskId { get; set; }
    public TaskModel? Task { get; set; }
}