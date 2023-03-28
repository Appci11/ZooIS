using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.SpeciesService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecies(AddSpeciesDto request)
        {
            await Console.Out.WriteLineAsync("WILL ADD SPECIESSSSS!!!!");
            var response = await _speciesService.AddSpecies(request);
            if(response != null)
            {
                return Created($"/api/[controller]/{response.Id}", response);
            }
            return NotFound(new { message = "Failed to add new species" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecies()
        {
            List<Species> response = await _speciesService.GetAllSpecies(true);
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No species found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Species>> GetSpecies(int id)
        {
            Species response = await _speciesService.GetSpecies(id, true);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Species not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecies(UpdateSpeciesDto request, int id)
        {
            Species response = await _speciesService.UpdateSpecies(request, id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Update error" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            Species response = await _speciesService.DeleteSpecies(id);
            if(response == null)
            {
                return NotFound(new { message = "Deletion error" });
            }
            return Ok(response);
        }
    }
}
