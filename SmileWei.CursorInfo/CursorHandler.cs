using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace SmileWei.CursorInfo
{
	public class CursorHandler
	{
		private const int CURSOR_SHOWING = 1;
		[DllImport("user32.dll")]
		private static extern bool GetCursorInfo(out SpecifiedCursor pci);
		static readonly int cbSize = Marshal.SizeOf(typeof(SpecifiedCursor));
		public static SpecifiedCursor GetCursorInfo()
		{
			var result = default(SpecifiedCursor);
			result.cbSize = cbSize;//Marshal.SizeOf(typeof(SpecifiedCursor));
			CursorHandler.GetCursorInfo(out result);
			return result;
		}
	    static Cursor GetWinFormCursor(IntPtr hCursor)
		{
			Cursor result = null;
			try
			{
				result = new Cursor(hCursor);
			}
			catch (Exception)
			{
			}
			return result;
		}
		static Cursor GetWinFormCursor()
		{
			return CursorHandler.GetWinFormCursor(CursorHandler.GetCursorInfo().hCursor);
		}
		public static Cursor GetWinFormCursor(SpecifiedCursor cursor)
		{
			return CursorHandler.GetWinFormCursor(cursor.hCursor);
		}
	}
}
