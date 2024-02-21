namespace SchoolData.Models;

public class UserModel
{
    public Guid UserId { get; set; }
    public  string Firstname { get; set; }
    public string? Lastname { get; set; }
    public  string Username { get; set; }
    public string UserRole { get; set; }
    public string BornDate { get; set; }
    public DateTime CreateDateTime { get; set; }
}