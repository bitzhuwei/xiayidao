using System;
namespace SmileWei.CursorInfo
{
	public struct SpecifiedCursor
	{
		public int cbSize;
		public int flags;
		public IntPtr hCursor;
		public POINT ptScreenPos;
	}
}
