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

        public static List<int> GetPaintsMatchingAllFilters(List<PaintFilter> enabledFilters, List<PaintFilter> disabledFilters)
        {
            return paintTags
                .Where(kvp =>
                    enabledFilters.All(filter => kvp.Value.Contains(filter)) &&  // Match all enabled filters
                    disabledFilters.All(filter => !kvp.Value.Contains(filter))   // Avoid any disabled filters
                )
                .Select(kvp => kvp.Key) // Select matching paint IDs
                .ToList();
        }

        private static void CreatePaintData()
        {
            //P100 Tarmac
            AddPaintTags(4, PaintFilter.Grayscale);
            AddPaintTags(5, PaintFilter.Grayscale);
            AddPaintTags(3, PaintFilter.Grayscale);
            AddPaintTags(7, PaintFilter.Red);
            AddPaintTags(157, PaintFilter.Red);
            AddPaintTags(107, PaintFilter.Grayscale);
            AddPaintTags(156, PaintFilter.Blue);
            AddPaintTags(158, PaintFilter.Green);
            AddPaintTags(159, PaintFilter.Orange);
            AddPaintTags(160, PaintFilter.Grayscale);
            AddPaintTags(161, PaintFilter.Yellow);

            //P200 Concrete
            AddPaintTags(0, PaintFilter.Yellow);
            AddPaintTags(1, PaintFilter.Grayscale);
            AddPaintTags(2, PaintFilter.Grayscale);
            AddPaintTags(121, PaintFilter.Grayscale);
            AddPaintTags(140, PaintFilter.Brown);
            AddPaintTags(141, PaintFilter.Brown);
            AddPaintTags(142, PaintFilter.Orange);
            AddPaintTags(143, PaintFilter.Orange);
            AddPaintTags(144, PaintFilter.Red);
            AddPaintTags(145, PaintFilter.Red);
            AddPaintTags(146, PaintFilter.Yellow);
            AddPaintTags(147, PaintFilter.Yellow);
            AddPaintTags(384, PaintFilter.Blue);
            AddPaintTags(385, PaintFilter.Blue);
            AddPaintTags(386, PaintFilter.Blue);
            AddPaintTags(387, PaintFilter.Green);
            AddPaintTags(388, PaintFilter.Green);
            AddPaintTags(389, PaintFilter.Green);
            AddPaintTags(496, PaintFilter.Purple);
            AddPaintTags(497, PaintFilter.Purple);
            AddPaintTags(498, PaintFilter.Purple);
            AddPaintTags(499, PaintFilter.Purple);
            AddPaintTags(500, PaintFilter.Purple);
            AddPaintTags(501, PaintFilter.Purple);
            AddPaintTags(502, PaintFilter.Green);
            AddPaintTags(503, PaintFilter.Green);
            AddPaintTags(504, PaintFilter.Green);
            AddPaintTags(505, PaintFilter.Red);
            AddPaintTags(506, PaintFilter.Red);
            AddPaintTags(507, PaintFilter.Red);
            AddPaintTags(508, PaintFilter.Blue);
            AddPaintTags(509, PaintFilter.Blue);
            AddPaintTags(510, PaintFilter.Blue);

            //P300 Pavement
            AddPaintTags(8, PaintFilter.Grayscale);
            AddPaintTags(173, PaintFilter.Grayscale);
            AddPaintTags(174, PaintFilter.Yellow);
            AddPaintTags(162, PaintFilter.Blue);
            AddPaintTags(163, PaintFilter.Red);
            AddPaintTags(164, PaintFilter.Green);
            AddPaintTags(165, PaintFilter.Orange);
            AddPaintTags(166, PaintFilter.Grayscale);
            AddPaintTags(9, PaintFilter.Grayscale);
            AddPaintTags(10, PaintFilter.Grayscale);
            AddPaintTags(167, PaintFilter.Blue);
            AddPaintTags(168, PaintFilter.Red);
            AddPaintTags(169, PaintFilter.Green);
            AddPaintTags(170, PaintFilter.Orange);
            AddPaintTags(171, PaintFilter.Grayscale);
            AddPaintTags(172, PaintFilter.Yellow);

            //P400 Bricks
            AddPaintTags(341, PaintFilter.Red);
            AddPaintTags(342, PaintFilter.Red);
            AddPaintTags(344, PaintFilter.Yellow);
            AddPaintTags(343, PaintFilter.Yellow);
            AddPaintTags(368, PaintFilter.Grayscale);
            AddPaintTags(366, PaintFilter.Grayscale);
            AddPaintTags(369, PaintFilter.Orange);
            AddPaintTags(367, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(370, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(371, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(372, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(381, PaintFilter.Grayscale);
            AddPaintTags(382, PaintFilter.Grayscale);
            AddPaintTags(394, PaintFilter.Brown);
            AddPaintTags(395, PaintFilter.Brown);
            AddPaintTags(396, PaintFilter.Brown);
            AddPaintTags(397, PaintFilter.Red);
            AddPaintTags(398, PaintFilter.Red);
            AddPaintTags(399, PaintFilter.Red);
            AddPaintTags(400, PaintFilter.Red);
            AddPaintTags(401, PaintFilter.Red);
            AddPaintTags(402, PaintFilter.Grayscale);

            //P500 Cobblestone
            AddPaintTags(373, PaintFilter.Grayscale);
            AddPaintTags(374, PaintFilter.Grayscale);
            AddPaintTags(375, PaintFilter.Yellow);
            AddPaintTags(376, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(377, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(378, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(379, PaintFilter.Grayscale);
            AddPaintTags(380, PaintFilter.Grayscale);

            //P1900 Roof
            AddPaintTags(403, PaintFilter.Grayscale);
            AddPaintTags(404, PaintFilter.Grayscale);
            AddPaintTags(405, PaintFilter.Grayscale);
            AddPaintTags(406, PaintFilter.Grayscale);
            AddPaintTags(407, PaintFilter.Brown);
            AddPaintTags(408, PaintFilter.Orange);
            AddPaintTags(409, PaintFilter.Orange);
            AddPaintTags(410, PaintFilter.Orange);
            AddPaintTags(411, PaintFilter.Red);
            AddPaintTags(412, PaintFilter.Red);
            AddPaintTags(413, PaintFilter.Blue);
            AddPaintTags(414, PaintFilter.Blue);
            AddPaintTags(415, PaintFilter.Green);
            AddPaintTags(416, PaintFilter.Yellow);
            AddPaintTags(417, PaintFilter.Yellow);
            AddPaintTags(418, PaintFilter.Yellow);
            AddPaintTags(419, PaintFilter.Purple);
            AddPaintTags(420, PaintFilter.Purple);

            //P2001 - Planks
            AddPaintTags(427, PaintFilter.Orange);
            AddPaintTags(428, PaintFilter.Orange);
            AddPaintTags(429, PaintFilter.Yellow);
            AddPaintTags(430, PaintFilter.Brown);
            AddPaintTags(431, PaintFilter.Brown);
            AddPaintTags(432, PaintFilter.Brown);
            AddPaintTags(433, PaintFilter.Brown);
            AddPaintTags(434, PaintFilter.Brown);
            AddPaintTags(435, PaintFilter.Brown);
            AddPaintTags(436, PaintFilter.Brown);
            AddPaintTags(437, PaintFilter.Brown);
            AddPaintTags(438, PaintFilter.Brown);
            AddPaintTags(439, PaintFilter.Brown);
            AddPaintTags(440, PaintFilter.Red);
            AddPaintTags(441, PaintFilter.Red);
            AddPaintTags(442, PaintFilter.Red);
            AddPaintTags(443, PaintFilter.Orange);
            AddPaintTags(444, PaintFilter.Yellow);
            AddPaintTags(445, PaintFilter.Yellow);
            AddPaintTags(446, PaintFilter.Green);
            AddPaintTags(447, PaintFilter.Green);
            AddPaintTags(448, PaintFilter.Green);
            AddPaintTags(449, PaintFilter.Green);
            AddPaintTags(450, PaintFilter.Blue);
            AddPaintTags(451, PaintFilter.Blue);
            AddPaintTags(452, PaintFilter.Purple);
            AddPaintTags(453, PaintFilter.Purple);
            AddPaintTags(454, PaintFilter.Grayscale);
            AddPaintTags(455, PaintFilter.Grayscale);
            AddPaintTags(456, PaintFilter.Grayscale);
            AddPaintTags(457, PaintFilter.Grayscale);
            AddPaintTags(458, PaintFilter.Grayscale);

            //P2002 - Planks
            AddPaintTags(459, PaintFilter.Orange);
            AddPaintTags(460, PaintFilter.Orange);
            AddPaintTags(461, PaintFilter.Yellow);
            AddPaintTags(462, PaintFilter.Brown);
            AddPaintTags(463, PaintFilter.Brown);
            AddPaintTags(464, PaintFilter.Brown);
            AddPaintTags(465, PaintFilter.Brown);
            AddPaintTags(466, PaintFilter.Brown);
            AddPaintTags(467, PaintFilter.Brown);
            AddPaintTags(468, PaintFilter.Brown);
            AddPaintTags(469, PaintFilter.Brown);
            AddPaintTags(470, PaintFilter.Brown);
            AddPaintTags(471, PaintFilter.Brown);
            AddPaintTags(472, PaintFilter.Red);
            AddPaintTags(473, PaintFilter.Red);
            AddPaintTags(474, PaintFilter.Red);
            AddPaintTags(475, PaintFilter.Orange);
            AddPaintTags(476, PaintFilter.Yellow);
            AddPaintTags(477, PaintFilter.Yellow);
            AddPaintTags(478, PaintFilter.Green);
            AddPaintTags(479, PaintFilter.Green);
            AddPaintTags(480, PaintFilter.Green);
            AddPaintTags(481, PaintFilter.Green);
            AddPaintTags(482, PaintFilter.Blue);
            AddPaintTags(483, PaintFilter.Blue);
            AddPaintTags(484, PaintFilter.Purple);
            AddPaintTags(485, PaintFilter.Purple);
            AddPaintTags(486, PaintFilter.Grayscale);
            AddPaintTags(487, PaintFilter.Grayscale);
            AddPaintTags(488, PaintFilter.Grayscale);
            AddPaintTags(489, PaintFilter.Grayscale);
            AddPaintTags(490, PaintFilter.Grayscale);

            //P600 Grass
            AddPaintTags(88, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(89, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(90, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(91, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(358, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(359, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(360, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(361, PaintFilter.Yellow, PaintFilter.Physics);
            AddPaintTags(362, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(363, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(364, PaintFilter.Red, PaintFilter.Physics);
            AddPaintTags(365, PaintFilter.Orange, PaintFilter.Physics);
            AddPaintTags(511, PaintFilter.Blue, PaintFilter.Physics);
            AddPaintTags(512, PaintFilter.Blue, PaintFilter.Physics);
            AddPaintTags(513, PaintFilter.Blue, PaintFilter.Physics);
            AddPaintTags(514, PaintFilter.Red, PaintFilter.Physics);
            AddPaintTags(515, PaintFilter.Red, PaintFilter.Physics);
            AddPaintTags(516, PaintFilter.Purple, PaintFilter.Physics);
            AddPaintTags(517, PaintFilter.Purple, PaintFilter.Physics);
            AddPaintTags(518, PaintFilter.Purple, PaintFilter.Physics);
            AddPaintTags(564, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(566, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(567, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(568, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(565, PaintFilter.Grayscale, PaintFilter.Physics);

            //P700 Bark
            AddPaintTags(17, PaintFilter.Orange, PaintFilter.Physics);
            AddPaintTags(18, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(19, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(20, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(21, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(22, PaintFilter.Orange, PaintFilter.Physics);
            AddPaintTags(148, PaintFilter.Purple, PaintFilter.Physics);
            AddPaintTags(149, PaintFilter.Red, PaintFilter.Physics);
            AddPaintTags(150, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(151, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(152, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(153, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(154, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(155, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(535, PaintFilter.Blue, PaintFilter.Physics);
            AddPaintTags(536, PaintFilter.Blue, PaintFilter.Physics);
            AddPaintTags(537, PaintFilter.Blue, PaintFilter.Physics);

            //P800 Leaves
            AddPaintTags(11, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(12, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(13, PaintFilter.Red, PaintFilter.Physics);
            AddPaintTags(14, PaintFilter.Orange, PaintFilter.Physics);
            AddPaintTags(15, PaintFilter.Yellow, PaintFilter.Physics);
            AddPaintTags(16, PaintFilter.Purple, PaintFilter.Physics);
            AddPaintTags(136, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(137, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(138, PaintFilter.Green, PaintFilter.Physics);
            AddPaintTags(139, PaintFilter.Yellow, PaintFilter.Physics);

            //P900 Sand
            AddPaintTags(120, PaintFilter.Yellow, PaintFilter.Physics);
            AddPaintTags(175, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(176, PaintFilter.Brown, PaintFilter.Physics);
            AddPaintTags(177, PaintFilter.Yellow, PaintFilter.Physics);
            AddPaintTags(178, PaintFilter.Red, PaintFilter.Physics);
            AddPaintTags(179, PaintFilter.Yellow, PaintFilter.Physics);
            AddPaintTags(180, PaintFilter.Brown, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(349, PaintFilter.Red, PaintFilter.Physics, PaintFilter.Reflective);

            //P1000 Ice
            AddPaintTags(108, PaintFilter.Grayscale, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(109, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(110, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(111, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(133, PaintFilter.Grayscale, PaintFilter.Physics);
            AddPaintTags(345, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(346, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(347, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(348, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(350, PaintFilter.Grayscale, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(351, PaintFilter.Green, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(352, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(353, PaintFilter.Red, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(354, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(355, PaintFilter.Green, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(356, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(357, PaintFilter.Red, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);

            //P1100 Soap
            AddPaintTags(390, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(391, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(392, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(393, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(563, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(494, PaintFilter.Green, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(495, PaintFilter.Green, PaintFilter.Physics, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(519, PaintFilter.Grayscale, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(520, PaintFilter.Grayscale, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(521, PaintFilter.Grayscale, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(522, PaintFilter.Grayscale, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(523, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(524, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(525, PaintFilter.Purple, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(526, PaintFilter.Red, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(527, PaintFilter.Orange, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(528, PaintFilter.Yellow, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(529, PaintFilter.Green, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(530, PaintFilter.Green, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(531, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective);
            AddPaintTags(532, PaintFilter.Blue, PaintFilter.Physics, PaintFilter.Reflective);

            //P1200 Barrier
            AddPaintTags(23, PaintFilter.Red);
            AddPaintTags(24, PaintFilter.Orange);
            AddPaintTags(25, PaintFilter.Yellow);
            AddPaintTags(26, PaintFilter.Green);
            AddPaintTags(27, PaintFilter.Blue);
            AddPaintTags(28, PaintFilter.Purple);
            AddPaintTags(29, PaintFilter.Yellow);
            AddPaintTags(30, PaintFilter.Grayscale);

            //P1303 Metal Panel
            AddPaintTags(73, PaintFilter.Blue);
            AddPaintTags(74, PaintFilter.Yellow);
            AddPaintTags(256, PaintFilter.Brown);
            AddPaintTags(267, PaintFilter.Blue);
            AddPaintTags(134, PaintFilter.Blue);
            AddPaintTags(135, PaintFilter.Purple);
            AddPaintTags(72, PaintFilter.Grayscale);
            AddPaintTags(75, PaintFilter.Grayscale);
            AddPaintTags(79, PaintFilter.Grayscale);
            AddPaintTags(181, PaintFilter.Blue);
            AddPaintTags(182, PaintFilter.Green);
            AddPaintTags(183, PaintFilter.Green);
            AddPaintTags(186, PaintFilter.Orange);
            AddPaintTags(187, PaintFilter.Purple);
            AddPaintTags(188, PaintFilter.Purple);
            AddPaintTags(189, PaintFilter.Red);
            AddPaintTags(190, PaintFilter.Blue);
            AddPaintTags(191, PaintFilter.Yellow);
            AddPaintTags(184, PaintFilter.Brown);
            AddPaintTags(77, PaintFilter.Green);
            AddPaintTags(185, PaintFilter.Grayscale);
            AddPaintTags(76, PaintFilter.Blue);
            AddPaintTags(78, PaintFilter.Red);

            //P1304 Metal
            AddPaintTags(81, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(82, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(255, PaintFilter.Brown, PaintFilter.Reflective);
            AddPaintTags(266, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(193, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(194, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(80, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(83, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(87, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(192, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(195, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(196, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(93, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(199, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(200, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(92, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(201, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(94, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(197, PaintFilter.Brown, PaintFilter.Reflective);
            AddPaintTags(84, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(198, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(85, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(86, PaintFilter.Red, PaintFilter.Reflective);

            //P1301 Diamond Plate
            AddPaintTags(65, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(66, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(257, PaintFilter.Brown, PaintFilter.Reflective);
            AddPaintTags(268, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(203, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(204, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(64, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(67, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(70, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(69, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(68, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(71, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(202, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(205, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(206, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(212, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(213, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(214, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(207, PaintFilter.Brown, PaintFilter.Reflective);
            AddPaintTags(208, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(209, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(210, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(211, PaintFilter.Red, PaintFilter.Reflective);

            //P1302 Mesh
            AddPaintTags(269, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(270, PaintFilter.Yellow, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(271, PaintFilter.Brown, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(272, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(273, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(274, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(275, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(276, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(277, PaintFilter.Yellow, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(278, PaintFilter.Brown, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(279, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(280, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(281, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(282, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);

            //P1403 Solid Plastic
            AddPaintTags(42, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(43, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(44, PaintFilter.Brown, PaintFilter.Reflective);
            AddPaintTags(45, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(46, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(47, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(48, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(49, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(50, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(51, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(52, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(53, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(54, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(55, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(56, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(258, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(259, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(260, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(261, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(262, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(263, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(264, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(265, PaintFilter.Yellow, PaintFilter.Reflective);

            //P1402 Groovy Plastics
            AddPaintTags(34, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(35, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(36, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(37, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(38, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(39, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(40, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(41, PaintFilter.Blue, PaintFilter.Reflective);

            //P1404 Plastic Stripe Diagonal
            AddPaintTags(229, PaintFilter.Grayscale, PaintFilter.Red, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(230, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(231, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(232, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(233, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(234, PaintFilter.Orange, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(235, PaintFilter.Yellow, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(236, PaintFilter.Red, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(237, PaintFilter.Orange, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(238, PaintFilter.Red, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(239, PaintFilter.Red, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(240, PaintFilter.Red, PaintFilter.Orange, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(241, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Grayscale, PaintFilter.Reflective);

            //P1405 Plastic Stripe Diagonal Mirrored
            AddPaintTags(242, PaintFilter.Grayscale, PaintFilter.Red, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(243, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(244, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(245, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(246, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(247, PaintFilter.Orange, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(248, PaintFilter.Yellow, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(249, PaintFilter.Red, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(250, PaintFilter.Orange, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(251, PaintFilter.Red, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(252, PaintFilter.Red, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(253, PaintFilter.Red, PaintFilter.Orange, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(254, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Grayscale, PaintFilter.Reflective);

            //P1406 Plastic Stripe Horizontal
            AddPaintTags(60, PaintFilter.Red, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(61, PaintFilter.Red, PaintFilter.Orange, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(63, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(222, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(223, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(224, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(225, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(226, PaintFilter.Orange, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(227, PaintFilter.Yellow, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(228, PaintFilter.Red, PaintFilter.Grayscale, PaintFilter.Reflective);

            //P1407 Plastic Stripe Vertical
            AddPaintTags(57, PaintFilter.Grayscale, PaintFilter.Red, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(58, PaintFilter.Orange, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(59, PaintFilter.Red, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(215, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(216, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(217, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(218, PaintFilter.Green, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(219, PaintFilter.Orange, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(220, PaintFilter.Yellow, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(221, PaintFilter.Red, PaintFilter.Grayscale, PaintFilter.Reflective);

            //P1401 Checkerboard
            AddPaintTags(122, PaintFilter.Yellow, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(123, PaintFilter.Orange, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(124, PaintFilter.Blue, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(125, PaintFilter.Yellow, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(126, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(127, PaintFilter.Orange, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(128, PaintFilter.Purple, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(129, PaintFilter.Red, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(130, PaintFilter.Red, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(131, PaintFilter.Yellow, PaintFilter.Brown, PaintFilter.Reflective);
            AddPaintTags(132, PaintFilter.Blue, PaintFilter.Purple, PaintFilter.Reflective);

            //P1500 Glass
            AddPaintTags(31, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(32, PaintFilter.Orange, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(33, PaintFilter.Purple, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(95, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(96, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(97, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(98, PaintFilter.Brown, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(99, PaintFilter.Red, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(100, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(101, PaintFilter.Green, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(102, PaintFilter.Green, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(103, PaintFilter.Purple, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(104, PaintFilter.Red, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(105, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(106, PaintFilter.Yellow, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(533, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(538, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(539, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(559, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(560, PaintFilter.Blue, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(561, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(562, PaintFilter.Red, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(569, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(580, PaintFilter.Green, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(581, PaintFilter.Green, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(582, PaintFilter.Yellow, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(583, PaintFilter.Orange, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(584, PaintFilter.Purple, PaintFilter.Reflective, PaintFilter.Transparent);
            AddPaintTags(585, PaintFilter.Grayscale, PaintFilter.Reflective, PaintFilter.Transparent);

            //P1600 Neon
            AddPaintTags(117, PaintFilter.Red);
            AddPaintTags(116, PaintFilter.Orange);
            AddPaintTags(119, PaintFilter.Yellow);
            AddPaintTags(114, PaintFilter.Green);
            AddPaintTags(113, PaintFilter.Blue);
            AddPaintTags(112, PaintFilter.Blue);
            AddPaintTags(115, PaintFilter.Purple);
            AddPaintTags(118, PaintFilter.Grayscale);
            AddPaintTags(383, PaintFilter.Purple);
            AddPaintTags(571, PaintFilter.Red);
            AddPaintTags(572, PaintFilter.Orange);
            AddPaintTags(573, PaintFilter.Green);
            AddPaintTags(574, PaintFilter.Blue);
            AddPaintTags(575, PaintFilter.Blue);
            AddPaintTags(576, PaintFilter.Purple);
            AddPaintTags(577, PaintFilter.Purple);
            AddPaintTags(578, PaintFilter.Red);
            AddPaintTags(579, PaintFilter.Yellow);

            //P1700 Solid Color Matte
            AddPaintTags(283, PaintFilter.Red);
            AddPaintTags(284, PaintFilter.Red);
            AddPaintTags(285, PaintFilter.Red);
            AddPaintTags(286, PaintFilter.Orange);
            AddPaintTags(287, PaintFilter.Yellow);
            AddPaintTags(288, PaintFilter.Yellow);
            AddPaintTags(289, PaintFilter.Yellow);
            AddPaintTags(290, PaintFilter.Blue);
            AddPaintTags(291, PaintFilter.Blue);
            AddPaintTags(292, PaintFilter.Blue);
            AddPaintTags(293, PaintFilter.Blue);
            AddPaintTags(294, PaintFilter.Blue);
            AddPaintTags(295, PaintFilter.Blue);
            AddPaintTags(296, PaintFilter.Green);
            AddPaintTags(297, PaintFilter.Green);
            AddPaintTags(298, PaintFilter.Green);
            AddPaintTags(299, PaintFilter.Green);
            AddPaintTags(300, PaintFilter.Green);
            AddPaintTags(301, PaintFilter.Green);
            AddPaintTags(302, PaintFilter.Green);
            AddPaintTags(303, PaintFilter.Purple);
            AddPaintTags(304, PaintFilter.Purple);
            AddPaintTags(305, PaintFilter.Purple);
            AddPaintTags(306, PaintFilter.Purple);
            AddPaintTags(307, PaintFilter.Purple);
            AddPaintTags(308, PaintFilter.Purple);
            AddPaintTags(309, PaintFilter.Brown);
            AddPaintTags(310, PaintFilter.Yellow);
            AddPaintTags(311, PaintFilter.Yellow);
            AddPaintTags(312, PaintFilter.Grayscale);
            AddPaintTags(313, PaintFilter.Grayscale);
            AddPaintTags(314, PaintFilter.Grayscale);
            AddPaintTags(315, PaintFilter.Grayscale);
            AddPaintTags(316, PaintFilter.Grayscale);
            AddPaintTags(534, PaintFilter.Grayscale);
            AddPaintTags(570, PaintFilter.Blue);

            //P1800 Solid Color Shiny
            AddPaintTags(317, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(318, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(319, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(320, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(321, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(322, PaintFilter.Blue, PaintFilter.Reflective);
            AddPaintTags(323, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(324, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(325, PaintFilter.Purple, PaintFilter.Reflective);
            AddPaintTags(326, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(327, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(328, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(329, PaintFilter.Orange, PaintFilter.Reflective);
            AddPaintTags(330, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(331, PaintFilter.Yellow, PaintFilter.Reflective);
            AddPaintTags(332, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(333, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(334, PaintFilter.Green, PaintFilter.Reflective);
            AddPaintTags(335, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(336, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(337, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(338, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(339, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(340, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(421, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(422, PaintFilter.Grayscale, PaintFilter.Reflective);
            AddPaintTags(423, PaintFilter.Red, PaintFilter.Reflective);
            AddPaintTags(424, PaintFilter.Red, PaintFilter.Reflective);

            //P1900 Unlit
            AddPaintTags(558, PaintFilter.Grayscale);
            AddPaintTags(540, PaintFilter.Grayscale);
            AddPaintTags(541, PaintFilter.Grayscale);
            AddPaintTags(542, PaintFilter.Grayscale);
            AddPaintTags(543, PaintFilter.Grayscale);
            AddPaintTags(544, PaintFilter.Grayscale);
            AddPaintTags(545, PaintFilter.Grayscale);
            AddPaintTags(546, PaintFilter.Red);
            AddPaintTags(547, PaintFilter.Orange);
            AddPaintTags(548, PaintFilter.Yellow);
            AddPaintTags(549, PaintFilter.Green);
            AddPaintTags(550, PaintFilter.Green);
            AddPaintTags(551, PaintFilter.Green);
            AddPaintTags(552, PaintFilter.Blue);
            AddPaintTags(553, PaintFilter.Blue);
            AddPaintTags(554, PaintFilter.Blue);
            AddPaintTags(555, PaintFilter.Purple);
            AddPaintTags(556, PaintFilter.Purple);
            AddPaintTags(557, PaintFilter.Purple);

            //Frikandel
            AddPaintTags(425, PaintFilter.Brown);
        }
    }
}
