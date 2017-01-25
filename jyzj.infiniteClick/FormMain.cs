using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyzj.infiniteClick
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)this.numericUpDown1.Value;
            if (value < 10) { value = 10; }
            this.timer1.Interval = value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = !this.timer1.Enabled;
            this.btnStart.Text = this.timer1.Enabled ? "停止" : "开始";
        }

        private ClickType clickType = ClickType.LeftRight;
        private bool lastLeft = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.clickType)
            {
                case ClickType.Left:
                    SmileWei.MouseKeyboardHook.MouseSimulator.Click(SmileWei.MouseKeyboardHook.MouseButton.Left);
                    break;
                case ClickType.Right:
                    SmileWei.MouseKeyboardHook.MouseSimulator.Click(SmileWei.MouseKeyboardHook.MouseButton.Right);
                    break;
                case ClickType.LeftRight:
                    if (this.lastLeft)
                    {
                        SmileWei.MouseKeyboardHook.MouseSimulator.Click(SmileWei.MouseKeyboardHook.MouseButton.Left);
                        this.lastLeft = true;
                    }
                    else
                    {
                        SmileWei.MouseKeyboardHook.MouseSimulator.Click(SmileWei.MouseKeyboardHook.MouseButton.Right);
                        this.lastLeft = false;
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void rdoLeftClick_CheckedChanged(object sender, EventArgs e)
        {
            this.clickType = ClickType.Left;
        }

        private void rdoRightClick_CheckedChanged(object sender, EventArgs e)
        {
            this.clickType = ClickType.Right;
        }

        private void rdoBoth_CheckedChanged(object sender, EventArgs e)
        {
            this.clickType = ClickType.LeftRight;
        }
    }

    enum ClickType
    {
        Left,
        Right,
        LeftRight,
    }
}
