using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlockFilter
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.blockfilter";
        public const string pluginName = "BlockFilter";
        public const string pluginVersion = "1.0";

        public static Plugin Instance;
        public LEV_LevelEditorCentral central;
        public LEV_CustomButton buttonPrefab;

        public void Awake()
        {
            Instance = this;

            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();
        }

        public void OnLevelEditor(LEV_LevelEditorCentral __instance)
        {
            central = __instance;

            CreateButtonPrefab();

            GenerateFilterButtons();
        }

        private void CreateButtonPrefab()
        {
            if (buttonPrefab != null)
            {
                return;
            }

            //Create a copy of the button
            GameObject copy = GameObject.Instantiate(central.tool.button_settings.gameObject, central.tool.button_settings.transform.parent);
            buttonPrefab = copy.GetComponent<LEV_CustomButton>();
            buttonPrefab.onClick.RemoveAllListeners();

            for (int i = buttonPrefab.onClick.GetPersistentEventCount() - 1; i >= 0; i--)
            {
                buttonPrefab.onClick.SetPersistentListenerState(i, UnityEngine.Events.UnityEventCallState.Off);
            }

            //Disable the hotkey script.
            LEV_HotkeyButton hotkeybutton = buttonPrefab.GetComponent<LEV_HotkeyButton>();
            if (hotkeybutton != null)
            {
                hotkeybutton.enabled = false;
            }

            buttonPrefab.gameObject.SetActive(false);
        }

        private void GenerateFilterButtons()
        {
            
        }
    }
    public enum Filter
    {
        Road,
        Tube,
        HalfPipe,
        Straight,
        Curve,
        Sbend,
        Special,
        Slope,
        Tilted,
        Field,
        Physics
    }

    public static class BlockData
    {
        // Dictionary mapping object IDs to their tags
        private static Dictionary<int, HashSet<Filter>> blockTags = new Dictionary<int, HashSet<Filter>>();
        private static bool init = false;

        public static void Initialize()
        {
            if(init)
            {
                return;
            }

            CreateBlockData();

            init = true;
        }

        private static void CreateBlockData()
        {
            //Folder 101
            AddBlockTags(0, Filter.Road, Filter.Straight);
            AddBlockTags(3, Filter.Road, Filter.Curve);
            AddBlockTags(4, Filter.Road, Filter.Curve);
            AddBlockTags(14, Filter.Road, Filter.Curve);
            AddBlockTags(15, Filter.Road, Filter.Curve);
            AddBlockTags(1189, Filter.Road, Filter.Sbend);
            AddBlockTags(1190, Filter.Road, Filter.Sbend);
            AddBlockTags(1191, Filter.Road, Filter.Sbend);

            //Folder 107
            AddBlockTags(1, Filter.Road, Filter.Straight, Filter.Special);
            AddBlockTags(1363, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(2, Filter.Road, Filter.Straight, Filter.Special, Filter.Field);
            AddBlockTags(1273, Filter.Road, Filter.Straight, Filter.Special, Filter.Field);
            AddBlockTags(1274, Filter.Road, Filter.Straight, Filter.Special, Filter.Field);
            AddBlockTags(22, Filter.Road, Filter.Straight, Filter.Special, Filter.Field);
            AddBlockTags(372, Filter.Road, Filter.Straight, Filter.Special, Filter.Field);
            AddBlockTags(373, Filter.Road, Filter.Straight, Filter.Special, Filter.Field);
            AddBlockTags(1275, Filter.Special, Filter.Field);
            AddBlockTags(1276, Filter.Special, Filter.Field);
            AddBlockTags(1277, Filter.Special, Filter.Field);
            AddBlockTags(1278, Filter.Special, Filter.Field);
            AddBlockTags(1279, Filter.Special, Filter.Field);
            AddBlockTags(1615, Filter.Special, Filter.Field);
            AddBlockTags(1616, Filter.Special, Filter.Field);
            AddBlockTags(2256, Filter.Road, Filter.Straight, Filter.Special);
            AddBlockTags(2259, Filter.Road, Filter.Straight, Filter.Special);

            //Folder 108-1
            AddBlockTags(1746, Filter.Field);
            AddBlockTags(1609, Filter.Field);
            AddBlockTags(1610, Filter.Field);
            AddBlockTags(1613, Filter.Field);
            AddBlockTags(1614, Filter.Field);
            AddBlockTags(1979, Filter.Field);
            AddBlockTags(1981, Filter.Field);
            AddBlockTags(1983, Filter.Field);
            AddBlockTags(1985, Filter.Field);
            AddBlockTags(2279, Filter.Field);
            AddBlockTags(2284, Filter.Field);

            //Folder 108-2
            AddBlockTags(1607, Filter.Field);
            AddBlockTags(1608, Filter.Field);
            AddBlockTags(1611, Filter.Field);
            AddBlockTags(1612, Filter.Field);
            AddBlockTags(1612, Filter.Field);
            AddBlockTags(1978, Filter.Field);
            AddBlockTags(1980, Filter.Field);
            AddBlockTags(1982, Filter.Field);
            AddBlockTags(1984, Filter.Field);

            //Folder 108-3
            AddBlockTags(1986, Filter.Field);
            AddBlockTags(1987, Filter.Field);
            AddBlockTags(1988, Filter.Field);
            AddBlockTags(1989, Filter.Field);
            AddBlockTags(1990, Filter.Field);
            AddBlockTags(1991, Filter.Field);
            AddBlockTags(1992, Filter.Field);
            AddBlockTags(1993, Filter.Field);

            //Folder 108-4
            AddBlockTags(1599, Filter.Field);
            AddBlockTags(1600, Filter.Field);
            AddBlockTags(1601, Filter.Field);
            AddBlockTags(1602, Filter.Field);
            AddBlockTags(1603, Filter.Field);
            AddBlockTags(1604, Filter.Field);
            AddBlockTags(1605, Filter.Field);

            //Folder 108
            AddBlockTags(69, Filter.Road, Filter.Straight, Filter.Field);
            AddBlockTags(1545, Filter.Road, Filter.Straight, Filter.Field);
            AddBlockTags(290, Filter.Road, Filter.Straight, Filter.Field);
            AddBlockTags(72, Filter.Road, Filter.Straight, Filter.Field);
            AddBlockTags(73, Filter.Road, Filter.Straight, Filter.Field);
            AddBlockTags(2280, Filter.Road, Filter.Straight, Filter.Field);
            AddBlockTags(131, Filter.Road, Filter.Straight, Filter.Physics);
            AddBlockTags(160, Filter.Road, Filter.Straight, Filter.Physics);
            AddBlockTags(1280, Filter.Road, Filter.Straight, Filter.Physics);
            AddBlockTags(1281, Filter.Road, Filter.Straight, Filter.Physics);
            AddBlockTags(1282, Filter.Road, Filter.Straight, Filter.Physics);

            //Folder 104-1
            AddBlockTags(86, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(87, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(88, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(1155, Filter.Road, Filter.Sbend, Filter.Slope);
            AddBlockTags(1156, Filter.Road, Filter.Sbend, Filter.Slope);
            AddBlockTags(1157, Filter.Road, Filter.Sbend, Filter.Slope);
            AddBlockTags(2235, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(2236, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(2237, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(2238, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(2239, Filter.Road, Filter.Curve, Filter.Slope);
            AddBlockTags(2240, Filter.Road, Filter.Curve, Filter.Slope);

            //Folder 104
            AddBlockTags(7, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(5, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(6, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1255, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(8, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(9, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(12, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(13, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(10, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(28, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(29, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(26, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(25, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(27, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1126, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1125, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1124, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1123, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1120, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1121, Filter.Road, Filter.Straight, Filter.Slope);
            AddBlockTags(1122, Filter.Road, Filter.Straight, Filter.Slope);

            //Folder 103-1
            AddBlockTags(1147, Filter.Road, Filter.Curve, Filter.Slope, Filter.Tilted);
            AddBlockTags(1148, Filter.Road, Filter.Curve, Filter.Slope, Filter.Tilted);
            AddBlockTags(1149, Filter.Road, Filter.Curve, Filter.Slope, Filter.Tilted);
            AddBlockTags(1150, Filter.Road, Filter.Curve, Filter.Slope, Filter.Tilted);
            AddBlockTags(1151, Filter.Road, Filter.Curve, Filter.Slope, Filter.Tilted);
            AddBlockTags(1152, Filter.Road, Filter.Curve, Filter.Slope, Filter.Tilted);
            AddBlockTags(1703, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1704, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1705, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1706, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1707, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1708, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(2240, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(2241, Filter.Road, Filter.Curve, Filter.Tilted, Filter.Slope);
            AddBlockTags(2242, Filter.Road, Filter.Curve, Filter.Tilted, Filter.Slope);
            AddBlockTags(2243, Filter.Road, Filter.Curve, Filter.Tilted, Filter.Slope);

            //Folder 103-2
            AddBlockTags(162, Filter.Road, Filter.Tilted, Filter.Straight);
            AddBlockTags(163, Filter.Road, Filter.Tilted, Filter.Straight);
            AddBlockTags(1154, Filter.Road, Filter.Tilted, Filter.Straight);
            AddBlockTags(164, Filter.Road, Filter.Tilted, Filter.Straight);
            AddBlockTags(165, Filter.Road, Filter.Tilted, Filter.Straight);
            AddBlockTags(1153, Filter.Road, Filter.Tilted, Filter.Straight);

            //Folder 103
            AddBlockTags(30, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(31, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(32, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(33, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(34, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(35, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(36, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(37, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(38, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(39, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(161, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(1697, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1698, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(1699, Filter.Road, Filter.Curve, Filter.Tilted);
            AddBlockTags(2254, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(2255, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);

            //Folder 105-1
            AddBlockTags(1206, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1207, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(1208, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(1209, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1210, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1211, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(1212, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1213, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1214, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1215, Filter.Road, Filter.Straight, Filter.Tilted);
            AddBlockTags(1216, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
            AddBlockTags(1217, Filter.Road, Filter.Straight, Filter.Tilted, Filter.Slope);
        }

        // Add block and its tags
        private static void AddBlockTags(int blockID, params Filter[] tags)
        {
            blockTags[blockID] = new HashSet<Filter>(tags);
        }

        // Get all block IDs matching all the filters
        public static List<int> GetBlocksMatchingAllFilters(List<Filter> filters)
        {
            return blockTags
                .Where(kvp => filters.All(filter => kvp.Value.Contains(filter))) // Ensure all filters match
                .Select(kvp => kvp.Key) // Select matching block IDs
                .ToList();
        }
    }

    //When we enter the level editor, get an empty copy of some button we can reuse for the filter.
    [HarmonyPatch(typeof(LEV_LevelEditorCentral), "Awake")]
    public class LEV_LevelEditorCentralAwakePatch
    {
        public static void Postfix(LEV_LevelEditorCentral __instance)
        {
            Plugin.Instance.OnLevelEditor(__instance);
        }
    }
}
