namespace WinAppVideoRentalStore
{
    partial class VRSMemberForm
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
            this.mskZipcode = new System.Windows.Forms.MaskedTextBox();
            this.mskCellPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSearchAddr = new System.Windows.Forms.Button();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.tbxAddrDetail = new System.Windows.Forms.TextBox();
            this.tbxAddr = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDeposit = new System.Windows.Forms.TextBox();
            this.grpbxGrade = new System.Windows.Forms.GroupBox();
            this.rdoGold = new System.Windows.Forms.RadioButton();
            this.rdoRegular = new System.Windows.Forms.RadioButton();
            this.rdoAssociate = new System.Windows.Forms.RadioButton();
            this.cbxMale = new System.Windows.Forms.CheckBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.grpbxGrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // mskZipcode
            // 
            this.mskZipcode.Location = new System.Drawing.Point(104, 98);
            this.mskZipcode.Mask = "000-000";
            this.mskZipcode.Name = "mskZipcode";
            this.mskZipcode.Size = new System.Drawing.Size(64, 25);
            this.mskZipcode.TabIndex = 7;
            this.mskZipcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // mskCellPhone
            // 
            this.mskCellPhone.Location = new System.Drawing.Point(104, 199);
            this.mskCellPhone.Mask = "000-9000-0000";
            this.mskCellPhone.Name = "mskCellPhone";
            this.mskCellPhone.Size = new System.Drawing.Size(115, 25);
            this.mskCellPhone.TabIndex = 10;
            this.mskCellPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(322, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(193, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 36);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnSearchAddr
            // 
            this.btnSearchAddr.Location = new System.Drawing.Point(174, 92);
            this.btnSearchAddr.Name = "btnSearchAddr";
            this.btnSearchAddr.Size = new System.Drawing.Size(120, 33);
            this.btnSearchAddr.TabIndex = 8;
            this.btnSearchAddr.Text = "우편번호 검색";
            this.btnSearchAddr.UseVisualStyleBackColor = true;
            this.btnSearchAddr.Click += new System.EventHandler(this.Button_Click);
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "yyyy-MM-dd";
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(104, 53);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(143, 25);
            this.dtpBirthday.TabIndex = 2;
            // 
            // tbxAddrDetail
            // 
            this.tbxAddrDetail.Location = new System.Drawing.Point(104, 159);
            this.tbxAddrDetail.Name = "tbxAddrDetail";
            this.tbxAddrDetail.Size = new System.Drawing.Size(265, 25);
            this.tbxAddrDetail.TabIndex = 9;
            this.tbxAddrDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // tbxAddr
            // 
            this.tbxAddr.Location = new System.Drawing.Point(104, 129);
            this.tbxAddr.Name = "tbxAddr";
            this.tbxAddr.ReadOnly = true;
            this.tbxAddr.Size = new System.Drawing.Size(265, 25);
            this.tbxAddr.TabIndex = 0;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(104, 18);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(143, 25);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "핸 드 폰 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "주　　소 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "생년월일 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "이　　름 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "예 치 금 :";
            // 
            // tbxDeposit
            // 
            this.tbxDeposit.Location = new System.Drawing.Point(104, 234);
            this.tbxDeposit.Name = "tbxDeposit";
            this.tbxDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbxDeposit.Size = new System.Drawing.Size(143, 25);
            this.tbxDeposit.TabIndex = 11;
            this.tbxDeposit.Text = "0";
            this.tbxDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // grpbxGrade
            // 
            this.grpbxGrade.Controls.Add(this.rdoGold);
            this.grpbxGrade.Controls.Add(this.rdoRegular);
            this.grpbxGrade.Controls.Add(this.rdoAssociate);
            this.grpbxGrade.Location = new System.Drawing.Point(394, 18);
            this.grpbxGrade.Name = "grpbxGrade";
            this.grpbxGrade.Size = new System.Drawing.Size(176, 166);
            this.grpbxGrade.TabIndex = 26;
            this.grpbxGrade.TabStop = false;
            this.grpbxGrade.Text = "회원등급";
            // 
            // rdoGold
            // 
            this.rdoGold.AutoSize = true;
            this.rdoGold.Location = new System.Drawing.Point(36, 111);
            this.rdoGold.Name = "rdoGold";
            this.rdoGold.Size = new System.Drawing.Size(88, 19);
            this.rdoGold.TabIndex = 6;
            this.rdoGold.Text = "우수회원";
            this.rdoGold.UseVisualStyleBackColor = true;
            this.rdoGold.CheckedChanged += new System.EventHandler(this.GradeCheckbox_CheckedChanged);
            // 
            // rdoRegular
            // 
            this.rdoRegular.AutoSize = true;
            this.rdoRegular.Location = new System.Drawing.Point(36, 76);
            this.rdoRegular.Name = "rdoRegular";
            this.rdoRegular.Size = new System.Drawing.Size(73, 19);
            this.rdoRegular.TabIndex = 5;
            this.rdoRegular.Text = "정회원";
            this.rdoRegular.UseVisualStyleBackColor = true;
            this.rdoRegular.CheckedChanged += new System.EventHandler(this.GradeCheckbox_CheckedChanged);
            // 
            // rdoAssociate
            // 
            this.rdoAssociate.AutoSize = true;
            this.rdoAssociate.Checked = true;
            this.rdoAssociate.Location = new System.Drawing.Point(36, 41);
            this.rdoAssociate.Name = "rdoAssociate";
            this.rdoAssociate.Size = new System.Drawing.Size(73, 19);
            this.rdoAssociate.TabIndex = 4;
            this.rdoAssociate.TabStop = true;
            this.rdoAssociate.Text = "준회원";
            this.rdoAssociate.UseVisualStyleBackColor = true;
            this.rdoAssociate.CheckedChanged += new System.EventHandler(this.GradeCheckbox_CheckedChanged);
            // 
            // cbxMale
            // 
            this.cbxMale.AutoSize = true;
            this.cbxMale.Location = new System.Drawing.Point(259, 56);
            this.cbxMale.Name = "cbxMale";
            this.cbxMale.Size = new System.Drawing.Size(59, 19);
            this.cbxMale.TabIndex = 3;
            this.cbxMale.Text = "남자";
            this.cbxMale.UseVisualStyleBackColor = true;
            // 
            // VRSMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.cbxMale);
            this.Controls.Add(this.grpbxGrade);
            this.Controls.Add(this.mskZipcode);
            this.Controls.Add(this.mskCellPhone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearchAddr);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.tbxAddrDetail);
            this.Controls.Add(this.tbxAddr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxDeposit);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "VRSMemberForm";
            this.Text = "신규회원등록";
            this.Load += new System.EventHandler(this.VRSMemberForm_Load);
            this.grpbxGrade.ResumeLayout(false);
            this.grpbxGrade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskZipcode;
        private System.Windows.Forms.MaskedTextBox mskCellPhone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSearchAddr;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.TextBox tbxAddrDetail;
        private System.Windows.Forms.TextBox tbxAddr;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxDeposit;
        private System.Windows.Forms.GroupBox grpbxGrade;
        private System.Windows.Forms.RadioButton rdoGold;
        private System.Windows.Forms.RadioButton rdoRegular;
        private System.Windows.Forms.RadioButton rdoAssociate;
        private System.Windows.Forms.CheckBox cbxMale;
        private System.Windows.Forms.ToolTip tip;
    }
}