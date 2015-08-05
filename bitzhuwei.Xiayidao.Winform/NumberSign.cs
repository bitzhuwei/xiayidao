using System;
using System.Drawing;
namespace bitzhuwei.Xiayidao.Winform
{
	internal class NumberSign
	{
		public const int line = 10;
		public const int column = 5;
		public int value;
		public bool[,] elements = new bool[10, 5];
		private static readonly NumberSign[] signs;
		public static readonly Color _defaultNumberColor;
		public static readonly Color _wugongNumberColor;
		public static readonly Color _experienceNumberColor;
		public static int Parse(Bitmap bmp, int x, int y)
		{
			return NumberSign.Parse(bmp, x, y, NumberSign._defaultNumberColor);
		}
		public static int Parse(Bitmap bmp, int x, int y, Color numberColor)
		{
			int num = NumberSign.signs.Length - 1;
			while (num >= 0 && !NumberSign.signs[num].Matches(bmp, x, y, numberColor))
			{
				num--;
			}
			return num;
		}
		public bool Matches(Bitmap bmp, int x, int y)
		{
			return this.Matches(bmp, x, y, NumberSign._defaultNumberColor);
		}
		public bool Matches(Bitmap bmp, int x, int y, Color numberColor)
		{
			bool flag = true;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (this.elements[i, j])
					{
						Color pixel = bmp.GetPixel(x + j, y + i);
						if (pixel.R != numberColor.R || pixel.G != numberColor.G || pixel.B != numberColor.B)
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag)
				{
					break;
				}
			}
			return flag;
		}
		protected NumberSign()
		{
		}
		static NumberSign()
		{
			NumberSign.signs = new NumberSign[11];
			NumberSign._defaultNumberColor = Color.FromArgb(240, 240, 216);
			NumberSign._wugongNumberColor = Color.FromArgb(216, 220, 216);
			NumberSign._experienceNumberColor = Color.FromArgb(216, 0, 0);
			NumberSign._defaultNumberColor = Color.FromArgb(240, 240, 216);
			NumberSign.signs[0] = new NumberSign();
			NumberSign numberSign = NumberSign.signs[0];
			numberSign.value = 0;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = true;
			numberSign.elements[3, 0] = true;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = true;
			numberSign.elements[4, 0] = true;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = false;
			numberSign.elements[4, 3] = false;
			numberSign.elements[4, 4] = true;
			numberSign.elements[5, 0] = true;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = false;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = true;
			numberSign.elements[6, 0] = true;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = true;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = true;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[1] = new NumberSign();
			numberSign = NumberSign.signs[1];
			numberSign.value = 1;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = false;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = false;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = false;
			numberSign.elements[2, 1] = true;
			numberSign.elements[2, 2] = true;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = false;
			numberSign.elements[3, 0] = false;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = true;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = false;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = false;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = true;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = false;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = true;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = false;
			numberSign.elements[7, 0] = false;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = true;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = false;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[2] = new NumberSign();
			numberSign = NumberSign.signs[2];
			numberSign.value = 2;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = true;
			numberSign.elements[3, 0] = true;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = true;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = false;
			numberSign.elements[4, 3] = true;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = true;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = false;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = true;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = false;
			numberSign.elements[7, 0] = true;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = false;
			numberSign.elements[8, 0] = true;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = true;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[3] = new NumberSign();
			numberSign = NumberSign.signs[3];
			numberSign.value = 3;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = true;
			numberSign.elements[3, 0] = false;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = true;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = true;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = false;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = true;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = true;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = true;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[4] = new NumberSign();
			numberSign = NumberSign.signs[4];
			numberSign.value = 4;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = false;
			numberSign.elements[1, 2] = false;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = false;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = true;
			numberSign.elements[2, 3] = true;
			numberSign.elements[2, 4] = false;
			numberSign.elements[3, 0] = false;
			numberSign.elements[3, 1] = true;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = true;
			numberSign.elements[3, 4] = false;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = true;
			numberSign.elements[4, 2] = false;
			numberSign.elements[4, 3] = true;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = true;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = false;
			numberSign.elements[5, 3] = true;
			numberSign.elements[5, 4] = false;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = true;
			numberSign.elements[6, 2] = true;
			numberSign.elements[6, 3] = true;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = false;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = true;
			numberSign.elements[7, 4] = false;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = false;
			numberSign.elements[8, 2] = false;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = true;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[5] = new NumberSign();
			numberSign = NumberSign.signs[5];
			numberSign.value = 5;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = true;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = true;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = false;
			numberSign.elements[3, 0] = true;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = false;
			numberSign.elements[4, 0] = true;
			numberSign.elements[4, 1] = true;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = true;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = false;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = true;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = true;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = true;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[6] = new NumberSign();
			numberSign = NumberSign.signs[6];
			numberSign.value = 6;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = true;
			numberSign.elements[2, 4] = false;
			numberSign.elements[3, 0] = true;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = false;
			numberSign.elements[4, 0] = true;
			numberSign.elements[4, 1] = true;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = true;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = true;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = false;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = true;
			numberSign.elements[6, 0] = true;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = true;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = true;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[7] = new NumberSign();
			numberSign = NumberSign.signs[7];
			numberSign.value = 7;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = true;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = true;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = true;
			numberSign.elements[2, 4] = false;
			numberSign.elements[3, 0] = false;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = true;
			numberSign.elements[3, 4] = false;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = false;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = true;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = false;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = true;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = false;
			numberSign.elements[7, 0] = false;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = true;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = false;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = false;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = false;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[8] = new NumberSign();
			numberSign = NumberSign.signs[8];
			numberSign.value = 8;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = true;
			numberSign.elements[3, 0] = true;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = true;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = true;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = true;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = true;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = false;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = true;
			numberSign.elements[6, 0] = true;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = true;
			numberSign.elements[7, 1] = false;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = true;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[9] = new NumberSign();
			numberSign = NumberSign.signs[9];
			numberSign.value = 9;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = false;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = true;
			numberSign.elements[1, 2] = true;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = true;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = false;
			numberSign.elements[2, 4] = true;
			numberSign.elements[3, 0] = true;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = false;
			numberSign.elements[3, 4] = true;
			numberSign.elements[4, 0] = true;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = false;
			numberSign.elements[4, 3] = false;
			numberSign.elements[4, 4] = true;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = true;
			numberSign.elements[5, 2] = true;
			numberSign.elements[5, 3] = true;
			numberSign.elements[5, 4] = true;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = false;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = true;
			numberSign.elements[7, 0] = false;
			numberSign.elements[7, 1] = true;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = true;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = true;
			numberSign.elements[8, 3] = true;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = false;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
			NumberSign.signs[10] = new NumberSign();
			numberSign = NumberSign.signs[10];
			numberSign.value = 10;
			numberSign.elements[0, 0] = false;
			numberSign.elements[0, 1] = false;
			numberSign.elements[0, 2] = false;
			numberSign.elements[0, 3] = false;
			numberSign.elements[0, 4] = true;
			numberSign.elements[1, 0] = false;
			numberSign.elements[1, 1] = false;
			numberSign.elements[1, 2] = false;
			numberSign.elements[1, 3] = true;
			numberSign.elements[1, 4] = false;
			numberSign.elements[2, 0] = false;
			numberSign.elements[2, 1] = false;
			numberSign.elements[2, 2] = false;
			numberSign.elements[2, 3] = true;
			numberSign.elements[2, 4] = false;
			numberSign.elements[3, 0] = false;
			numberSign.elements[3, 1] = false;
			numberSign.elements[3, 2] = false;
			numberSign.elements[3, 3] = true;
			numberSign.elements[3, 4] = false;
			numberSign.elements[4, 0] = false;
			numberSign.elements[4, 1] = false;
			numberSign.elements[4, 2] = true;
			numberSign.elements[4, 3] = false;
			numberSign.elements[4, 4] = false;
			numberSign.elements[5, 0] = false;
			numberSign.elements[5, 1] = false;
			numberSign.elements[5, 2] = true;
			numberSign.elements[5, 3] = false;
			numberSign.elements[5, 4] = false;
			numberSign.elements[6, 0] = false;
			numberSign.elements[6, 1] = true;
			numberSign.elements[6, 2] = false;
			numberSign.elements[6, 3] = false;
			numberSign.elements[6, 4] = false;
			numberSign.elements[7, 0] = false;
			numberSign.elements[7, 1] = true;
			numberSign.elements[7, 2] = false;
			numberSign.elements[7, 3] = false;
			numberSign.elements[7, 4] = false;
			numberSign.elements[8, 0] = false;
			numberSign.elements[8, 1] = true;
			numberSign.elements[8, 2] = false;
			numberSign.elements[8, 3] = false;
			numberSign.elements[8, 4] = false;
			numberSign.elements[9, 0] = true;
			numberSign.elements[9, 1] = false;
			numberSign.elements[9, 2] = false;
			numberSign.elements[9, 3] = false;
			numberSign.elements[9, 4] = false;
		}
		public static NumberSign GetNumber(EnumNumberSign eSign)
		{
			NumberSign numberSign = new NumberSign();
			NumberSign numberSign2 = NumberSign.signs[(int)eSign];
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					numberSign.elements[i, j] = numberSign2.elements[i, j];
					numberSign.value = numberSign2.value;
				}
			}
			return numberSign;
		}
		internal static Tuple<int, int> GetTwoNumbers(Bitmap myimage, int x, int y, bool leftToRight, Color numberColor)
		{
			if (leftToRight)
			{
				return NumberSign.GetTwoNumbersFromLeft(myimage, x, y, numberColor);
			}
			return NumberSign.GetTwoNumbersFromRight(myimage, x, y, numberColor);
		}
		internal static Tuple<int, int> GetTwoNumbers(Bitmap myimage, int x, int y, bool leftToRight)
		{
			return NumberSign.GetTwoNumbers(myimage, x, y, leftToRight, NumberSign._defaultNumberColor);
		}
		private static Tuple<int, int> GetTwoNumbersFromRight(Bitmap myimage, int x, int y, Color numberColor)
		{
			int num = 0;
			int num2 = 1;
			while (x >= 0)
			{
				int num3 = NumberSign.Parse(myimage, x, y, numberColor);
				if (9 < num3 || num3 < 0)
				{
					break;
				}
				num += num3 * num2;
				num2 *= 10;
				x -= 6;
			}
			for (x -= 6; x >= 0; x -= 6)
			{
				int num4 = NumberSign.Parse(myimage, x, y, numberColor);
				if (9 >= num4 && num4 >= 0)
				{
					break;
				}
			}
			int num5 = 0;
			num2 = 1;
			while (x >= 0)
			{
				int num6 = NumberSign.Parse(myimage, x, y, numberColor);
				if (9 < num6 || num6 < 0)
				{
					break;
				}
				num5 += num6 * num2;
				num2 *= 10;
				x -= 6;
			}
			return new Tuple<int, int>(num5, num);
		}
		private static Tuple<int, int> GetTwoNumbersFromLeft(Bitmap myimage, int x, int y, Color numberColor)
		{
			int num = 0;
			while (x < myimage.Width - 4)
			{
				int num2 = NumberSign.Parse(myimage, x, y, numberColor);
				if (9 < num2 || num2 < 0)
				{
					break;
				}
				num = num * 10 + num2;
				x += 6;
			}
			for (x += 6; x < myimage.Width - 4; x += 6)
			{
				int num3 = NumberSign.Parse(myimage, x, y, numberColor);
				if (9 >= num3 && num3 >= 0)
				{
					break;
				}
			}
			int num4 = 0;
			while (x < myimage.Width - 4)
			{
				int num5 = NumberSign.Parse(myimage, x, y, numberColor);
				if (9 < num5 || num5 < 0)
				{
					break;
				}
				num4 = num4 * 10 + num5;
				x += 6;
			}
			return new Tuple<int, int>(num, num4);
		}
	}
}
