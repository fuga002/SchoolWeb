using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class UserSubject
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string SubjectStatus { get; set; }

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public int SubjectId { get; set; }
    public virtual Subject? Subject { get; set; }
}