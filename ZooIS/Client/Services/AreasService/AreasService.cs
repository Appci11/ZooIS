using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.AreasService
{
    public class AreasService : IAreasService
    {
        private readonly HttpClient _http;

        public List<Area> Areas { get; set; } = new List<Area>();

        public AreasService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateArea(Area area)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/areas", area);
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> DeleteArea(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/areas/{id}");
            if (response.IsSuccessStatusCode)
            {
                Area area = Areas.FirstOrDefault(a => a.Id == id);
                if (area != null)
                {
                    Areas.Remove(area);
                    return true;
                }
                //Lieka atvejis, jei API sekmingai pasalino, bet client dalyje kazkas nepavyko
            }
            return false;
        }

        public async Task<Area> GetArea(int id)
        {
            var result = await _http.GetFromJsonAsync<Area>($"/api/areas/{id}");
            if(result != null)
            {
                return result;
            }
            throw new Exception("User not found");
        }

        public async Task GetAreas()
        {
            var result = await _http.GetFromJsonAsync<List<Area>>("/api/areas");
            if(result != null)
            {
                Areas = result;
            }
        }

        public async Task<bool> UpdateArea(Area area)
        {
            HttpResponseMessage response =  await _http.PutAsJsonAsync($"/api/areas/{area.Id}", area);
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
