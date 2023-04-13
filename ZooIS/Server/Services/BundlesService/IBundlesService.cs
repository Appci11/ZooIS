using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.BundlesService
{
    public interface IBundlesService
    {
        Task<Bundle> AddBundle(AddBundleDto addBundleDto);
        Task<List<Bundle>> GetAllBundles(bool includeRelated);
        Task<Bundle> GetBundle(int id, bool includeRelated);
        Task<Bundle> GetLatestUserBundle(int userId, bool includeRelated);
        Task<Bundle> GetBundleByUserId(int id, bool includeRelated);
        Task<Bundle> UpdateBundle(UpdateBundleDto updateBundleDto, int id);
        Task<Bundle> DeleteBundle(int id);
    }
}
