using System.Net.Http.Json;
using ZooIS.Shared.Models;
using static MudBlazor.CategoryTypes;

namespace ZooIS.Client.Services.BundlesService
{
    public class BundlesService : IBundlesService
    {
        private readonly HttpClient _http;

        public List<Bundle> Bundles { get; set; } = new List<Bundle>();

        public BundlesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateBundle(Bundle bundle)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/bundles", bundle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBundle(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/bundles/{id}");
            if (response.IsSuccessStatusCode)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Bundle bundle = Bundles.FirstOrDefault(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (bundle != null)
                {
                    Bundles.Remove(bundle);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateBundle(Bundle bundle)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/bundles/{bundle.Id}", bundle);
            return response.IsSuccessStatusCode;
        }

        // remember to add get with extras too
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Bundle> GetBundle(int id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetBundles()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }


    }
}
