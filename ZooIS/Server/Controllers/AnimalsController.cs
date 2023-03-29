using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.AnimalsService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsService _animalsService;

        public AnimalsController(IAnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AddAnimalDto addAnimalDto)
        {
            var response = await _animalsService.AddAnimal(addAnimalDto);
            if(response != null)
            {
                return Created($"/api/[controller]/{response.Id}", response);
            }
            return NotFound(new { message = "Failed to add new animal" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            List<Animal> response = await _animalsService.GetAllAnimals(true);
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No animals found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            Animal response = await _animalsService.GetAnimal(id);
            if(response != null )
            {
                return Ok(response);
            }
            return NotFound(new { message = "Animal not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(UpdateAnimalDto updateAnimalDto, int id)
        {
            Animal response = await _animalsService.UdateAnimal(updateAnimalDto, id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Animal data update failed" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            Animal response = await _animalsService.DeleteAnimal(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Deletion error" });
        }
    }
}
