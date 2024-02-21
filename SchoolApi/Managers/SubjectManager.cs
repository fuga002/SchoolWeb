using SchoolApi.Extensions;
using SchoolApi.Services;
using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using SchoolData.Models.SubjectModels;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Managers;

    public class SubjectManager
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUserRepository _userRepository;

        public SubjectManager(ISubjectRepository subjectRepository, IUserRepository userRepository)
        {
            _subjectRepository = subjectRepository;
            _userRepository = userRepository;
        }

        public async Task<List<SubjectModelByAdmin>> GetAllSubjectsByAdmin()
        {
            var subjects = await _subjectRepository.GetAllSubjects();
            return ParseCollectionExtensions.ParseList(subjects);
        }

        public async Task<SubjectModelByAdmin> GetSubjectByAdmin(int subjectId)
        {
            var subject = await _subjectRepository.GetSubjectById(subjectId);
            return subject.ParseModel();
        }

        public async Task<SubjectModelByAdmin> AddSubject(CreateSubjectModel model)
        {
            var subject = new Subject()
            {
                SubjectName = model.SubjectName,
                SubjectDescription = model.SubjectDescription,
                TeacherIds = new List<Guid>(){(await _userRepository.GetByUserName(model.TeacherUsername))!.Id},
                //at least, default photo is needed to set up !

            };
            await _subjectRepository.DeleteSubject(subject);
            return subject.ParseModel();
        }

        public async Task<SubjectModelByAdmin> UpdateSubject(int subjectId, UpdateSubjectModel model)
        {
            var subject = await _subjectRepository.GetSubjectById(subjectId);
            subject.SubjectName = model.SubjectName;
            subject.SubjectDescription = model.SubjectDescription;
            await _subjectRepository.UpdateSubject(subject);
            return subject.ParseModel();
        }

        public async Task<SubjectModelByAdmin> AddTeacherToSubject(int subjectId, string userName)
        {
            var user = await _userRepository.GetByUserName(userName);
            var subject = await _subjectRepository.GetSubjectById(subjectId);
            subject.TeacherIds.Add(user!.Id);
            await _subjectRepository.UpdateSubject(subject);
            return subject.ParseModel();
        }

        public async Task<SubjectModelByAdmin> UpdateSubjectPhoto(int subjectId, IFormFile file)
        {
            var subject = await _subjectRepository.GetSubjectById(subjectId);
            subject.SubjectPhotoUrl = await FileService.SaveFile(file);
            await _subjectRepository.UpdateSubject(subject);
            return subject.ParseModel();
        }

        public async Task DeleteSubject(int subjectId)
        {
            var subject = await _subjectRepository.GetSubjectById(subjectId);
            await _subjectRepository.DeleteSubject(subject);
        }

    }
