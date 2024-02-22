using System.ComponentModel.DataAnnotations;
using SchoolData.Models.SubjectModels;

namespace SchoolData.Models.TaskModels;

public class TaskModel
{
    public int Id { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public string TaskStatus { get; set; }
    public List<TaskResponseModel>? TaskResponses { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    [Required]
    public float MaxGrade { get; set; }

    public DateOnly EndDayOfGrade;

    public int SubjectId { get; set; }
}