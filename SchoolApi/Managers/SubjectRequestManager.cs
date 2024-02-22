using SchoolApi.Services.Interfaces;

namespace SchoolApi.Managers;

public class SubjectRequestManager
{
    private readonly ISubjectRequestRepository _subjectRequestRepository;

    public SubjectRequestManager(ISubjectRequestRepository subjectRequestRepository)
    {
        _subjectRequestRepository = subjectRequestRepository;
    }

    
}