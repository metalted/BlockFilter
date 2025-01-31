using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BlockFilter
{
    public enum PaintFilter
    {
        Transparent,
        Physics,
        Reflective,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Grayscale,
        Brown,
        ClearAll
    }

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
            filters.Add(PaintFilter.Orange, new FilterObject("Orange"));
            filters.Add(PaintFilter.Yellow, new FilterObject("Yellow"));
            filters.Add(PaintFilter.Green, new FilterObject("Green"));
            filters.Add(PaintFilter.Blue, new FilterObject("Blue"));
            filters.Add(PaintFilter.Purple, new FilterObject("Purple"));
            filters.Add(PaintFilter.Brown, new FilterObject("Brown"));
            filters.Add(PaintFilter.Grayscale, new FilterObject("Grayscale"));
            filters.Add(PaintFilter.Transparent, new FilterObject("Transparent"));
            filters.Add(PaintFilter.Physics, new FilterObject("Physics"));
            filters.Add(PaintFilter.Reflective, new FilterObject("Reflective"));
            filters.Add(PaintFilter.ClearAll, new FilterObject("Clear All"));
        }

        public void ClearAll()
        {
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
            {
                kvp.Value.State = FilterState.Off;

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
                if (kvp.Key == PaintFilter.Transparent || kvp.Key == PaintFilter.Physics || kvp.Key == PaintFilter.Reflective)
                {
                    if(!includePropertyFilters)
                    {
                        continue;
                    }
                }

                kvp.Value.State = FilterState.Off;
            }
        }

        public void UpdateButtonColors()
        {
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
            {
                if (kvp.Value.Button != null)
                {
                    switch(kvp.Value.State)
                    {
                        case FilterState.Off:
                            UIUtils.StandardRecolorOffButton(kvp.Value.Button);
                            break;
                        case FilterState.Enabled:
                            UIUtils.StandardRecolorEnabledButton(kvp.Value.Button);
                            break;
                        case FilterState.Disabled:
                            UIUtils.StandardRecolorDisabledButton(kvp.Value.Button);
                            break;
                    }
                }
            }
        }

        public void AssignSprites()
        {
            filters[PaintFilter.Red].Sprite = MaterialManager.AllMaterials[285].thumbnail;
            filters[PaintFilter.Orange].Sprite = MaterialManager.AllMaterials[286].thumbnail;
            filters[PaintFilter.Yellow].Sprite = MaterialManager.AllMaterials[288].thumbnail;
            filters[PaintFilter.Green].Sprite = MaterialManager.AllMaterials[297].thumbnail;
            filters[PaintFilter.Blue].Sprite = MaterialManager.AllMaterials[292].thumbnail;
            filters[PaintFilter.Purple].Sprite = MaterialManager.AllMaterials[304].thumbnail;
            filters[PaintFilter.Brown].Sprite = MaterialManager.AllMaterials[44].thumbnail;
            filters[PaintFilter.Grayscale].Sprite = MaterialManager.AllMaterials[126].thumbnail;
            filters[PaintFilter.Transparent].Sprite = MaterialManager.AllMaterials[280].thumbnail;
            filters[PaintFilter.Physics].Sprite = MaterialManager.AllMaterials[90].thumbnail;
            filters[PaintFilter.Reflective].Sprite = MaterialManager.AllMaterials[83].thumbnail;
            filters[PaintFilter.ClearAll].Sprite = Sprites.xSprite;
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
                    if(kvp.Key == PaintFilter.ClearAll)
                    {
                        ResetAllSelections(true);
                    }
                    else if(kvp.Key == PaintFilter.Physics || kvp.Key == PaintFilter.Transparent || kvp.Key == PaintFilter.Reflective)
                    {
                        switch(filters[kvp.Key].State)
                        {
                            case FilterState.Off:
                                filters[kvp.Key].State = FilterState.Enabled;
                                break;
                            case FilterState.Enabled:
                                filters[kvp.Key].State = FilterState.Disabled;
                                break;
                            case FilterState.Disabled:
                                filters[kvp.Key].State = FilterState.Off;
                                break;
                        }
                    }
                    else
                    {
                        FilterState currentState = filters[kvp.Key].State;
                        ResetAllSelections(false);
                        switch(currentState)
                        {
                            case FilterState.Off:
                                filters[kvp.Key].State = FilterState.Enabled;
                                break;
                            case FilterState.Enabled:
                                filters[kvp.Key].State = FilterState.Off;
                                break;
                        }
                        
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

        public List<PaintFilter> GetCurrentEnabledFilters()
        {
            List<PaintFilter> applied = new List<PaintFilter>();
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
            {
                if (kvp.Value.State == FilterState.Enabled)
                {
                    applied.Add(kvp.Key);
                }
            }

            return applied;
        }

        public List<PaintFilter> GetCurrentDisabledFilters()
        {
            List<PaintFilter> disabled = new List<PaintFilter>();
            foreach (KeyValuePair<PaintFilter, FilterObject> kvp in filters)
            {
                if (kvp.Value.State == FilterState.Disabled)
                {
                    disabled.Add(kvp.Key);
                }
            }

            return disabled;
        }
    }
}
