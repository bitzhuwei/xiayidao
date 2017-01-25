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
        private List<Bitmap> keyList;

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
            this.keyList = new List<Bitmap>() { this.bmpA, this.bmpS, this.bmpD, this.bmpW, this.bmpJ, this.bmpK, };
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
            this.timer1.Enabled = !this.timer1.Enabled;
            this.btnStart.Text = this.timer1.Enabled ? "停止" : "开始";
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

            // step 4: arrange in left-to-right order

            // step 5: press keys

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
    }

}
