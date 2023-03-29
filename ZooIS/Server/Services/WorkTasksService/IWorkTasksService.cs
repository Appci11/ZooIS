using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.WorkTasksService
{
    public interface IWorkTasksService
    {
        Task<WorkTask> AddWorkTask(AddWorkTaskDto workTaskDto);
        Task<List<WorkTask>> GetAllWorkTasks();
        Task<WorkTask> GetWorkTask(int id);
        Task<WorkTask> UpdateWorkTask(UpdateWorkTaskDto dto, int id);
        Task<WorkTask> DeleteWorkTask(int id);
    }
}
