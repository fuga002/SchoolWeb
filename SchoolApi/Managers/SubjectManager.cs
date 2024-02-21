using SchoolApi.Services.Interfaces;
using SchoolData.Models.SubjectModels;
using SchoolData.StaticServices;

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

        public async Task<SubjectModelByAdmin> GetAllSubjectsByAdmin(Guid userId)
        {
            return new SubjectModelByAdmin();
        }
    }
