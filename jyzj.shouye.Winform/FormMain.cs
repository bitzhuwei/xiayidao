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

        public FormMain()
        {
            InitializeComponent();
            this.keyboardHook = new KeyboardHook();
            this.keyboardHook.KeyDown += keyboardHook_KeyDown;
            this.keyboardHook.KeyUp += keyboardHook_KeyUp;
            this.keyboardHook.Start();
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

            // step 1: find window

            // step 2: copy window to bitmap

            // step 3: find all ASDWJK

            // step 4: arrange in left-to-right order

            // step 5: press keys

        }


    }
}
