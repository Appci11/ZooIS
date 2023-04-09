using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZooIS.Server.Services.MapsService;
using ZooIS.Shared;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly IMapsService _mapsService;

        public MapsController(IMapsService mapsService)
        {
            _mapsService = mapsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMap(Map map)
        {
            Map response = await _mapsService.AddMap(map);
            if(response == null)
            {
                return NotFound(new { message = "Failed to add map" });
            }
            return Created($"/api/maps", response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Map>> GetMap()
        {
            Map response = await _mapsService.GetMap();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Map not found" });
        }
    }
}
