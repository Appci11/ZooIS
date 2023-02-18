using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.WorkTasksService
{
    public class WorkTasksService : IWorkTasksService
    {
        private readonly DataContext _context;

        public WorkTasksService(DataContext context)
        {
            _context = context;
        }
        public async Task<WorkTask> AddWorkTask(AddWorkTaskDto workTaskDto)
        {
            WorkTask workTask = new WorkTask();

            workTask.Name = workTaskDto.Name;
            workTask.Description = workTaskDto.Description;

            _context.WorkTasks.Add(workTask);
            await _context.SaveChangesAsync();

            return workTask;
        }

        public async Task<WorkTask> DeleteWorkTask(int id)
        {
            WorkTask? response = await _context.WorkTasks.FirstOrDefaultAsync(x => x.Id == id);
            if(response == null)
            {
                return null;
            }

            _context.WorkTasks.Remove(response);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<List<WorkTask>> GetAllWorkTasks()
        {
            return await _context.WorkTasks.ToListAsync();
        }

        public async Task<WorkTask> GetWorkTask(int id)
        {
            WorkTask? response = await _context.WorkTasks.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }
    }
}
