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

    public List<TaskResponse>? TaskResponses { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public float MaxGrade { get; set; }

    public DateTime EndDayOfGrade => EndDate.AddDays(3);

    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
}