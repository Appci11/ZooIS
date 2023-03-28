﻿using System.Net.Http.Json;
using ZooIS.Shared.Models;
using static MudBlazor.CategoryTypes;

namespace ZooIS.Client.Services.BundlesService
{
    public class BundlesService : IBundlesService
    {
        private readonly HttpClient _http;

        public List<Bundle> Bundles { get; set; } = new List<Bundle>();

        public BundlesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateBundle(Bundle bundle)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/bundles", bundle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBundle(int id)
        {
            HttpResponseMessage response = await _http.DeleteAsync($"/api/bundles/{id}");
            if (response.IsSuccessStatusCode)
            {
                Bundle bundle = Bundles.FirstOrDefault(t => t.Id == id);
                if (bundle != null)
                {
                    Bundles.Remove(bundle);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateBundle(Bundle bundle)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/bundles/{bundle.Id}", bundle);
            return response.IsSuccessStatusCode;
        }

        // remember to add get with extras too
        public async Task<Bundle> GetBundle(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetBundles()
        {
            throw new NotImplementedException();
        }


    }
}