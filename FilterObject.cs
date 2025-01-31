using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BlockFilter
{
    public enum FilterState
    {
        Off,
        Enabled,
        Disabled
    }

    public class FilterObject
    {
        public LEV_CustomButton Button;
        public Sprite Sprite;
        public string Name;
        public FilterState State;

        public FilterObject(string name)
        {
            Name = name;
        }
    }
}
