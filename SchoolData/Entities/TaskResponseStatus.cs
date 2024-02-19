using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class TaskResponseStatus
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Status { get; set; }
}