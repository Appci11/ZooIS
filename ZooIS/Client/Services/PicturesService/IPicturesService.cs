using ZooIS.Shared.Models.MapAreaModels;

namespace ZooIS.Client.Services.PicturesService
{
    public interface IPicturesService
    {
        public Task<Coordinates> GetPictureCoordinates(int id);
    }
}
