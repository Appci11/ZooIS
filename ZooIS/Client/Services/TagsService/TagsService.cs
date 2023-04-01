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
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/tags", tag);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTag(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/tags/{id}");
            if(response.IsSuccessStatusCode)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Tag tag = Tags.FirstOrDefault(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
            var result = await _http.GetFromJsonAsync<Tag>($"/api/tags/{id}");
            if(result != null)
            {
                return result;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task GetTags()
        {
            List<Tag> result = new List<Tag>();
            try
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                result = await _http.GetFromJsonAsync<List<Tag>>("/api/tags");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
            return response.IsSuccessStatusCode;
        }
    }
}
