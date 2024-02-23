using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.TaskModels;

public class UpdateTaskResponseStatus
{
    [Required]
    public string Status { get; set; }
    public int TaskResponseId { get; set; }
}