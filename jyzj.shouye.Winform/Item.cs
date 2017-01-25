using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jyzj.shouye.Winform
{
    class Item
    {
        public readonly System.Drawing.Point location;
        public readonly KeyInfo keyInfo;

        public Item(System.Drawing.Point location, KeyInfo keyBitmap)
        {
            // TODO: Complete member initialization
            this.location = location;
            this.keyInfo = keyBitmap;
        }
    }
}
