using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace jyzj.shouye.Winform
{
    public class WindowsAPI
    {
        public delegate bool CallBack(IntPtr pwnd, int lParam);
        private struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public WindowsAPI.POINT ptScreenPos;
        }
        public delegate bool EnumWindowsProc(IntPtr pHandle, int p_Param);
        public struct POINT
        {
            public int X;
            public int Y;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Down;
            public override string ToString()
            {
                return string.Concat(new object[]
				{
					"{Left:",
					this.Left,
					", Up:",
					this.Top,
					", RightPP:",
					this.Right,
					"DownPP:",
					this.Down,
					"}"
				});
            }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct STRINGBUFFER
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string szText;
        }
        public const uint KEYEVENTF_KEYDOWN = 0u;
        public const uint KEYEVENTF_KEYUP = 2u;
        private const int STRINGBUFFER_SizeConst = 512;
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteObject(IntPtr hObject);
        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, WindowsAPI.CallBack lpfn, int lParam);
        [DllImport("user32.dll")]
        public static extern int EnumWindows(WindowsAPI.EnumWindowsProc ewp, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, StringBuilder lpszClass, StringBuilder lpszWindow);
        public static int GetClassName(IntPtr hWnd, out string lpString)
        {
            WindowsAPI.STRINGBUFFER sTRINGBUFFER = default(WindowsAPI.STRINGBUFFER);
            int className = WindowsAPI.GetClassName(hWnd, out sTRINGBUFFER, 512);
            lpString = sTRINGBUFFER.szText;
            return className;
        }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, out WindowsAPI.STRINGBUFFER lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern IntPtr GetCursor();
        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out WindowsAPI.CURSORINFO pci);
        public static int GetCursorPos(ref Point lpPoint)
        {
            WindowsAPI.POINT pOINT = default(WindowsAPI.POINT);
            int cursorPos = WindowsAPI.GetCursorPos(ref pOINT);
            lpPoint.X = pOINT.X;
            lpPoint.Y = pOINT.Y;
            return cursorPos;
        }
        [DllImport("user32.dll")]
        private static extern int GetCursorPos(ref WindowsAPI.POINT lpPoint);
        public static string GetCursorShape()
        {
            string result;
            try
            {
                WindowsAPI.CURSORINFO cURSORINFO = default(WindowsAPI.CURSORINFO);
                cURSORINFO.cbSize = Marshal.SizeOf(cURSORINFO);
                WindowsAPI.GetCursorInfo(out cURSORINFO);
                if (cURSORINFO.flags == 1)
                {
                    result = new Cursor(cURSORINFO.hCursor).ToString();
                }
                else
                {
                    result = "(Hidden)";
                }
            }
            catch (Exception)
            {
                result = "(Failure)";
            }
            return result;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        public static Bitmap GetDesktop()
        {
            IntPtr dC = WindowsAPI.GetDC(WindowsAPI.GetDesktopWindow());
            IntPtr intPtr = WindowsAPI.CreateCompatibleDC(dC);
            int systemMetrics = WindowsAPI.GetSystemMetrics(0);
            int systemMetrics2 = WindowsAPI.GetSystemMetrics(1);
            IntPtr intPtr2 = WindowsAPI.CreateCompatibleBitmap(dC, systemMetrics, systemMetrics2);
            if (intPtr2 != IntPtr.Zero)
            {
                IntPtr hgdiobjBm = WindowsAPI.SelectObject(intPtr, intPtr2);
                WindowsAPI.BitBlt(intPtr, 0, 0, systemMetrics, systemMetrics2, dC, 0, 0, 13369376);
                WindowsAPI.SelectObject(intPtr, hgdiobjBm);
                WindowsAPI.DeleteDC(intPtr);
                WindowsAPI.ReleaseDC(WindowsAPI.GetDesktopWindow(), dC);
                Bitmap result = Image.FromHbitmap(intPtr2);
                WindowsAPI.DeleteObject(intPtr2);
                GC.Collect();
                return result;
            }
            return null;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);
        [DllImport("user32.dll")]
        public static extern int GetWindow(int hwnd, int wCmd);
        public static bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect)
        {
            WindowsAPI.Rect rect = default(WindowsAPI.Rect);
            WindowsAPI.GetWindowRect(hWnd, out rect);
            lpRect = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Down - rect.Top);
            return true;
        }
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out WindowsAPI.Rect lpRect);
        public static int GetWindowText(IntPtr hWnd, out string text)
        {
            WindowsAPI.STRINGBUFFER sTRINGBUFFER = default(WindowsAPI.STRINGBUFFER);
            int windowText = WindowsAPI.GetWindowText(hWnd, out sTRINGBUFFER, 512);
            text = sTRINGBUFFER.szText;
            return windowText;
        }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, out WindowsAPI.STRINGBUFFER text, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);
        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobjBm);
        [DllImport("user32.dll")]
        public static extern bool SetCurorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point Point);
    }
}
