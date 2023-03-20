using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.WorkTasksService
{
    public interface IWorkTasksService
    {
        List<WorkTask> WorkTasks { get; set; }

        public Task GetWorkTasks();
        public Task<WorkTask> GetWorkTask(int id);
        public Task<bool> CreateWorkTask(WorkTask workTask);
        public Task<bool> UpdateWorkTask(WorkTask workTask);
        public Task<bool> DeleteWorkTask(int id);
    }
}
