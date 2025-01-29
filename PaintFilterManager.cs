using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BlockFilter
{
    public class PaintFilterManager
    {
        private int Columns;
        private int Rows;
        private float Padding;
        private Vector2 AreaMin;
        private Vector2 AreaMax;

        private Dictionary<PaintFilter, FilterObject> filters;
        public PaintFilterManager(int columns, int rows, float padding, Vector2 areaMin, Vector2 areaMax)
        {
            Columns = columns;
            Rows = rows;
            Padding = padding;
            AreaMin = areaMin;
            AreaMax = areaMax;

            filters = new Dictionary<PaintFilter, FilterObject>();
            filters.Add(PaintFilter.Red, new FilterObject("Red"));
            filters.Add(PaintFilter.Blue, new FilterObject("Blue"));
            filters.Add(PaintFilter.Green, new FilterObject("Green"));
            filters.Add(PaintFilter.Grayscale, new FilterObject("Greyscale"));
            filters.Add(PaintFilter.Transparent, new FilterObject("Transparent"));
            filters.Add(PaintFilter.Physics, new FilterObject("Physics"));
        }

        public void ClearAll()
        {
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
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

        public void ResetAllSelections(bool includePropertyFilters = true)
        {
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
            {
                if(kvp.Key == PaintFilter.Transparent || kvp.Key == PaintFilter.Physics)
                {
                    if(!includePropertyFilters)
                    {
                        continue;
                    }
                }

                kvp.Value.State = false;
            }
        }

        public void UpdateButtonColors()
        {
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
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
            //... Get the paint sprites.
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

            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
            {
                // Create a new button
                GameObject copy = GameObject.Instantiate(buttonPrefab.gameObject, buttonParent);
                copy.gameObject.name = $"{kvp.Value.Name} Filter Button";
                copy.gameObject.SetActive(true);

                LEV_CustomButton button = copy.GetComponent<LEV_CustomButton>();
                button.onClick.AddListener(() =>
                {
                    if(kvp.Key == PaintFilter.Physics || kvp.Key == PaintFilter.Transparent)
                    {
                        filters[kvp.Key].State = !filters[kvp.Key].State;
                    }
                    else
                    {
                        bool currentState = filters[kvp.Key].State;
                        ResetAllSelections(false);
                        filters[kvp.Key].State = !currentState;
                    }
                    
                    instance.CreatePaintGUI();
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
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
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

        public List<PaintFilter> GetCurrentActiveFilters()
        {
            List<PaintFilter> applied = new List<PaintFilter>();
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
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
