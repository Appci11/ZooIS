using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.BundlesService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundlesController : ControllerBase
    {
        private readonly IBundlesService _bundlesService;

        public BundlesController(IBundlesService bundlesService)
        {
            _bundlesService = bundlesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTbundle(AddBundleDto request)
        {
            var response = await _bundlesService.AddBundle(request);
            if (response == null) return NotFound(new { message = "Bundle was not created" });
            return Created($"/api/tbundles/{response.Id}", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBundles()
        {
            List<Bundle> response = await _bundlesService.GetAllBundles();

            if (response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No Bundles found" });
        }

        [HttpGet]
        [Route("~/api/BundlesWTickets")]
        public async Task<IActionResult> GetAllBundlesWithTickets()
        {
            List<Bundle> response = await _bundlesService.GetAllBundlesWithTickets();

            if (response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No Bundles found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bundle>> GetBundle(int id)
        {
            Bundle response = await _bundlesService.GetBundle(id);
            if(response == null) return NotFound(new { message = "Ticket no found" });
            return Ok(response);
        }

        [HttpGet]
        [Route("~/api/BundlesWTickets/{id}")]
        public async Task<ActionResult<Bundle>> GetBundleWithTickets(int id)
        {
            Bundle response = await _bundlesService.GetBundleWithTickets(id);
            if (response == null) return NotFound(new { message = "Ticket no found" });
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddTbundle(AddBundleDto request, int id)
        {
            Bundle response = await _bundlesService.UpdateBundle(request, id);
            if (response == null)
            {
                return NotFound(new { message = "Ticket was not updated" });
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBundle(int id)
        {
            Bundle response = await _bundlesService.DeleteBundle(id);
            if (response == null)
            {
                return NotFound(new { message = "Deletion error." });
            }
            return Ok(response);
        }
    }
}
