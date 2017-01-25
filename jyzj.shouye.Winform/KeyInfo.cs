using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jyzj.shouye.Winform
{
    class KeyInfo
    {
        public readonly System.Drawing.Bitmap bitmap;
        public readonly System.Windows.Forms.Keys key;

        public KeyInfo(System.Drawing.Bitmap bitmap, System.Windows.Forms.Keys key)
        {
            // TODO: Complete member initialization
            this.bitmap = bitmap;
            this.key = key;
        }
    }

}
