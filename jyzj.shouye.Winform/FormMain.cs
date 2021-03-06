﻿using SmileWei.MouseKeyboardHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace jyzj.shouye.Winform
{
    public partial class FormMain : Form
    {
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
            // test mouse and keyboard hooks:
            //var keyboardHook = new KeyboardHook();
            //keyboardHook.KeyDown += keyboardHook_KeyDown;
            //keyboardHook.KeyUp += keyboardHook_KeyUp;
            //keyboardHook.Start();
            //var mouseHook = new MouseHook();
            //mouseHook.MouseMove += mouseHook_MouseMove;
            //mouseHook.MouseDown += mouseHook_MouseDown;
            //mouseHook.MouseUp += mouseHook_MouseUp;
            //mouseHook.MouseWheel += mouseHook_MouseWheel;
            //mouseHook.Start();

            InitASDWJK();
        }

        void mouseHook_MouseWheel(object sender, MouseEventArgs e)
        {
            this.txtContent.AppendText(string.Format("{0}: {1} Mouse Wheel", DateTime.Now, e.Delta));
            this.txtContent.AppendText(Environment.NewLine);
        }

        void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtContent.AppendText(string.Format("{0}: {1} Mouse Up", DateTime.Now, e.Button));
            this.txtContent.AppendText(Environment.NewLine);
        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtContent.AppendText(string.Format("{0}: {1} Mouse Down", DateTime.Now, e.Button));
            this.txtContent.AppendText(Environment.NewLine);
        }

        void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            this.txtContent.AppendText(string.Format("{0}: {1} Mouse Move", DateTime.Now, e.Location));
            this.txtContent.AppendText(Environment.NewLine);
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
            this.txtContent.AppendText(string.Format("{0}: {1} Up", DateTime.Now, e.KeyCode));
            this.txtContent.AppendText(Environment.NewLine);
        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtContent.AppendText(string.Format("{0}: {1} Down", DateTime.Now, e.KeyCode));
            this.txtContent.AppendText(Environment.NewLine);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = !this.timer1.Enabled;
            this.btnStart.Text = this.timer1.Enabled ? "停止" : "开始";
            //timer1_Tick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MouseSimulator.Click(MouseButton.Left);
            //KeyboardSimulator.KeyPress(Keys.R);

            // step 1: find window area
            Rectangle rect = GetJYZJClientRect();
            if (rect == Rectangle.Empty) { this.txtContent.AppendText("没有找到 九阴真经 游戏窗口！"); }
            // step 2: copy window to bitmap
            var bigBitmap = new Bitmap(540, rect.Height / 2, PixelFormat.Format24bppRgb);
            {
                var graphics = Graphics.FromImage(bigBitmap);
                graphics.CopyFromScreen(rect.X + rect.Width / 2, rect.Y + rect.Height / 2, 0, 0, new Size(540, rect.Height / 2));
                graphics.Dispose();
            }
            // step 3: find all ASDWJK
            var list = new List<Item>();
            foreach (KeyInfo keyBitmap in this.keyBitmapList)
            {
                List<Point> locationList = BmpColor.FindPic(0, 0, bigBitmap.Width, bigBitmap.Height, bigBitmap, keyBitmap.bitmap, 40);
                foreach (Point location in locationList)
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
                this.txtContent.AppendText(string.Format("{0}: {1}, {2}", DateTime.Now, item.keyInfo, item.location));
                this.txtContent.AppendText(Environment.NewLine);
                Thread.Sleep(10);
            }

            if (list.Count > 0)
            {
                Image original = this.pictureBox1.BackgroundImage;
                this.pictureBox1.BackgroundImage = bigBitmap;
                if (original != null) { original.Dispose(); }
                if (this.txtContent.Lines.Length > 1000) { this.txtContent.Clear(); }
                this.txtContent.AppendText(Environment.NewLine);
            }
            else
            {
                bigBitmap.Dispose();
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.btnStart_Click(sender, e);
        }

    }

}
