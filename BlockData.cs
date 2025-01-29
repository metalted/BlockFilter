using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFilter
{
    public static class BlockData
    {
        // Dictionary mapping object IDs to their tags
        private static Dictionary<int, HashSet<BlockFilter>> blockTags = new Dictionary<int, HashSet<BlockFilter>>();
        private static bool init = false;

        public static void Initialize()
        {
            if (init)
            {
                return;
            }

            CreateBlockData();

            init = true;
        }

        // Add block and its tags
        private static void AddBlockTags(int blockID, params BlockFilter[] tags)
        {
            blockTags[blockID] = new HashSet<BlockFilter>(tags);
        }

        // Get all block IDs matching all the filters
        public static List<int> GetBlocksMatchingAllFilters(List<BlockFilter> filters)
        {
            return blockTags
                .Where(kvp => filters.All(filter => kvp.Value.Contains(filter))) // Ensure all filters match
                .Select(kvp => kvp.Key) // Select matching block IDs
                .ToList();
        }

        private static void CreateBlockData()
        {
            //Folder 101
            AddBlockTags(0, BlockFilter.Road, BlockFilter.Straight);
            AddBlockTags(3, BlockFilter.Road, BlockFilter.Curve);
            AddBlockTags(4, BlockFilter.Road, BlockFilter.Curve);
            AddBlockTags(14, BlockFilter.Road, BlockFilter.Curve);
            AddBlockTags(15, BlockFilter.Road, BlockFilter.Curve);
            AddBlockTags(1189, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1190, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1191, BlockFilter.Road, BlockFilter.Sbend);

            //Folder 107
            AddBlockTags(1, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special);
            AddBlockTags(1363, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(2, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1273, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1274, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(22, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(372, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(373, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1275, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1276, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1277, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1278, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1279, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1615, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(1616, BlockFilter.Special, BlockFilter.Field);
            AddBlockTags(2256, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special);
            AddBlockTags(2259, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Special);

            //Folder 108-1
            AddBlockTags(1746, BlockFilter.Field);
            AddBlockTags(1609, BlockFilter.Field);
            AddBlockTags(1610, BlockFilter.Field);
            AddBlockTags(1613, BlockFilter.Field);
            AddBlockTags(1614, BlockFilter.Field);
            AddBlockTags(1979, BlockFilter.Field);
            AddBlockTags(1981, BlockFilter.Field);
            AddBlockTags(1983, BlockFilter.Field);
            AddBlockTags(1985, BlockFilter.Field);
            AddBlockTags(2279, BlockFilter.Field);
            AddBlockTags(2284, BlockFilter.Field);

            //Folder 108-2
            AddBlockTags(1607, BlockFilter.Field);
            AddBlockTags(1608, BlockFilter.Field);
            AddBlockTags(1611, BlockFilter.Field);
            AddBlockTags(1612, BlockFilter.Field);
            AddBlockTags(1612, BlockFilter.Field);
            AddBlockTags(1978, BlockFilter.Field);
            AddBlockTags(1980, BlockFilter.Field);
            AddBlockTags(1982, BlockFilter.Field);
            AddBlockTags(1984, BlockFilter.Field);

            //Folder 108-3
            AddBlockTags(1986, BlockFilter.Field);
            AddBlockTags(1987, BlockFilter.Field);
            AddBlockTags(1988, BlockFilter.Field);
            AddBlockTags(1989, BlockFilter.Field);
            AddBlockTags(1990, BlockFilter.Field);
            AddBlockTags(1991, BlockFilter.Field);
            AddBlockTags(1992, BlockFilter.Field);
            AddBlockTags(1993, BlockFilter.Field);

            //Folder 108-4
            AddBlockTags(1599, BlockFilter.Field);
            AddBlockTags(1600, BlockFilter.Field);
            AddBlockTags(1601, BlockFilter.Field);
            AddBlockTags(1602, BlockFilter.Field);
            AddBlockTags(1603, BlockFilter.Field);
            AddBlockTags(1604, BlockFilter.Field);
            AddBlockTags(1605, BlockFilter.Field);

            //Folder 108
            AddBlockTags(69, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Field);
            AddBlockTags(1545, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Field);
            AddBlockTags(290, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Field);
            AddBlockTags(72, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Field);
            AddBlockTags(73, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Field);
            AddBlockTags(2280, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Field);
            AddBlockTags(131, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Physics);
            AddBlockTags(160, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Physics);
            AddBlockTags(1280, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Physics);
            AddBlockTags(1281, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Physics);
            AddBlockTags(1282, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Physics);

            //Folder 104-1
            AddBlockTags(86, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(87, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(88, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1155, BlockFilter.Road, BlockFilter.Sbend, BlockFilter.Slope);
            AddBlockTags(1156, BlockFilter.Road, BlockFilter.Sbend, BlockFilter.Slope);
            AddBlockTags(1157, BlockFilter.Road, BlockFilter.Sbend, BlockFilter.Slope);
            AddBlockTags(2235, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2236, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2237, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2238, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2239, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2240, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope);

            //Folder 104
            AddBlockTags(7, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(5, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(6, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1255, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(8, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(9, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(12, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(13, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(10, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(28, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(29, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(26, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(25, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(27, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1126, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1125, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1124, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1123, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1120, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1121, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1122, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);

            //Folder 103-1
            AddBlockTags(1147, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(1148, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(1149, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(1150, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(1151, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(1152, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(1703, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1704, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1705, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1706, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1707, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1708, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(2240, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(2241, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(2242, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(2243, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);

            //Folder 103-2
            AddBlockTags(162, BlockFilter.Road, BlockFilter.Tilted, BlockFilter.Straight);
            AddBlockTags(163, BlockFilter.Road, BlockFilter.Tilted, BlockFilter.Straight);
            AddBlockTags(1154, BlockFilter.Road, BlockFilter.Tilted, BlockFilter.Straight);
            AddBlockTags(164, BlockFilter.Road, BlockFilter.Tilted, BlockFilter.Straight);
            AddBlockTags(165, BlockFilter.Road, BlockFilter.Tilted, BlockFilter.Straight);
            AddBlockTags(1153, BlockFilter.Road, BlockFilter.Tilted, BlockFilter.Straight);

            //Folder 103
            AddBlockTags(30, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(31, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(32, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(33, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(34, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(35, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(36, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(37, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(38, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(39, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(161, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(1697, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1698, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1699, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(2254, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(2255, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);

            //Folder 105-1
            AddBlockTags(1206, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1207, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(1208, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(1209, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1210, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1211, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(1212, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1213, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1214, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1215, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(1216, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1217, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
        }
    }
}
