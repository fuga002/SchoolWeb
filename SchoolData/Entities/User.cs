using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    public string? PhotoUrl { get; set; }
    [Required]
    public string BornDate { get; set; }
    public Role UserRole { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public List<Subject>? Subjects { get; set; }
    public List<UserSubject>? UserSubjects { get; set; }
}