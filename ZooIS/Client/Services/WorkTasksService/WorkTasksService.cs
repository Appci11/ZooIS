using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.WorkTasksService
{
    public class WorkTasksService : IWorkTasksService
    {
        private readonly HttpClient _http;

        public List<WorkTask> WorkTasks { get; set; }

        public WorkTasksService(HttpClient http)
        {
            _http = http;
        }

        public Task<bool> CreateWorkTask(WorkTask workTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWorkTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkTask> GetWorkTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetWorkTasks()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWorkTask(WorkTask workTask)
        {
            throw new NotImplementedException();
        }
    }
}
