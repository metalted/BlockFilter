using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFilter
{
    public enum BlockFilter
    {
        Road,
        Tube,
        HalfPipe,
        Special,
        Field,
        Physics,
        Straight,
        Curve,
        Sbend,
        Slope,
        Tilted,
        Irregular,
        Transition,
        Interactive,
        Building,
        Shape,
        Decoration,
        ClearAll
    }

    //Transition BlockFilter? Like road -> tube etc.
    //Shapes filter? 
    //Loop filter?
    //Open tag (for tubes)?

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
        public static List<int> GetBlocksMatchingAllFilters(List<BlockFilter> enabledFilters, List<BlockFilter> disabledFilters)
        {
            return blockTags
                .Where(kvp =>
                    enabledFilters.All(filter => kvp.Value.Contains(filter)) &&  // Match all enabled filters
                    disabledFilters.All(filter => !kvp.Value.Contains(filter))   // Avoid any disabled filters
                )
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
            AddBlockTags(131, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Interactive);
            AddBlockTags(160, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Interactive);
            AddBlockTags(1280, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Interactive);
            AddBlockTags(1281, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Interactive);
            AddBlockTags(1282, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Interactive);

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
            AddBlockTags(1703, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1704, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1705, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1706, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1707, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1708, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
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
            AddBlockTags(30, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(31, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(32, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(33, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(34, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(35, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(36, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(37, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(38, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(39, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(161, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted);
            AddBlockTags(1697, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1698, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(1699, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted);
            AddBlockTags(2254, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(2255, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);

            //Folder 105-1
            AddBlockTags(1206, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1207, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1208, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1209, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1210, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1211, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1212, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1213, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1214, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1215, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1216, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1217, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope, BlockFilter.Transition);

            //Folder 105
            AddBlockTags(89, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(90, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(91, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1204, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1205, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1195, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1196, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1197, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1198, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1199, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1200, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1201, BlockFilter.Road, BlockFilter.Sbend, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1202, BlockFilter.Road, BlockFilter.Sbend, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1203, BlockFilter.Road, BlockFilter.Sbend, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1700, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1701, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            AddBlockTags(1702, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Slope);
            //...Half pipe blocks 1192, 1193, 1194 are double and skipped.

            //Folder 111
            AddBlockTags(313, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Transition);
            AddBlockTags(351, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Transition);
            AddBlockTags(352, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Transition);
            AddBlockTags(314, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(315, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(316, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(317, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(318, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);

            //Folder 112
            AddBlockTags(324, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(322, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(323, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(325, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(326, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(328, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(329, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(327, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(333, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(334, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(331, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(330, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(332, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            
            AddBlockTags(1223, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1224, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1222, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1221, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1218, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1219, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1220, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);

            AddBlockTags(319, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(320, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(321, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Irregular);

            //Folder 109
            AddBlockTags(291, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Transition);
            AddBlockTags(349, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Transition);
            AddBlockTags(350, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Transition);
            AddBlockTags(292, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);

            AddBlockTags(293, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(294, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(295, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(296, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Irregular);

            //Folder 110
            AddBlockTags(302, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(300, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(301, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(303, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(304, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(306, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(307, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(305, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(311, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(312, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(309, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(308, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(310, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1230, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1231, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1229, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1228, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1225, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1226, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(1227, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Irregular);

            AddBlockTags(297, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(298, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Irregular);
            AddBlockTags(299, BlockFilter.Road, BlockFilter.Curve, BlockFilter.Slope, BlockFilter.Irregular);

            //Folder 102
            AddBlockTags(75, BlockFilter.Irregular, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(76, BlockFilter.Irregular, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(77, BlockFilter.Irregular, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(78, BlockFilter.Irregular, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(79, BlockFilter.Irregular, BlockFilter.Sbend, BlockFilter.Slope);
            AddBlockTags(80, BlockFilter.Irregular, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(81, BlockFilter.Irregular, BlockFilter.Curve);
            AddBlockTags(82, BlockFilter.Irregular, BlockFilter.Straight);
            AddBlockTags(83, BlockFilter.Irregular, BlockFilter.Sbend, BlockFilter.Slope);
            AddBlockTags(84, BlockFilter.Irregular, BlockFilter.Sbend, BlockFilter.Slope);
            AddBlockTags(1556, BlockFilter.Building);

            //Folder 106
            AddBlockTags(167, BlockFilter.Road, BlockFilter.Irregular);
            AddBlockTags(168, BlockFilter.Road, BlockFilter.Irregular);
            AddBlockTags(168, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(168, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(168, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(144, BlockFilter.Shape);

            //Folder 115
            AddBlockTags(1622, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1623, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1624, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1628, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1629, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1630, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1631, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1632, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1633, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1634, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1635, BlockFilter.Road, BlockFilter.Sbend);
            AddBlockTags(1636, BlockFilter.Road, BlockFilter.Sbend);

            //Folder 116
            AddBlockTags(1680, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1682, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1683, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1684, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1681, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1685, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1686, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1687, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1688, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1689, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(2278, BlockFilter.Special);
            AddBlockTags(1500, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Irregular, BlockFilter.Special);
            AddBlockTags(223, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(224, BlockFilter.Curve, BlockFilter.Irregular);
            AddBlockTags(225, BlockFilter.Curve, BlockFilter.Irregular);

            //Toobs
            //Folder 200
            AddBlockTags(56, BlockFilter.Tube, BlockFilter.Straight);
            AddBlockTags(58, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(59, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(60, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(116, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2343, BlockFilter.Tube, BlockFilter.Sbend);

            AddBlockTags(227, BlockFilter.Tube, BlockFilter.Straight);
            AddBlockTags(228, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(229, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(230, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(231, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2341, BlockFilter.Tube, BlockFilter.Sbend);

            AddBlockTags(257, BlockFilter.Tube, BlockFilter.Straight);
            AddBlockTags(258, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(259, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(260, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(261, BlockFilter.Tube, BlockFilter.Curve);

            AddBlockTags(2345, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2346, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2347, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2348, BlockFilter.Tube, BlockFilter.Curve);

            //Folder 201
            AddBlockTags(226, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(248, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(57, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition);
            AddBlockTags(341, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(342, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(343, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(344, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(345, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(346, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(347, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(348, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Slope);
            AddBlockTags(1232, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1233, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(124, BlockFilter.Shape);
            AddBlockTags(1461, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1555, BlockFilter.Shape);
            AddBlockTags(1618, BlockFilter.Shape);
            AddBlockTags(1619, BlockFilter.Shape);
            AddBlockTags(1620, BlockFilter.Shape);
            AddBlockTags(1621, BlockFilter.Tube, BlockFilter.Straight);
            AddBlockTags(2184, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2185, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition);
            AddBlockTags(2186, BlockFilter.Shape);
            AddBlockTags(2187, BlockFilter.Shape);
            AddBlockTags(2311, BlockFilter.Shape);
            AddBlockTags(2312, BlockFilter.Shape);

            //Folder 202
            AddBlockTags(1709, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1710, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1711, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1712, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1713, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1714, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1715, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            AddBlockTags(1716, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            //... some shapes in here
            AddBlockTags(1721, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(1722, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(1723, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(1718, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(1719, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(1720, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(1724, BlockFilter.Road, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1725, BlockFilter.Road, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(1726, BlockFilter.Road, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Tilted, BlockFilter.Transition);
            AddBlockTags(2203, BlockFilter.Road, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition);
            AddBlockTags(2204, BlockFilter.Road, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Tilted, BlockFilter.Transition);

            //Folder 203
            AddBlockTags(110, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(61, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(62, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(63, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(114, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(115, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(112, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(111, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(113, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1239, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1240, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1238, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1237, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1234, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1235, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1236, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(336, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(335, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);

            //Folder 204
            AddBlockTags(117, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(118, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(119, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(120, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(121, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(122, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(123, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);

            //Folder 205
            AddBlockTags(232, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(236, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(234, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(240, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(237, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(238, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(235, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(233, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(239, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1246, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1247, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1245, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1244, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1241, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1242, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1243, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(337, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(338, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);

            AddBlockTags(249, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(250, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(251, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(252, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(253, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(254, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(255, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(256, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);

            //Folder 206
            AddBlockTags(244, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(241, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(242, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(243, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(245, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(246, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(247, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);

            //Folder 207
            AddBlockTags(262, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(266, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(264, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(270, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(267, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(268, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(265, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(263, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(269, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1253, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1254, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1252, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1251, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1248, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1249, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1250, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(339, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(340, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope);

            //Folder 208
            AddBlockTags(274, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(271, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(272, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(273, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(275, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(274, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(277, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2352, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2349, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2350, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2351, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2353, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2354, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2355, BlockFilter.Tube, BlockFilter.Curve, BlockFilter.Slope);

            //Folder 209
            AddBlockTags(1547, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1548, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1549, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1550, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1551, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1552, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1553, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(1554, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(2344, BlockFilter.Tube, BlockFilter.Irregular, BlockFilter.Sbend);
            AddBlockTags(2342, BlockFilter.Tube, BlockFilter.Irregular, BlockFilter.Sbend);

            //Folder 300
            AddBlockTags(375, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(376, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(23, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(394, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(395, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(377, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(378, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(379, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(380, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(381, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(382, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(383, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(384, BlockFilter.HalfPipe, BlockFilter.Curve);

            //Folder 302
            AddBlockTags(20, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(392, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(24, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(50, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(385, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(386, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(391, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Transition);
            AddBlockTags(45, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(46, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(16, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1127, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1128, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1129, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(387, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(388, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(389, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(390, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(1373, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(1373, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(2260, BlockFilter.HalfPipe, BlockFilter.Sbend);
            AddBlockTags(2261, BlockFilter.HalfPipe, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Transition);
            AddBlockTags(2262, BlockFilter.HalfPipe, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Transition, BlockFilter.Tilted);

            //Folder 301
            AddBlockTags(1130, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1131, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1132, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1133, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1134, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1135, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1136, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1137, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(1138, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(1139, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(1140, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(1142, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(1143, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(1144, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(1145, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(1146, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(1166, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1167, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1168, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1169, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1170, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1171, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1172, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1173, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1174, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1175, BlockFilter.HalfPipe, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(1192, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1193, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1194, BlockFilter.HalfPipe, BlockFilter.Straight, BlockFilter.Slope);

            //Folder 303
            AddBlockTags(1330, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1331, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1332, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1333, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1334, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1335, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1336, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(1337, BlockFilter.Road, BlockFilter.Straight, BlockFilter.Slope);

            AddBlockTags(2229, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(2230, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Tilted);
            AddBlockTags(2231, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(2232, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(2233, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight, BlockFilter.Slope);
            AddBlockTags(2234, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight, BlockFilter.Slope);

            //Folder 304
            AddBlockTags(2191, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Tilted, BlockFilter.Curve);
            AddBlockTags(2192, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Tilted, BlockFilter.Curve);
            AddBlockTags(2193, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Tilted, BlockFilter.Curve);

            AddBlockTags(2194, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Tilted, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2195, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Tilted, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2196, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Tilted, BlockFilter.Curve, BlockFilter.Slope);

            AddBlockTags(2197, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve);
            AddBlockTags(2198, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve);
            AddBlockTags(2199, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve);

            AddBlockTags(2200, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2201, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2202, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);

            AddBlockTags(2205, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2206, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2207, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);

            AddBlockTags(2208, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2209, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);
            AddBlockTags(2210, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve, BlockFilter.Slope);

            AddBlockTags(2226, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve);
            AddBlockTags(2227, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve);
            AddBlockTags(2228, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Curve);

            AddBlockTags(2340, BlockFilter.Road, BlockFilter.HalfPipe, BlockFilter.Transition, BlockFilter.Straight);

            //Folder 305
            AddBlockTags(2211, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(2212, BlockFilter.HalfPipe, BlockFilter.Straight);
            AddBlockTags(2213, BlockFilter.HalfPipe, BlockFilter.Straight);

            AddBlockTags(2214, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2215, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2216, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2217, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2218, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2219, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2220, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2221, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2222, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2223, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2224, BlockFilter.HalfPipe, BlockFilter.Curve);
            AddBlockTags(2225, BlockFilter.HalfPipe, BlockFilter.Curve);

            //Folder 401
            AddBlockTags(212, BlockFilter.Physics);
            AddBlockTags(209, BlockFilter.Physics);
            AddBlockTags(210, BlockFilter.Physics);
            AddBlockTags(211, BlockFilter.Physics);
            AddBlockTags(213, BlockFilter.Physics);
            AddBlockTags(214, BlockFilter.Physics);
            AddBlockTags(215, BlockFilter.Physics);
            AddBlockTags(216, BlockFilter.Physics);
            AddBlockTags(217, BlockFilter.Physics);
            AddBlockTags(218, BlockFilter.Physics);
            AddBlockTags(219, BlockFilter.Physics);
            AddBlockTags(220, BlockFilter.Physics);
            AddBlockTags(221, BlockFilter.Physics);
            AddBlockTags(222, BlockFilter.Physics);
            AddBlockTags(2300, BlockFilter.Physics);
            AddBlockTags(2301, BlockFilter.Physics);

            //Folder 402
            AddBlockTags(1452, BlockFilter.Physics);
            AddBlockTags(1453, BlockFilter.Physics);
            AddBlockTags(1454, BlockFilter.Physics);
            AddBlockTags(1455, BlockFilter.Physics);
            AddBlockTags(1456, BlockFilter.Physics);
            AddBlockTags(1457, BlockFilter.Physics);
            AddBlockTags(1458, BlockFilter.Physics);
            AddBlockTags(1459, BlockFilter.Physics);
            AddBlockTags(1460, BlockFilter.Physics);
            AddBlockTags(1462, BlockFilter.Physics);

            //Folder 403
            AddBlockTags(1492, BlockFilter.Physics);
            AddBlockTags(1493, BlockFilter.Physics);
            AddBlockTags(1494, BlockFilter.Physics);
            AddBlockTags(1495, BlockFilter.Physics);
            AddBlockTags(1496, BlockFilter.Physics);
            AddBlockTags(1497, BlockFilter.Physics);
            AddBlockTags(1539, BlockFilter.Physics);
            AddBlockTags(1499, BlockFilter.Physics);
            AddBlockTags(1500, BlockFilter.Road, BlockFilter.Irregular);

            //Folder 404
            AddBlockTags(1727, BlockFilter.Field);
            AddBlockTags(1728, BlockFilter.Field);
            AddBlockTags(1729, BlockFilter.Field);
            AddBlockTags(1730, BlockFilter.Field);
            AddBlockTags(2285, BlockFilter.Field);
            AddBlockTags(2286, BlockFilter.Field);
            AddBlockTags(1744, BlockFilter.Field);
            AddBlockTags(2291, BlockFilter.Field);
            AddBlockTags(2284, BlockFilter.Field);
            AddBlockTags(1745, BlockFilter.Road, BlockFilter.Irregular);
            AddBlockTags(1731, BlockFilter.Physics);
            AddBlockTags(1732, BlockFilter.Physics);
            AddBlockTags(1733, BlockFilter.Physics);
            AddBlockTags(1734, BlockFilter.Physics);
            AddBlockTags(1735, BlockFilter.Physics);
            AddBlockTags(1736, BlockFilter.Physics);
            AddBlockTags(1738, BlockFilter.Physics);

            //Folder 405
            AddBlockTags(1617, BlockFilter.Interactive);
            AddBlockTags(2032, BlockFilter.Interactive);
            AddBlockTags(2033, BlockFilter.Interactive);
            AddBlockTags(2034, BlockFilter.Interactive);
            AddBlockTags(2035, BlockFilter.Interactive);
            AddBlockTags(2036, BlockFilter.Interactive);
            AddBlockTags(2037, BlockFilter.Interactive);
            AddBlockTags(2039, BlockFilter.Interactive);
            AddBlockTags(2040, BlockFilter.Interactive);
            AddBlockTags(2041, BlockFilter.Interactive);

            //Folder 406
            AddBlockTags(2292, BlockFilter.Physics);
            AddBlockTags(2293, BlockFilter.Physics);
            AddBlockTags(2294, BlockFilter.Physics);
            AddBlockTags(2295, BlockFilter.Physics);
            AddBlockTags(2296, BlockFilter.Physics);
            AddBlockTags(2297, BlockFilter.Physics);
            AddBlockTags(2298, BlockFilter.Physics);
            AddBlockTags(2299, BlockFilter.Physics);

            //Folder 407
            AddBlockTags(2331, BlockFilter.Physics);
            AddBlockTags(2332, BlockFilter.Physics);
            AddBlockTags(2333, BlockFilter.Physics);
            AddBlockTags(2334, BlockFilter.Physics);
            AddBlockTags(2335, BlockFilter.Physics);
            AddBlockTags(2336, BlockFilter.Physics);
            AddBlockTags(2337, BlockFilter.Physics);
            AddBlockTags(2338, BlockFilter.Physics);

            //Folder 400
            AddBlockTags(42, BlockFilter.Interactive);
            AddBlockTags(52, BlockFilter.Physics);
            AddBlockTags(43, BlockFilter.Interactive);
            AddBlockTags(51, BlockFilter.Interactive);
            AddBlockTags(53, BlockFilter.Interactive);
            AddBlockTags(54, BlockFilter.Interactive);
            AddBlockTags(74, BlockFilter.Physics);
            AddBlockTags(281, BlockFilter.Interactive);
            AddBlockTags(1158, BlockFilter.Interactive);
            AddBlockTags(1265, BlockFilter.Interactive);
            AddBlockTags(1283, BlockFilter.Physics);
            AddBlockTags(1498, BlockFilter.Physics);
            AddBlockTags(1546, BlockFilter.Field);

            //Folder 500
            AddBlockTags(1324, BlockFilter.Building);
            AddBlockTags(1320, BlockFilter.Building);
            AddBlockTags(1321, BlockFilter.Building);
            AddBlockTags(1322, BlockFilter.Building);
            AddBlockTags(1323, BlockFilter.Building);

            //Folder 501
            AddBlockTags(145, BlockFilter.Building);
            AddBlockTags(146, BlockFilter.Building);
            AddBlockTags(147, BlockFilter.Building);
            AddBlockTags(148, BlockFilter.Building);
            AddBlockTags(149, BlockFilter.Building);
            AddBlockTags(150, BlockFilter.Building);
            AddBlockTags(151, BlockFilter.Building);
            AddBlockTags(152, BlockFilter.Building);
            AddBlockTags(153, BlockFilter.Building);
            AddBlockTags(154, BlockFilter.Building);
            AddBlockTags(155, BlockFilter.Building);
            AddBlockTags(156, BlockFilter.Building);
            AddBlockTags(368, BlockFilter.Building);
            AddBlockTags(371, BlockFilter.Building);

            //Folder 502
            AddBlockTags(157, BlockFilter.Building);
            AddBlockTags(158, BlockFilter.Building);
            AddBlockTags(159, BlockFilter.Building);
            AddBlockTags(184, BlockFilter.Building);
            AddBlockTags(369, BlockFilter.Building);
            AddBlockTags(370, BlockFilter.Building);

            //Folder 503
            AddBlockTags(132, BlockFilter.Building);
            AddBlockTags(133, BlockFilter.Building);
            AddBlockTags(134, BlockFilter.Building);
            AddBlockTags(135, BlockFilter.Building);
            AddBlockTags(136, BlockFilter.Building);
            AddBlockTags(137, BlockFilter.Building);
            AddBlockTags(138, BlockFilter.Building);
            AddBlockTags(166, BlockFilter.Building);
            AddBlockTags(139, BlockFilter.Building);
            AddBlockTags(140, BlockFilter.Building);
            AddBlockTags(141, BlockFilter.Building);
            AddBlockTags(142, BlockFilter.Building);
            AddBlockTags(143, BlockFilter.Building);
            AddBlockTags(200, BlockFilter.Building);

            //Folder 504
            AddBlockTags(172, BlockFilter.Building);
            AddBlockTags(173, BlockFilter.Building);
            AddBlockTags(174, BlockFilter.Building);
            AddBlockTags(175, BlockFilter.Building);
            AddBlockTags(176, BlockFilter.Building);
            AddBlockTags(177, BlockFilter.Building);
            AddBlockTags(178, BlockFilter.Building);
            AddBlockTags(179, BlockFilter.Building);
            AddBlockTags(180, BlockFilter.Building);
            AddBlockTags(181, BlockFilter.Building);
            AddBlockTags(183, BlockFilter.Building);
            AddBlockTags(182, BlockFilter.Building);
            AddBlockTags(1419, BlockFilter.Building);
            AddBlockTags(2244, BlockFilter.Building);
            AddBlockTags(2245, BlockFilter.Building);
            AddBlockTags(2246, BlockFilter.Building);
            AddBlockTags(2247, BlockFilter.Building);
            AddBlockTags(2248, BlockFilter.Building);
            AddBlockTags(2249, BlockFilter.Building);
            AddBlockTags(2250, BlockFilter.Building);

            //Folder 505
            AddBlockTags(1388, BlockFilter.Building);
            AddBlockTags(1465, BlockFilter.Building);
            AddBlockTags(1480, BlockFilter.Building);
            AddBlockTags(1467, BlockFilter.Building);
            AddBlockTags(1485, BlockFilter.Building);
            AddBlockTags(1477, BlockFilter.Building);
            AddBlockTags(1486, BlockFilter.Building);
            AddBlockTags(1487, BlockFilter.Building);
            AddBlockTags(1478, BlockFilter.Building);
            AddBlockTags(1479, BlockFilter.Building);
            AddBlockTags(1476, BlockFilter.Building);
            AddBlockTags(1466, BlockFilter.Building);
            AddBlockTags(1488, BlockFilter.Building);
            AddBlockTags(1489, BlockFilter.Building);
            AddBlockTags(1491, BlockFilter.Building);

            //Folder 506
            AddBlockTags(1472, BlockFilter.Building);
            AddBlockTags(1484, BlockFilter.Building);
            AddBlockTags(1474, BlockFilter.Building);
            AddBlockTags(1475, BlockFilter.Building);
            AddBlockTags(1473, BlockFilter.Building);
            AddBlockTags(1481, BlockFilter.Building);
            AddBlockTags(1468, BlockFilter.Building);
            AddBlockTags(1469, BlockFilter.Building);
            AddBlockTags(1470, BlockFilter.Building);
            AddBlockTags(1471, BlockFilter.Building);
            AddBlockTags(1482, BlockFilter.Building);
            AddBlockTags(1483, BlockFilter.Building);

            //Folder 507-1
            AddBlockTags(1935, BlockFilter.Building);
            AddBlockTags(1936, BlockFilter.Building);
            AddBlockTags(1971, BlockFilter.Building);
            AddBlockTags(1972, BlockFilter.Building);
            AddBlockTags(1973, BlockFilter.Building);
            AddBlockTags(1974, BlockFilter.Building);
            AddBlockTags(1975, BlockFilter.Building);
            AddBlockTags(1976, BlockFilter.Building);
            AddBlockTags(1977, BlockFilter.Building);
            AddBlockTags(2277, BlockFilter.Building);

            //Folder 507-2
            AddBlockTags(1933, BlockFilter.Building);
            AddBlockTags(1934, BlockFilter.Building);
            AddBlockTags(1937, BlockFilter.Building);
            AddBlockTags(1938, BlockFilter.Building);
            AddBlockTags(1939, BlockFilter.Building);
            AddBlockTags(1940, BlockFilter.Building);
            AddBlockTags(1941, BlockFilter.Building);
            AddBlockTags(1942, BlockFilter.Building);
            AddBlockTags(1943, BlockFilter.Building);
            AddBlockTags(1944, BlockFilter.Building);
            AddBlockTags(1947, BlockFilter.Building);
            AddBlockTags(1948, BlockFilter.Building);
            AddBlockTags(1949, BlockFilter.Building);
            AddBlockTags(1950, BlockFilter.Building);
            AddBlockTags(1951, BlockFilter.Building);
            AddBlockTags(1952, BlockFilter.Building);
            AddBlockTags(1959, BlockFilter.Building);

            //Folder 507-3
            AddBlockTags(1960, BlockFilter.Building);
            AddBlockTags(1962, BlockFilter.Building);
            AddBlockTags(1963, BlockFilter.Building);
            AddBlockTags(1961, BlockFilter.Building);
            AddBlockTags(1969, BlockFilter.Building);
            AddBlockTags(1970, BlockFilter.Building);
            AddBlockTags(1964, BlockFilter.Building);
            AddBlockTags(1965, BlockFilter.Building);
            AddBlockTags(1966, BlockFilter.Building);
            AddBlockTags(1967, BlockFilter.Building);
            AddBlockTags(1968, BlockFilter.Building);

            //Folder 507-4
            AddBlockTags(1931, BlockFilter.Building);
            AddBlockTags(1932, BlockFilter.Building);
            AddBlockTags(1945, BlockFilter.Building);
            AddBlockTags(1946, BlockFilter.Building);
            AddBlockTags(1953, BlockFilter.Building);
            AddBlockTags(1954, BlockFilter.Building);
            AddBlockTags(1956, BlockFilter.Building);
            AddBlockTags(1955, BlockFilter.Building);
            AddBlockTags(1957, BlockFilter.Building);
            AddBlockTags(1958, BlockFilter.Building);

            //Folder 507-5
            AddBlockTags(1894, BlockFilter.Building);
            AddBlockTags(1895, BlockFilter.Building);
            AddBlockTags(1896, BlockFilter.Building);
            AddBlockTags(1897, BlockFilter.Building);
            AddBlockTags(1898, BlockFilter.Building);
            AddBlockTags(1899, BlockFilter.Building);
            AddBlockTags(1900, BlockFilter.Building);
            AddBlockTags(1901, BlockFilter.Building);
            AddBlockTags(1902, BlockFilter.Building);

            //Folder 507-6
            AddBlockTags(1884, BlockFilter.Building);
            AddBlockTags(1885, BlockFilter.Building);
            AddBlockTags(1886, BlockFilter.Building);
            AddBlockTags(1887, BlockFilter.Building);
            AddBlockTags(1888, BlockFilter.Building);
            AddBlockTags(1889, BlockFilter.Building);
            AddBlockTags(1890, BlockFilter.Building);
            AddBlockTags(1891, BlockFilter.Building);
            AddBlockTags(1892, BlockFilter.Building);
            AddBlockTags(1893, BlockFilter.Building);

            //Folder 507-7
            AddBlockTags(1903, BlockFilter.Building);
            AddBlockTags(1904, BlockFilter.Building);
            AddBlockTags(1905, BlockFilter.Building);
            AddBlockTags(1906, BlockFilter.Building);
            AddBlockTags(1907, BlockFilter.Building);
            AddBlockTags(1908, BlockFilter.Building);
            AddBlockTags(1909, BlockFilter.Building);
            AddBlockTags(1910, BlockFilter.Building);
            AddBlockTags(1911, BlockFilter.Building);
            AddBlockTags(1912, BlockFilter.Building);
            AddBlockTags(1913, BlockFilter.Building);
            AddBlockTags(1914, BlockFilter.Building);

            //Folder 507-8
            AddBlockTags(1915, BlockFilter.Building);
            AddBlockTags(1916, BlockFilter.Building);
            AddBlockTags(1917, BlockFilter.Building);
            AddBlockTags(1918, BlockFilter.Building);
            AddBlockTags(1919, BlockFilter.Building);
            AddBlockTags(1920, BlockFilter.Building);
            AddBlockTags(1921, BlockFilter.Building);
            AddBlockTags(1922, BlockFilter.Building);
            AddBlockTags(1923, BlockFilter.Building);
            AddBlockTags(1924, BlockFilter.Building);
            AddBlockTags(1925, BlockFilter.Building);
            AddBlockTags(1926, BlockFilter.Building);
            AddBlockTags(1927, BlockFilter.Building);
            AddBlockTags(1928, BlockFilter.Building);
            AddBlockTags(1929, BlockFilter.Building);
            AddBlockTags(1930, BlockFilter.Building);

            //Folder 600
            AddBlockTags(201, BlockFilter.Decoration);
            AddBlockTags(202, BlockFilter.Decoration);
            AddBlockTags(203, BlockFilter.Decoration);
            AddBlockTags(204, BlockFilter.Decoration);
            AddBlockTags(205, BlockFilter.Decoration);
            AddBlockTags(130, BlockFilter.Decoration);
            AddBlockTags(206, BlockFilter.Decoration);
            AddBlockTags(207, BlockFilter.Decoration);
            AddBlockTags(208, BlockFilter.Decoration);
            AddBlockTags(1364, BlockFilter.Decoration);
            AddBlockTags(1365, BlockFilter.Decoration);
            AddBlockTags(1366, BlockFilter.Decoration);
            AddBlockTags(1367, BlockFilter.Decoration);
            AddBlockTags(1368, BlockFilter.Decoration);
            AddBlockTags(1369, BlockFilter.Decoration);
            AddBlockTags(2283, BlockFilter.Decoration);
            AddBlockTags(2183, BlockFilter.Decoration);
            AddBlockTags(2258, BlockFilter.Decoration);
            AddBlockTags(2319, BlockFilter.Decoration);

            //Folder 700
            AddBlockTags(128, BlockFilter.Building, BlockFilter.Interactive, BlockFilter.Decoration);
            AddBlockTags(356, BlockFilter.Decoration);
            AddBlockTags(393, BlockFilter.Interactive, BlockFilter.Decoration);
            AddBlockTags(1159, BlockFilter.Decoration);
            AddBlockTags(1358, BlockFilter.Decoration);
            AddBlockTags(1362, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Irregular);
            AddBlockTags(1543, BlockFilter.Decoration);
            AddBlockTags(2339, BlockFilter.Decoration);
            AddBlockTags(355, BlockFilter.Special);

            //Folder 701
            AddBlockTags(1268, BlockFilter.Decoration);
            AddBlockTags(1272, BlockFilter.Decoration);
            AddBlockTags(1269, BlockFilter.Interactive, BlockFilter.Decoration);
            AddBlockTags(1270, BlockFilter.Interactive, BlockFilter.Decoration);
            AddBlockTags(1271, BlockFilter.Interactive, BlockFilter.Decoration);
            AddBlockTags(1267, BlockFilter.Decoration);

            //Folder 702
            AddBlockTags(1338, BlockFilter.Decoration);
            AddBlockTags(1339, BlockFilter.Decoration);
            AddBlockTags(1340, BlockFilter.Decoration);
            AddBlockTags(1341, BlockFilter.Decoration);
            AddBlockTags(1342, BlockFilter.Decoration);
            AddBlockTags(1343, BlockFilter.Decoration);
            AddBlockTags(1344, BlockFilter.Decoration);
            AddBlockTags(1345, BlockFilter.Decoration);
            AddBlockTags(1370, BlockFilter.Decoration);
            AddBlockTags(1371, BlockFilter.Decoration);

            //Folder 703
            AddBlockTags(1359, BlockFilter.Special, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1360, BlockFilter.Special, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1361, BlockFilter.Decoration);

            //Folder 704
            AddBlockTags(1446, BlockFilter.Shape);
            AddBlockTags(1447, BlockFilter.Shape);
            AddBlockTags(1448, BlockFilter.Shape);
            AddBlockTags(1449, BlockFilter.Shape);
            AddBlockTags(1450, BlockFilter.Shape);
            AddBlockTags(1451, BlockFilter.Shape);

            //Folder 705
            AddBlockTags(85, BlockFilter.Decoration);
            AddBlockTags(282, BlockFilter.Decoration);
            AddBlockTags(287, BlockFilter.Decoration);
            AddBlockTags(288, BlockFilter.Decoration);
            AddBlockTags(289, BlockFilter.Decoration);
            AddBlockTags(283, BlockFilter.Decoration);
            AddBlockTags(284, BlockFilter.Decoration);
            AddBlockTags(285, BlockFilter.Decoration);
            AddBlockTags(286, BlockFilter.Decoration);
            AddBlockTags(353, BlockFilter.Decoration);
            AddBlockTags(354, BlockFilter.Decoration);
            AddBlockTags(374, BlockFilter.Decoration);
            AddBlockTags(1266, BlockFilter.Decoration);
            AddBlockTags(1325, BlockFilter.Decoration);

            //Folder 706
            AddBlockTags(1590, BlockFilter.Shape, BlockFilter.Decoration);
            AddBlockTags(1591, BlockFilter.Decoration);
            AddBlockTags(1592, BlockFilter.Decoration);
            AddBlockTags(1593, BlockFilter.Decoration);
            AddBlockTags(1594, BlockFilter.Decoration);
            AddBlockTags(1595, BlockFilter.Decoration);
            AddBlockTags(1596, BlockFilter.Decoration);
            AddBlockTags(1598, BlockFilter.Shape, BlockFilter.Decoration);
            AddBlockTags(1597, BlockFilter.Decoration);

            //Folder 707
            AddBlockTags(2322, BlockFilter.Decoration);
            AddBlockTags(2323, BlockFilter.Decoration);
            AddBlockTags(2324, BlockFilter.Decoration);
            AddBlockTags(2325, BlockFilter.Decoration);
            AddBlockTags(2326, BlockFilter.Decoration);
            AddBlockTags(2327, BlockFilter.Decoration);
            AddBlockTags(2328, BlockFilter.Decoration);
            AddBlockTags(2329, BlockFilter.Decoration);
            AddBlockTags(2330, BlockFilter.Decoration);

            //Folder 1201
            AddBlockTags(1413, BlockFilter.Decoration);
            AddBlockTags(1414, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1415, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1416, BlockFilter.Decoration);
            AddBlockTags(1417, BlockFilter.Decoration);
            AddBlockTags(1418, BlockFilter.Decoration);
            AddBlockTags(1428, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1429, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1430, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1431, BlockFilter.Decoration, BlockFilter.Interactive);

            //Folder 1202
            AddBlockTags(1375, BlockFilter.Decoration);
            AddBlockTags(1376, BlockFilter.Decoration);
            AddBlockTags(1377, BlockFilter.Decoration);
            AddBlockTags(1378, BlockFilter.Decoration);
            AddBlockTags(1379, BlockFilter.Decoration);
            AddBlockTags(1380, BlockFilter.Decoration);
            AddBlockTags(1381, BlockFilter.Decoration);
            AddBlockTags(1382, BlockFilter.Decoration);
            AddBlockTags(1383, BlockFilter.Decoration);
            AddBlockTags(1384, BlockFilter.Decoration);
            AddBlockTags(1385, BlockFilter.Decoration);
            AddBlockTags(1386, BlockFilter.Decoration);
            AddBlockTags(1387, BlockFilter.Decoration);
            AddBlockTags(1490, BlockFilter.Decoration);

            //Folder 1203
            AddBlockTags(1389, BlockFilter.Decoration);
            AddBlockTags(1390, BlockFilter.Decoration);
            AddBlockTags(1391, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1392, BlockFilter.Decoration, BlockFilter.Interactive);

            //Folder 1204
            AddBlockTags(1437, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1438, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1439, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1440, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1441, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1442, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1443, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1444, BlockFilter.Decoration, BlockFilter.Interactive);

            //Folder 1200
            AddBlockTags(1410, BlockFilter.Decoration);
            AddBlockTags(1411, BlockFilter.Decoration);
            AddBlockTags(1412, BlockFilter.Special);
            AddBlockTags(1432, BlockFilter.Decoration);
            AddBlockTags(1433, BlockFilter.Decoration);
            AddBlockTags(1434, BlockFilter.Decoration);
            AddBlockTags(1435, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1436, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1445, BlockFilter.Decoration, BlockFilter.Interactive);
            AddBlockTags(1463, BlockFilter.Decoration);

            //Folder 1100
            AddBlockTags(1329, BlockFilter.Shape);
            AddBlockTags(1326, BlockFilter.Shape);
            AddBlockTags(1327, BlockFilter.Shape);
            AddBlockTags(1328, BlockFilter.Shape);
            AddBlockTags(1531, BlockFilter.Shape);
            AddBlockTags(2176, BlockFilter.Shape);
            AddBlockTags(2177, BlockFilter.Shape);

            //Folder 1101
            AddBlockTags(1291, BlockFilter.Shape);
            AddBlockTags(1292, BlockFilter.Shape);
            AddBlockTags(1293, BlockFilter.Shape);
            AddBlockTags(1294, BlockFilter.Shape);
            AddBlockTags(1295, BlockFilter.Shape);
            AddBlockTags(1296, BlockFilter.Shape);
            AddBlockTags(1297, BlockFilter.Shape);
            AddBlockTags(1298, BlockFilter.Shape);
            AddBlockTags(1299, BlockFilter.Shape);
            AddBlockTags(1300, BlockFilter.Shape);
            AddBlockTags(1301, BlockFilter.Shape);
            AddBlockTags(1302, BlockFilter.Shape);
            AddBlockTags(1571, BlockFilter.Shape);
            AddBlockTags(2178, BlockFilter.Shape);
            AddBlockTags(2179, BlockFilter.Shape);
            AddBlockTags(2180, BlockFilter.Shape);
            AddBlockTags(2181, BlockFilter.Shape);

            //Folder 1102
            AddBlockTags(1316, BlockFilter.Shape);
            AddBlockTags(1317, BlockFilter.Shape);
            AddBlockTags(1318, BlockFilter.Shape);
            AddBlockTags(1572, BlockFilter.Shape);
            AddBlockTags(1573, BlockFilter.Shape);
            AddBlockTags(1574, BlockFilter.Shape);
            AddBlockTags(1575, BlockFilter.Shape);
            AddBlockTags(1584, BlockFilter.Shape);
            AddBlockTags(1585, BlockFilter.Shape);
            AddBlockTags(1586, BlockFilter.Shape);
            AddBlockTags(1587, BlockFilter.Shape);
            AddBlockTags(1588, BlockFilter.Shape);
            AddBlockTags(1589, BlockFilter.Shape);

            //Folder 1103
            AddBlockTags(1303, BlockFilter.Shape);
            AddBlockTags(1304, BlockFilter.Shape);
            AddBlockTags(1305, BlockFilter.Shape);
            AddBlockTags(1306, BlockFilter.Shape);
            AddBlockTags(1576, BlockFilter.Shape);
            AddBlockTags(1577, BlockFilter.Shape);
            AddBlockTags(1578, BlockFilter.Shape);
            AddBlockTags(1579, BlockFilter.Shape);
            AddBlockTags(1580, BlockFilter.Shape);
            AddBlockTags(1581, BlockFilter.Shape);
            AddBlockTags(1582, BlockFilter.Shape);
            AddBlockTags(1583, BlockFilter.Shape);
            AddBlockTags(2188, BlockFilter.Shape);
            AddBlockTags(2189, BlockFilter.Shape);
            AddBlockTags(2356, BlockFilter.Shape);

            //Folder 1104
            AddBlockTags(1307, BlockFilter.Shape);
            AddBlockTags(1311, BlockFilter.Decoration);
            AddBlockTags(1312, BlockFilter.Decoration);
            AddBlockTags(1313, BlockFilter.Decoration);
            AddBlockTags(1314, BlockFilter.Decoration);
            AddBlockTags(1315, BlockFilter.Shape);
            AddBlockTags(1372, BlockFilter.Shape);
            AddBlockTags(1606, BlockFilter.Shape);
            AddBlockTags(1667, BlockFilter.Shape);
            AddBlockTags(1737, BlockFilter.Shape);
            AddBlockTags(2005, BlockFilter.Decoration);
            AddBlockTags(2011, BlockFilter.Decoration);
            AddBlockTags(2012, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2020, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2038, BlockFilter.Decoration);
            AddBlockTags(2043, BlockFilter.Decoration);
            AddBlockTags(2190, BlockFilter.Shape);
            AddBlockTags(2275, BlockFilter.Decoration);

            //Folder 1105
            AddBlockTags(1308, BlockFilter.Shape);
            AddBlockTags(1309, BlockFilter.Shape);
            AddBlockTags(1310, BlockFilter.Shape);
            AddBlockTags(2014, BlockFilter.Decoration);
            AddBlockTags(2015, BlockFilter.Decoration);
            AddBlockTags(1514, BlockFilter.Decoration);
            AddBlockTags(1515, BlockFilter.Decoration);
            AddBlockTags(1541, BlockFilter.Decoration);
            AddBlockTags(2253, BlockFilter.Decoration);

            //Folder 1106
            AddBlockTags(1198, BlockFilter.Decoration);
            AddBlockTags(2004, BlockFilter.Decoration);
            AddBlockTags(1319, BlockFilter.Decoration);
            AddBlockTags(2003, BlockFilter.Decoration);
            AddBlockTags(2002, BlockFilter.Decoration);
            AddBlockTags(1999, BlockFilter.Decoration);
            AddBlockTags(2000, BlockFilter.Decoration);
            AddBlockTags(2001, BlockFilter.Decoration);
            AddBlockTags(1996, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1997, BlockFilter.Decoration);
            AddBlockTags(2009, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1994, BlockFilter.Decoration);
            AddBlockTags(1995, BlockFilter.Decoration);
            AddBlockTags(2021, BlockFilter.Decoration);
            AddBlockTags(2182, BlockFilter.Decoration);
            AddBlockTags(2276, BlockFilter.Decoration);

            //Folder 1107
            AddBlockTags(2006, BlockFilter.Decoration);
            AddBlockTags(2007, BlockFilter.Decoration);
            AddBlockTags(2008, BlockFilter.Decoration);
            AddBlockTags(2016, BlockFilter.Decoration);
            AddBlockTags(2017, BlockFilter.Decoration);
            AddBlockTags(2018, BlockFilter.Decoration);
            AddBlockTags(2019, BlockFilter.Decoration);
            AddBlockTags(2042, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2044, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2290, BlockFilter.Decoration);

            //Folder 1108
            AddBlockTags(2304, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2305, BlockFilter.Decoration);
            AddBlockTags(2306, BlockFilter.Decoration);
            AddBlockTags(2307, BlockFilter.Decoration);
            AddBlockTags(2308, BlockFilter.Decoration);
            AddBlockTags(2309, BlockFilter.Decoration);
            AddBlockTags(2310, BlockFilter.Decoration);

            //Folder 1109
            AddBlockTags(2010, BlockFilter.Decoration);
            AddBlockTags(2013, BlockFilter.Decoration);
            AddBlockTags(2257, BlockFilter.Decoration);
            AddBlockTags(2274, BlockFilter.Decoration);
            AddBlockTags(2313, BlockFilter.Decoration);
            AddBlockTags(2314, BlockFilter.Decoration);
            AddBlockTags(2315, BlockFilter.Decoration);
            AddBlockTags(2316, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2317, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(2318, BlockFilter.Decoration);
            AddBlockTags(2320, BlockFilter.Decoration);
            AddBlockTags(2321, BlockFilter.Decoration);
            AddBlockTags(2302, BlockFilter.Decoration);
            AddBlockTags(2303, BlockFilter.Decoration);

            //Folder 1110
            AddBlockTags(2357, BlockFilter.Shape);
            AddBlockTags(2358, BlockFilter.Shape);
            AddBlockTags(2359, BlockFilter.Shape);
            AddBlockTags(2360, BlockFilter.Shape);
            AddBlockTags(2361, BlockFilter.Shape);
            AddBlockTags(2362, BlockFilter.Shape);
            AddBlockTags(2363, BlockFilter.Shape);
            AddBlockTags(2364, BlockFilter.Shape);
            AddBlockTags(2365, BlockFilter.Shape);
            AddBlockTags(2366, BlockFilter.Shape);
            AddBlockTags(2367, BlockFilter.Shape);
            AddBlockTags(2368, BlockFilter.Shape);

            //Folder 1300
            AddBlockTags(1501, BlockFilter.Decoration);
            AddBlockTags(1502, BlockFilter.Decoration);
            AddBlockTags(1503, BlockFilter.Decoration);
            AddBlockTags(1504, BlockFilter.Decoration);
            AddBlockTags(1505, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1513, BlockFilter.Decoration, BlockFilter.Shape);
            AddBlockTags(1516, BlockFilter.Decoration);
            AddBlockTags(1517, BlockFilter.Decoration);
            AddBlockTags(1540, BlockFilter.Decoration);

            //Folder 1301
            AddBlockTags(1532, BlockFilter.Decoration);
            AddBlockTags(1533, BlockFilter.Decoration);
            AddBlockTags(1534, BlockFilter.Decoration);
            AddBlockTags(1535, BlockFilter.Decoration);
            AddBlockTags(1536, BlockFilter.Decoration);
            AddBlockTags(1537, BlockFilter.Decoration);
            AddBlockTags(1538, BlockFilter.Decoration);

            //Folder 1302
            AddBlockTags(1505, BlockFilter.Decoration);
            AddBlockTags(1506, BlockFilter.Decoration);
            AddBlockTags(1507, BlockFilter.Decoration);
            AddBlockTags(1508, BlockFilter.Decoration);
            AddBlockTags(1509, BlockFilter.Decoration);
            AddBlockTags(1510, BlockFilter.Decoration);
            AddBlockTags(1511, BlockFilter.Decoration);
        }
    }
}
