using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class Subject
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string SubjectName { get; set; }
    [Required]
    public string SubjectDescription { get; set; }
    public virtual List<Task>? Tasks { get; set; }

    public List<Guid> TeacherIds { get; set; }

    public string? SubjectPhotoUrl { get; set; }

    public float TotalGrade { get; set; } = 0;
    public float TotalGetGrade { get; set; } = 0;


    public virtual List<SubjectRequest> Requests { get; set; }

    public virtual List<UserSubject>? UserSubjects { get; set; }
}