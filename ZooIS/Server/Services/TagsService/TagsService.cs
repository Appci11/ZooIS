using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.TagsService
{
    public class TagsService : ITagsService
    {
        private readonly DataContext _context;

        public TagsService(DataContext context)
        {
            _context = context;
        }
        public async Task<Tag> AddTag(AddTagDto addTagDto)
        {
            Tag tag = new Tag();

            tag.Name= addTagDto.Name.ToLower();
            tag.Description = addTagDto.Description;

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return  tag;
        }

        public async Task<Tag> DeleteTag(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if(tag == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        public async Task<List<Tag>> GetAllTags(bool includeRelated)
        {
            if(includeRelated)
            {
                return await _context.Tags
                .Include(t => t.Habitats)
                .Include(t => t.SpeciesRequire)
                .Include(t => t.SpeciesAvoid)

                .ToListAsync();
            }
            return await _context.Tags
                .ToListAsync();
        }

        public async Task<Tag> GetTag(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            return tag;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Tag> UpdateTag(UpdateTagDto updateTagDto, int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if(tag == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            tag.Name = updateTagDto.Name.ToLower();
            tag.Description= updateTagDto.Description;
            await _context.SaveChangesAsync();

            return tag;
        }
    }
}
