using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class SubjectRequest
{
    [Key]
    public int Id { get; set; }

    public string? Text { get; set; }

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }

    public int SubjectId { get; set; }
    public virtual Subject? Subject { get; set; }
}