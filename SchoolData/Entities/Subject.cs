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
    public List<Task>? Tasks { get; set; }

    public int TeacherId { get; set; }

    public string? SubjectPhotoUrl { get; set; }


    public List<SubjectRequest> Requests { get; set; }

    public List<UserSubject>? UserSubjects { get; set; }
}