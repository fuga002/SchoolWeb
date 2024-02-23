using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.SubjectModels;

public class UpdateSubjectModel
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public string SubjectName { get; set; }
    [Required]
    public string SubjectDescription { get; set; }
}