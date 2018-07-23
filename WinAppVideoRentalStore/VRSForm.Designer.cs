namespace WinAppVideoRentalStore
{
    partial class VRSForm
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
            this.grpbxMember = new System.Windows.Forms.GroupBox();
            this.lsvMembership = new System.Windows.Forms.ListView();
            this.btnNewMembership = new System.Windows.Forms.Button();
            this.btnEditMembership = new System.Windows.Forms.Button();
            this.btnWithdrawMembership = new System.Windows.Forms.Button();
            this.grpbxVideo = new System.Windows.Forms.GroupBox();
            this.btnDeleteVideo = new System.Windows.Forms.Button();
            this.btnEditVideo = new System.Windows.Forms.Button();
            this.btnNewVideo = new System.Windows.Forms.Button();
            this.lsvVideo = new System.Windows.Forms.ListView();
            this.grpbxRendVideo = new System.Windows.Forms.GroupBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnRend = new System.Windows.Forms.Button();
            this.lsvRend = new System.Windows.Forms.ListView();
            this.grpbxMember.SuspendLayout();
            this.grpbxVideo.SuspendLayout();
            this.grpbxRendVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxMember
            // 
            this.grpbxMember.Controls.Add(this.btnWithdrawMembership);
            this.grpbxMember.Controls.Add(this.btnEditMembership);
            this.grpbxMember.Controls.Add(this.btnNewMembership);
            this.grpbxMember.Controls.Add(this.lsvMembership);
            this.grpbxMember.Location = new System.Drawing.Point(12, 12);
            this.grpbxMember.Name = "grpbxMember";
            this.grpbxMember.Size = new System.Drawing.Size(291, 286);
            this.grpbxMember.TabIndex = 0;
            this.grpbxMember.TabStop = false;
            this.grpbxMember.Text = "회원 목록";
            // 
            // lsvMembership
            // 
            this.lsvMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvMembership.Location = new System.Drawing.Point(15, 31);
            this.lsvMembership.Margin = new System.Windows.Forms.Padding(10);
            this.lsvMembership.Name = "lsvMembership";
            this.lsvMembership.Size = new System.Drawing.Size(260, 193);
            this.lsvMembership.TabIndex = 1;
            this.lsvMembership.UseCompatibleStateImageBehavior = false;
            // 
            // btnNewMembership
            // 
            this.btnNewMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewMembership.Location = new System.Drawing.Point(15, 237);
            this.btnNewMembership.Name = "btnNewMembership";
            this.btnNewMembership.Size = new System.Drawing.Size(87, 38);
            this.btnNewMembership.TabIndex = 2;
            this.btnNewMembership.Text = "신규회원";
            this.btnNewMembership.UseVisualStyleBackColor = true;
            this.btnNewMembership.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnEditMembership
            // 
            this.btnEditMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditMembership.Location = new System.Drawing.Point(108, 237);
            this.btnEditMembership.Name = "btnEditMembership";
            this.btnEditMembership.Size = new System.Drawing.Size(87, 38);
            this.btnEditMembership.TabIndex = 2;
            this.btnEditMembership.Text = "정보수정";
            this.btnEditMembership.UseVisualStyleBackColor = true;
            this.btnEditMembership.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnWithdrawMembership
            // 
            this.btnWithdrawMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWithdrawMembership.Location = new System.Drawing.Point(201, 237);
            this.btnWithdrawMembership.Name = "btnWithdrawMembership";
            this.btnWithdrawMembership.Size = new System.Drawing.Size(74, 38);
            this.btnWithdrawMembership.TabIndex = 2;
            this.btnWithdrawMembership.Text = "탈퇴";
            this.btnWithdrawMembership.UseVisualStyleBackColor = true;
            this.btnWithdrawMembership.Click += new System.EventHandler(this.Button_Click);
            // 
            // grpbxVideo
            // 
            this.grpbxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpbxVideo.Controls.Add(this.btnDeleteVideo);
            this.grpbxVideo.Controls.Add(this.btnEditVideo);
            this.grpbxVideo.Controls.Add(this.btnNewVideo);
            this.grpbxVideo.Controls.Add(this.lsvVideo);
            this.grpbxVideo.Location = new System.Drawing.Point(12, 305);
            this.grpbxVideo.Name = "grpbxVideo";
            this.grpbxVideo.Size = new System.Drawing.Size(291, 286);
            this.grpbxVideo.TabIndex = 0;
            this.grpbxVideo.TabStop = false;
            this.grpbxVideo.Text = "비디오 목록";
            // 
            // btnDeleteVideo
            // 
            this.btnDeleteVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteVideo.Location = new System.Drawing.Point(201, 237);
            this.btnDeleteVideo.Name = "btnDeleteVideo";
            this.btnDeleteVideo.Size = new System.Drawing.Size(74, 38);
            this.btnDeleteVideo.TabIndex = 2;
            this.btnDeleteVideo.Text = "삭제";
            this.btnDeleteVideo.UseVisualStyleBackColor = true;
            this.btnDeleteVideo.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnEditVideo
            // 
            this.btnEditVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditVideo.Location = new System.Drawing.Point(108, 237);
            this.btnEditVideo.Name = "btnEditVideo";
            this.btnEditVideo.Size = new System.Drawing.Size(87, 38);
            this.btnEditVideo.TabIndex = 2;
            this.btnEditVideo.Text = "정보수정";
            this.btnEditVideo.UseVisualStyleBackColor = true;
            this.btnEditVideo.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnNewVideo
            // 
            this.btnNewVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewVideo.Location = new System.Drawing.Point(15, 237);
            this.btnNewVideo.Name = "btnNewVideo";
            this.btnNewVideo.Size = new System.Drawing.Size(87, 38);
            this.btnNewVideo.TabIndex = 2;
            this.btnNewVideo.Text = "신규등록";
            this.btnNewVideo.UseVisualStyleBackColor = true;
            this.btnNewVideo.Click += new System.EventHandler(this.Button_Click);
            // 
            // lsvVideo
            // 
            this.lsvVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvVideo.Location = new System.Drawing.Point(15, 31);
            this.lsvVideo.Margin = new System.Windows.Forms.Padding(10);
            this.lsvVideo.Name = "lsvVideo";
            this.lsvVideo.Size = new System.Drawing.Size(260, 193);
            this.lsvVideo.TabIndex = 1;
            this.lsvVideo.UseCompatibleStateImageBehavior = false;
            // 
            // grpbxRendVideo
            // 
            this.grpbxRendVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpbxRendVideo.Controls.Add(this.btnReturn);
            this.grpbxRendVideo.Controls.Add(this.btnRend);
            this.grpbxRendVideo.Controls.Add(this.lsvRend);
            this.grpbxRendVideo.Location = new System.Drawing.Point(329, 12);
            this.grpbxRendVideo.Name = "grpbxRendVideo";
            this.grpbxRendVideo.Size = new System.Drawing.Size(291, 579);
            this.grpbxRendVideo.TabIndex = 0;
            this.grpbxRendVideo.TabStop = false;
            this.grpbxRendVideo.Text = "대여 목록";
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Location = new System.Drawing.Point(188, 505);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(87, 63);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "반환";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnRend
            // 
            this.btnRend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRend.Location = new System.Drawing.Point(95, 505);
            this.btnRend.Name = "btnRend";
            this.btnRend.Size = new System.Drawing.Size(87, 63);
            this.btnRend.TabIndex = 2;
            this.btnRend.Text = "대여";
            this.btnRend.UseVisualStyleBackColor = true;
            this.btnRend.Click += new System.EventHandler(this.Button_Click);
            // 
            // lsvRend
            // 
            this.lsvRend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvRend.Location = new System.Drawing.Point(15, 31);
            this.lsvRend.Margin = new System.Windows.Forms.Padding(10);
            this.lsvRend.Name = "lsvRend";
            this.lsvRend.Size = new System.Drawing.Size(260, 461);
            this.lsvRend.TabIndex = 1;
            this.lsvRend.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 603);
            this.Controls.Add(this.grpbxRendVideo);
            this.Controls.Add(this.grpbxVideo);
            this.Controls.Add(this.grpbxMember);
            this.MinimumSize = new System.Drawing.Size(650, 650);
            this.Name = "Form1";
            this.Text = "비디오 대여점";
            this.grpbxMember.ResumeLayout(false);
            this.grpbxVideo.ResumeLayout(false);
            this.grpbxRendVideo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxMember;
        private System.Windows.Forms.Button btnWithdrawMembership;
        private System.Windows.Forms.Button btnEditMembership;
        private System.Windows.Forms.Button btnNewMembership;
        private System.Windows.Forms.ListView lsvMembership;
        private System.Windows.Forms.GroupBox grpbxVideo;
        private System.Windows.Forms.Button btnDeleteVideo;
        private System.Windows.Forms.Button btnEditVideo;
        private System.Windows.Forms.Button btnNewVideo;
        private System.Windows.Forms.ListView lsvVideo;
        private System.Windows.Forms.GroupBox grpbxRendVideo;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnRend;
        private System.Windows.Forms.ListView lsvRend;
    }
}

