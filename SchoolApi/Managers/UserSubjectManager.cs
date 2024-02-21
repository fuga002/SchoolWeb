using SchoolApi.Exceptions;
using SchoolApi.Extensions;
using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using SchoolData.Models.SubjectModels;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Managers;

public class UserSubjectManager
{
    private readonly IUserSubjectRepository _subjectRepository;

    public UserSubjectManager(IUserSubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<List<UserSubjectModel>> GetAllUserSubject()
    {
        var userSubjects = await _subjectRepository.GetAllSubject();
        return ParseCollectionExtensions.ParseList(userSubjects);    
    }

    public async Task<UserSubjectModel> GetUserSubjectById(int id)
    {
        var userSubject = await _subjectRepository.GetSubjectById(id);
        return userSubject == null ? throw new UserSubjectNotFoundException() : userSubject.ParseModel();
    }

    public async Task AddUserSubject(CreateUserSubjectModel model)
    {
        var userSubject = new UserSubject()
        {
            SubjectStatus = model.SubjectStatus,
            UserId = model.UserId,
            SubjectId = model.SubjectId
        };
        await _subjectRepository.AddUserSubject(userSubject);
    }

    public async Task UpdateUserSubject(CreateUserSubjectModel model)
    {
        var userSubject = await _subjectRepository.GetSubjectByIds(model.UserId, model.SubjectId);
        if (userSubject is null)
            throw new UserSubjectNotFoundException();

        userSubject.SubjectStatus = model.SubjectStatus;
        await _subjectRepository.UpdateUserSubject(userSubject);
    }

    public async Task DeleteUserSubject(Guid userId, int subjectId)
    {
        var userSubject = await _subjectRepository.GetSubjectByIds(userId, subjectId);
        if (userSubject is null)
            throw new UserSubjectNotFoundException();
        await _subjectRepository.DeleteUserSubject(userSubject);
    }
}