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

        public override string ToString()
        {
            return string.Format("{0}({1})", this.key, Translate(this.key));
        }

        private string Translate(System.Windows.Forms.Keys key)
        {
            var result = string.Empty;
            switch (key)
            {
                case System.Windows.Forms.Keys.A:
                    result = "←";
                    break;
                case System.Windows.Forms.Keys.S:
                    result = "↓";
                    break;
                case System.Windows.Forms.Keys.D:
                    result = "→";
                    break;
                case System.Windows.Forms.Keys.W:
                    result = "↑";
                    break;
                default:
                    result = key.ToString();
                    break;
            }
            return result;
        }
    }
}

