namespace jyzj.infiniteClick
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
            this.rdoLeftClick = new System.Windows.Forms.RadioButton();
            this.rdoRightClick = new System.Windows.Forms.RadioButton();
            this.rdoBoth = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoLeftClick
            // 
            this.rdoLeftClick.AutoSize = true;
            this.rdoLeftClick.Location = new System.Drawing.Point(12, 12);
            this.rdoLeftClick.Name = "rdoLeftClick";
            this.rdoLeftClick.Size = new System.Drawing.Size(58, 19);
            this.rdoLeftClick.TabIndex = 0;
            this.rdoLeftClick.Text = "左键";
            this.rdoLeftClick.UseVisualStyleBackColor = true;
            this.rdoLeftClick.CheckedChanged += new System.EventHandler(this.rdoLeftClick_CheckedChanged);
            // 
            // rdoRightClick
            // 
            this.rdoRightClick.AutoSize = true;
            this.rdoRightClick.Location = new System.Drawing.Point(12, 37);
            this.rdoRightClick.Name = "rdoRightClick";
            this.rdoRightClick.Size = new System.Drawing.Size(58, 19);
            this.rdoRightClick.TabIndex = 0;
            this.rdoRightClick.Text = "右键";
            this.rdoRightClick.UseVisualStyleBackColor = true;
            this.rdoRightClick.CheckedChanged += new System.EventHandler(this.rdoRightClick_CheckedChanged);
            // 
            // rdoBoth
            // 
            this.rdoBoth.AutoSize = true;
            this.rdoBoth.Checked = true;
            this.rdoBoth.Location = new System.Drawing.Point(12, 62);
            this.rdoBoth.Name = "rdoBoth";
            this.rdoBoth.Size = new System.Drawing.Size(96, 19);
            this.rdoBoth.TabIndex = 0;
            this.rdoBoth.TabStop = true;
            this.rdoBoth.Text = "左键+右键";
            this.rdoBoth.UseVisualStyleBackColor = true;
            this.rdoBoth.CheckedChanged += new System.EventHandler(this.rdoBoth_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(181, 140);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "间隔：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(70, 87);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 192);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rdoBoth);
            this.Controls.Add(this.rdoRightClick);
            this.Controls.Add(this.rdoLeftClick);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoLeftClick;
        private System.Windows.Forms.RadioButton rdoRightClick;
        private System.Windows.Forms.RadioButton rdoBoth;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}