using System.Net.Http.Json;
using ZooIS.Client.Pages.WorkTasks;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.WorkTasksService
{
    public class WorkTasksService : IWorkTasksService
    {
        private readonly HttpClient _http;
        public List<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();

        public WorkTasksService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateWorkTask(WorkTask workTask)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/worktasks/", workTask);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorkTask(int id)
        {
            var response = await _http.DeleteAsync($"/api/worktasks/{id}");
            if (response.IsSuccessStatusCode)
            {
                WorkTask task = WorkTasks.FirstOrDefault(x => x.Id == id)!;
                if (task != null)
                {
                    WorkTasks.Remove(task);
                    return true;
                }
            }
            return false;
        }

        public async Task<WorkTask> GetWorkTask(int id)
        {
            var result = await _http.GetFromJsonAsync<WorkTask>($"/api/worktasks/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task GetWorkTasks()
        {
            List<WorkTask> result = new List<WorkTask>();
            try
            {
                result = await _http.GetFromJsonAsync<List<WorkTask>>("/api/worktasks");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                WorkTasks = result;
            }
        }

        public async Task<bool> UpdateWorkTask(WorkTask workTask)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/worktasks/{workTask.Id}", workTask);
            if (response.IsSuccessStatusCode)
            {
                WorkTask task = WorkTasks.FirstOrDefault(x => x.Id == workTask.Id)!;
                if (task != null)
                {
                    task.Name = workTask.Name;
                    task.IsCompleted = workTask.IsCompleted;
                }
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> WorkTaskSetToCompleted(int id)
        {
            HttpResponseMessage response = await _http.PatchAsJsonAsync($"/api/worktasks/{id}", "whatever");
            if (response.IsSuccessStatusCode)
            {
                WorkTask task = WorkTasks.FirstOrDefault(x => x.Id == id)!;
                if (task != null)
                {
                    task.IsCompleted = true;
                }
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<int> DeleteWorkTasks(HashSet<WorkTask> workTasks)
        {
            int c = 0;
            foreach (var item in workTasks)
            {
                if (await DeleteWorkTask(item.Id)) c++;
            }
            return c;
        }
    }
}
