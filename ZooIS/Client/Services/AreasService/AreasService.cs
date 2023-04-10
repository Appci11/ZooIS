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
            return response.IsSuccessStatusCode;
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
        public async Task<bool> DeleteAreaByNr(int nr)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/areas/bynumber/{nr}");
            if (response.IsSuccessStatusCode)
            {
                Area area = Areas.FirstOrDefault(a => a.Id == nr);
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
            throw new Exception("Area not found");
        }

        public async Task GetAreas()
        {
            List<Area> result = new List<Area>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Area>>("/api/Areas");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                Areas = result;
            }
            else Areas = new();
        }

        public async Task<bool> UpdateArea(Area area)
        {
            HttpResponseMessage response =  await _http.PutAsJsonAsync($"/api/areas/{area.Id}", area);
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<Dictionary<int, string>> GetAreaNames()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            if(Areas == null || Areas.Count == 0)
            {
                await GetAreas();
            }
            if(Areas != null)
            {
                foreach (var item in Areas)
                {
                    result.Add(item.Id, item.Name);
                }
            }
            return result;
        }

        public async Task<List<int>> GetExistingTagIds(int id)
        {
            var result = await _http.GetFromJsonAsync<List<int>>($"/api/areas/tagsexisting/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Area not found");
        }

        public async Task<List<int>> GetToAvoidTagIds(int id)
        {
            var result = await _http.GetFromJsonAsync<List<int>>($"/api/areas/tagstoavoid/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Area not found");
        }
    }
}
