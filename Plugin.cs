using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BlockFilter
{
    public enum Filter
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
        Tilted
    }

    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.blockfilter";
        public const string pluginName = "BlockFilter";
        public const string pluginVersion = "1.0";

        public static Plugin Instance;
        public LEV_LevelEditorCentral central;
        public LEV_CustomButton buttonPrefab;

        public int filterColumns = 6;
        public int filterRows = 2;

        private Dictionary<Filter, bool> filterStates;
        private Dictionary<Filter, LEV_CustomButton> filterButtons;
        private Dictionary<Filter, Sprite> filterSprites;

        private readonly Color green = new Color(0.00f, 0.80f, 0.00f, 1.0f);
        private readonly Color greenHover = new Color(0.00f, 1.00f, 0.00f, 1.0f);
        private readonly Color greenActive = new Color(0.30f, 1.00f, 0.30f, 1.0f);
        private readonly Color grey = new Color(1.00f, 0.91f, 0.45f, 1.0f);
        private readonly Color greyHover = new Color(1.00f, 0.93f, 0.56f, 1.0f);
        private readonly Color greyActive = new Color(1.00f, 0.95f, 0.73f, 1.0f);

        public void Awake()
        {
            Instance = this;

            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();

            filterStates = new Dictionary<Filter, bool>()
            {
                { Filter.Road, false },
                { Filter.Tube, false },
                { Filter.HalfPipe, false },
                { Filter.Special, false },
                { Filter.Field, false },
                { Filter.Physics, false },
                { Filter.Straight, false },
                { Filter.Curve, false },
                { Filter.Sbend, false },                
                { Filter.Slope, false },
                { Filter.Tilted, false }
            };

            Sprites.Initialize();
            BlockData.Initialize();
        }

        #region Initialization
        public void OnLevelInspector(LEV_Inspector instance)
        {
            central = instance.central;

            List<BlockProperties> blockList = PlayerManager.Instance.loader.globalBlockList.blocks;

            filterSprites = new Dictionary<Filter, Sprite>() {
                { Filter.Road, blockList[0].thumbnail },
                { Filter.Tube, blockList[56].thumbnail },
                { Filter.HalfPipe, blockList[20].thumbnail },
                { Filter.Straight, Sprites.straightSprite },
                { Filter.Curve, Sprites.curveSprite },
                { Filter.Sbend, Sprites.sbendSprite },
                { Filter.Special, blockList[2].thumbnail },
                { Filter.Slope, Sprites.slopeSprite },
                { Filter.Tilted, Sprites.tiltSprite },
                { Filter.Field, blockList[1746].thumbnail },
                { Filter.Physics, blockList[1280].thumbnail }
            };

            CreateButtonPrefab();
            GenerateFilterButtons(instance, new Vector2(0.1f, 0.81f), new Vector2(0.9f, 0.94f), filterColumns, filterRows, 0.02f);

            //Move the titles to make room for the buttons
            instance.inspectorTitle.rectTransform.anchorMin = new Vector2(0.51f, 0.95f);
            instance.inspectorTitle.rectTransform.anchorMax = new Vector2(0.9f, 0.98f);

            RectTransform mainTitle = instance.transform.GetChild(0).GetComponent<RectTransform>();
            mainTitle.anchorMin = new Vector2(0.1f, 0.95f);
            mainTitle.anchorMax = new Vector2(0.5f, 0.98f);
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

        private void GenerateFilterButtons(LEV_Inspector instance, Vector2 anchorMin, Vector2 anchorMax, int columns, int rows, float paddingPercentage)
        {
            filterButtons = new Dictionary<Filter, LEV_CustomButton>();

            // Get the block GUI parent
            Transform buttonParent = instance.inspectorTitle.transform.parent;

            // Calculate the total width and height of the area
            float totalWidth = anchorMax.x - anchorMin.x;
            float totalHeight = anchorMax.y - anchorMin.y;

            // Calculate total padding space
            float totalHorizontalPadding = totalWidth * paddingPercentage; // Total horizontal padding space
            float totalVerticalPadding = totalHeight * paddingPercentage;  // Total vertical padding space

            // Calculate individual padding
            float horizontalPadding = totalHorizontalPadding / (columns - 1); // Horizontal padding between buttons
            float verticalPadding = totalVerticalPadding / (rows - 1);        // Vertical padding between buttons

            // Adjust cell dimensions to account for padding
            float cellWidth = (totalWidth - totalHorizontalPadding) / columns; // Width of each cell without horizontal padding
            float cellHeight = (totalHeight - totalVerticalPadding) / rows;    // Height of each cell without vertical padding

            int index = 0; // Index to track the button position in the grid

            foreach (var filter in filterStates)
            {
                // Create a new button
                GameObject copy = GameObject.Instantiate(buttonPrefab.gameObject, buttonParent);
                copy.gameObject.name = $"{filter.Key} Filter Button";
                copy.gameObject.SetActive(true);

                LEV_CustomButton button = copy.GetComponent<LEV_CustomButton>();
                Filter currentFilter = filter.Key; // Capture the current filter for the lambda
                button.onClick.AddListener(() =>
                {
                    filterStates[currentFilter] = !filterStates[currentFilter];
                    instance.CreateBlockGUI();
                });

                button.transform.GetChild(0).GetComponent<Image>().sprite = filterSprites[currentFilter];

                // Calculate grid position
                int column = index % columns;
                int row = index / columns;

                // Calculate button anchors, including both horizontal and vertical padding
                float buttonAnchorMinX = anchorMin.x + column * (cellWidth + horizontalPadding);
                float buttonAnchorMaxX = buttonAnchorMinX + cellWidth;
                float buttonAnchorMaxY = anchorMax.y - row * (cellHeight + verticalPadding);
                float buttonAnchorMinY = buttonAnchorMaxY - cellHeight;

                // Set button anchors
                RectTransform rect = button.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(buttonAnchorMinX, buttonAnchorMinY);
                rect.anchorMax = new Vector2(buttonAnchorMaxX, buttonAnchorMaxY);
                rect.offsetMin = rect.offsetMax = Vector2.zero; // Remove any offsets

                filterButtons.Add(currentFilter, button);

                try
                {
                    ZeepSDK.UI.UIApi.AddTooltip(button.gameObject, currentFilter.ToString());
                }
                catch(Exception e) 
                {
                    Debug.LogWarning(e.Message);
                }

                index++;
            }
        }
        #endregion

        public void OnCreateNotBlockGUI(LEV_Inspector instance)
        {
            //Make sure all buttons are disabled
            foreach (KeyValuePair<Filter, LEV_CustomButton> kvp in filterButtons)
            {
                kvp.Value.gameObject.SetActive(false);
            };
        }

        public bool OnCreateBlockGUI(LEV_Inspector instance)
        {
            //Make sure all buttons are enabled
            foreach(KeyValuePair<Filter, LEV_CustomButton> kvp in filterButtons)
            {
                kvp.Value.gameObject.SetActive(true);
            };

            //Get the currently applied filters.
            List<Filter> filters = GetCurrentFilters();

            //If no filters are applied return true
            if(filters.Count == 0)
            {
                instance.DestroyBlockGUI();
                instance.isPopulated = false;
                UpdateFilterButtons(instance);
                return true;
            }

            //Get all block IDs that match the filter.
            List<int> matches = BlockData.GetBlocksMatchingAllFilters(filters);

            //Create the block gui and return false.
            GenerateBlockGUI(instance, matches);

            return false;
        }

        private List<Filter> GetCurrentFilters()
        {
            List<Filter> applied = new List<Filter>();
            foreach (KeyValuePair<Filter, bool> kvp in filterStates)
            {
                if (kvp.Value)
                {
                    applied.Add(kvp.Key);
                }
            }

            return applied;
        }

        public void GenerateBlockGUI(LEV_Inspector instance, List<int> blockIDs)
        {
            instance.inspectorTitle.text = I2.Loc.LocalizationManager.GetTranslation("Editor_Select_Block");

            //Set the position for the inspector title to make room for the filter buttons

            if (instance.isPopulated)
            {
                instance.DestroyBlockGUI();
                instance.isPopulated = false;
            }

            //Generate the filter buttons in their current state.
            UpdateFilterButtons(instance);

            //Determine layout
            int horizontalAmount = instance.GetHorizontalAmount();
            int totalBlocks = blockIDs.Count;
            float width = instance.contentBox.rect.width;
            float rows = Mathf.Ceil((float)totalBlocks / horizontalAmount);
            instance.contentBox.sizeDelta = new Vector2(0.0f, width);

            //Create a button for each block
            for (int i = 0; i < totalBlocks; i++)
            {
                //Instantiate button
                ThumbnailButton thumbnailButton = GameObject.Instantiate<ThumbnailButton>(instance.buttonPrefab2);
                thumbnailButton.button.central = instance.central;
                instance.blockThumbImages.Add(thumbnailButton.thumbnailImage);

                //Get blockproperties
                int blockID = blockIDs[i];
                BlockProperties block = PlayerManager.Instance.loader.globalBlockList.blocks[blockID];

                //Setup button actions
                instance.blockThumbImages[i].sprite = block.thumbnail;
                thumbnailButton.button.onClick.AddListener(() => instance.central.gizmos.CreateNewBlock(blockID));
                string localizedName = block.bridge.localizedName;
                thumbnailButton.button.onHoverEnter.AddListener(() => instance.BlockHoverEnter(blockID, localizedName));
                thumbnailButton.button.onHoverExit.AddListener(() => instance.BlockHoverExit());
                thumbnailButton.ApplyIcon(block.thumbnail_icon);

                //Set button parent and layout
                thumbnailButton.transform.SetParent(instance.contentBox, false);
                RectTransform rectTransform = thumbnailButton.GetComponent<RectTransform>();

                if (i == 0)
                {
                    instance.testRect = rectTransform;
                }

                float row = Mathf.Floor((float)i / horizontalAmount);
                float col = i % horizontalAmount;
                float colWidth = 1f / horizontalAmount;
                float rowHeight = 1f / rows;

                float x1 = col * colWidth;
                float x2 = x1 + colWidth;
                float y1 = 1f - (row * rowHeight);
                float y2 = y1 - rowHeight;

                rectTransform.anchorMin = new Vector2(x1, y2);
                rectTransform.anchorMax = new Vector2(x2, y1);

                instance.allButtons2.Add(thumbnailButton);
            }

            //Update button aspects and scrollbar
            instance.UpdateButtonAspects();
            instance.currentBlockIndicator.SetSiblingIndex(99999);
            instance.currentBlockIndicator.gameObject.SetActive(false);
            instance.isPopulated = true;
            instance.scrollbar.value = instance.rememberScrollbarValue;
        }

        public void UpdateFilterButtons(LEV_Inspector instance)
        {
            foreach(KeyValuePair<Filter, LEV_CustomButton> kvp in filterButtons)
            {
                if (filterStates[kvp.Key])
                {
                    StandardRecolorEnabledButton(kvp.Value);
                }
                else
                {
                    StandardRecolorDisabledButton(kvp.Value);
                }
            }
        }

        private void RecolorButton(LEV_CustomButton button, Color normalColor, Color hoverColor, Color clickColor, bool recolorAllNormal = false)
        {
            button.normalColor = normalColor;
            button.overrideNormalColor = true;
            button.buttonImage.color = normalColor;
            button.hoverColor = hoverColor;
            button.clickColor = clickColor;
            button.isDisabled_clickColor = clickColor;
            button.isDisabled_hoverColor = hoverColor;
            button.isDisabled_normalColor = normalColor;

            if (recolorAllNormal)
            {
                button.clickColor = normalColor;
                button.hoverColor = normalColor;
                button.normalColor = normalColor;
                button.selectedColor = normalColor;
                button.isDisabled_clickColor = normalColor;
                button.isDisabled_hoverColor = normalColor;
                button.isDisabled_normalColor = normalColor;
                button.isDisabled_selectedColor = normalColor;
            }
        }

        private void StandardRecolorDisabledButton(LEV_CustomButton button)
        {
            RecolorButton(button, grey, greyHover, greyActive, false);
        }

        private void StandardRecolorEnabledButton(LEV_CustomButton button)
        {
            RecolorButton(button, green, greenHover, greenActive, false);
        }
    }   

    public static class BlockData
    {
        // Dictionary mapping object IDs to their tags
        private static Dictionary<int, HashSet<Filter>> blockTags = new Dictionary<int, HashSet<Filter>>();
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
    }

    [HarmonyPatch(typeof(LEV_Inspector), "CreateBlockGUI")]
    public class LEV_InspectorCreateBlockGUIPatch
    {
        public static bool Prefix(LEV_Inspector __instance)
        {
            return Plugin.Instance.OnCreateBlockGUI(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_Inspector), "CreatePaintGUI")]
    public class LEV_InspectorCreatePaintGUIPatch
    {
        public static void Prefix(LEV_Inspector __instance)
        {
            Plugin.Instance.OnCreateNotBlockGUI(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_Inspector), "CreateTreeGUI")]
    public class LEV_InspectorCreateTreeGUIPatch
    {
        public static void Prefix(LEV_Inspector __instance)
        {
            Plugin.Instance.OnCreateNotBlockGUI(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_Inspector), "CreateInspectorUI")]
    public class LEV_InspectorCreateInspectorUIPatch
    {
        public static void Prefix(LEV_Inspector __instance)
        {
            Plugin.Instance.OnCreateNotBlockGUI(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_Inspector), "Awake")]
    public class LEV_LevelInspectorAwakePatch
    {
        public static void Postfix(LEV_Inspector __instance)
        {
            Plugin.Instance.OnLevelInspector(__instance);
        }
    }
}
    
