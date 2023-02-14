using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.TBundlesService
{
    public interface ITBundlesService
    {
        Task<TBundle> AddTBundle(AddTBundleDto addTBundleDto);
        Task<List<TBundle>> GetAllTBundles();
        
    }
}
