using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bitzhuwei.Xiayidao.Winform
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.circleX = new System.Windows.Forms.NumericUpDown();
            this.circleY = new System.Windows.Forms.NumericUpDown();
            this.minRadius = new System.Windows.Forms.NumericUpDown();
            this.tmrCircleClick = new System.Windows.Forms.Timer(this.components);
            this.lblState = new System.Windows.Forms.Label();
            this.maxRadius = new System.Windows.Forms.NumericUpDown();
            this.picCursor = new System.Windows.Forms.PictureBox();
            this.chkClick = new System.Windows.Forms.CheckBox();
            this.pointDistance = new System.Windows.Forms.NumericUpDown();
            this.roundDistance = new System.Windows.Forms.NumericUpDown();
            this.timeInterval = new System.Windows.Forms.NumericUpDown();
            this.picXue = new System.Windows.Forms.PictureBox();
            this.picLan = new System.Windows.Forms.PictureBox();
            this.picTi = new System.Windows.Forms.PictureBox();
            this.picRen = new System.Windows.Forms.PictureBox();
            this.intelligentClick = new System.ComponentModel.BackgroundWorker();
            this.picWugong = new System.Windows.Forms.PictureBox();
            this.picXueYao = new System.Windows.Forms.PictureBox();
            this.picLanYao = new System.Windows.Forms.PictureBox();
            this.picTiYao = new System.Windows.Forms.PictureBox();
            this.picExp = new System.Windows.Forms.PictureBox();
            this.picExpPercent = new System.Windows.Forms.PictureBox();
            this.chkHandFirst = new System.Windows.Forms.CheckBox();
            this.runAwayXueYao = new System.Windows.Forms.NumericUpDown();
            this.runAwayLanYao = new System.Windows.Forms.NumericUpDown();
            this.chkHand = new System.Windows.Forms.CheckBox();
            this.chkNoSkill = new System.Windows.Forms.CheckBox();
            this.noSkillInterval = new System.Windows.Forms.NumericUpDown();
            this.picShazhen = new System.Windows.Forms.PictureBox();
            this.chkBack = new System.Windows.Forms.CheckBox();
            this.patrolRadiusX = new System.Windows.Forms.NumericUpDown();
            this.patrolRadiusY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.circleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCursor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWugong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXueYao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLanYao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTiYao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runAwayXueYao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runAwayLanYao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noSkillInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShazhen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patrolRadiusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patrolRadiusY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(12, 425);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(57, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 132);
            this.label1.TabIndex = 15;
            this.label1.Text = "圆心：  X            Y\r\n\r\n半径：min          max\r\n\r\n点距：           轮距：\r\n\r\n时间间隔：         " +
    "毫秒\r\n\r\n逃跑红：         逃跑蓝：\r\n\r\n巡逻半径：X            Y";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // circleX
            // 
            this.circleX.Location = new System.Drawing.Point(66, 12);
            this.circleX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.circleX.Name = "circleX";
            this.circleX.Size = new System.Drawing.Size(48, 21);
            this.circleX.TabIndex = 1;
            // 
            // circleY
            // 
            this.circleY.Location = new System.Drawing.Point(148, 12);
            this.circleY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.circleY.Name = "circleY";
            this.circleY.Size = new System.Drawing.Size(48, 21);
            this.circleY.TabIndex = 2;
            // 
            // minRadius
            // 
            this.minRadius.Location = new System.Drawing.Point(66, 36);
            this.minRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.minRadius.Name = "minRadius";
            this.minRadius.Size = new System.Drawing.Size(48, 21);
            this.minRadius.TabIndex = 3;
            // 
            // tmrCircleClick
            // 
            this.tmrCircleClick.Tick += new System.EventHandler(this.tmrCircleClick_Tick);
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoEllipsis = true;
            this.lblState.Location = new System.Drawing.Point(84, 203);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(117, 248);
            this.lblState.TabIndex = 16;
            // 
            // maxRadius
            // 
            this.maxRadius.Location = new System.Drawing.Point(148, 36);
            this.maxRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxRadius.Name = "maxRadius";
            this.maxRadius.Size = new System.Drawing.Size(48, 21);
            this.maxRadius.TabIndex = 4;
            // 
            // picCursor
            // 
            this.picCursor.Location = new System.Drawing.Point(12, 203);
            this.picCursor.Name = "picCursor";
            this.picCursor.Size = new System.Drawing.Size(66, 66);
            this.picCursor.TabIndex = 5;
            this.picCursor.TabStop = false;
            // 
            // chkClick
            // 
            this.chkClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClick.AutoSize = true;
            this.chkClick.Checked = true;
            this.chkClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClick.Location = new System.Drawing.Point(12, 406);
            this.chkClick.Name = "chkClick";
            this.chkClick.Size = new System.Drawing.Size(72, 16);
            this.chkClick.TabIndex = 14;
            this.chkClick.Text = "模拟鼠标";
            this.chkClick.UseVisualStyleBackColor = true;
            // 
            // pointDistance
            // 
            this.pointDistance.Location = new System.Drawing.Point(45, 60);
            this.pointDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pointDistance.Name = "pointDistance";
            this.pointDistance.Size = new System.Drawing.Size(48, 21);
            this.pointDistance.TabIndex = 5;
            // 
            // roundDistance
            // 
            this.roundDistance.Location = new System.Drawing.Point(148, 60);
            this.roundDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.roundDistance.Name = "roundDistance";
            this.roundDistance.Size = new System.Drawing.Size(48, 21);
            this.roundDistance.TabIndex = 6;
            // 
            // timeInterval
            // 
            this.timeInterval.Location = new System.Drawing.Point(66, 84);
            this.timeInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timeInterval.Name = "timeInterval";
            this.timeInterval.Size = new System.Drawing.Size(48, 21);
            this.timeInterval.TabIndex = 7;
            // 
            // picXue
            // 
            this.picXue.Location = new System.Drawing.Point(12, 275);
            this.picXue.Name = "picXue";
            this.picXue.Size = new System.Drawing.Size(59, 10);
            this.picXue.TabIndex = 5;
            this.picXue.TabStop = false;
            // 
            // picLan
            // 
            this.picLan.Location = new System.Drawing.Point(12, 291);
            this.picLan.Name = "picLan";
            this.picLan.Size = new System.Drawing.Size(59, 10);
            this.picLan.TabIndex = 5;
            this.picLan.TabStop = false;
            // 
            // picTi
            // 
            this.picTi.Location = new System.Drawing.Point(12, 307);
            this.picTi.Name = "picTi";
            this.picTi.Size = new System.Drawing.Size(59, 10);
            this.picTi.TabIndex = 5;
            this.picTi.TabStop = false;
            // 
            // picRen
            // 
            this.picRen.Location = new System.Drawing.Point(12, 323);
            this.picRen.Name = "picRen";
            this.picRen.Size = new System.Drawing.Size(41, 10);
            this.picRen.TabIndex = 5;
            this.picRen.TabStop = false;
            // 
            // intelligentClick
            // 
            this.intelligentClick.WorkerReportsProgress = true;
            this.intelligentClick.WorkerSupportsCancellation = true;
            this.intelligentClick.DoWork += new System.ComponentModel.DoWorkEventHandler(this.intelligentClick_DoWork);
            this.intelligentClick.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.intelligentClick_ProgressChanged);
            this.intelligentClick.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.intelligentClick_RunWorkerCompleted);
            // 
            // picWugong
            // 
            this.picWugong.Location = new System.Drawing.Point(12, 339);
            this.picWugong.Name = "picWugong";
            this.picWugong.Size = new System.Drawing.Size(65, 10);
            this.picWugong.TabIndex = 5;
            this.picWugong.TabStop = false;
            // 
            // picXueYao
            // 
            this.picXueYao.Location = new System.Drawing.Point(12, 355);
            this.picXueYao.Name = "picXueYao";
            this.picXueYao.Size = new System.Drawing.Size(23, 10);
            this.picXueYao.TabIndex = 5;
            this.picXueYao.TabStop = false;
            // 
            // picLanYao
            // 
            this.picLanYao.Location = new System.Drawing.Point(41, 355);
            this.picLanYao.Name = "picLanYao";
            this.picLanYao.Size = new System.Drawing.Size(23, 10);
            this.picLanYao.TabIndex = 5;
            this.picLanYao.TabStop = false;
            // 
            // picTiYao
            // 
            this.picTiYao.Location = new System.Drawing.Point(12, 371);
            this.picTiYao.Name = "picTiYao";
            this.picTiYao.Size = new System.Drawing.Size(23, 10);
            this.picTiYao.TabIndex = 5;
            this.picTiYao.TabStop = false;
            // 
            // picExp
            // 
            this.picExp.Location = new System.Drawing.Point(12, 387);
            this.picExp.Name = "picExp";
            this.picExp.Size = new System.Drawing.Size(65, 10);
            this.picExp.TabIndex = 5;
            this.picExp.TabStop = false;
            // 
            // picExpPercent
            // 
            this.picExpPercent.Location = new System.Drawing.Point(41, 371);
            this.picExpPercent.Name = "picExpPercent";
            this.picExpPercent.Size = new System.Drawing.Size(23, 10);
            this.picExpPercent.TabIndex = 5;
            this.picExpPercent.TabStop = false;
            // 
            // chkHandFirst
            // 
            this.chkHandFirst.AutoSize = true;
            this.chkHandFirst.Location = new System.Drawing.Point(76, 159);
            this.chkHandFirst.Name = "chkHandFirst";
            this.chkHandFirst.Size = new System.Drawing.Size(84, 16);
            this.chkHandFirst.TabIndex = 11;
            this.chkHandFirst.Text = "捡物品优先";
            this.chkHandFirst.UseVisualStyleBackColor = true;
            // 
            // runAwayXueYao
            // 
            this.runAwayXueYao.Location = new System.Drawing.Point(57, 108);
            this.runAwayXueYao.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.runAwayXueYao.Name = "runAwayXueYao";
            this.runAwayXueYao.Size = new System.Drawing.Size(42, 21);
            this.runAwayXueYao.TabIndex = 8;
            // 
            // runAwayLanYao
            // 
            this.runAwayLanYao.Location = new System.Drawing.Point(160, 108);
            this.runAwayLanYao.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.runAwayLanYao.Name = "runAwayLanYao";
            this.runAwayLanYao.Size = new System.Drawing.Size(35, 21);
            this.runAwayLanYao.TabIndex = 9;
            // 
            // chkHand
            // 
            this.chkHand.AutoSize = true;
            this.chkHand.Checked = true;
            this.chkHand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHand.Location = new System.Drawing.Point(10, 159);
            this.chkHand.Name = "chkHand";
            this.chkHand.Size = new System.Drawing.Size(60, 16);
            this.chkHand.TabIndex = 10;
            this.chkHand.Text = "捡物品";
            this.chkHand.UseVisualStyleBackColor = true;
            // 
            // chkNoSkill
            // 
            this.chkNoSkill.AutoSize = true;
            this.chkNoSkill.Location = new System.Drawing.Point(10, 181);
            this.chkNoSkill.Name = "chkNoSkill";
            this.chkNoSkill.Size = new System.Drawing.Size(120, 16);
            this.chkNoSkill.TabIndex = 12;
            this.chkNoSkill.Text = "不用武功打怪时间";
            this.chkNoSkill.UseVisualStyleBackColor = true;
            // 
            // noSkillInterval
            // 
            this.noSkillInterval.Location = new System.Drawing.Point(139, 179);
            this.noSkillInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.noSkillInterval.Name = "noSkillInterval";
            this.noSkillInterval.Size = new System.Drawing.Size(60, 21);
            this.noSkillInterval.TabIndex = 13;
            // 
            // picShazhen
            // 
            this.picShazhen.Location = new System.Drawing.Point(59, 323);
            this.picShazhen.Name = "picShazhen";
            this.picShazhen.Size = new System.Drawing.Size(5, 10);
            this.picShazhen.TabIndex = 5;
            this.picShazhen.TabStop = false;
            // 
            // chkBack
            // 
            this.chkBack.AutoSize = true;
            this.chkBack.Checked = true;
            this.chkBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBack.Location = new System.Drawing.Point(151, 86);
            this.chkBack.Name = "chkBack";
            this.chkBack.Size = new System.Drawing.Size(48, 16);
            this.chkBack.TabIndex = 17;
            this.chkBack.Text = "归位";
            this.chkBack.UseVisualStyleBackColor = true;
            // 
            // patrolRadiusX
            // 
            this.patrolRadiusX.Location = new System.Drawing.Point(76, 132);
            this.patrolRadiusX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.patrolRadiusX.Name = "patrolRadiusX";
            this.patrolRadiusX.Size = new System.Drawing.Size(42, 21);
            this.patrolRadiusX.TabIndex = 8;
            this.patrolRadiusX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // patrolRadiusY
            // 
            this.patrolRadiusY.Location = new System.Drawing.Point(157, 132);
            this.patrolRadiusY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.patrolRadiusY.Name = "patrolRadiusY";
            this.patrolRadiusY.Size = new System.Drawing.Size(42, 21);
            this.patrolRadiusY.TabIndex = 8;
            this.patrolRadiusY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(207, 460);
            this.Controls.Add(this.chkBack);
            this.Controls.Add(this.noSkillInterval);
            this.Controls.Add(this.chkHand);
            this.Controls.Add(this.chkNoSkill);
            this.Controls.Add(this.chkHandFirst);
            this.Controls.Add(this.chkClick);
            this.Controls.Add(this.picExpPercent);
            this.Controls.Add(this.picTiYao);
            this.Controls.Add(this.picShazhen);
            this.Controls.Add(this.picLanYao);
            this.Controls.Add(this.picXueYao);
            this.Controls.Add(this.picExp);
            this.Controls.Add(this.picWugong);
            this.Controls.Add(this.picRen);
            this.Controls.Add(this.picTi);
            this.Controls.Add(this.picLan);
            this.Controls.Add(this.picXue);
            this.Controls.Add(this.picCursor);
            this.Controls.Add(this.circleY);
            this.Controls.Add(this.roundDistance);
            this.Controls.Add(this.maxRadius);
            this.Controls.Add(this.runAwayLanYao);
            this.Controls.Add(this.patrolRadiusY);
            this.Controls.Add(this.patrolRadiusX);
            this.Controls.Add(this.runAwayXueYao);
            this.Controls.Add(this.timeInterval);
            this.Controls.Add(this.pointDistance);
            this.Controls.Add(this.minRadius);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.circleX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "FormMain";
            this.Text = "侠义道·单挑版";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.circleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCursor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWugong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXueYao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLanYao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTiYao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runAwayXueYao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runAwayLanYao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noSkillInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShazhen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patrolRadiusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patrolRadiusY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private Label label1;
        private NumericUpDown circleX;
        private NumericUpDown circleY;
        private NumericUpDown minRadius;
        private System.Windows.Forms.Timer tmrCircleClick;
        private Label lblState;
        private NumericUpDown maxRadius;
        private PictureBox picCursor;
        private CheckBox chkClick;
        private NumericUpDown pointDistance;
        private NumericUpDown roundDistance;
        private NumericUpDown timeInterval;
        private PictureBox picXue;
        private PictureBox picLan;
        private PictureBox picTi;
        private PictureBox picRen;
        private BackgroundWorker intelligentClick;
        private PictureBox picWugong;
        private PictureBox picXueYao;
        private PictureBox picLanYao;
        private PictureBox picTiYao;
        private PictureBox picExp;
        private PictureBox picExpPercent;
        private CheckBox chkHandFirst;
        private NumericUpDown runAwayXueYao;
        private NumericUpDown runAwayLanYao;
        private CheckBox chkHand;
        private CheckBox chkNoSkill;
        private NumericUpDown noSkillInterval;
        private PictureBox picShazhen;
        private CheckBox chkBack;
        private NumericUpDown patrolRadiusX;
        private NumericUpDown patrolRadiusY;
    }
}