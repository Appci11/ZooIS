using MudBlazor;
using ZooIS.Client.Models;
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
        /// Provides string list with colors depending on Habitat/Animal tags in certain area
        /// </summary>
        /// <param name="areaIds"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetColorsForTagMismatch(List<AreaIds> areaIds)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();
            int i = 0;
            foreach (var item in areaIds)
            {
                i++;
                IEnumerable<int> both = item.Existing.Intersect(item.ToAvoid);
                int n = 0;
                foreach (var repeating in both) n++;
                switch (n)
                {
                    case 0:
                        colors.Add(i, Green.Lighten1.ToString());
                        break;
                    case 1:
                        colors.Add(i, Yellow.Lighten1.ToString());
                        break;
                    default:
                        colors.Add(i, Red.Lighten1.ToString());
                        break;
                }
            }
            return colors;
        }
        /// <summary>
        /// Provides string list with colors depending on work task importance
        /// </summary>
        /// <param name="AreasIdName"></param>
        /// <param name="areasCount"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetColorsFromWorkTasks(List<WorkTask> WorkTasks, int areasCount)
        {
            Dictionary<int, string> colors = new Dictionary<int, string>();
            
            for(int i = 1; i < areasCount + 1; i++)
            {
                colors.Add(i, "#ffffff");
            }

            foreach (var item in WorkTasks)
            {
                if(item.AreaId == 0)    // 0 - sutartine reiksme, kad nepriskirta jokiai zonai
                    continue;
                if (item.Severity == 2)
                {
                    colors[item.AreaId] = DeepOrange.Lighten1;
                    continue;
                }
                if(item.Severity == 1)
                {
                    if (colors[item.AreaId] == DeepOrange.Lighten1)
                        continue;   // jei jau yra svarbesne spalva - skip
                    colors[item.AreaId] = Lime.Lighten1;
                    continue;
                }
                if (item.Severity == 0)
                {
                    if (colors[item.AreaId] == DeepOrange.Lighten1 || colors[item.AreaId] == Lime.Lighten1)
                        continue;   // jei egzistuoja svarbesne praleidziam
                    colors[item.AreaId] = Teal.Lighten1;
                    continue;
                }
            }
            return colors;
        }
    }
}