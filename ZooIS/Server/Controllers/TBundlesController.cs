using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.TBundlesService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBundlesController : ControllerBase
    {
        private readonly ITBundlesService _tBundlesService;

        public TBundlesController(ITBundlesService tBundlesService)
        {
            _tBundlesService = tBundlesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTbundle(AddTBundleDto request)
        {
            var response = await _tBundlesService.AddTBundle(request);
            if (response == null) return NotFound(new { message = "TBundle was not created" });
            return Created($"/api/tbundles/{response.Id}", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTBundles()
        {
            List<TBundle> response = await _tBundlesService.GetAllTBundles();
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No TBundles found" });
        }
    }
}
