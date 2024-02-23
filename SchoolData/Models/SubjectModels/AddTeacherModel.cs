using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models.SubjectModels;

public class AddTeacherModel
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public string TeacherUsername { get; set; }
}