using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.WorkTasksService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTasksController : ControllerBase
    {
        private readonly IWorkTasksService _workTasksService;

        public WorkTasksController(IWorkTasksService workTasksService)
        {
            _workTasksService = workTasksService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkTask(AddWorkTaskDto request)
        {
            WorkTask response = await _workTasksService.AddWorkTask(request);
            if(response != null)
            {
                return Created($"/api/[controller]/{response.Id}", response);
            }
            return NotFound(new { message = "Work task was not added. Try again later." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkTasks()
        {
            List<WorkTask> response = await _workTasksService.GetAllWorkTasks();
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No work tasks found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkTask>> GetWorkTask(int id)
        {
            WorkTask response = await _workTasksService.GetWorkTask(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Work Task was not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkTask(int id)
        {
            WorkTask response = await _workTasksService.DeleteWorkTask(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No task was found. Nothing deleted." });
        }
    }
}
