namespace School.Common.Models.SubjectModels;

public class UserSubjectModel
{
    public int Id { get; set; }
    public string SubjectStatus { get; set; }
    public float TotalGetGrade { get; set; }

    public Guid UserId { get; set; }
    public UserModel? User { get; set; }
    public int SubjectId { get; set; }
    public SubjectModelByAdmin? Subject { get; set; }
}