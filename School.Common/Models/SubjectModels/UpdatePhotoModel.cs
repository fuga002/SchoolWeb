using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace School.Common.Models.SubjectModels;

public class UpdatePhotoModel
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public IFormFile File { get; set; }
}