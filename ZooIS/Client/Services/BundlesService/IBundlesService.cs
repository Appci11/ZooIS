using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.BundlesService
{
    public interface IBundlesService
    {
        List<Bundle> Bundles { get; set; }

        public Task GetBundles();
        public Task<Bundle> GetBundle(int id);
        public Task<Bundle> GetBundleByUserId(int id);
        public Task<Bundle> GetLastUserBundle(int userId);
        public Task<bool> CreateBundle(AddBundleDto dto);
        public Task<bool> UpdateBundle(Bundle bundle);
        public Task<bool> DeleteBundle(int id);
    }
}
