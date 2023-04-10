using ZooIS.Shared.Models;
using static MudBlazor.Colors;

namespace ZooIS.Client.Pages.ZooMap
{
    public static class AreasColorProvider
    {
        /// <summary>
        /// Provides string list with random color values
        /// </summary>
        /// <param name="quantity">size of list</param>
        /// <returns></returns>
        public static Dictionary<int, string> GetRandomColors(int quantity)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();
            Random rnd = new Random();
            for (int i = 0; i < quantity; i++)
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
        /// <summary>
        /// Provides string list with white color values
        /// </summary>
        /// <param name="quantity">size of list</param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDefaultColors(int quantity)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();
            for (int i = 0; i < quantity; i++)
            {
                colors.Add(i + 1, "#FFFFFF");
            }
            return colors;
        }

        /// <summary>
        /// Provides string list with colors depending on species "TagsToAvoid" and habitats "HasTags" status
        /// </summary>
        /// <param name="Areas"></param>
        /// <param name="Habitats"></param>
        /// <param name="Animals"></param>
        /// <param name="Species"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetColorsForTagMismatch(List<Area> Areas, List<Habitat> Habitats,
                                                   List<Animal> Animals, List<ZooIS.Shared.Models.Species> Species)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();






            return colors;
        }
    }
}
