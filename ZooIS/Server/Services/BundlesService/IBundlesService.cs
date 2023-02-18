using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.BundlesService
{
    public interface IBundlesService
    {
        Task<Bundle> AddBundle(AddBundleDto addBundleDto);
        Task<List<Bundle>> GetAllBundles();
        Task<List<Bundle>> GetAllBundlesWithTickets();  //perteklinis?
        Task<Bundle> GetBundle(int id);
        Task<Bundle> GetBundleWithTickets(int id);
        Task<Bundle> UpdateBundle(AddBundleDto addBundleDto, int id);
        Task<Bundle> DeleteBundle(int id);
    }
}
