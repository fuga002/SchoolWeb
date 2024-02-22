using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models.TaskModels;

public class UpdateTaskDateModel
{
    [Required]
    public DateOnly EndDate;
}