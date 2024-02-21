﻿using SchoolData.Models.TaskModels;

namespace SchoolData.Models.SubjectModels;

public class SubjectModelByAdmin
{
    public int Id { get; set; }

    public string SubjectName { get; set; }
    public string SubjectDescription { get; set; }

    public int TeacherId { get; set; }

    public string? SubjectPhotoUrl { get; set; }
    public List<TaskModel>? Tasks { get; set; }
    public List<SubjectRequestModel>? Requests { get; set; }

    public List<UserSubjectModel>? UserSubjects { get; set; }
}