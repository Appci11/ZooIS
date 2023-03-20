using System.Net.Http.Json;
using ZooIS.Shared.Models;
using static MudBlazor.CategoryTypes;

namespace ZooIS.Client.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        private readonly HttpClient _http;

        public List<Species> AllSpecies { get; set; } = new List<Species>();

        public SpeciesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateSingleSpecies(Species species)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/species", species);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSingleSpecies(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/species/{id}");
            if (response.IsSuccessStatusCode)
            {
                Species species = AllSpecies.FirstOrDefault(s => s.Id == id);
                if (species != null)
                {
                    AllSpecies.Remove(species);
                    return true;
                }
            }
            return false;
        }

        public async Task GetAllSpecies()
        {
            List<Species> result = new List<Species>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Species>>("/api/species");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                AllSpecies = result;
            }
        }

        public async Task<Species> GetSingleSpecies(int id)
        {
            var result = await _http.GetFromJsonAsync<Species>($"/api/species/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> UpdateSingleSpecies(Species species)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/species/{species.Id}", species);
            return response.IsSuccessStatusCode;
        }
    }
}
