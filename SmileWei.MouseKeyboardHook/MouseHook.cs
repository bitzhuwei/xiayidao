using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace SmileWei.MouseKeyboardHook
{
    public class MouseHook : GlobalHook
    {
        private enum MouseEventType
        {
            None,
            MouseDown,
            MouseUp,
            DoubleClick,
            MouseWheel,
            MouseMove
        }
        public event MouseEventHandler MouseDown;
        public event MouseEventHandler MouseUp;
        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseWheel;
        public event EventHandler Click;
        public event EventHandler DoubleClick;

        private const int WH_MOUSE_LL = 14;

        public MouseHook()
            : base(WH_MOUSE_LL)
        {
        }
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode > -1 && (this.MouseDown != null || this.MouseUp != null || this.MouseMove != null))
            {
                GlobalHook.MouseLLHookStruct mouseLLHookStruct = (GlobalHook.MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(GlobalHook.MouseLLHookStruct));
                MouseButtons button = this.GetButton(wParam);
                MouseHook.MouseEventType mouseEventType = this.GetEventType(wParam);
                MouseEventArgs e = new MouseEventArgs(button, (mouseEventType == MouseHook.MouseEventType.DoubleClick) ? 2 : 1, mouseLLHookStruct.pt.x, mouseLLHookStruct.pt.y, (int)((mouseEventType == MouseHook.MouseEventType.MouseWheel) ? ((short)(mouseLLHookStruct.mouseData >> 16 & 65535)) : 0));
                if (button == MouseButtons.Right && mouseLLHookStruct.flags != 0)
                {
                    mouseEventType = MouseHook.MouseEventType.None;
                }
                switch (mouseEventType)
                {
                    case MouseHook.MouseEventType.MouseDown:
                        if (this.MouseDown != null)
                        {
                            this.MouseDown(this, e);
                        }
                        break;
                    case MouseHook.MouseEventType.MouseUp:
                        if (this.Click != null)
                        {
                            this.Click(this, new EventArgs());
                        }
                        if (this.MouseUp != null)
                        {
                            this.MouseUp(this, e);
                        }
                        break;
                    case MouseHook.MouseEventType.DoubleClick:
                        if (this.DoubleClick != null)
                        {
                            this.DoubleClick(this, new EventArgs());
                        }
                        break;
                    case MouseHook.MouseEventType.MouseWheel:
                        if (this.MouseWheel != null)
                        {
                            this.MouseWheel(this, e);
                        }
                        break;
                    case MouseHook.MouseEventType.MouseMove:
                        if (this.MouseMove != null)
                        {
                            this.MouseMove(this, e);
                        }
                        break;
                }
            }
            return GlobalHook.CallNextHookEx(this._handleToHook, nCode, wParam, lParam);
        }
        private MouseButtons GetButton(int wParam)
        {
            switch (wParam)
            {
                case 513:
                case 514:
                case 515:
                    return MouseButtons.Left;
                case 516:
                case 517:
                case 518:
                    return MouseButtons.Right;
                case 519:
                case 520:
                case 521:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;
            }
        }
        private MouseHook.MouseEventType GetEventType(int wParam)
        {
            switch (wParam)
            {
                case 512:
                    return MouseHook.MouseEventType.MouseMove;
                case 513:
                case 516:
                case 519:
                    return MouseHook.MouseEventType.MouseDown;
                case 514:
                case 517:
                case 520:
                    return MouseHook.MouseEventType.MouseUp;
                case 515:
                case 518:
                case 521:
                    return MouseHook.MouseEventType.DoubleClick;
                case 522:
                    return MouseHook.MouseEventType.MouseWheel;
                default:
                    return MouseHook.MouseEventType.None;
            }
        }
    }
}
