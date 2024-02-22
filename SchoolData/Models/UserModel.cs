using SchoolData.Models.SubjectModels;

namespace SchoolData.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public  string Firstname { get; set; }
    public string? Lastname { get; set; }
    public  string Username { get; set; }
    public string UserRole { get; set; }
    public string BornDate { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string PhotoUrl { get; set; }
    public virtual List<SubjectRequestModel> Requests { get; set; }
    public virtual List<UserSubjectModel>? UserSubjects { get; set; }
}