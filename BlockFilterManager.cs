using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BlockFilter
{
    public class BlockFilterManager
    {
        private int Columns;
        private int Rows;
        private float Padding;
        private Vector2 AreaMin;
        private Vector2 AreaMax;

        private Dictionary<BlockFilter, FilterObject> filters;

        public BlockFilterManager(int columns, int rows, float padding, Vector2 areaMin, Vector2 areaMax)
        {
            Columns = columns;
            Rows = rows;
            Padding = padding;
            AreaMin = areaMin;
            AreaMax = areaMax;

            filters = new Dictionary<BlockFilter, FilterObject>();
            filters.Add(BlockFilter.Road, new FilterObject("Road"));
            filters.Add(BlockFilter.Tube, new FilterObject("Tube"));
            filters.Add(BlockFilter.HalfPipe, new FilterObject("Half Pipe"));
            filters.Add(BlockFilter.Special, new FilterObject("Special"));
            filters.Add(BlockFilter.Field, new FilterObject("Field"));
            filters.Add(BlockFilter.Physics, new FilterObject("Physics"));
            filters.Add(BlockFilter.Straight, new FilterObject("Straight"));
            filters.Add(BlockFilter.Curve, new FilterObject("Curve"));
            filters.Add(BlockFilter.Sbend, new FilterObject("S-Bend"));
            filters.Add(BlockFilter.Slope, new FilterObject("Slope"));
            filters.Add(BlockFilter.Tilted, new FilterObject("Tilted"));
        }

        public void ClearAll()
        {
            foreach (KeyValuePair<BlockFilter, FilterObject> kvp in filters)
            {
                kvp.Value.State = false;

                if (kvp.Value.Button != null)
                {
                    if (kvp.Value.Button.gameObject != null)
                    {
                        GameObject.Destroy(kvp.Value.Button.gameObject);
                    }
                }

                kvp.Value.Button = null;
            }
        }

        public void ResetAllSelections()
        {
            foreach (KeyValuePair<BlockFilter, FilterObject> kvp in filters)
            {
                kvp.Value.State = false;
            }
        }

        public void UpdateButtonColors()
        {
            foreach (KeyValuePair<BlockFilter, FilterObject> kvp in filters)
            {
                if (kvp.Value.Button != null)
                {
                    if (kvp.Value.State)
                    {
                        UIUtils.StandardRecolorEnabledButton(kvp.Value.Button);
                    }
                    else
                    {
                        UIUtils.StandardRecolorDisabledButton(kvp.Value.Button);
                    }
                }
            }
        }

        public void AssignSprites()
        {
            List<BlockProperties> blockList = PlayerManager.Instance.loader.globalBlockList.blocks;

            filters[BlockFilter.Road].Sprite = blockList[0].thumbnail;
            filters[BlockFilter.Tube].Sprite = blockList[56].thumbnail;
            filters[BlockFilter.HalfPipe].Sprite = blockList[20].thumbnail;
            filters[BlockFilter.Special].Sprite = blockList[2].thumbnail;
            filters[BlockFilter.Field].Sprite = blockList[1746].thumbnail;
            filters[BlockFilter.Physics].Sprite = blockList[1280].thumbnail;
            filters[BlockFilter.Straight].Sprite = Sprites.straightSprite;
            filters[BlockFilter.Curve].Sprite = Sprites.curveSprite;
            filters[BlockFilter.Sbend].Sprite = Sprites.sbendSprite;
            filters[BlockFilter.Slope].Sprite = Sprites.slopeSprite;
            filters[BlockFilter.Tilted].Sprite = Sprites.tiltSprite;
        }

        public void GenerateFilterButtons(LEV_Inspector instance, LEV_CustomButton buttonPrefab)
        {
            // Get the block GUI parent
            Transform buttonParent = instance.inspectorTitle.transform.parent;

            // Calculate the total width and height of the area
            float totalWidth = AreaMax.x - AreaMin.x;
            float totalHeight = AreaMax.y - AreaMin.y;

            // Calculate total padding space
            float totalHorizontalPadding = totalWidth * Padding; // Total horizontal padding space
            float totalVerticalPadding = totalHeight * Padding;  // Total vertical padding space

            // Calculate individual padding
            float horizontalPadding = totalHorizontalPadding / (Columns - 1); // Horizontal padding between buttons
            float verticalPadding = totalVerticalPadding / (Rows - 1);        // Vertical padding between buttons

            // Adjust cell dimensions to account for padding
            float cellWidth = (totalWidth - totalHorizontalPadding) / Columns; // Width of each cell without horizontal padding
            float cellHeight = (totalHeight - totalVerticalPadding) / Rows;    // Height of each cell without vertical padding

            int index = 0; // Index to track the button position in the grid

            foreach (KeyValuePair<BlockFilter, FilterObject> kvp in filters)
            {
                // Create a new button
                GameObject copy = GameObject.Instantiate(buttonPrefab.gameObject, buttonParent);
                copy.gameObject.name = $"{kvp.Value.Name} Filter Button";
                copy.gameObject.SetActive(true);

                LEV_CustomButton button = copy.GetComponent<LEV_CustomButton>();
                button.onClick.AddListener(() =>
                {
                    filters[kvp.Key].State = !filters[kvp.Key].State;
                    instance.CreateBlockGUI();
                });

                button.transform.GetChild(0).GetComponent<Image>().sprite = filters[kvp.Key].Sprite;

                // Calculate grid position
                int column = index % Columns;
                int row = index / Columns;

                // Calculate button anchors, including both horizontal and vertical padding
                float buttonAnchorMinX = AreaMin.x + column * (cellWidth + horizontalPadding);
                float buttonAnchorMaxX = buttonAnchorMinX + cellWidth;
                float buttonAnchorMaxY = AreaMax.y - row * (cellHeight + verticalPadding);
                float buttonAnchorMinY = buttonAnchorMaxY - cellHeight;

                // Set button anchors
                RectTransform rect = button.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(buttonAnchorMinX, buttonAnchorMinY);
                rect.anchorMax = new Vector2(buttonAnchorMaxX, buttonAnchorMaxY);
                rect.offsetMin = rect.offsetMax = Vector2.zero; // Remove any offsets

                filters[kvp.Key].Button = button;

                try
                {
                    ZeepSDK.UI.UIApi.AddTooltip(button.gameObject, filters[kvp.Key].Name);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e.Message);
                }

                index++;
            }
        }

        public void SetButtonVisibility(bool state)
        {
            foreach (KeyValuePair<BlockFilter, FilterObject> kvp in filters)
            {
                if (kvp.Value.Button != null)
                {
                    if (kvp.Value.Button.gameObject != null)
                    {
                        kvp.Value.Button.gameObject.SetActive(state);
                    }
                }
            }
        }

        public List<BlockFilter> GetCurrentActiveFilters()
        {
            List<BlockFilter> applied = new List<BlockFilter>();
            foreach (KeyValuePair<BlockFilter, FilterObject> kvp in filters)
            {
                if (kvp.Value.State)
                {
                    applied.Add(kvp.Key);
                }
            }

            return applied;
        }
    }

}
