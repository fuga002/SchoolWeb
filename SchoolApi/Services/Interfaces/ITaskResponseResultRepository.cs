using SchoolData.Entities;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Services.Interfaces;

public interface ITaskResponseResultRepository
{
    Task<List<TaskResponseResult>?> GetResponseResults();
    Task<TaskResponseResult?> GetResponseResultsById(int resultId);

    Task UpdateResponseResult(TaskResponseResult result);
}