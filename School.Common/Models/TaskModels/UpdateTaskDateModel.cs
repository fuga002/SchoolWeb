using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.TaskModels;

public class UpdateTaskDateModel
{
    [Required]
    public DateOnly EndDate;
}