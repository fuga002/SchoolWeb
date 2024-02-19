using System.ComponentModel.DataAnnotations;

namespace SchoolData.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    [Required]
    public  string RoleName { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}