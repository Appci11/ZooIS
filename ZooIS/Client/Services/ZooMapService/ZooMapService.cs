using System.Net.Http.Json;
using System.Text.Json;
using ZooIS.Client.Pages.ZooMap;
using ZooIS.Client.Services.AnimalsService;
using ZooIS.Client.Services.AreasService;
using ZooIS.Client.Services.HabitatsService;
using ZooIS.Client.Services.SpeciesService;
using ZooIS.Client.Services.WorkTasksService;
using ZooIS.Shared;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.ZooMapService
{
    public class ZooMapService : IZooMapService
    {
        public Map Map { get; set; } = new Map();

        private readonly HttpClient _http;
        private readonly IAreasService _areaService;
        private readonly IHabitatsService _habitatsService;
        private readonly IAnimalsService _animalsService;
        private readonly ISpeciesService _speciesService;

        public ZooMapService(HttpClient http, IAreasService areaService, IHabitatsService habitatsService,
                             IAnimalsService animalsService, ISpeciesService speciesService)
        {
            _http = http;
            _areaService = areaService;
            _habitatsService = habitatsService;
            _animalsService = animalsService;
            _speciesService = speciesService;
        }

        public async Task<Dictionary<int, string>> GetAreasColorsByTags()
        {
            Dictionary<int, string> Values = new Dictionary<int, string>();
            await _areaService.GetAreas();
            await _habitatsService.GetHabitats();
            await _animalsService.GetAnimals();
            await _speciesService.GetAllSpecies();
            Values = AreasColorProvider.GetColorsForTagMismatch(_areaService.Areas, _habitatsService.Habitats,
                                                    _animalsService.Animals, _speciesService.AllSpecies);
            return Values;
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
