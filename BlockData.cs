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
        Transition
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
            //... some shapes in here
            AddBlockTags(1461, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Slope, BlockFilter.Transition);
            //... some shapes in here
            AddBlockTags(1621, BlockFilter.Tube, BlockFilter.Straight);
            AddBlockTags(2184, BlockFilter.Tube, BlockFilter.Curve);
            AddBlockTags(2185, BlockFilter.Tube, BlockFilter.Straight, BlockFilter.Transition);
            //... some shapes in here

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
            AddBlockTags(2344, BlockFilter.Tube, BlockFilter.Irregular);
            AddBlockTags(2342, BlockFilter.Tube, BlockFilter.Irregular);

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
        }
    }
}
