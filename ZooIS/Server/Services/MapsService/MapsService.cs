using Newtonsoft.Json;
using System.Text;
using ZooIS.Server.Models;
using ZooIS.Shared.Models;
using ZooIS.Shared.Models.MapAreaModels;

namespace ZooIS.Server.Services.MapsService
{
    public class MapsService : IMapsService
    {
        private readonly DataContext _context;

        public MapsService(DataContext context)
        {
            _context = context;
        }

        public async Task<Map> AddMap(Map map)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(map);
            await Console.Out.WriteLineAsync(jsonString);
            try
            {
                MapData response = await _context.MapsData.FirstAsync();
                if (response != null)
                {
                    _context.MapsData.Remove(response);
                }
            }
            catch { };
            MapData data = new MapData();
            data.Id = map.Id;
            data.PictureId = map.PictureId;
            data.AreasDrawData = ObjToByte(map.AreasData);
            _context.MapsData.Add(data);
            await _context.SaveChangesAsync();
            return map;
        }

        public async Task<Map> GetMap()
        {
            MapData data = null;
            try
            {
                data = await _context.MapsData.FirstAsync();
            }
            catch { }   // arba galeciau FirstAsync nenaudot...
            if (data == null)
            {
                await AddMap(new Map());
                data = await _context.MapsData.FirstAsync();
            }
            if (data != null)
            {
                Map map = new();
                map.Id = data.Id;
                map.PictureId = data.PictureId;
                map.AreasData = ByteToObj<List<AreaDrawData>>(data.AreasDrawData);
                return map;
            }
            return null;
        }

        TData ByteToObj<TData>(byte[] arr)
        {
            return JsonConvert.DeserializeObject<TData>(Encoding.UTF8.GetString(arr));
        }

        byte[] ObjToByte<TData>(TData data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
