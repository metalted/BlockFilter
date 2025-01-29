using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BlockFilter
{
    public static class UIUtils
    {
        private static readonly Color green = new Color(0.00f, 0.80f, 0.00f, 1.0f);
        private static readonly Color greenHover = new Color(0.00f, 1.00f, 0.00f, 1.0f);
        private static readonly Color greenActive = new Color(0.30f, 1.00f, 0.30f, 1.0f);
        private static readonly Color grey = new Color(1.00f, 0.91f, 0.45f, 1.0f);
        private static readonly Color greyHover = new Color(1.00f, 0.93f, 0.56f, 1.0f);
        private static readonly Color greyActive = new Color(1.00f, 0.95f, 0.73f, 1.0f);

        public static void StandardRecolorDisabledButton(LEV_CustomButton button)
        {
            RecolorButton(button, grey, greyHover, greyActive, false);
        }

        public static void StandardRecolorEnabledButton(LEV_CustomButton button)
        {
            RecolorButton(button, green, greenHover, greenActive, false);
        }

        private static void RecolorButton(LEV_CustomButton button, Color normalColor, Color hoverColor, Color clickColor, bool recolorAllNormal = false)
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


    }
}
