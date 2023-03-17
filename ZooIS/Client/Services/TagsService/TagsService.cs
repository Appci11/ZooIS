using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.TagsService
{
    public class TagsService : ITagsService
    {
        private readonly HttpClient _http;

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public TagsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateTag(Tag tag)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/Tags", tag);
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> DeleteTag(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/Tags/{id}");
            if(response.IsSuccessStatusCode)
            {
                Tag tag = Tags.FirstOrDefault(t => t.Id == id);
                if(tag != null)
                {
                    Tags.Remove(tag);
                    return true;
                }
                // sitoj vietoj atvejis kai is db pasalino, bet is client kazkodel ne
            }
            return false;
        }

        public async Task<Tag> GetTag(int id)
        {
            var result = await _http.GetFromJsonAsync<Tag>($"/api/aread/{id}");
            if(result != null)
            {
                return result;
            }
            throw new Exception("Tag not found");
        }

        public async Task GetTags()
        {
            List<Tag> result = new List<Tag>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Tag>>("/api/tags");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                Tags = result;
            }
        }

        public async Task<bool> UpdateTag(Tag tag)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/tags/{tag.Id}", tag);
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
