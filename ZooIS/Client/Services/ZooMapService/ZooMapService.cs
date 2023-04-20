using System.Net.Http.Json;
using ZooIS.Client.Models;
using ZooIS.Client.Pages.ZooMap;
using ZooIS.Client.Services.AreasService;
using ZooIS.Client.Services.WorkTasksService;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.ZooMapService
{
    public class ZooMapService : IZooMapService
    {
        public Map Map { get; set; } = new Map();

        private readonly HttpClient _http;
        private readonly IAreasService _areasService;
        private readonly IWorkTasksService _workTasksService;

        public ZooMapService(HttpClient http, IAreasService areasService, IWorkTasksService workTasksService)
        {
            _http = http;
            _areasService = areasService;
            _workTasksService = workTasksService;
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
            Map result = await _http.GetFromJsonAsync<Map>($"/api/maps/{0}");
            if (result != null)
            {
                Map = result;
                return true;
            }
            return false;
        }

        public async Task<Dictionary<int, string>> GetAreasColorsByTags()
        {
            Dictionary<int, string> Values = new Dictionary<int, string>();
            List<AreaIds> areaIds = new List<AreaIds>();
            await _areasService.GetAreas();
            foreach (var item in _areasService.Areas)
            {
                AreaIds exisintgIds = new AreaIds();
                exisintgIds.Existing = await _areasService.GetExistingTagIds(item.Id);
                exisintgIds.ToAvoid = await _areasService.GetToAvoidTagIds(item.Id);
                areaIds.Add(exisintgIds);
            }
            Values = AreasColorProvider.GetColorsForTagMismatch(areaIds);
            return Values;
        }

        public async Task<Dictionary<int, string>> GetAreasColorsByWorkTasks()
        {
            Dictionary<int, string> Values = new Dictionary<int, string>();
            int n = _areasService.Areas.Count;
            await _workTasksService.GetWorkTasks();
            Values = AreasColorProvider.GetColorsFromWorkTasks(_workTasksService.WorkTasks, n);
            return Values;
        }
    }
}
