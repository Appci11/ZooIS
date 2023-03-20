using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.HabitatsService
{
    public class HabitatsService : IHabitatsService
    {
        public List<Habitat> Habitats { get; set; } = new List<Habitat>();


        private readonly HttpClient _http;

        public HabitatsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateHabitat(Habitat habitat)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/habitats", habitat);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteHabitat(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/habitats/{id}");
            if (response.IsSuccessStatusCode)
            {
                Habitat habitat = Habitats.FirstOrDefault(x => x.Id == id);
                if (habitat != null)
                {
                    Habitats.Remove(habitat);
                    return true;
                }
            }
            return false;
        }

        public async Task<Habitat> GetHabitat(int id)
        {
            var result = await _http.GetFromJsonAsync<Habitat>($"/api/habitats/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task GetHabitats()
        {
            List<Habitat> result = new List<Habitat>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Habitat>>("/api/habitats");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                Habitats = result;
            }
        }

        public async Task<bool> UpdataHabitat(Habitat habitat)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/habitats/{habitat.Id}", habitat);
            return response.IsSuccessStatusCode;
        }
    }
}
