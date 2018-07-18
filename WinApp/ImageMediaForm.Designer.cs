namespace WinApp
{
    partial class ImageForm
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
            this.timerDoubleBuffer = new System.Windows.Forms.Timer(this.components);
            this.btnDingdong = new System.Windows.Forms.Button();
            this.btnPosion = new System.Windows.Forms.Button();
            this.lnkDaum = new System.Windows.Forms.LinkLabel();
            this.mskPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnMobile = new System.Windows.Forms.Button();
            this.lstbxDash = new System.Windows.Forms.ListBox();
            this.cbxDropDown = new System.Windows.Forms.ComboBox();
            this.cbxDropDownList = new System.Windows.Forms.ComboBox();
            this.cbxSimple = new System.Windows.Forms.ComboBox();
            this.chkLstInfo = new System.Windows.Forms.CheckedListBox();
            this.lblSelections = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerDoubleBuffer
            // 
            this.timerDoubleBuffer.Interval = 500;
            // 
            // btnDingdong
            // 
            this.btnDingdong.Location = new System.Drawing.Point(443, 479);
            this.btnDingdong.Name = "btnDingdong";
            this.btnDingdong.Size = new System.Drawing.Size(103, 28);
            this.btnDingdong.TabIndex = 0;
            this.btnDingdong.Text = "playSound";
            this.btnDingdong.UseVisualStyleBackColor = true;
            this.btnDingdong.Click += new System.EventHandler(this.btnDingdong_Click);
            // 
            // btnPosion
            // 
            this.btnPosion.Location = new System.Drawing.Point(325, 479);
            this.btnPosion.Name = "btnPosion";
            this.btnPosion.Size = new System.Drawing.Size(103, 28);
            this.btnPosion.TabIndex = 0;
            this.btnPosion.Text = "playPosion";
            this.btnPosion.UseVisualStyleBackColor = true;
            this.btnPosion.Click += new System.EventHandler(this.btnDingdong_Click);
            // 
            // lnkDaum
            // 
            this.lnkDaum.AutoSize = true;
            this.lnkDaum.Location = new System.Drawing.Point(21, 486);
            this.lnkDaum.Name = "lnkDaum";
            this.lnkDaum.Size = new System.Drawing.Size(143, 15);
            this.lnkDaum.TabIndex = 1;
            this.lnkDaum.TabStop = true;
            this.lnkDaum.Text = "http://www.daum.net";
            this.lnkDaum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDaum_LinkClicked);
            // 
            // mskPhone
            // 
            this.mskPhone.Location = new System.Drawing.Point(24, 458);
            this.mskPhone.Mask = "000-9000-0000";
            this.mskPhone.Name = "mskPhone";
            this.mskPhone.Size = new System.Drawing.Size(115, 25);
            this.mskPhone.TabIndex = 2;
            this.mskPhone.TextChanged += new System.EventHandler(this.mskPhone_TextChanged);
            // 
            // btnMobile
            // 
            this.btnMobile.Enabled = false;
            this.btnMobile.Location = new System.Drawing.Point(145, 454);
            this.btnMobile.Name = "btnMobile";
            this.btnMobile.Size = new System.Drawing.Size(64, 28);
            this.btnMobile.TabIndex = 0;
            this.btnMobile.Text = "휴대폰";
            this.btnMobile.UseVisualStyleBackColor = true;
            this.btnMobile.Click += new System.EventHandler(this.btnDingdong_Click);
            // 
            // lstbxDash
            // 
            this.lstbxDash.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstbxDash.FormattingEnabled = true;
            this.lstbxDash.ItemHeight = 15;
            this.lstbxDash.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.lstbxDash.Location = new System.Drawing.Point(44, 12);
            this.lstbxDash.Name = "lstbxDash";
            this.lstbxDash.Size = new System.Drawing.Size(120, 109);
            this.lstbxDash.TabIndex = 3;
            this.lstbxDash.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstbxDash_DrawItem);
            this.lstbxDash.SelectedIndexChanged += new System.EventHandler(this.lstbxDash_SelectedIndexChanged);
            // 
            // cbxDropDown
            // 
            this.cbxDropDown.FormattingEnabled = true;
            this.cbxDropDown.Items.AddRange(new object[] {
            "나보기가 역겨워",
            "가실때에는",
            "죽어도 ",
            "아니눈물 흘리오리다",
            "가시는 걸음걸음",
            "놓인 그꽃을",
            "사뿐히 즈려밟고 ",
            "가시옵소서"});
            this.cbxDropDown.Location = new System.Drawing.Point(43, 217);
            this.cbxDropDown.Name = "cbxDropDown";
            this.cbxDropDown.Size = new System.Drawing.Size(121, 23);
            this.cbxDropDown.TabIndex = 4;
            this.cbxDropDown.SelectedIndexChanged += new System.EventHandler(this.combox_SelectedIndexChanged);
            this.cbxDropDown.TextChanged += new System.EventHandler(this.combox_TextChanged);
            // 
            // cbxDropDownList
            // 
            this.cbxDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDropDownList.FormattingEnabled = true;
            this.cbxDropDownList.Items.AddRange(new object[] {
            "나보기가 역겨워",
            "가실때에는",
            "죽어도 ",
            "아니눈물 흘리오리다",
            "가시는 걸음걸음",
            "놓인 그꽃을",
            "사뿐히 즈려밟고 ",
            "가시옵소서"});
            this.cbxDropDownList.Location = new System.Drawing.Point(44, 309);
            this.cbxDropDownList.Name = "cbxDropDownList";
            this.cbxDropDownList.Size = new System.Drawing.Size(121, 23);
            this.cbxDropDownList.TabIndex = 5;
            this.cbxDropDownList.SelectedIndexChanged += new System.EventHandler(this.combox_TextChanged);
            // 
            // cbxSimple
            // 
            this.cbxSimple.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbxSimple.FormattingEnabled = true;
            this.cbxSimple.Items.AddRange(new object[] {
            "나보기가 역겨워",
            "가실때에는",
            "죽어도 ",
            "아니눈물 흘리오리다",
            "가시는 걸음걸음",
            "놓인 그꽃을",
            "사뿐히 즈려밟고 ",
            "가시옵소서"});
            this.cbxSimple.Location = new System.Drawing.Point(214, 217);
            this.cbxSimple.Name = "cbxSimple";
            this.cbxSimple.Size = new System.Drawing.Size(121, 150);
            this.cbxSimple.TabIndex = 5;
            this.cbxSimple.SelectedIndexChanged += new System.EventHandler(this.combox_SelectedIndexChanged);
            this.cbxSimple.TextChanged += new System.EventHandler(this.combox_TextChanged);
            // 
            // chkLstInfo
            // 
            this.chkLstInfo.FormattingEnabled = true;
            this.chkLstInfo.Items.AddRange(new object[] {
            "문자가 없는 곳에도 문자열 입력받기",
            "선택 영역에 입력할 경우 대체하기",
            "인쇄할 때는 항상 시스템 폰트 사용",
            "시작할 때 최근 문서 목록 읽기",
            "미저장 문서 확인없이 바로 종료하기",
            "입력할 때는 커서 숨기기",
            "포커스 잃을 때 선택영역 숨기기",
            "선택 영역 드래그해서 이동 및 복사하기"});
            this.chkLstInfo.Location = new System.Drawing.Point(361, 217);
            this.chkLstInfo.Name = "chkLstInfo";
            this.chkLstInfo.Size = new System.Drawing.Size(320, 184);
            this.chkLstInfo.TabIndex = 6;
            this.chkLstInfo.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstInfo_ItemCheck);
            this.chkLstInfo.SelectedIndexChanged += new System.EventHandler(this.chkLstInfo_SelectedIndexChanged);
            // 
            // lblSelections
            // 
            this.lblSelections.AutoSize = true;
            this.lblSelections.Location = new System.Drawing.Point(21, 424);
            this.lblSelections.Name = "lblSelections";
            this.lblSelections.Size = new System.Drawing.Size(57, 23);
            this.lblSelections.TabIndex = 7;
            this.lblSelections.Text = "선택값:";
            this.lblSelections.UseCompatibleTextRendering = true;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 587);
            this.Controls.Add(this.lblSelections);
            this.Controls.Add(this.chkLstInfo);
            this.Controls.Add(this.cbxSimple);
            this.Controls.Add(this.cbxDropDownList);
            this.Controls.Add(this.cbxDropDown);
            this.Controls.Add(this.lstbxDash);
            this.Controls.Add(this.mskPhone);
            this.Controls.Add(this.lnkDaum);
            this.Controls.Add(this.btnMobile);
            this.Controls.Add(this.btnPosion);
            this.Controls.Add(this.btnDingdong);
            this.DoubleBuffered = true;
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerDoubleBuffer;
        private System.Windows.Forms.Button btnDingdong;
        private System.Windows.Forms.Button btnPosion;
        private System.Windows.Forms.LinkLabel lnkDaum;
        private System.Windows.Forms.MaskedTextBox mskPhone;
        private System.Windows.Forms.Button btnMobile;
        private System.Windows.Forms.ListBox lstbxDash;
        private System.Windows.Forms.ComboBox cbxDropDown;
        private System.Windows.Forms.ComboBox cbxDropDownList;
        private System.Windows.Forms.ComboBox cbxSimple;
        private System.Windows.Forms.CheckedListBox chkLstInfo;
        private System.Windows.Forms.Label lblSelections;
    }
}