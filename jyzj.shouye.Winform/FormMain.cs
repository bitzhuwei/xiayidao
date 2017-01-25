using SmileWei.MouseKeyboardHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyzj.shouye.Winform
{
    public partial class FormMain : Form
    {
        KeyboardHook keyboardHook;
        private Bitmap bmpA;
        private Bitmap bmpS;
        private Bitmap bmpD;
        private Bitmap bmpW;
        private Bitmap bmpJ;
        private Bitmap bmpK;
        private List<KeyInfo> keyBitmapList;

        public FormMain()
        {
            InitializeComponent();
            this.keyboardHook = new KeyboardHook();
            this.keyboardHook.KeyDown += keyboardHook_KeyDown;
            this.keyboardHook.KeyUp += keyboardHook_KeyUp;
            this.keyboardHook.Start();

            InitASDWJK();
        }

        private void InitASDWJK()
        {
            this.bmpA = new Bitmap(@"ASDWJK\A.bmp");
            this.bmpS = new Bitmap(@"ASDWJK\S.bmp");
            this.bmpD = new Bitmap(@"ASDWJK\D.bmp");
            this.bmpW = new Bitmap(@"ASDWJK\W.bmp");
            this.bmpJ = new Bitmap(@"ASDWJK\J.bmp");
            this.bmpK = new Bitmap(@"ASDWJK\K.bmp");
            this.keyBitmapList = new List<KeyInfo>();
            this.keyBitmapList.Add(new KeyInfo(this.bmpA, Keys.A));
            this.keyBitmapList.Add(new KeyInfo(this.bmpS, Keys.S));
            this.keyBitmapList.Add(new KeyInfo(this.bmpD, Keys.D));
            this.keyBitmapList.Add(new KeyInfo(this.bmpW, Keys.W));
            this.keyBitmapList.Add(new KeyInfo(this.bmpJ, Keys.J));
            this.keyBitmapList.Add(new KeyInfo(this.bmpK, Keys.K));
        }

        void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            // TODO: why not working ???
            this.txtContent.AppendText(string.Format("{0}: {1} Up", DateTime.Now, e.KeyCode));
        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            // TODO: why not working ???
            this.txtContent.AppendText(string.Format("{0}: {1} Down", DateTime.Now, e.KeyCode));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //this.timer1.Enabled = !this.timer1.Enabled;
            this.btnStart.Text = this.timer1.Enabled ? "停止" : "开始";
            timer1_Tick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MouseSimulator.Click(MouseButton.Left);
            //KeyboardSimulator.KeyPress(Keys.R);

            // step 1: find window area
            Rectangle rect = GetJYZJClientRect();
            if (rect == Rectangle.Empty) { this.txtContent.AppendText("没有找到 九阴真经 游戏窗口！"); }
            // step 2: copy window to bitmap
            var bitmap = new Bitmap(rect.Width, rect.Height);
            {
                var graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
                graphics.Dispose();
            }
            // step 3: find all ASDWJK
            var list = new List<Item>();
            foreach (KeyInfo keyBitmap in this.keyBitmapList)
            {
                foreach (Point location in FindAll(keyBitmap.bitmap, bitmap))
                {
                    list.Add(new Item(location, keyBitmap));
                }
            }
            // step 4: arrange in left-to-right order
            for (int i = 0; i < list.Count - 1; i++)
            {
                int p = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[p].location.X > list[j].location.X)
                    {
                        p = j;
                    }
                }
                if (p != i)
                {
                    Item tmp = list[i];
                    list[i] = list[p];
                    list[p] = tmp;
                }
            }
            // step 5: press keys
            foreach (Item item in list)
            {
                KeyboardSimulator.KeyPress(item.keyInfo.key);
            }
        }

        Rectangle GetJYZJClientRect()
        {
            IntPtr intPtr = WindowsAPI.FindWindow("fxMain", null);
            if (intPtr == IntPtr.Zero)
            {
                return Rectangle.Empty;
            }
            Rectangle empty = Rectangle.Empty;
            WindowsAPI.GetWindowRect(intPtr, out empty);
            return empty;
        }

        IEnumerable<Point> FindAll(Bitmap target, Bitmap bigPicture)
        {
            for (int x = 0; x < bigPicture.Width - target.Width; x++)
            {
                for (int y = 0; y < bigPicture.Height - target.Height; y++)
                {
                    if (IsSame(target, bigPicture, x, y))
                    {
                        yield return new Point(x, y);
                    }
                }
            }
        }

        private bool IsSame(Bitmap target, Bitmap bigPicture, int firstX, int firstY)
        {
            for (int x = 0; x < target.Width; x++)
            {
                for (int y = 0; y < target.Height; y++)
                {
                    Color targetColor = target.GetPixel(x, y);
                    Color bigPictureColor = bigPicture.GetPixel(x + firstX, y + firstY);
                    if (targetColor != bigPictureColor)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

}
