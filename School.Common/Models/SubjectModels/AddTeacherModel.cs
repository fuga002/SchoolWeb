using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.SubjectModels;

public class AddTeacherModel
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public string TeacherUsername { get; set; }
}