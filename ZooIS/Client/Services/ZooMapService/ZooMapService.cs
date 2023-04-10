using System.Net.Http.Json;
using System.Text.Json;
using ZooIS.Shared;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.ZooMapService
{
    public class ZooMapService : IZooMapService
    {
        public Map Map { get; set; } = new Map();

        private readonly HttpClient _http;

        public ZooMapService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> AddMap(Map map)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/maps", map);
            if (response.IsSuccessStatusCode)
            {
                Map = map;
                return true;
            }
            return false;
        }

        public async Task<bool> GetMap()
        {
            Map result = await _http.GetFromJsonAsync<Map>($"/api/maps/{5}");
            if (result != null)
            {
                Map = result;
                return true;
            }
            return false;
        }
    }
}
