using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.TaskModels;

public class CreateTaskModel
{
    [Required]
    public string TaskTitle { get; set; }
    [Required]
    public string TaskDescription { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    [Required]
    public float MaxGrade { get; set; }
}