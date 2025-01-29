using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFilter
{
    public static class PaintData
    {
        private static bool init;
        private static Dictionary<int, HashSet<PaintFilter>> paintTags = new Dictionary<int, HashSet<PaintFilter>>();

        public static void Initialize()
        {
            if (init)
            {
                return;
            }

            CreatePaintData();

            init = true;
        }

        private static void AddPaintTags(int paintID, params PaintFilter[] tags)
        {
            paintTags[paintID] = new HashSet<PaintFilter>(tags);
        }

        public static List<int> GetPaintsMatchingAllFilters(List<PaintFilter> filters)
        {
            return paintTags
                .Where(kvp => filters.All(filter => kvp.Value.Contains(filter))) // Ensure all filters match
                .Select(kvp => kvp.Key) // Select matching block IDs
                .ToList();
        }

        private static void CreatePaintData()
        {
            //...
        }
    }
}
