using SchoolData.Entities;
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
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public float MaxGrade { get; set; }

    public DateTime EndDayOfGrade;

    public int SubjectId { get; set; }
    public SubjectModelByAdmin? Subject { get; set; }
}