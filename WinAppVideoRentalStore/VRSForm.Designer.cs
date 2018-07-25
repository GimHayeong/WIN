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
            this.btnWithdrawMembership = new System.Windows.Forms.Button();
            this.btnEditMembership = new System.Windows.Forms.Button();
            this.btnNewMembership = new System.Windows.Forms.Button();
            this.lbxMembership = new System.Windows.Forms.ListView();
            this.MemberNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemberName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemberGradeCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemberDeposit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemberRendCnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpbxVideo = new System.Windows.Forms.GroupBox();
            this.btnDeleteVideo = new System.Windows.Forms.Button();
            this.btnEditVideo = new System.Windows.Forms.Button();
            this.btnNewVideo = new System.Windows.Forms.Button();
            this.lbxVideo = new System.Windows.Forms.ListView();
            this.VideoNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VideoType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VideoCnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpbxRendVideo = new System.Windows.Forms.GroupBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnRend = new System.Windows.Forms.Button();
            this.lbxRendVideo = new System.Windows.Forms.ListView();
            this.RendNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RendDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RendMemberGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RendVideoTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vrsDataSet = new WinAppVideoRentalStore.VRSDataSet();
            this.tblMembershipTableAdt = new WinAppVideoRentalStore.VRSDataSetTableAdapters.tblMembershipTableAdapter();
            this.tblVideoTableAdt = new WinAppVideoRentalStore.VRSDataSetTableAdapters.tblVideoTableAdapter();
            this.tblRentVideoTableAdt = new WinAppVideoRentalStore.VRSDataSetTableAdapters.tblRentVideoTableAdapter();
            this.tblCodeTableAdt = new WinAppVideoRentalStore.VRSDataSetTableAdapters.tblCodeTableAdapter();
            this.RendMemberName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RendState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpbxMember.SuspendLayout();
            this.grpbxVideo.SuspendLayout();
            this.grpbxRendVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vrsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbxMember
            // 
            this.grpbxMember.Controls.Add(this.btnWithdrawMembership);
            this.grpbxMember.Controls.Add(this.btnEditMembership);
            this.grpbxMember.Controls.Add(this.btnNewMembership);
            this.grpbxMember.Controls.Add(this.lbxMembership);
            this.grpbxMember.Location = new System.Drawing.Point(12, 12);
            this.grpbxMember.Name = "grpbxMember";
            this.grpbxMember.Size = new System.Drawing.Size(357, 286);
            this.grpbxMember.TabIndex = 0;
            this.grpbxMember.TabStop = false;
            this.grpbxMember.Text = "회원 목록";
            // 
            // btnWithdrawMembership
            // 
            this.btnWithdrawMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWithdrawMembership.Location = new System.Drawing.Point(236, 237);
            this.btnWithdrawMembership.Name = "btnWithdrawMembership";
            this.btnWithdrawMembership.Size = new System.Drawing.Size(74, 38);
            this.btnWithdrawMembership.TabIndex = 2;
            this.btnWithdrawMembership.Text = "탈퇴";
            this.btnWithdrawMembership.UseVisualStyleBackColor = true;
            this.btnWithdrawMembership.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnEditMembership
            // 
            this.btnEditMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditMembership.Location = new System.Drawing.Point(143, 237);
            this.btnEditMembership.Name = "btnEditMembership";
            this.btnEditMembership.Size = new System.Drawing.Size(87, 38);
            this.btnEditMembership.TabIndex = 2;
            this.btnEditMembership.Text = "정보수정";
            this.btnEditMembership.UseVisualStyleBackColor = true;
            this.btnEditMembership.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnNewMembership
            // 
            this.btnNewMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewMembership.Location = new System.Drawing.Point(50, 237);
            this.btnNewMembership.Name = "btnNewMembership";
            this.btnNewMembership.Size = new System.Drawing.Size(87, 38);
            this.btnNewMembership.TabIndex = 2;
            this.btnNewMembership.Text = "신규회원";
            this.btnNewMembership.UseVisualStyleBackColor = true;
            this.btnNewMembership.Click += new System.EventHandler(this.Button_Click);
            // 
            // lbxMembership
            // 
            this.lbxMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxMembership.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MemberNo,
            this.MemberName,
            this.MemberGradeCode,
            this.MemberDeposit,
            this.MemberRendCnt});
            this.lbxMembership.FullRowSelect = true;
            this.lbxMembership.GridLines = true;
            this.lbxMembership.Location = new System.Drawing.Point(15, 31);
            this.lbxMembership.Margin = new System.Windows.Forms.Padding(10);
            this.lbxMembership.MultiSelect = false;
            this.lbxMembership.Name = "lbxMembership";
            this.lbxMembership.Size = new System.Drawing.Size(326, 193);
            this.lbxMembership.TabIndex = 1;
            this.lbxMembership.UseCompatibleStateImageBehavior = false;
            this.lbxMembership.View = System.Windows.Forms.View.Details;
            // 
            // MemberNo
            // 
            this.MemberNo.Text = "번호";
            this.MemberNo.Width = 45;
            // 
            // MemberName
            // 
            this.MemberName.Text = "이름";
            this.MemberName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemberGradeCode
            // 
            this.MemberGradeCode.Text = "등급";
            this.MemberGradeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemberDeposit
            // 
            this.MemberDeposit.Text = "예치금";
            this.MemberDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemberRendCnt
            // 
            this.MemberRendCnt.Text = "대여";
            this.MemberRendCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpbxVideo
            // 
            this.grpbxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpbxVideo.Controls.Add(this.btnDeleteVideo);
            this.grpbxVideo.Controls.Add(this.btnEditVideo);
            this.grpbxVideo.Controls.Add(this.btnNewVideo);
            this.grpbxVideo.Controls.Add(this.lbxVideo);
            this.grpbxVideo.Location = new System.Drawing.Point(12, 305);
            this.grpbxVideo.Name = "grpbxVideo";
            this.grpbxVideo.Size = new System.Drawing.Size(357, 286);
            this.grpbxVideo.TabIndex = 0;
            this.grpbxVideo.TabStop = false;
            this.grpbxVideo.Text = "비디오 목록";
            // 
            // btnDeleteVideo
            // 
            this.btnDeleteVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteVideo.Location = new System.Drawing.Point(236, 237);
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
            this.btnEditVideo.Location = new System.Drawing.Point(143, 237);
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
            this.btnNewVideo.Location = new System.Drawing.Point(50, 237);
            this.btnNewVideo.Name = "btnNewVideo";
            this.btnNewVideo.Size = new System.Drawing.Size(87, 38);
            this.btnNewVideo.TabIndex = 2;
            this.btnNewVideo.Text = "신규등록";
            this.btnNewVideo.UseVisualStyleBackColor = true;
            this.btnNewVideo.Click += new System.EventHandler(this.Button_Click);
            // 
            // lbxVideo
            // 
            this.lbxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxVideo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VideoNo,
            this.Title,
            this.VideoType,
            this.VideoCnt});
            this.lbxVideo.FullRowSelect = true;
            this.lbxVideo.GridLines = true;
            this.lbxVideo.Location = new System.Drawing.Point(15, 31);
            this.lbxVideo.Margin = new System.Windows.Forms.Padding(10);
            this.lbxVideo.Name = "lbxVideo";
            this.lbxVideo.Size = new System.Drawing.Size(326, 193);
            this.lbxVideo.TabIndex = 1;
            this.lbxVideo.UseCompatibleStateImageBehavior = false;
            this.lbxVideo.View = System.Windows.Forms.View.Details;
            // 
            // VideoNo
            // 
            this.VideoNo.Text = "번호";
            this.VideoNo.Width = 45;
            // 
            // Title
            // 
            this.Title.Text = "제목";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Title.Width = 100;
            // 
            // VideoType
            // 
            this.VideoType.Text = "유형";
            this.VideoType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VideoType.Width = 50;
            // 
            // VideoCnt
            // 
            this.VideoCnt.Text = "개수";
            this.VideoCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VideoCnt.Width = 50;
            // 
            // grpbxRendVideo
            // 
            this.grpbxRendVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbxRendVideo.Controls.Add(this.btnReturn);
            this.grpbxRendVideo.Controls.Add(this.btnRend);
            this.grpbxRendVideo.Controls.Add(this.lbxRendVideo);
            this.grpbxRendVideo.Location = new System.Drawing.Point(393, 12);
            this.grpbxRendVideo.Name = "grpbxRendVideo";
            this.grpbxRendVideo.Size = new System.Drawing.Size(427, 579);
            this.grpbxRendVideo.TabIndex = 0;
            this.grpbxRendVideo.TabStop = false;
            this.grpbxRendVideo.Text = "대여 목록";
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(324, 505);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(87, 63);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "반환";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnRend
            // 
            this.btnRend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRend.Location = new System.Drawing.Point(231, 505);
            this.btnRend.Name = "btnRend";
            this.btnRend.Size = new System.Drawing.Size(87, 63);
            this.btnRend.TabIndex = 2;
            this.btnRend.Text = "대여";
            this.btnRend.UseVisualStyleBackColor = true;
            this.btnRend.Click += new System.EventHandler(this.Button_Click);
            // 
            // lbxRendVideo
            // 
            this.lbxRendVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxRendVideo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RendNo,
            this.RendDate,
            this.RendMemberGrade,
            this.RendVideoTitle,
            this.RendMemberName,
            this.RendState});
            this.lbxRendVideo.FullRowSelect = true;
            this.lbxRendVideo.GridLines = true;
            this.lbxRendVideo.Location = new System.Drawing.Point(15, 31);
            this.lbxRendVideo.Margin = new System.Windows.Forms.Padding(10);
            this.lbxRendVideo.Name = "lbxRendVideo";
            this.lbxRendVideo.Size = new System.Drawing.Size(396, 461);
            this.lbxRendVideo.TabIndex = 1;
            this.lbxRendVideo.UseCompatibleStateImageBehavior = false;
            this.lbxRendVideo.View = System.Windows.Forms.View.Details;
            // 
            // RendNo
            // 
            this.RendNo.Text = "번호";
            this.RendNo.Width = 45;
            // 
            // RendDate
            // 
            this.RendDate.Text = "대여일";
            this.RendDate.Width = 80;
            // 
            // RendMemberGrade
            // 
            this.RendMemberGrade.Text = "등급";
            this.RendMemberGrade.Width = 45;
            // 
            // RendVideoTitle
            // 
            this.RendVideoTitle.Text = "비디오";
            this.RendVideoTitle.Width = 100;
            // 
            // vrsDataSet
            // 
            this.vrsDataSet.DataSetName = "VRSDataSet";
            this.vrsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblMembershipTableAdt
            // 
            this.tblMembershipTableAdt.ClearBeforeFill = true;
            // 
            // tblVideoTableAdt
            // 
            this.tblVideoTableAdt.ClearBeforeFill = true;
            // 
            // tblRentVideoTableAdt
            // 
            this.tblRentVideoTableAdt.ClearBeforeFill = true;
            // 
            // tblCodeTableAdt
            // 
            this.tblCodeTableAdt.ClearBeforeFill = true;
            // 
            // RendMemberName
            // 
            this.RendMemberName.Text = "회원명";
            // 
            // RendState
            // 
            this.RendState.Text = "상태";
            // 
            // VRSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 603);
            this.Controls.Add(this.grpbxRendVideo);
            this.Controls.Add(this.grpbxVideo);
            this.Controls.Add(this.grpbxMember);
            this.MinimumSize = new System.Drawing.Size(700, 650);
            this.Name = "VRSForm";
            this.Text = "비디오 대여점";
            this.Load += new System.EventHandler(this.VRSForm_Load);
            this.grpbxMember.ResumeLayout(false);
            this.grpbxVideo.ResumeLayout(false);
            this.grpbxRendVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vrsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxMember;
        private System.Windows.Forms.Button btnWithdrawMembership;
        private System.Windows.Forms.Button btnEditMembership;
        private System.Windows.Forms.Button btnNewMembership;
        private System.Windows.Forms.ListView lbxMembership;
        private System.Windows.Forms.GroupBox grpbxVideo;
        private System.Windows.Forms.Button btnDeleteVideo;
        private System.Windows.Forms.Button btnEditVideo;
        private System.Windows.Forms.Button btnNewVideo;
        private System.Windows.Forms.ListView lbxVideo;
        private System.Windows.Forms.GroupBox grpbxRendVideo;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnRend;
        private System.Windows.Forms.ListView lbxRendVideo;
        private VRSDataSet vrsDataSet;
        private System.Windows.Forms.ColumnHeader MemberNo;
        private System.Windows.Forms.ColumnHeader MemberName;
        private System.Windows.Forms.ColumnHeader MemberGradeCode;
        private System.Windows.Forms.ColumnHeader MemberDeposit;
        private System.Windows.Forms.ColumnHeader MemberRendCnt;
        private System.Windows.Forms.ColumnHeader VideoNo;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader VideoType;
        private System.Windows.Forms.ColumnHeader VideoCnt;
        private System.Windows.Forms.ColumnHeader RendNo;
        private System.Windows.Forms.ColumnHeader RendDate;
        private System.Windows.Forms.ColumnHeader RendMemberGrade;
        private System.Windows.Forms.ColumnHeader RendVideoTitle;
        private VRSDataSetTableAdapters.tblMembershipTableAdapter tblMembershipTableAdt;
        private VRSDataSetTableAdapters.tblVideoTableAdapter tblVideoTableAdt;
        private VRSDataSetTableAdapters.tblRentVideoTableAdapter tblRentVideoTableAdt;
        private VRSDataSetTableAdapters.tblCodeTableAdapter tblCodeTableAdt;
        private System.Windows.Forms.ColumnHeader RendMemberName;
        private System.Windows.Forms.ColumnHeader RendState;
    }
}

