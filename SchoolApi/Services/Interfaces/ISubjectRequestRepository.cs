using SchoolData.Entities;

namespace SchoolApi.Services.Interfaces;

public interface ISubjectRequestRepository
{
    Task<List<SubjectRequest>> GetAllRequests();
    Task<SubjectRequest> GetRequestById(int id);

    Task<SubjectRequest> AddSubjectRequest(SubjectRequest subjectRequest);
    Task<SubjectRequest> UpdateSubjectRequest(SubjectRequest subjectRequest);
    Task<SubjectRequest> DeleteSubjectRequest(SubjectRequest subjectRequest);
}