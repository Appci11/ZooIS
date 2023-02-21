﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using ZooIS.Server.Services.AreasService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreasService _areasService;

        public AreasController(IAreasService areasService)
        {
            _areasService = areasService;
        }

        [HttpPost]
        public async Task<IActionResult> AddArea(AddAreaDto addAreaDto)
        {
            Area response = await _areasService.AddArea(addAreaDto);
            if(response == null)
            {
                return NotFound(new {message = "Failed to add new area"});
            }
            return Created($"/api/[controller]/{response.Id}", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            List<Area> response = await _areasService.GetAllAreas();
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No areas found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            Area response = await _areasService.GetArea(id);
            if(response != null) 
            {
                return Ok(response);
            }
            return NotFound(new { message = "Area not found" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Area>> UpdateArea(UpdateAreaDto request, int id)
        {
            Area response = await _areasService.UpdateArea(request, id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Area was not updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            Area response = await _areasService.DeleteArea(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Area was not deleted" });
        }
    }
}