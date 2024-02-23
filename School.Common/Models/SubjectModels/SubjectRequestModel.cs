namespace School.Common.Models.SubjectModels;

public class SubjectRequestModel
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public Guid UserId { get; set; }
    public UserModel? User { get; set; }

    public int SubjectId { get; set; }
    public SubjectModelByAdmin? Subject { get; set; }
}