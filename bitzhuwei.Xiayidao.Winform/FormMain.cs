using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using SmileWei.CursorInfo;
using SmileWei.MouseKeyboardHook;

namespace bitzhuwei.Xiayidao.Winform
{
    public partial class FormMain : Form
    {
        private const string strConfigFile = "xiayidao.dantiaoban.xml";
        private double _currentRadius;
        private double _angle;
        private Point _currentPoint = default(Point);
        private Pen _anglePen = new Pen(Color.Aqua);
        private SolidBrush _keyPointBrush = new SolidBrush(Color.Aqua);
        public static readonly int xueLeft = 61;
        public static readonly int xueTop = 3;
        public static readonly int xueRight = 119;
        public static readonly int lanLeft = 252;
        public static readonly int lanTop = 3;
        public static readonly int lanRight = 310;
        public static readonly int tiLeft = 441;
        public static readonly int tiTop = 3;
        public static readonly int tiRight = 499;
        public static readonly int renLeft = 694;
        public static readonly int renTop = 19;
        public static readonly int renRight = 734;
        public static readonly int wugongMinLeft = 468;
        public static readonly int wugongTop = 507;
        public static readonly int xueYaoLeft = 298;
        public static readonly int xueYaoTop = 526;
        public static readonly int xueYaoRight = FormMain.xueYaoLeft + 22;
        public static readonly int lanYaoLeft = 334;
        public static readonly int lanYaoTop = 526;
        public static readonly int lanYaoRight = FormMain.lanYaoLeft + 22;
        public static readonly int tiYaoLeft = 370;
        public static readonly int tiYaoTop = 526;
        public static readonly int tiYaoRight = FormMain.tiYaoLeft + 22;
        public static readonly int killedOfNineLeft = 72;
        public static readonly int killedOfNineTop = 37;
        public static readonly int killedOfNineRight = 332;
        private SpecifiedCursor _pci;
        private Cursor _cur;
        private Bitmap _curImage;
        private string _mouseShape = string.Empty;
        private EMouseShape _emouseShape;
        private int _xueNow;
        private int _xueFull;
        private int _lanNow;
        private int _lanFull;
        private int _tiNow;
        private int _tiFull;
        private int _renX;
        private int _renY;
        private int _wugongNow;
        private int _wugongFull;
        private int _xueYao;
        private int _lanYao;
        private int _tiYao;
        private Rectangle _xydClientRect = Rectangle.Empty;
        private Point _originalPostion = Point.Empty;
        //private Point _expPoint = default(Point);
        private CircleClickSettings _settings;
        private EGameState _state = EGameState.未知;
        private Point _runAwayPoint = default(Point);
        private Bitmap[] _killedOfNineImages = new Bitmap[10];
        private MemoryStream[] _killedOfNineImageStreams = new MemoryStream[10];
        private Rectangle[] _killedOfNineRects = new Rectangle[10];
        private static readonly int wugongKuangCenterX = 450;
        private static readonly int wugongKuangCenterY = 540;
        private Point _wugongPoint = new Point(FormMain.wugongKuangCenterX, FormMain.wugongKuangCenterY);
        private Target _target = new Target();
        private Random _randomInitialAngle = new Random();
        private int _killed;
        public int _killedOfNine;
        private int _usedTime;
        public FormMain()
        {
            InitializeComponent();
			this.tmrGuaWugong = new System.Windows.Forms.Timer();
			this.tmrGuaWugong.Interval = 100;
			this.tmrGuaWugong.Tick += new System.EventHandler(this.tmrGuaWugong_Tick);
			this.picCursor.Click += new System.EventHandler(this.picCursor_Click);
        }
		void picCursor_Click(object sender, EventArgs e)
		{
			if (!this.intelligentClick.IsBusy)
			{
				if (tmrGuaWugong.Enabled)
				{
					tmrGuaWugong.Stop();
					MessageBox.Show("挂武功已取消。");
				}
				else
				{
					MessageBox.Show("开始挂武功。");
					tmrGuaWugong.Start();					
				}
			}
		}
		System.Windows.Forms.Timer tmrGuaWugong;// = new Timer();
		void tmrGuaWugong_Tick(object sender, EventArgs e)
		{
			this._xydClientRect = FormMain.GetXYDClientRect();
			var center = new Point(this._xydClientRect.X + this._xydClientRect.Width / 2, 
				this._xydClientRect.Y + this._xydClientRect.Height / 2 - 90);
			var mouse = Control.MousePosition;
			if (Math.Abs(mouse.X - center.X) >= this._xydClientRect.Width / 2
				|| Math.Abs(mouse.Y - center.Y) >= this._xydClientRect.Height / 2)
			{ tmrGuaWugong.Enabled = false; }
			//MouseSimulator.Position = center;
			MouseSimulator.Click(MouseButton.Right);
		}
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("角度: " + this._angle.ToString("f5"));
            stringBuilder.AppendLine("半径: " + this._currentRadius);
            stringBuilder.AppendLine("工作中: " + this.intelligentClick.IsBusy);
            stringBuilder.AppendLine("状态: " + this._state);
            stringBuilder.AppendLine("游戏窗口：" + this._xydClientRect);
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"鼠标：(",
				this._pci.ptScreenPos.x,
				", ",
				this._pci.ptScreenPos.y,
				")"
			}));
            stringBuilder.AppendLine("     " + this._mouseShape);
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"血：",
				this._xueNow,
				"/",
				this._xueFull
			}));
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"蓝：",
				this._lanNow,
				"/",
				this._lanFull
			}));
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"体：",
				this._tiNow,
				"/",
				this._tiNow
			}));
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"初始位置：",
				this._originalPostion.X,
				"/",
				this._originalPostion.Y
			}));
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"当前位置：",
				this._renX,
				"/",
				this._renY
			}));
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"武功：",
				this._wugongNow,
				"/",
				this._wugongFull
			}));
            stringBuilder.AppendLine(string.Concat(new object[]
			{
				"杀阵：",
				this._killedOfNine,
				"/",
				this._killed,
				"/",
				this._usedTime
			}));
            stringBuilder.AppendLine("血药：" + this._xueYao);
            stringBuilder.AppendLine("蓝药：" + this._lanYao);
            stringBuilder.AppendLine("体药：" + this._tiYao);
            return stringBuilder.ToString();
        }
        private void chkNoSkill_Click(object sender, EventArgs e)
        {
            this.chkNoSkill.Checked = false;
            MessageBox.Show("由于缺失必要资源，无法使用左键砍杀功能。", "提示");
        }
		
		Bitmap bmpXue, bmpLan, bmpTi, bmpRen, bmpWugong, bmpXueYao, bmpLanYao, bmpTiYao, bmpShazhen;
		Graphics gXue, gLan, gTi, gRen, gWugong, gXueYao, gLanYao, gTiYao, gShazhen;
        private void tmrCircleClick_Tick(object sender, EventArgs e)
        {
            this._xydClientRect = FormMain.GetXYDClientRect();
            this._pci = CursorHandler.GetCursorInfo();
            int width = this.picCursor.Width;
            int height = this.picCursor.Height;
            Graphics graphics = Graphics.FromImage(this._curImage);
            try
            {
                this._cur = CursorHandler.GetWinFormCursor(this._pci);
                graphics.CopyFromScreen(new Point(this._pci.ptScreenPos.x - width / 2, this._pci.ptScreenPos.y - height / 2), new Point(0, 0), new Size(width, height));
                graphics.DrawLine(this._anglePen, (float)(width / 2), (float)(height / 2), (float)(-(float)(this._pci.ptScreenPos.x - this._xydClientRect.X - this._xydClientRect.Width / 2) + width / 2), (float)(-(float)(this._pci.ptScreenPos.y - this._xydClientRect.Y - this._xydClientRect.Height / 2) + height / 2));
                if (this._cur != null)
                {
                    this._cur.Draw(graphics, new Rectangle(width / 2 - this._cur.HotSpot.X, height / 2 - this._cur.HotSpot.Y, this._cur.Size.Width, this._cur.Size.Height));
                }
            }
            catch (Exception)
            {
            }
            Color pixel = this._curImage.GetPixel(width / 2 + 18, height / 2 + 15);
            this._keyPointBrush.Color = pixel;
            graphics.FillRectangle(this._keyPointBrush, 1, 1, 9, 9);
            graphics.DrawRectangle(this._anglePen, 0, 0, 10, 10);
            if (pixel.R == 192 && pixel.G == 64 && pixel.B == 64)
            {
                this._mouseShape = "刀";
                this._emouseShape = EMouseShape.Kill;
            }
            else
            {
                if (pixel.R == 224 && pixel.G == 192 && pixel.B == 128)
                {
                    this._mouseShape = "手";
                    this._emouseShape = EMouseShape.Get;
                }
                else
                {
                    this._mouseShape = "常";
                    this._emouseShape = EMouseShape.Normal;
                }
            }
            object mouseShape = this._mouseShape;
            this._mouseShape = string.Concat(new object[]
			{
				mouseShape,
				"(",
				pixel.R,
				",",
				pixel.G,
				",",
				pixel.B,
				")"
			});
            this.picCursor.Image = this._curImage;
            {
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.xueLeft, this._xydClientRect.Y + FormMain.xueTop, FormMain.xueRight - FormMain.xueLeft + 1, 10);
				if (bmpXue == null)	
				{
					bmpXue = new Bitmap(this.picXue.Width, this.picXue.Height);
					gXue = Graphics.FromImage(bmpXue);			
				}
				gXue.CopyFromScreen(new Point(rectangle.X, rectangle.Y), new Point(0, 0), new Size(this.picXue.Width, this.picXue.Height));
				this.picXue.Image = bmpXue;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpXue, rectangle.Width + 1 - 6, 0, false);
				this._xueNow = twoNumbers.Item1;
				this._xueFull = twoNumbers.Item2;
			}
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.lanLeft, this._xydClientRect.Y + FormMain.lanTop, FormMain.lanRight - FormMain.lanLeft + 1, 10);
				if (bmpLan == null) 
				{
					bmpLan = new Bitmap(this.picLan.Width, this.picLan.Height);
					gLan = Graphics.FromImage(bmpLan);
				}
				gLan.CopyFromScreen(new Point(rectangle.X, rectangle.Y), new Point(0, 0), new Size(this.picLan.Width, this.picLan.Height));
				this.picLan.Image = bmpLan;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpLan, rectangle.Width + 1 - 6, 0, false);
				this._lanNow = twoNumbers.Item1;
				this._lanFull = twoNumbers.Item2;
			}
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.tiLeft, this._xydClientRect.Y + FormMain.tiTop, FormMain.tiRight - FormMain.tiLeft + 1, 10);
				if (bmpTi == null) 
				{
					bmpTi = new Bitmap(this.picTi.Width, this.picTi.Height);
					gTi = Graphics.FromImage(bmpTi);
				}
				gTi.CopyFromScreen(new Point(rectangle.X, rectangle.Y), new Point(0, 0), new Size(this.picTi.Width, this.picTi.Height));
				this.picTi.Image = bmpTi;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpTi, rectangle.Width + 1 - 6, 0, false);
				this._tiNow = twoNumbers.Item1;
				this._tiFull = twoNumbers.Item2;
			}
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.renLeft, this._xydClientRect.Y + FormMain.renTop, FormMain.renRight - FormMain.renLeft + 1, 10);
				if (bmpRen == null) 
				{
					bmpRen = new Bitmap(this.picRen.Width, this.picRen.Height);
					gRen = Graphics.FromImage(bmpRen);
				}
				gRen.CopyFromScreen(rectangle.Location, Point.Empty, this.picRen.Size);
				this.picRen.Image = bmpRen;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpRen, 0, 0, true);
				this._renX = twoNumbers.Item1;
				this._renY = twoNumbers.Item2;
			}
            if (!this._settings._noSkill)
            {
                for (int i = 0; i < 12; i++)
                {
                    var rectangle = new Rectangle(this._xydClientRect.X + FormMain.wugongMinLeft + i, this._xydClientRect.Y + FormMain.wugongTop, 53, 10);
                    if (bmpWugong == null) 
					{
						bmpWugong = new Bitmap(this.picWugong.Width, this.picWugong.Height);
						gWugong = Graphics.FromImage(bmpWugong);
                    }
					gWugong.CopyFromScreen(rectangle.Location, Point.Empty, this.picWugong.Size);
                    int num = NumberSign.Parse(bmpWugong, 0, 0, NumberSign._wugongNumberColor);
                    if (10 > num && num >= 0)
                    {
                        this.picWugong.Image = bmpWugong;
                        Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpWugong, 0, 0, true, NumberSign._wugongNumberColor);
                        this._wugongNow = twoNumbers.Item1;
                        this._wugongFull = twoNumbers.Item2;
                        break;
                    }
                }
            }
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.xueYaoLeft, this._xydClientRect.Y + FormMain.xueYaoTop, FormMain.xueYaoRight - FormMain.xueYaoLeft + 1, 10);
				if (bmpXueYao == null) 
				{
					bmpXueYao = new Bitmap(this.picXueYao.Width, this.picXueYao.Height);
					gXueYao = Graphics.FromImage(bmpXueYao);
				}
				gXueYao.CopyFromScreen(rectangle.Location, Point.Empty, this.picXueYao.Size);
				this.picXueYao.Image = bmpXueYao;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpXueYao, 0, 0, true);
				this._xueYao = twoNumbers.Item1;
			}
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.lanYaoLeft, this._xydClientRect.Y + FormMain.lanYaoTop, FormMain.lanYaoRight - FormMain.lanYaoLeft + 1, 10);
				if (bmpLanYao == null) 
				{
					bmpLanYao = new Bitmap(this.picLanYao.Width, this.picLanYao.Height);
					gLanYao = Graphics.FromImage(bmpLanYao);
				}
				gLanYao.CopyFromScreen(rectangle.Location, Point.Empty, this.picLanYao.Size);
				this.picLanYao.Image = bmpLanYao;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpLanYao, 0, 0, true);
				this._lanYao = twoNumbers.Item1;
			}
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.tiYaoLeft, this._xydClientRect.Y + FormMain.tiYaoTop, FormMain.tiYaoRight - FormMain.tiYaoLeft + 1, 10);
				if (bmpTiYao == null) 
				{
					bmpTiYao = new Bitmap(this.picTiYao.Width, this.picTiYao.Height);
					gTiYao = Graphics.FromImage(bmpTiYao);
				}
				gTiYao.CopyFromScreen(rectangle.Location, Point.Empty, rectangle.Size);
				this.picTiYao.Image = bmpTiYao;
				Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bmpTiYao, 0, 0, true);
				this._tiYao = twoNumbers.Item1;
			}
			{
				var rectangle = new Rectangle(this._xydClientRect.X + FormMain.killedOfNineLeft, this._xydClientRect.Y + FormMain.killedOfNineTop, FormMain.killedOfNineRight - FormMain.killedOfNineLeft + 1, 10);
				if (bmpShazhen == null) 
				{
					bmpShazhen = new Bitmap(rectangle.Width, rectangle.Height);
					gShazhen = Graphics.FromImage(bmpShazhen);
				}
				gShazhen.CopyFromScreen(rectangle.Location, Point.Empty, rectangle.Size);
				this._killedOfNine = this.GetKilledOfNine(bmpShazhen);
				this.picShazhen.Image = this._killedOfNineImages[this._killedOfNine];
			}
            this.lblState.Text = this.ToString();
        }
        public static Rectangle GetXYDClientRect()
        {
            IntPtr intPtr = WindowsAPI.FindWindow("XYDClient", null);
            if (intPtr == IntPtr.Zero)
            {
                return Rectangle.Empty;
            }
            Rectangle empty = Rectangle.Empty;
            WindowsAPI.GetWindowRect(intPtr, out empty);
            return empty;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.intelligentClick.IsBusy)
            {
                this._xydClientRect = FormMain.GetXYDClientRect();
                this.circleX.Value = this._xydClientRect.X + this._xydClientRect.Width / 2;
                this.circleY.Value = this._xydClientRect.Y + this._xydClientRect.Height / 2;
                Rectangle rectangle = new Rectangle(this._xydClientRect.X + FormMain.renLeft, this._xydClientRect.Y + FormMain.renTop, FormMain.renRight - FormMain.renLeft + 1, 10);
                Bitmap bitmap = new Bitmap(this.picRen.Width, this.picRen.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(rectangle.Location, Point.Empty, this.picRen.Size);
                this.picRen.Image = bitmap;
                Tuple<int, int> twoNumbers = NumberSign.GetTwoNumbers(bitmap, 0, 0, true);
                this._renX = twoNumbers.Item1;
                this._renY = twoNumbers.Item2;
                this._originalPostion.X = this._renX;
                this._originalPostion.Y = this._renY;
                this.UpdateSettings();
                this._currentRadius = (double)this._settings._minRadius;
                this._angle = 0.0;
                this.UpdatePatrolRect((int)this.patrolRadiusX.Value, (int)this.patrolRadiusY.Value);
                //MessageBox.Show(string.Format("{0}", this.leaveOriginalPosition.Length));
                this.intelligentClickCancelled = false;
				this.tmrGuaWugong.Stop();
                this.tmrCircleClick.Start();
                this.intelligentClick.RunWorkerAsync();
                this.btnStart.Text = "停止";
            }
            else
            {
				this.intelligentClickCancelled = true;
                this.intelligentClick.CancelAsync();
                this.tmrCircleClick.Stop();
                this.btnStart.Text = "开始";
            }
        }
		
		private bool intelligentClickCancelled = false;

        private void UpdatePatrolRect(int radiusX, int radiusY)
        {
            this.leaveOriginalPosition = new Tuple<int, int>[(radiusX * 2 + 1) * (radiusY * 2 + 1)];
            int index = 0;
            for (int i = -radiusX; i <= radiusX; i++)
            {
                for (int j = -radiusY; j <= radiusY; j++)
                {
                    this.leaveOriginalPosition[index] = new Tuple<int, int>(i, j);
                    index++;
                }
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.lblState.Text = "";
            if (File.Exists("xiayidao.dantiaoban.xml"))
            {
                XElement xCircleClickSettings = XElement.Load("xiayidao.dantiaoban.xml");
                this._settings = CircleClickSettings.From(xCircleClickSettings);
            }
            if (this._settings == null)
            {
                this._settings = new CircleClickSettings();
            }
            this.UpdateControls(this._settings);
            this._currentRadius = (double)this._settings._minRadius;
            this._angle = 0.0;
            EventHandler value = new EventHandler(this.circleX_ValueChanged);
            this.circleX.ValueChanged += value;
            this.circleY.ValueChanged += value;
            this.minRadius.ValueChanged += value;
            this.maxRadius.ValueChanged += value;
            this.pointDistance.ValueChanged += value;
            this.roundDistance.ValueChanged += value;
            this.timeInterval.ValueChanged += value;
            this.chkBack.CheckedChanged += value;
            this.runAwayXueYao.ValueChanged += value;
            this.runAwayLanYao.ValueChanged += value;
            this.chkHand.CheckedChanged += value;
            this.chkHandFirst.CheckedChanged += value;
            this.chkNoSkill.CheckedChanged += value;
            this.noSkillInterval.ValueChanged += value;
            this.chkClick.CheckedChanged += value;
            this._curImage = new Bitmap(this.picCursor.Width, this.picCursor.Height);
            int num = 0;
            int y = 0;
            int width = 5;
            int height = 10;
            int num2 = 32;
            for (int i = 0; i < this._killedOfNineRects.Length; i++)
            {
                this._killedOfNineRects[i] = new Rectangle(num, y, width, height);
                num += num2;
            }
            try
            {
                for (int j = 0; j < this._killedOfNineImages.Length; j++)
                {
                    this._killedOfNineImages[j] = new Bitmap(Path.Combine(Application.StartupPath, "shazhen\\shazhen" + j.ToString() + ".bmp"));
                    this._killedOfNineImageStreams[j] = new MemoryStream();
                    this._killedOfNineImages[j].Save(this._killedOfNineImageStreams[j], ImageFormat.Bmp);
                }
            }
            catch (Exception)
            {
                this.chkNoSkill.Checked = false;
                this.chkNoSkill.ForeColor = Color.Gray;
                this.noSkillInterval.Enabled = false;
                this.chkNoSkill.Click += new EventHandler(this.chkNoSkill_Click);
            }
        }
        private void UpdateSettings()
        {
            this._settings._circleX = (int)this.circleX.Value;
            this._settings._circleY = (int)this.circleY.Value;
            this._settings._minRadius = (int)this.minRadius.Value;
            this._settings._maxRadius = (int)this.maxRadius.Value;
            this._settings._pointDistance = (int)this.pointDistance.Value;
            this._settings._roundDistance = (int)this.roundDistance.Value;
            this._settings._timeInterval = (int)this.timeInterval.Value;
            this._settings._back = this.chkBack.Checked;
            this._settings._simulateMouse = this.chkClick.Checked;
            this._settings._noSkill = this.chkNoSkill.Checked;
            this._settings._noSkillInterval = (int)this.noSkillInterval.Value;
            this.noSkillInterval.Enabled = this._settings._noSkill;
            this._settings._hand = this.chkHand.Checked;
            this._settings._handFirst = (this.chkHand.Checked && this.chkHandFirst.Checked);
            this._settings._runAwayXueYao = (int)this.runAwayXueYao.Value;
            this._settings._runAwayLanYao = (int)this.runAwayLanYao.Value;
        }
        private void UpdateControls(CircleClickSettings settings)
        {
            this.circleX.Value = settings._circleX;
            this.circleY.Value = settings._circleY;
            this.minRadius.Value = settings._minRadius;
            this.maxRadius.Value = settings._maxRadius;
            this.pointDistance.Value = settings._pointDistance;
            this.roundDistance.Value = settings._roundDistance;
            this.timeInterval.Value = settings._timeInterval;
            this.chkBack.Checked = settings._back;
            this.chkClick.Checked = settings._simulateMouse;
            this.chkNoSkill.Checked = settings._noSkill;
            this.noSkillInterval.Value = settings._noSkillInterval;
            this.noSkillInterval.Enabled = settings._noSkill;
            this.chkHand.Checked = settings._hand;
            this.chkHandFirst.Checked = (settings._hand && settings._handFirst);
            this.runAwayXueYao.Value = settings._runAwayXueYao;
            this.runAwayLanYao.Value = settings._runAwayLanYao;
        }
        private void circleX_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateSettings();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._settings.Save("xiayidao.dantiaoban.xml");
        }
        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this._settings.ToXElement().ToString());
            MessageBox.Show(this.ToString());
        }
        Predicate<int> useWugongPredict = null;
        private void RunAway()
        {
            double num = this._randomInitialAngle.NextDouble() * 3.1415926535897931 * 2.0;
            this._runAwayPoint.X = (int)((double)(this._xydClientRect.Left + this._xydClientRect.Width / 2) + (double)this._settings._maxRadius * Math.Cos(num));
            this._runAwayPoint.Y = (int)((double)(this._xydClientRect.Top + this._xydClientRect.Height / 2) + (double)this._settings._maxRadius * Math.Sin(num));
            MouseSimulator.Position = this._runAwayPoint;
            MouseSimulator.Click(MouseButton.Left);
        }
        private void intelligentClick_DoWork(object sender, DoWorkEventArgs e)
        {
            if(useWugongPredict==null)
            {
                useWugongPredict = new Predicate<int>(x=>this._killed == this._killedOfNine);
            }
            this._state = EGameState.搜索;
            while (!this.intelligentClickCancelled)
            {
                if (!this._settings._noSkill && this._lanYao <= this._settings._runAwayLanYao && this._xueYao > this._settings._runAwayXueYao)
                {
                    this._settings._noSkill = true;
                    this.intelligentClick.ReportProgress(100);
                }
                if (this._xueYao <= this._settings._runAwayXueYao)
                {
                    this.RunAway();
                    this._state = EGameState.未知;
                    Thread.Sleep(3000);
                }
                else
                {
                    switch (this._state)
                    {
                        case EGameState.搜索:
                            while (!this.intelligentClickCancelled && this._settings._simulateMouse)
                            {
                                if (this._settings._back)
                                {
                                    this.GetBack();
                                }
                                this.FindTarget();
                                if (this._target.mouseShape == EMouseShape.Kill)
                                {
                                    if (!this.intelligentClickCancelled && this._settings._simulateMouse)
                                    {
                                        MouseSimulator.Position = this._target.location;
                                        if (this._settings._noSkill)
                                        {
											if (this._lanNow + this._lanNow >= this._lanFull)
											{ MouseSimulator.Click(MouseButton.Right); }
											else
                                            { MouseSimulator.Click(MouseButton.Left); }
                                        }
                                        else
                                        {
                                            MouseSimulator.Click(MouseButton.Right);
                                        }
                                        this._state = EGameState.定位;
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    if (this._target.mouseShape == EMouseShape.Get)
                                    {
                                        if (this.intelligentClickCancelled || !this._settings._simulateMouse)
                                        {
                                            break;
                                        }
                                        MouseSimulator.Position = this._target.location;
                                        MouseSimulator.Click(MouseButton.Right);
                                        Thread.Sleep(2500);
                                    }
                                    else
                                    {
                                        if (!this._settings._simulateMouse)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            this._state = EGameState.定位;
                            break;
                        case EGameState.定位:
                            this._killed = this._killedOfNine;
                            if (this._settings._noSkill)
                            {
                                this._state = EGameState.打怪;
                            }
                            else
                            {
								var current = DateTime.Now.Second;
								while ((this._killed == this._killedOfNine) && ((DateTime.Now.Second + 60 - current) % 60 <= 2))
								{
									Thread.Sleep(10);
								}
								if (this._killed != this._killedOfNine)
								{
									this.FindWupin();
									if (this._target.mouseShape == EMouseShape.Get)
									{
										MouseSimulator.Position = this._target.location;
										MouseSimulator.Click(MouseButton.Right);
										Thread.Sleep(701);
									}
								}
								if (!this.intelligentClickCancelled && this.UseWugong(2000, useWugongPredict) && this._settings._simulateMouse)
                                {
                                    this._state = EGameState.打怪;
                                }
                                else
                                {
                                    this._state = EGameState.搜索;
                                }
                            }
                            break;
                        case EGameState.打怪:
                            if (this._settings._noSkill)
                            {
                                int num = 100;
                                this._usedTime = this._settings._noSkillInterval;
                                while (this._usedTime > 0)
                                {
                                    Thread.Sleep(num);
                                    if (this._killed != this._killedOfNine)
                                    {
                                        break;
                                    }
                                    this._usedTime -= num;
									if (this._lanNow * 20 <= this._lanFull)
									{ break; /*MouseSimulator.Click(MouseButton.Left);*/ }
                                }
                            }
                            else
                            {
                                int minute = DateTime.Now.Minute;
                                
                                while(true)
                                {
                                    if (this.intelligentClickCancelled) break;
                                    if (!(this._settings._simulateMouse)) break;
                                    if (!this.UseWugong(2000, useWugongPredict))
									{
										if (this._killed != this._killedOfNine)
										{
											this.FindWupin();
											if (this._target.mouseShape == EMouseShape.Get)
											{
												MouseSimulator.Position = this._target.location;
												MouseSimulator.Click(MouseButton.Right);
												Thread.Sleep(701);
											}
										}
										break;
									}
                                    if ((DateTime.Now.Minute + 60 - minute) % 60 > 5) break;
                                }
                            }
                            this._state = EGameState.搜索;
                            break;
                        case EGameState.未知:
                            this._state = EGameState.搜索;
                            break;
                        default:
                            this._state = EGameState.搜索;
                            break;
                    }
                }
            }
        }
		
		private void FindWupin()
        {
            double num = this._randomInitialAngle.NextDouble() * 3.1415926535897931 * 2.0;
            this._angle = num;
            this._currentRadius = (double)this._settings._minRadius;
            this._target.mouseShape = EMouseShape.Normal;
            while (this._settings._hand && this._currentRadius <= 101.0)
            {
                this._currentPoint.X = (int)(this._currentRadius * Math.Cos(this._angle) + (double)this._settings._circleX);
                this._currentPoint.Y = (int)(-this._currentRadius * Math.Sin(this._angle) + (double)this._settings._circleY);
                if (this.intelligentClickCancelled || !this._settings._simulateMouse)
                {
                    return;
                }
                MouseSimulator.Position = this._currentPoint;
                Thread.Sleep(this._settings._timeInterval);
                if (!this._settings._simulateMouse)
                {
                    break;
                }
                if (this._emouseShape == EMouseShape.Get)
                {
                    this._target.mouseShape = this._emouseShape;
                    this._target.location = new Point(this._currentPoint.X, this._currentPoint.Y);
                    return;
                }
                this._angle += 2.0 * Math.Asin((double)this._settings._pointDistance / this._currentRadius);
                if (this._angle > 6.2831853071795862 + num)
                {
                    this._angle = num;
                    this._currentRadius += (double)this._settings._roundDistance;
                }
            }
        }
		
        Tuple<int, int>[] leaveOriginalPosition
            = new Tuple<int, int>[] { 
            new Tuple<int,int>(-1,-1),
            new Tuple<int,int>(-1,0),
            new Tuple<int,int>(-1,1),
            new Tuple<int,int>(0,-1),
            new Tuple<int,int>(0,0),
            new Tuple<int,int>(0,1),
            new Tuple<int,int>(1,-1),
            new Tuple<int,int>(1,0),
            new Tuple<int,int>(1,1),
        };
        int leaveOriginalPositionIndex = 0;
        private void GetBack()
        {
            int num = (this._renX - this._originalPostion.X) * 50;
            int num2 = (this._renY - this._originalPostion.Y) * 20;
            this._target.location.X = this._xydClientRect.X + this._xydClientRect.Width / 2 - num
                + leaveOriginalPosition[leaveOriginalPositionIndex].Item1 * 50;
            this._target.location.Y = this._xydClientRect.Y + this._xydClientRect.Height / 2 - num2
                + leaveOriginalPosition[leaveOriginalPositionIndex].Item2 * 20;
            leaveOriginalPositionIndex++;
            if (leaveOriginalPositionIndex >= leaveOriginalPosition.Length)
            { leaveOriginalPositionIndex = 0; }
            this._target.mouseShape = EMouseShape.Normal;
            MouseSimulator.Position = this._target.location;
            Thread.Sleep(100);
            MouseSimulator.Click(MouseButton.Left);
            Thread.Sleep(300);
        }
        private int GetKilledOfNine(Bitmap killedOfNineImage)
        {
            int i;
            for (i = 0; i < 9; i++)
            {
                Bitmap image = killedOfNineImage.Clone(this._killedOfNineRects[i], killedOfNineImage.PixelFormat);
                if (!this.Same(image, i + 1))
                {
                    break;
                }
            }
            return i;
        }
        private bool Same(Bitmap image1, int index)
        {
            Bitmap bitmap = this._killedOfNineImages[index];
            if (image1.Width != bitmap.Width)
            {
                return false;
            }
            if (image1.Height != bitmap.Height)
            {
                return false;
            }
            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixel = image1.GetPixel(i, j);
                    Color pixel2 = bitmap.GetPixel(i, j);
                    if (pixel != pixel2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool UseWugong(int p, Predicate<int> interrupt)
        {
            this._wugongPoint.X = this._xydClientRect.X + FormMain.wugongKuangCenterX;
            this._wugongPoint.Y = this._xydClientRect.Y + FormMain.wugongKuangCenterY;
            if (this.intelligentClickCancelled || !this._settings._simulateMouse)
            {
                return false;
            }
            MouseSimulator.Position = this._wugongPoint;
            int num = (this._settings._timeInterval > 0) ? this._settings._timeInterval : 1;
            Thread.Sleep(num);
            int wugongNow = this._wugongNow;
            for (int i = num; i < p; i += num)
            {
                if(interrupt!=null)
                {
                    if (interrupt(i) == false)
                    { return false; }
                }
                Thread.Sleep(num);
                if (wugongNow != this._wugongNow)
                {
                    return true;
                }
            }
            return false;
        }
        private void FindTarget()
        {
            double num = this._randomInitialAngle.NextDouble() * 3.1415926535897931 * 2.0;
            this._angle = num;
            this._currentRadius = (double)this._settings._minRadius;
            this._target.mouseShape = EMouseShape.Normal;
            while (this._settings._hand && this._settings._handFirst && this._currentRadius <= 150.0)
            {
                this._currentPoint.X = (int)(this._currentRadius * Math.Cos(this._angle) + (double)this._settings._circleX);
                this._currentPoint.Y = (int)(-this._currentRadius * Math.Sin(this._angle) + (double)this._settings._circleY);
                if (this.intelligentClickCancelled || !this._settings._simulateMouse)
                {
                    return;
                }
                MouseSimulator.Position = this._currentPoint;
                Thread.Sleep(this._settings._timeInterval);
                if (!this._settings._simulateMouse)
                {
                    break;
                }
                if (this._emouseShape == EMouseShape.Get)
                {
                    this._target.mouseShape = this._emouseShape;
                    this._target.location = new Point(this._currentPoint.X, this._currentPoint.Y);
                    return;
                }
                this._angle += 2.0 * Math.Asin((double)this._settings._pointDistance / this._currentRadius);
                if (this._angle > 6.2831853071795862 + num)
                {
                    this._angle = num;
                    this._currentRadius += (double)this._settings._roundDistance;
                }
            }
            this._currentRadius = (double)this._settings._minRadius;
            while (this._currentRadius <= (double)this._settings._maxRadius)
            {
                this._currentPoint.X = (int)(this._currentRadius * Math.Cos(this._angle) + (double)this._settings._circleX);
                this._currentPoint.Y = (int)(-this._currentRadius * Math.Sin(this._angle) + (double)this._settings._circleY);
                if (this.intelligentClickCancelled || !this._settings._simulateMouse)
                {
                    return;
                }
                MouseSimulator.Position = this._currentPoint;
                Thread.Sleep(this._settings._timeInterval);
                if (!this._settings._simulateMouse)
                {
                    return;
                }
                if (this._emouseShape == EMouseShape.Kill || (this._settings._hand && this._emouseShape == EMouseShape.Get))
                {
                    this._target.mouseShape = this._emouseShape;
                    this._target.location = new Point(this._currentPoint.X, this._currentPoint.Y);
                    return;
                }
                this._angle += 2.0 * Math.Asin((double)this._settings._pointDistance / this._currentRadius);
                if (this._angle > 6.2831853071795862)
                {
                    this._angle = 0.0;
                    this._currentRadius += (double)this._settings._roundDistance;
                }
            }
        }
        private void intelligentClick_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                this.UpdateControls(this._settings);
            }
        }
        private void intelligentClick_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblState.Text = this.ToString();
        }
    }
}
