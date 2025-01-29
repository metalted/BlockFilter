using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BlockFilter
{
    public class FilterObject
    {
        public LEV_CustomButton Button;
        public Sprite Sprite;
        public string Name;
        public bool State;

        public FilterObject(string name)
        {
            Name = name;
        }
    }
}
