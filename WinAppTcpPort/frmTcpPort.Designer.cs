namespace WinAppTcpPort
{
    partial class frmTcpPort
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxEnablePort = new System.Windows.Forms.TextBox();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "활성화된 포트번호 검출";
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(26, 43);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(387, 25);
            this.tbxIP.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(419, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "검출";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxEnablePort
            // 
            this.tbxEnablePort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxEnablePort.Location = new System.Drawing.Point(28, 91);
            this.tbxEnablePort.Multiline = true;
            this.tbxEnablePort.Name = "tbxEnablePort";
            this.tbxEnablePort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxEnablePort.Size = new System.Drawing.Size(350, 472);
            this.tbxEnablePort.TabIndex = 3;
            this.tbxEnablePort.Text = "*** 활성화된 포트 정보 ***";
            // 
            // tbxInfo
            // 
            this.tbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfo.Location = new System.Drawing.Point(398, 91);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfo.Size = new System.Drawing.Size(444, 472);
            this.tbxInfo.TabIndex = 4;
            this.tbxInfo.Text = "*** 검색 포트 진행 상황 ***";
            // 
            // frmTcpPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 575);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.tbxEnablePort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxIP);
            this.Controls.Add(this.label1);
            this.Name = "frmTcpPort";
            this.Text = "포트 검출";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTcpPort_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxEnablePort;
        private System.Windows.Forms.TextBox tbxInfo;
    }
}

