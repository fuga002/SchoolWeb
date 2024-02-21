using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models;

public class UpdateUserModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string BornDate { get; set; }
    public string UserRole { get; set; }
}