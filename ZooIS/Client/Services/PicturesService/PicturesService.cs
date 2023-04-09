using System.Net.Http.Json;
using ZooIS.Shared.Models.MapAreaModels;

namespace ZooIS.Client.Services.PicturesService
{
    public class PicturesService : IPicturesService
    {
        private readonly HttpClient _http;

        public PicturesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Coordinates> GetPictureCoordinates(int id)
        {
            var result = await _http.GetFromJsonAsync<Coordinates>($"/api/pictures/data/{id}");
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
