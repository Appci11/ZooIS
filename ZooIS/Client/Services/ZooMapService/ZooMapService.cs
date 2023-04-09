using System.Net.Http.Json;
using System.Text.Json;
using ZooIS.Shared;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.ZooMapService
{
    public class ZooMapService : IZooMapService
    {
        public Map Map { get; set; } = new Map();

        const int ZOO_AREAS_COUNT = 35; // = actual areas count + 1
        private readonly HttpClient _http;

        public string[] ZooMapFillColors { get; set; } = new string[ZOO_AREAS_COUNT];
        public string[] ZooMapStrokeColors { get; set; } = new string[ZOO_AREAS_COUNT];
        public ZooMapService(HttpClient http)
        {
            for (int i = 1; i < ZOO_AREAS_COUNT; i++)
            {
                ZooMapFillColors[i] = "#ffffff";
            }
            ZooMapFillColors[1] = "#ffffff";
            ZooMapFillColors[2] = "#66FF66";
            ZooMapFillColors[3] = "#FFFF66";
            ZooMapFillColors[4] = "#FFB366";
            ZooMapFillColors[5] = "#FF6666";
            for (int i = 1; i < ZOO_AREAS_COUNT; i++)
            {
                ZooMapStrokeColors[i] = "#000000";
            }
            ZooMapStrokeColors[1] = "#000000";
            ZooMapStrokeColors[2] = "#82b366";
            ZooMapStrokeColors[3] = "#d6b656";
            ZooMapStrokeColors[4] = "#d79b00";
            ZooMapStrokeColors[5] = "#b85450";
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
