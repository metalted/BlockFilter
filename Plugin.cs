using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//Revert the titles for the inspector gui and the tree gui.
namespace BlockFilter
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.quickfilter";
        public const string pluginName = "QuickFilter";
        public const string pluginVersion = "1.0";

        public static Plugin Instance;
        public LEV_LevelEditorCentral central;
        public LEV_CustomButton buttonPrefab;
        public BlockFilterManager blockFilter;
        public PaintFilterManager paintFilter;

        public void Awake()
        {
            Instance = this;

            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();           

            Sprites.Initialize();
            BlockData.Initialize();
            PaintData.Initialize();

            blockFilter = new BlockFilterManager(6, 3, 0.01f, new Vector2(0.1f, 0.81f), new Vector2(0.9f, 0.94f));
            paintFilter = new PaintFilterManager(5, 2, 0.01f, new Vector2(0.1f, 0.81f), new Vector2(0.9f, 0.94f));
        }

        public void OnLevelInspector(LEV_Inspector instance)
        {
            central = instance.central;            

            CreateButtonPrefab();
            
            blockFilter.ClearAll();
            blockFilter.AssignSprites();
            blockFilter.GenerateFilterButtons(instance, buttonPrefab);

            paintFilter.ClearAll();
            paintFilter.AssignSprites();
            paintFilter.GenerateFilterButtons(instance, buttonPrefab);
            paintFilter.SetButtonVisibility(false);

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

        public bool OnCreateBlockGUI(LEV_Inspector instance)
        {
            blockFilter.SetButtonVisibility(true);
            paintFilter.SetButtonVisibility(false);

            //Get the currently applied filters.
            List<BlockFilter> filters = blockFilter.GetCurrentActiveFilters();

            //If no filters are applied return true
            if(filters.Count == 0)
            {
                instance.DestroyBlockGUI();
                instance.isPopulated = false;
                blockFilter.UpdateButtonColors();
                return true;
            }

            //Get all block IDs that match the filter.
            List<int> matches = BlockData.GetBlocksMatchingAllFilters(filters);

            //Create the block gui and return false.
            GenerateBlockGUI(instance, matches);

            return false;
        }    
        
        public bool OnCreatePaintGUI(LEV_Inspector instance)
        {
            paintFilter.SetButtonVisibility(true);
            blockFilter.SetButtonVisibility(false);

            List<PaintFilter> filters = paintFilter.GetCurrentActiveFilters();

            if(filters.Count == 0)
            {
                instance.DestroyBlockGUI();
                instance.isPopulated = false;
                paintFilter.UpdateButtonColors();
                return true;
            }

            List<int> matches = PaintData.GetPaintsMatchingAllFilters(filters);

            GeneratePaintGUI(instance, matches);

            return false;
        }

        public void OnCreateTreeGUI(LEV_Inspector instance)
        {
            blockFilter.SetButtonVisibility(false);
            paintFilter.SetButtonVisibility(false);
        }

        public void OnCreateInspectorGUI(LEV_Inspector instance)
        {
            blockFilter.SetButtonVisibility(false);
            paintFilter.SetButtonVisibility(false);
        }

        public void GeneratePaintGUI(LEV_Inspector instance, List<int> paintIDs)
        {
            instance.inspectorTitle.text = I2.Loc.LocalizationManager.GetTranslation("Editor_Select_Material");

            if(instance.isPopulated)
            {
                instance.DestroyBlockGUI();
                instance.isPopulated = false;
            }

            paintFilter.UpdateButtonColors();

            //Determine layout
            int horizontalAmount = instance.GetHorizontalAmount();
            int totalPaints = paintIDs.Count;
            float width = instance.contentBox.rect.width;
            float rows = Mathf.Ceil((float)totalPaints / horizontalAmount);
            instance.contentBox.sizeDelta = new Vector2(0.0f, width);

            //Create a button for each block
            for (int i = 0; i < totalPaints; i++)
            {
                //Instantiate button
                ThumbnailButton thumbnailButton = GameObject.Instantiate<ThumbnailButton>(instance.buttonPrefab2);
                thumbnailButton.button.central = instance.central;
                instance.blockThumbImages.Add(thumbnailButton.thumbnailImage);

                //Get blockproperties
                int paintID = paintIDs[i];
                MaterialHolder paint = MaterialManager.AllMaterials[paintID];

                //Setup button actions
                instance.blockThumbImages[i].sprite = paint.thumbnail;
                thumbnailButton.button.onClick.AddListener(() => instance.central.painter.SetToCurrentPaint(paint));
                string localizedName = paint.localizedName;
                int indicatorPosition = i;

                thumbnailButton.button.onClick.AddListener(() => instance.PositionIndicator(indicatorPosition, true, instance.GetBlockName(paintID.ToString(), localizedName)));
                thumbnailButton.button.onHoverEnter.AddListener(() => instance.BlockHoverEnter(paintID, localizedName));
                thumbnailButton.button.onHoverExit.AddListener(() => instance.BlockHoverExit());
                thumbnailButton.ApplyIcon(paint.thumbnail_icon);

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
            instance.currentBlockIndicator.gameObject.SetActive(true);
            instance.isPopulated = true;
            instance.scrollbar.value = instance.rememberScrollbarValue;
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
            blockFilter.UpdateButtonColors();

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
        public static bool Prefix(LEV_Inspector __instance)
        {
            return Plugin.Instance.OnCreatePaintGUI(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_Inspector), "CreateTreeGUI")]
    public class LEV_InspectorCreateTreeGUIPatch
    {
        public static void Prefix(LEV_Inspector __instance)
        {
            Plugin.Instance.OnCreateTreeGUI(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_Inspector), "CreateInspectorUI")]
    public class LEV_InspectorCreateInspectorUIPatch
    {
        public static void Prefix(LEV_Inspector __instance)
        {
            Plugin.Instance.OnCreateInspectorGUI(__instance);
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
    
