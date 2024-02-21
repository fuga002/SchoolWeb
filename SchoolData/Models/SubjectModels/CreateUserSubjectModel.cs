namespace SchoolData.Models.SubjectModels;

public class CreateUserSubjectModel
{
    public required string SubjectStatus { get; set; }

    public Guid UserId { get; set; }
    public int SubjectId { get; set; }
}