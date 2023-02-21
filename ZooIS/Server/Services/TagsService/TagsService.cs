﻿using ZooIS.Shared.Dto;
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

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return  tag;
        }

        public async Task<Tag> DeleteTag(int id)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if(tag == null)
            {
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTag(int id)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            return tag;
        }

        public async Task<Tag> UpdateTag(UpdateTagDto updateTagDto, int id)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if(tag == null)
            {
                return null;
            }
            tag.Name = updateTagDto.Name.ToLower();
            tag.Description= updateTagDto.Description;
            await _context.SaveChangesAsync();

            return tag;
        }
    }
}