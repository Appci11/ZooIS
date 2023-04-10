using ZooIS.Client.Services.AreasService;
using static MudBlazor.Colors;

namespace ZooIS.Client.Pages.ZooMap
{
    public static class AreasColorProvider
    {
        public static Dictionary<int, string> GetRandomColors(int quantity)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();
            Random rnd = new Random();
            for(int i = 0; i < quantity; i++)
            {
                int val = rnd.Next(1, 11);
                switch (val)
                {
                    case < 6:
                        colors.Add(i + 1, Green.Lighten1.ToString());
                        break;
                    case > 8:
                        colors.Add(i + 1, Red.Lighten1.ToString());
                        break;
                    default:
                        colors.Add(i + 1, Yellow.Lighten1.ToString());
                        break;
                }
            }
            return colors;
        }

        public static Dictionary<int, string> GetDefaultColors(int quantity)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();
            for (int i = 0; i < quantity; i++)
            {
                colors.Add(i + 1, "#FFFFFF");
            }
            return colors;
        }
    }
}
