using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.TaskModels;

public class UpdateTaskModel
{
    [Required]
    public string TaskTitle { get; set; }
    [Required]
    public string TaskDescription { get; set; }

    [Required]
    public float MaxGrade { get; set; }

    public int SubjectId { get; set; } 
    public int TaskId { get; set; }



}