using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SchoolData.Models.TaskModels;

public class CreateTaskResponseModel
{
    public IFormFile? File { get; set; }
    [Required]
    public string ResponseText { get; set; }
    public int TaskId { get; set; }
}