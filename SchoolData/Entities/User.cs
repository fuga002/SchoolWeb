using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
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
    [Required]
    public string UserRole { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public List<SubjectRequest> Requests { get; set; }
    public List<UserSubject>? UserSubjects { get; set; }
}