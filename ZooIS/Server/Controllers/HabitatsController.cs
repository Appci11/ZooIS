using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.HabitatsService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitatsController : ControllerBase
    {
        private readonly IHabitatsService _habitatsService;

        public HabitatsController(IHabitatsService habitatsService)
        {
            _habitatsService = habitatsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHabitat(AddHabitatDto request)
        {
            var response = await _habitatsService.AddHabitat(request);
            if(response != null)
            {
                return Created($"/api/[controller]/{request.AreaId}", response);
            }
            return NotFound(new { message = "Failed to add new habitat" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHabitats()
        {
            List<Habitat> response = await _habitatsService.GetAllHabitats(true);
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new {message = "No habitats found"});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Habitat>> GetHabitat(int id)
        {
            Habitat response = await _habitatsService.GetHabitat(id, true);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Habitat not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitat(UpdateHabitatDto updateHabitatDto, int id)
        {
            Habitat response = await _habitatsService.UpdateHabitat(updateHabitatDto, id);
            if(response == null)
            {
                return NotFound(new { message = "Habitat update failed" });
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitat(int id)
        {
            Habitat response = await _habitatsService.DeleteHabitat(id);
            if(response == null)
            {
                return NotFound(new { message = "Deletion error" });
            }
            return Ok(response);
        }
    }
}
