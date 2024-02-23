using System.ComponentModel.DataAnnotations;

namespace School.Common.Models;

public class CreateUserModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    [Required]
    public  string Password { get; set; }
    [Compare(nameof(Password))]
    [Required]
    public  string ConfirmPassword { get; set; }

    public string BornDate { get; set; }
    public string UserRole { get; set; }
}