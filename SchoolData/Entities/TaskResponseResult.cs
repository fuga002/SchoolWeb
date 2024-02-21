using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolData.Entities;

public class TaskResponseResult
{
    [Key]
    public int Id { get; set; }

    public float Grade { get; set; }

    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey("TaskId")]
    public int TaskId { get; set; }
    public Task? Task { get; set; }
}