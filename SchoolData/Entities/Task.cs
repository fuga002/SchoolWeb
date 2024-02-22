using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class Task
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string TaskTitle { get; set; }
    [Required]
    public string TaskDescription { get; set; }
    [Required]
    public string TaskStatus { get; set; }

    public virtual List<TaskResponse>? TaskResponses { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    [Required]
    public float MaxGrade { get; set; }

    public DateOnly EndDayOfGrade ;

    public int SubjectId { get; set; }
    public virtual Subject? Subject { get; set; }
}