using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.TagsService
{
    public interface ITagsService
    {
        List<Tag> Tags { get; set; }

        public Task GetTags();
        public Task<Tag> GetTag(int id);
        public Task<bool> CreateTag(Tag tag);
        public Task<bool> UpdateTag(Tag tag);
        public Task<bool> DeleteTag(int id);
    }
}
