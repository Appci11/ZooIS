﻿using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.BundlesService
{
    public interface IBundlesService
    {
        List<Bundle> Bundles { get; set; }

        public Task GetBundles();
        public Task<Bundle> GetBundle(int id);
        public Task<bool> CreateBundle(Bundle bundle);
        public Task<bool> UpdateBundle(Bundle bundle);
        public Task<bool> DeleteBundle(int id);
    }
}