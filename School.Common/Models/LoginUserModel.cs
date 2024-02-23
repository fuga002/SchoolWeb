using System.ComponentModel.DataAnnotations;

namespace School.Common.Models;

public class LoginUserModel
{
    [Required]
    public  string Password { get; set; }
    [Required]
    public  string Username { get; set; }
}