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

    public TaskStatus Status { get; set; }


    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey("TaskId")]
    public int TaskId { get; set; }
    public Task? Task { get; set; }
}