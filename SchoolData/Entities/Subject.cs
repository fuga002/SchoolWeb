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

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<UserSubject>? UserSubjects { get; set; }
}