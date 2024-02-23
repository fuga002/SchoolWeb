using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SchoolData.Models.SubjectModels;

public class UpdatePhotoModel
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public IFormFile File { get; set; }
}