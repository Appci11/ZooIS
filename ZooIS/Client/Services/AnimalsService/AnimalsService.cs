using System.Net.Http.Json;
using ZooIS.Shared.Models;
using static MudBlazor.CategoryTypes;

namespace ZooIS.Client.Services.AnimalsService
{
    public class AnimalsService : IAnimalsService
    {
        private readonly HttpClient _http;

        public List<Animal> Animals { get; set; } = new List<Animal>();

        public AnimalsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateAnimal(Animal animal)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/animals", animal);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/animals/{id}");
            if (response.IsSuccessStatusCode)
            {
                Animal animal = Animals.FirstOrDefault(a => a.Id == id);
                if (animal != null)
                {
                    Animals.Remove(animal);
                    return true;
                }
            }
            return false;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            var result = await _http.GetFromJsonAsync<Animal>($"/api/animals/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task GetAnimals()
        {
            List<Animal> result = new List<Animal>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Animal>>("/api/animals");
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                Animals = result;
            }
        }

        public async Task<bool> UpdateAnimal(Animal animal)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/animals/{animal.Id}", animal);
            return response.IsSuccessStatusCode;
        }
    }
}
