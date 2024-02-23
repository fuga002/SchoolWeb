using SchoolApi.Extensions;
using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using SchoolData.Models.TaskModels;

namespace SchoolApi.Managers;

public class TaskResponseResultManager
{
    private readonly ITaskResponseResultRepository _resultRepository;

    public TaskResponseResultManager(ITaskResponseResultRepository taskResponseResultRepository)
    {
        _resultRepository = taskResponseResultRepository;
    }

    public async Task<List<TaskResponseResultModel>> GetResponseResults()
    {
        var results = await _resultRepository.GetResponseResults();
        return  results.ParseList();
    }

}