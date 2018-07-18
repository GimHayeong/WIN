namespace WinApp
{
    partial class MDHForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstSystemInfo = new System.Windows.Forms.ListBox();
            this.btnSystemInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSystemInfo
            // 
            this.lstSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSystemInfo.FormattingEnabled = true;
            this.lstSystemInfo.ItemHeight = 15;
            this.lstSystemInfo.Location = new System.Drawing.Point(0, 0);
            this.lstSystemInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 50);
            this.lstSystemInfo.Name = "lstSystemInfo";
            this.lstSystemInfo.Size = new System.Drawing.Size(442, 364);
            this.lstSystemInfo.TabIndex = 0;
            // 
            // btnSystemInfo
            // 
            this.btnSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemInfo.Location = new System.Drawing.Point(176, 376);
            this.btnSystemInfo.Name = "btnSystemInfo";
            this.btnSystemInfo.Size = new System.Drawing.Size(111, 37);
            this.btnSystemInfo.TabIndex = 1;
            this.btnSystemInfo.Text = "시스템정보";
            this.btnSystemInfo.UseVisualStyleBackColor = true;
            this.btnSystemInfo.Click += new System.EventHandler(this.btnSystemInfo_Click);
            // 
            // MDHForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(441, 425);
            this.Controls.Add(this.btnSystemInfo);
            this.Controls.Add(this.lstSystemInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MDHForm";
            this.Opacity = 0.8D;
            this.Text = "시스템정보";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MDHForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSystemInfo;
        private System.Windows.Forms.Button btnSystemInfo;
    }
}

