using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models.TaskModels;

public class UpdateTaskModel
{
    [Required]
    public string TaskTitle { get; set; }
    [Required]
    public string TaskDescription { get; set; }

    [Required]
    public float MaxGrade { get; set; }
    

}