namespace WinApp
{
    partial class DataSetForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxNewMale = new System.Windows.Forms.CheckBox();
            this.nudNewAge = new System.Windows.Forms.NumericUpDown();
            this.tbxNewName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.btnLoadXmlForPeople = new System.Windows.Forms.Button();
            this.btnXmlForPeople = new System.Windows.Forms.Button();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSaleInfo = new System.Windows.Forms.Button();
            this.lbxSale = new System.Windows.Forms.ListBox();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadXmlForSale = new System.Windows.Forms.Button();
            this.btnXmlForSale = new System.Windows.Forms.Button();
            this.lblMale = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCustomerInfo = new System.Windows.Forms.Button();
            this.dgvSale = new System.Windows.Forms.DataGridView();
            this.btnXmlForDataSet = new System.Windows.Forms.Button();
            this.btnLoadXmlForDataSet = new System.Windows.Forms.Button();
            this.dgvNewPeople = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDeletedPeople = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeletedPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxNewMale);
            this.groupBox1.Controls.Add(this.nudNewAge);
            this.groupBox1.Controls.Add(this.tbxNewName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxSearch);
            this.groupBox1.Controls.Add(this.btnLoadXmlForPeople);
            this.groupBox1.Controls.Add(this.btnXmlForPeople);
            this.groupBox1.Controls.Add(this.btnDeleteData);
            this.groupBox1.Controls.Add(this.btnUpdateData);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Controls.Add(this.btnSaleInfo);
            this.groupBox1.Controls.Add(this.lbxSale);
            this.groupBox1.Controls.Add(this.dgvPeople);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 533);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "고객목록";
            // 
            // cbxNewMale
            // 
            this.cbxNewMale.AutoSize = true;
            this.cbxNewMale.Checked = true;
            this.cbxNewMale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNewMale.Location = new System.Drawing.Point(131, 502);
            this.cbxNewMale.Name = "cbxNewMale";
            this.cbxNewMale.Size = new System.Drawing.Size(59, 19);
            this.cbxNewMale.TabIndex = 14;
            this.cbxNewMale.Text = "남자";
            this.cbxNewMale.UseVisualStyleBackColor = true;
            // 
            // nudNewAge
            // 
            this.nudNewAge.Location = new System.Drawing.Point(62, 496);
            this.nudNewAge.Name = "nudNewAge";
            this.nudNewAge.Size = new System.Drawing.Size(55, 25);
            this.nudNewAge.TabIndex = 13;
            // 
            // tbxNewName
            // 
            this.tbxNewName.Location = new System.Drawing.Point(62, 469);
            this.tbxNewName.Name = "tbxNewName";
            this.tbxNewName.Size = new System.Drawing.Size(100, 25);
            this.tbxNewName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "나이 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "이름 :";
            // 
            // cbxSearch
            // 
            this.cbxSearch.FormattingEnabled = true;
            this.cbxSearch.Items.AddRange(new object[] {
            "전체",
            "남자",
            "여자"});
            this.cbxSearch.Location = new System.Drawing.Point(12, 281);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(121, 23);
            this.cbxSearch.TabIndex = 6;
            this.cbxSearch.SelectedIndexChanged += new System.EventHandler(this.cbxSearch_SelectedIndexChanged);
            // 
            // btnLoadXmlForPeople
            // 
            this.btnLoadXmlForPeople.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoadXmlForPeople.Location = new System.Drawing.Point(37, 16);
            this.btnLoadXmlForPeople.Name = "btnLoadXmlForPeople";
            this.btnLoadXmlForPeople.Size = new System.Drawing.Size(162, 36);
            this.btnLoadXmlForPeople.TabIndex = 5;
            this.btnLoadXmlForPeople.Text = "고객목록 XML 읽기";
            this.btnLoadXmlForPeople.UseVisualStyleBackColor = false;
            this.btnLoadXmlForPeople.Click += new System.EventHandler(this.btnLoadXmlForPeople_Click);
            // 
            // btnXmlForPeople
            // 
            this.btnXmlForPeople.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXmlForPeople.Location = new System.Drawing.Point(202, 16);
            this.btnXmlForPeople.Name = "btnXmlForPeople";
            this.btnXmlForPeople.Size = new System.Drawing.Size(162, 36);
            this.btnXmlForPeople.TabIndex = 5;
            this.btnXmlForPeople.Text = "고객목록 XML 저장";
            this.btnXmlForPeople.UseVisualStyleBackColor = false;
            this.btnXmlForPeople.Click += new System.EventHandler(this.btnXmlForPeople_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(256, 472);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(54, 49);
            this.btnUpdateData.TabIndex = 5;
            this.btnUpdateData.Text = "수정";
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(202, 472);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(54, 49);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "추가";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSaleInfo
            // 
            this.btnSaleInfo.Location = new System.Drawing.Point(222, 286);
            this.btnSaleInfo.Name = "btnSaleInfo";
            this.btnSaleInfo.Size = new System.Drawing.Size(142, 36);
            this.btnSaleInfo.TabIndex = 5;
            this.btnSaleInfo.Text = "구입한 상품보기";
            this.btnSaleInfo.UseVisualStyleBackColor = true;
            this.btnSaleInfo.Click += new System.EventHandler(this.btnSaleInfo_Click);
            // 
            // lbxSale
            // 
            this.lbxSale.FormattingEnabled = true;
            this.lbxSale.ItemHeight = 15;
            this.lbxSale.Location = new System.Drawing.Point(12, 332);
            this.lbxSale.Name = "lbxSale";
            this.lbxSale.Size = new System.Drawing.Size(352, 124);
            this.lbxSale.TabIndex = 4;
            // 
            // dgvPeople
            // 
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Location = new System.Drawing.Point(12, 58);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.RowTemplate.Height = 27;
            this.dgvPeople.Size = new System.Drawing.Size(352, 217);
            this.dgvPeople.TabIndex = 3;
            this.dgvPeople.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvPeople_RowStateChanged);
            this.dgvPeople.SelectionChanged += new System.EventHandler(this.dgvPeople_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadXmlForSale);
            this.groupBox2.Controls.Add(this.btnXmlForSale);
            this.groupBox2.Controls.Add(this.lblMale);
            this.groupBox2.Controls.Add(this.lblAge);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCustomerInfo);
            this.groupBox2.Controls.Add(this.dgvSale);
            this.groupBox2.Location = new System.Drawing.Point(406, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 471);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "구입목록";
            // 
            // btnLoadXmlForSale
            // 
            this.btnLoadXmlForSale.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoadXmlForSale.Location = new System.Drawing.Point(42, 16);
            this.btnLoadXmlForSale.Name = "btnLoadXmlForSale";
            this.btnLoadXmlForSale.Size = new System.Drawing.Size(162, 36);
            this.btnLoadXmlForSale.TabIndex = 9;
            this.btnLoadXmlForSale.Text = "구입목록 XML 읽기";
            this.btnLoadXmlForSale.UseVisualStyleBackColor = false;
            this.btnLoadXmlForSale.Click += new System.EventHandler(this.btnLoadXmlForSale_Click);
            // 
            // btnXmlForSale
            // 
            this.btnXmlForSale.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXmlForSale.Location = new System.Drawing.Point(207, 16);
            this.btnXmlForSale.Name = "btnXmlForSale";
            this.btnXmlForSale.Size = new System.Drawing.Size(162, 36);
            this.btnXmlForSale.TabIndex = 9;
            this.btnXmlForSale.Text = "구입목록 XML 저장";
            this.btnXmlForSale.UseVisualStyleBackColor = false;
            this.btnXmlForSale.Click += new System.EventHandler(this.btnXmlForSale_Click);
            // 
            // lblMale
            // 
            this.lblMale.AutoSize = true;
            this.lblMale.Location = new System.Drawing.Point(73, 406);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new System.Drawing.Size(0, 15);
            this.lblMale.TabIndex = 8;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(73, 375);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(0, 15);
            this.lblAge.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "성별 :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(73, 344);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 15);
            this.lblName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "나이 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "이름 :";
            // 
            // btnCustomerInfo
            // 
            this.btnCustomerInfo.Location = new System.Drawing.Point(12, 286);
            this.btnCustomerInfo.Name = "btnCustomerInfo";
            this.btnCustomerInfo.Size = new System.Drawing.Size(142, 36);
            this.btnCustomerInfo.TabIndex = 6;
            this.btnCustomerInfo.Text = "구입한 고객정보";
            this.btnCustomerInfo.UseVisualStyleBackColor = true;
            this.btnCustomerInfo.Click += new System.EventHandler(this.btnCustomerInfo_Click);
            // 
            // dgvSale
            // 
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSale.Location = new System.Drawing.Point(12, 58);
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.RowTemplate.Height = 27;
            this.dgvSale.Size = new System.Drawing.Size(352, 217);
            this.dgvSale.TabIndex = 3;
            // 
            // btnXmlForDataSet
            // 
            this.btnXmlForDataSet.BackColor = System.Drawing.SystemColors.Control;
            this.btnXmlForDataSet.Location = new System.Drawing.Point(617, 483);
            this.btnXmlForDataSet.Name = "btnXmlForDataSet";
            this.btnXmlForDataSet.Size = new System.Drawing.Size(162, 56);
            this.btnXmlForDataSet.TabIndex = 5;
            this.btnXmlForDataSet.Text = "데이터셋 XML 저장";
            this.btnXmlForDataSet.UseVisualStyleBackColor = false;
            this.btnXmlForDataSet.Click += new System.EventHandler(this.btnXmlForDataSet_Click);
            // 
            // btnLoadXmlForDataSet
            // 
            this.btnLoadXmlForDataSet.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoadXmlForDataSet.Location = new System.Drawing.Point(452, 483);
            this.btnLoadXmlForDataSet.Name = "btnLoadXmlForDataSet";
            this.btnLoadXmlForDataSet.Size = new System.Drawing.Size(162, 56);
            this.btnLoadXmlForDataSet.TabIndex = 5;
            this.btnLoadXmlForDataSet.Text = "데이터셋 XML 읽기";
            this.btnLoadXmlForDataSet.UseVisualStyleBackColor = false;
            this.btnLoadXmlForDataSet.Click += new System.EventHandler(this.btnLoadXmlForDataSet_Click);
            // 
            // dgvNewPeople
            // 
            this.dgvNewPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewPeople.Location = new System.Drawing.Point(23, 605);
            this.dgvNewPeople.Name = "dgvNewPeople";
            this.dgvNewPeople.RowTemplate.Height = 27;
            this.dgvNewPeople.Size = new System.Drawing.Size(352, 112);
            this.dgvNewPeople.TabIndex = 3;
            this.dgvNewPeople.SelectionChanged += new System.EventHandler(this.dgvPeople_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 573);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "새로 추가된 고객";
            // 
            // dgvDeletedPeople
            // 
            this.dgvDeletedPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeletedPeople.Location = new System.Drawing.Point(418, 605);
            this.dgvDeletedPeople.Name = "dgvDeletedPeople";
            this.dgvDeletedPeople.RowTemplate.Height = 27;
            this.dgvDeletedPeople.Size = new System.Drawing.Size(352, 112);
            this.dgvDeletedPeople.TabIndex = 3;
            this.dgvDeletedPeople.SelectionChanged += new System.EventHandler(this.dgvPeople_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 573);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "삭제된 고객";
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Location = new System.Drawing.Point(310, 472);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(54, 49);
            this.btnDeleteData.TabIndex = 5;
            this.btnDeleteData.Text = "삭제";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // DataSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 729);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoadXmlForDataSet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnXmlForDataSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDeletedPeople);
            this.Controls.Add(this.dgvNewPeople);
            this.Name = "DataSetForm";
            this.Text = "데이터셋";
            this.Load += new System.EventHandler(this.DataSetForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeletedPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaleInfo;
        private System.Windows.Forms.ListBox lbxSale;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMale;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCustomerInfo;
        private System.Windows.Forms.DataGridView dgvSale;
        private System.Windows.Forms.Button btnXmlForPeople;
        private System.Windows.Forms.Button btnXmlForSale;
        private System.Windows.Forms.Button btnLoadXmlForPeople;
        private System.Windows.Forms.Button btnLoadXmlForSale;
        private System.Windows.Forms.Button btnXmlForDataSet;
        private System.Windows.Forms.Button btnLoadXmlForDataSet;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.CheckBox cbxNewMale;
        private System.Windows.Forms.NumericUpDown nudNewAge;
        private System.Windows.Forms.TextBox tbxNewName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dgvNewPeople;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDeletedPeople;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteData;
    }
}