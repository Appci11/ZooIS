using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.TagsService
{
    public interface ITagsService
    {
        Task<Tag> AddTag(AddTagDto addTagDto);
        Task<List<Tag>> GetAllTags(bool includeRelated);
        Task<Tag> GetTag(int id);
        Task<Tag> UpdateTag(UpdateTagDto updateTagDto, int id);
        Task<Tag> DeleteTag(int id);
    }
}
