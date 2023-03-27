using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.TagsService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }
        [HttpPost]
        public async Task<IActionResult> AddTag(AddTagDto addTagDto)
        {

            Tag response = await _tagsService.AddTag(addTagDto);
            if (response != null)
            {
                return Created($"/api/[controller]/{response.Id}", response);
            }
            return NotFound(new { message = "Failed to add new tag" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            List<Tag> response= await _tagsService.GetAllTags(true);
            if(response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No tags found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            Tag response = await _tagsService.GetTag(id);
            if(response != null) 
            {
                return Ok(response);
            }
            return NotFound(new { message = "Tag not found" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tag>> UpdateTag(UpdateTagDto updateTagDto, int id)
        {
            Tag response = await _tagsService.UpdateTag(updateTagDto, id);
            if(response!=null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Tag update failed" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            Tag response = await _tagsService.DeleteTag(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "Tag deletion failed" });
        }
    }
}
