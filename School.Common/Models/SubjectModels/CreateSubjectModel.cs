﻿using System.ComponentModel.DataAnnotations;

namespace School.Common.Models.SubjectModels;

public class CreateSubjectModel
{
    [Required]
    public string SubjectName { get; set; }
    [Required]
    public string SubjectDescription { get; set; }
    [Required]
    public string TeacherUsername { get; set; }
}