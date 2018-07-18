namespace WinApp
{
    partial class ControlForm
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
            this.prgValue = new System.Windows.Forms.ProgressBar();
            this.prgStep = new System.Windows.Forms.ProgressBar();
            this.btnProgressbar = new System.Windows.Forms.Button();
            this.chkIsMarquee = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ddlType = new System.Windows.Forms.DomainUpDown();
            this.trkFontSize = new System.Windows.Forms.TrackBar();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // prgValue
            // 
            this.prgValue.Location = new System.Drawing.Point(12, 458);
            this.prgValue.Name = "prgValue";
            this.prgValue.Size = new System.Drawing.Size(227, 23);
            this.prgValue.TabIndex = 0;
            // 
            // prgStep
            // 
            this.prgStep.Location = new System.Drawing.Point(339, 458);
            this.prgStep.Name = "prgStep";
            this.prgStep.Size = new System.Drawing.Size(227, 23);
            this.prgStep.Step = 1;
            this.prgStep.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgStep.TabIndex = 0;
            // 
            // btnProgressbar
            // 
            this.btnProgressbar.Location = new System.Drawing.Point(245, 449);
            this.btnProgressbar.Name = "btnProgressbar";
            this.btnProgressbar.Size = new System.Drawing.Size(88, 39);
            this.btnProgressbar.TabIndex = 1;
            this.btnProgressbar.Text = "시작";
            this.btnProgressbar.UseVisualStyleBackColor = true;
            this.btnProgressbar.Click += new System.EventHandler(this.btnProgressbar_Click);
            // 
            // chkIsMarquee
            // 
            this.chkIsMarquee.AutoSize = true;
            this.chkIsMarquee.Location = new System.Drawing.Point(12, 433);
            this.chkIsMarquee.Name = "chkIsMarquee";
            this.chkIsMarquee.Size = new System.Drawing.Size(133, 19);
            this.chkIsMarquee.TabIndex = 2;
            this.chkIsMarquee.Text = "Style : Marquee";
            this.chkIsMarquee.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown1.TabIndex = 3;
            // 
            // ddlType
            // 
            this.ddlType.Items.Add("A");
            this.ddlType.Items.Add("B");
            this.ddlType.Items.Add("C");
            this.ddlType.Items.Add("D");
            this.ddlType.Items.Add("E");
            this.ddlType.Items.Add("F");
            this.ddlType.Items.Add("G");
            this.ddlType.Location = new System.Drawing.Point(12, 61);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(120, 25);
            this.ddlType.TabIndex = 4;
            this.ddlType.Text = "유형선택";
            // 
            // trkFontSize
            // 
            this.trkFontSize.Location = new System.Drawing.Point(12, 102);
            this.trkFontSize.Maximum = 100;
            this.trkFontSize.Name = "trkFontSize";
            this.trkFontSize.Size = new System.Drawing.Size(120, 56);
            this.trkFontSize.TabIndex = 5;
            this.trkFontSize.Value = 10;
            this.trkFontSize.Scroll += new System.EventHandler(this.trkFontSize_Scroll);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(12, 164);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 25);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 493);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.trkFontSize);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chkIsMarquee);
            this.Controls.Add(this.btnProgressbar);
            this.Controls.Add(this.prgStep);
            this.Controls.Add(this.prgValue);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgValue;
        private System.Windows.Forms.ProgressBar prgStep;
        private System.Windows.Forms.Button btnProgressbar;
        private System.Windows.Forms.CheckBox chkIsMarquee;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DomainUpDown ddlType;
        private System.Windows.Forms.TrackBar trkFontSize;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ImageList imageList1;
    }
}