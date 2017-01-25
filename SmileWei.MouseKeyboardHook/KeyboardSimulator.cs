using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace SmileWei.MouseKeyboardHook
{
    public static class KeyboardSimulator
    {
        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte key, byte scan, int flags, int extraInfo);
        [DllImport("user32.dll")]
        static extern byte MapVirtualKey(byte wCode, int wMap);

        public static void KeyDown(Keys key)
        {
            byte k = KeyboardSimulator.ParseKey(key);
            KeyboardSimulator.keybd_event(k, MapVirtualKey(k, 0), 0, 0);
        }
        public static void KeyUp(Keys key)
        {
            byte k = KeyboardSimulator.ParseKey(key);
            KeyboardSimulator.keybd_event(k, MapVirtualKey(k, 0), 2, 0);
        }
        public static void KeyPress(Keys key)
        {
            KeyboardSimulator.KeyDown(key);
            KeyboardSimulator.KeyUp(key);
        }
        public static void SimulateStandardShortcut(StandardShortcut shortcut)
        {
            switch (shortcut)
            {
                case StandardShortcut.Copy:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.C);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.Cut:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.X);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.Paste:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.V);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.SelectAll:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.A);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.Save:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.S);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.Open:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.O);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.New:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.N);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                case StandardShortcut.Close:
                    KeyboardSimulator.KeyDown(Keys.Alt);
                    KeyboardSimulator.KeyPress(Keys.F4);
                    KeyboardSimulator.KeyUp(Keys.Alt);
                    return;
                case StandardShortcut.Print:
                    KeyboardSimulator.KeyDown(Keys.Control);
                    KeyboardSimulator.KeyPress(Keys.P);
                    KeyboardSimulator.KeyUp(Keys.Control);
                    return;
                default:
                    return;
            }
        }
        private static byte ParseKey(Keys key)
        {
            if (key == Keys.Shift)
            {
                return 16;
            }
            if (key == Keys.Control)
            {
                return 17;
            }
            if (key == Keys.Alt)
            {
                return 18;
            }
            return (byte)key;
        }
    }
}
