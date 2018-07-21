namespace WinAppAddressBook
{
    partial class AddressDetailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchAddr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxAddr = new System.Windows.Forms.TextBox();
            this.tbxAddrDetail = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.mskCellPhone = new System.Windows.Forms.MaskedTextBox();
            this.mskZipcode = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEmailHost = new System.Windows.Forms.ComboBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.cbxMale = new System.Windows.Forms.CheckBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.jusoDataSet = new WinAppAddressBook.JusoDataSet();
            this.tblJusoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblJusoTableAdapter = new WinAppAddressBook.JusoDataSetTableAdapters.tblJusoTableAdapter();
            this.tableAdapterManager = new WinAppAddressBook.JusoDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.jusoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblJusoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "이　　름 :";
            // 
            // btnSearchAddr
            // 
            this.btnSearchAddr.Location = new System.Drawing.Point(186, 91);
            this.btnSearchAddr.Name = "btnSearchAddr";
            this.btnSearchAddr.Size = new System.Drawing.Size(120, 33);
            this.btnSearchAddr.TabIndex = 5;
            this.btnSearchAddr.Text = "우편번호 검색";
            this.btnSearchAddr.UseVisualStyleBackColor = true;
            this.btnSearchAddr.Click += new System.EventHandler(this.btnSearchAddr_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "생년월일 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "주　　소 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "핸 드 폰 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "이 메 일 :";
            // 
            // tbxAddr
            // 
            this.tbxAddr.Location = new System.Drawing.Point(116, 128);
            this.tbxAddr.Name = "tbxAddr";
            this.tbxAddr.ReadOnly = true;
            this.tbxAddr.Size = new System.Drawing.Size(265, 25);
            this.tbxAddr.TabIndex = 6;
            // 
            // tbxAddrDetail
            // 
            this.tbxAddrDetail.Location = new System.Drawing.Point(116, 158);
            this.tbxAddrDetail.Name = "tbxAddrDetail";
            this.tbxAddrDetail.Size = new System.Drawing.Size(265, 25);
            this.tbxAddrDetail.TabIndex = 7;
            this.tbxAddrDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(138, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 36);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(116, 233);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(136, 25);
            this.tbxEmail.TabIndex = 9;
            this.tbxEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbxEmail.Leave += new System.EventHandler(this.tbxEmail_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // mskCellPhone
            // 
            this.mskCellPhone.Location = new System.Drawing.Point(116, 198);
            this.mskCellPhone.Mask = "000-9000-0000";
            this.mskCellPhone.Name = "mskCellPhone";
            this.mskCellPhone.Size = new System.Drawing.Size(115, 25);
            this.mskCellPhone.TabIndex = 8;
            this.mskCellPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // mskZipcode
            // 
            this.mskZipcode.Location = new System.Drawing.Point(116, 97);
            this.mskZipcode.Mask = "000-000";
            this.mskZipcode.Name = "mskZipcode";
            this.mskZipcode.Size = new System.Drawing.Size(64, 25);
            this.mskZipcode.TabIndex = 4;
            this.mskZipcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(258, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "@";
            // 
            // cbxEmailHost
            // 
            this.cbxEmailHost.FormattingEnabled = true;
            this.cbxEmailHost.Items.AddRange(new object[] {
            "daum.net",
            "gmail.com",
            "hanmail.com",
            "nate.com",
            "naver.com"});
            this.cbxEmailHost.Location = new System.Drawing.Point(285, 234);
            this.cbxEmailHost.Name = "cbxEmailHost";
            this.cbxEmailHost.Size = new System.Drawing.Size(125, 23);
            this.cbxEmailHost.TabIndex = 10;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "yyyy-MM-dd";
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(116, 52);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(143, 25);
            this.dtpBirthday.TabIndex = 3;
            // 
            // cbxMale
            // 
            this.cbxMale.AutoSize = true;
            this.cbxMale.Location = new System.Drawing.Point(277, 20);
            this.cbxMale.Name = "cbxMale";
            this.cbxMale.Size = new System.Drawing.Size(59, 19);
            this.cbxMale.TabIndex = 2;
            this.cbxMale.Text = "남자";
            this.cbxMale.UseVisualStyleBackColor = true;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(116, 17);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(143, 25);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // jusoDataSet
            // 
            this.jusoDataSet.DataSetName = "JusoDataSet";
            this.jusoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblJusoBindingSource
            // 
            this.tblJusoBindingSource.DataMember = "tblJuso";
            this.tblJusoBindingSource.DataSource = this.jusoDataSet;
            // 
            // tblJusoTableAdapter
            // 
            this.tblJusoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tblJusoTableAdapter = this.tblJusoTableAdapter;
            this.tableAdapterManager.UpdateOrder = WinAppAddressBook.JusoDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // AddressDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 353);
            this.Controls.Add(this.mskZipcode);
            this.Controls.Add(this.mskCellPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxEmailHost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearchAddr);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.tbxAddrDetail);
            this.Controls.Add(this.cbxMale);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.tbxAddr);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "AddressDetailForm";
            this.Text = "새 친구 추가";
            this.Load += new System.EventHandler(this.AddressDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jusoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblJusoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxAddr;
        private System.Windows.Forms.TextBox tbxAddrDetail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.MaskedTextBox mskCellPhone;
        private System.Windows.Forms.MaskedTextBox mskZipcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEmailHost;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.CheckBox cbxMale;
        private System.Windows.Forms.TextBox tbxName;
        private JusoDataSet jusoDataSet;
        private System.Windows.Forms.BindingSource tblJusoBindingSource;
        private JusoDataSetTableAdapters.tblJusoTableAdapter tblJusoTableAdapter;
        private JusoDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}