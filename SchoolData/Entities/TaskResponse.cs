using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolData.Entities;

public class TaskResponse
{
    [Key]
    public int Id { get; set; }
    public string? ResponseFilePath { get; set; }
    public string? ResponseText { get; set; }

    public DateTime ? CreatedAt { get; set; } = DateTime.Now;

    public string Status { get; set; }

    public string StudentName { get; set; }

    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }

    [ForeignKey("TaskId")]
    public int TaskId { get; set; }
    public virtual Task? Task { get; set; }

    public virtual List<TaskResponseResult> Results { get; set; }
}