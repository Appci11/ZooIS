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
        public async Task<IActionResult> Addbundle(AddBundleDto request)
        {
            var response = await _bundlesService.AddBundle(request);
            if (response == null) return NotFound(new { message = "Bundle was not created" });
            return Created($"/api/bundles/{response.Id}", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBundles()
        {
            List<Bundle> response = await _bundlesService.GetAllBundles(true);

            if (response == null || response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No Bundles found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bundle>> GetBundle(int id)
        {
            Bundle response = await _bundlesService.GetBundle(id, true);
            if(response == null) return NotFound(new { message = "Bundle no found" });
            return Ok(response);
        }

        [HttpGet("getByUser/{id}")]
        public async Task<ActionResult<Bundle>> GetBundleByUserId(int id)
        {
            Bundle response = await _bundlesService.GetBundleByUserId(id, true);
            if (response == null) return NotFound(new { message = "Bundle no found" });
            return Ok(response);
        }
        [HttpGet("getLatestUserBundle/{id}")]
        public async Task<ActionResult<Bundle>> GetLatestUserBundle(int id)
        {
            Bundle response = await _bundlesService.GetLatestUserBundle(id, true);
            if (response == null) return NotFound(new { message = "Bundle not found" });
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBundle(UpdateBundleDto request, int id)
        {
            Bundle response = await _bundlesService.UpdateBundle(request, id);
            if (response == null)
            {
                return NotFound(new { message = "Bundle was not updated" });
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
