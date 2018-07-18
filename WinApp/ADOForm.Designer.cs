namespace WinApp
{
    partial class ADOForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbxResult = new System.Windows.Forms.ListBox();
            this.btnCreatePeople = new System.Windows.Forms.Button();
            this.btnCreateSale = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxQueryResult = new System.Windows.Forms.ListBox();
            this.cbxQueryMale = new System.Windows.Forms.CheckBox();
            this.nudQueryAge = new System.Windows.Forms.NumericUpDown();
            this.tbxQueryName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxHostName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSomeAge = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsertCommandParams = new System.Windows.Forms.Button();
            this.btnInsertCommandText = new System.Windows.Forms.Button();
            this.btnAllAge = new System.Windows.Forms.Button();
            this.btnSelectMultiTable = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxDeleteName = new System.Windows.Forms.TextBox();
            this.nudNewAge = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.tbxSelectedName = new System.Windows.Forms.TextBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnUpdateAge = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudSearchAgeOver = new System.Windows.Forms.NumericUpDown();
            this.btnSearchAgeOver = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSortDESC = new System.Windows.Forms.Button();
            this.btnSortASC = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvAdtResult = new System.Windows.Forms.DataGridView();
            this.btnAdtUpdate = new System.Windows.Forms.Button();
            this.btnAdtChangedData = new System.Windows.Forms.Button();
            this.btnAdtSelect = new System.Windows.Forms.Button();
            this.btnAdtMerge = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbxBindingName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQueryAge)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewAge)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchAgeOver)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdtResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(480, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 35);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Tag = "Open";
            this.btnConnect.Text = "DB연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(561, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "DB연결끊기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // lbxResult
            // 
            this.lbxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxResult.FormattingEnabled = true;
            this.lbxResult.ItemHeight = 15;
            this.lbxResult.Location = new System.Drawing.Point(17, 24);
            this.lbxResult.Name = "lbxResult";
            this.lbxResult.Size = new System.Drawing.Size(396, 64);
            this.lbxResult.TabIndex = 1;
            this.lbxResult.SelectedIndexChanged += new System.EventHandler(this.lbxResult_SelectedIndexChanged);
            // 
            // btnCreatePeople
            // 
            this.btnCreatePeople.Location = new System.Drawing.Point(611, 24);
            this.btnCreatePeople.Name = "btnCreatePeople";
            this.btnCreatePeople.Size = new System.Drawing.Size(75, 77);
            this.btnCreatePeople.TabIndex = 0;
            this.btnCreatePeople.Tag = "PeopleTable";
            this.btnCreatePeople.Text = "People 테이블 샘플생성";
            this.btnCreatePeople.UseVisualStyleBackColor = true;
            this.btnCreatePeople.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnCreateSale
            // 
            this.btnCreateSale.Location = new System.Drawing.Point(611, 107);
            this.btnCreateSale.Name = "btnCreateSale";
            this.btnCreateSale.Size = new System.Drawing.Size(75, 77);
            this.btnCreateSale.TabIndex = 0;
            this.btnCreateSale.Tag = "SaleTable";
            this.btnCreateSale.Text = "Sale    테이블 샘플생성";
            this.btnCreateSale.UseVisualStyleBackColor = true;
            this.btnCreateSale.Click += new System.EventHandler(this.Button_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 24);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 27;
            this.dgvResult.Size = new System.Drawing.Size(576, 265);
            this.dgvResult.TabIndex = 2;
            this.dgvResult.SelectionChanged += new System.EventHandler(this.dgvResult_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxQueryResult);
            this.groupBox1.Controls.Add(this.cbxQueryMale);
            this.groupBox1.Controls.Add(this.nudQueryAge);
            this.groupBox1.Controls.Add(this.tbxQueryName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxHostName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnCommit);
            this.groupBox1.Controls.Add(this.btnSum);
            this.groupBox1.Controls.Add(this.btnRollback);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSomeAge);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnInsertCommandParams);
            this.groupBox1.Controls.Add(this.btnInsertCommandText);
            this.groupBox1.Controls.Add(this.btnAllAge);
            this.groupBox1.Controls.Add(this.btnSelectMultiTable);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(12, 424);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 217);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터베이스연결";
            // 
            // lbxQueryResult
            // 
            this.lbxQueryResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxQueryResult.FormattingEnabled = true;
            this.lbxQueryResult.ItemHeight = 15;
            this.lbxQueryResult.Location = new System.Drawing.Point(17, 61);
            this.lbxQueryResult.Name = "lbxQueryResult";
            this.lbxQueryResult.Size = new System.Drawing.Size(259, 139);
            this.lbxQueryResult.TabIndex = 20;
            // 
            // cbxQueryMale
            // 
            this.cbxQueryMale.AutoSize = true;
            this.cbxQueryMale.Checked = true;
            this.cbxQueryMale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxQueryMale.Location = new System.Drawing.Point(413, 128);
            this.cbxQueryMale.Name = "cbxQueryMale";
            this.cbxQueryMale.Size = new System.Drawing.Size(59, 19);
            this.cbxQueryMale.TabIndex = 19;
            this.cbxQueryMale.Text = "남자";
            this.cbxQueryMale.UseVisualStyleBackColor = true;
            // 
            // nudQueryAge
            // 
            this.nudQueryAge.Location = new System.Drawing.Point(344, 122);
            this.nudQueryAge.Name = "nudQueryAge";
            this.nudQueryAge.Size = new System.Drawing.Size(55, 25);
            this.nudQueryAge.TabIndex = 18;
            // 
            // tbxQueryName
            // 
            this.tbxQueryName.Location = new System.Drawing.Point(344, 95);
            this.tbxQueryName.Name = "tbxQueryName";
            this.tbxQueryName.Size = new System.Drawing.Size(100, 25);
            this.tbxQueryName.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "나이 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "이름 :";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(332, 26);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(112, 25);
            this.tbxPassword.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "비밀번호";
            // 
            // tbxHostName
            // 
            this.tbxHostName.Location = new System.Drawing.Point(108, 26);
            this.tbxHostName.Name = "tbxHostName";
            this.tbxHostName.Size = new System.Drawing.Size(112, 25);
            this.tbxHostName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB서버명";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(561, 175);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(109, 29);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Tag = "";
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(480, 175);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(75, 29);
            this.btnSum.TabIndex = 0;
            this.btnSum.Tag = "";
            this.btnSum.Text = "SUM";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(561, 140);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(109, 29);
            this.btnRollback.TabIndex = 0;
            this.btnRollback.Tag = "";
            this.btnRollback.Text = "Rollback";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(480, 140);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnSomeAge
            // 
            this.btnSomeAge.Location = new System.Drawing.Point(561, 105);
            this.btnSomeAge.Name = "btnSomeAge";
            this.btnSomeAge.Size = new System.Drawing.Size(109, 29);
            this.btnSomeAge.TabIndex = 0;
            this.btnSomeAge.Tag = "";
            this.btnSomeAge.Text = "IncSomeAge";
            this.btnSomeAge.UseVisualStyleBackColor = true;
            this.btnSomeAge.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(480, 105);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Tag = "";
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnInsertCommandParams
            // 
            this.btnInsertCommandParams.Location = new System.Drawing.Point(382, 158);
            this.btnInsertCommandParams.Name = "btnInsertCommandParams";
            this.btnInsertCommandParams.Size = new System.Drawing.Size(75, 43);
            this.btnInsertCommandParams.TabIndex = 0;
            this.btnInsertCommandParams.Tag = "";
            this.btnInsertCommandParams.Text = "INSERT (params)";
            this.btnInsertCommandParams.UseVisualStyleBackColor = true;
            this.btnInsertCommandParams.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnInsertCommandText
            // 
            this.btnInsertCommandText.Location = new System.Drawing.Point(294, 158);
            this.btnInsertCommandText.Name = "btnInsertCommandText";
            this.btnInsertCommandText.Size = new System.Drawing.Size(75, 43);
            this.btnInsertCommandText.TabIndex = 0;
            this.btnInsertCommandText.Tag = "";
            this.btnInsertCommandText.Text = "INSERT (string)";
            this.btnInsertCommandText.UseVisualStyleBackColor = true;
            this.btnInsertCommandText.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnAllAge
            // 
            this.btnAllAge.Location = new System.Drawing.Point(561, 70);
            this.btnAllAge.Name = "btnAllAge";
            this.btnAllAge.Size = new System.Drawing.Size(109, 29);
            this.btnAllAge.TabIndex = 0;
            this.btnAllAge.Tag = "";
            this.btnAllAge.Text = "IncAllAge";
            this.btnAllAge.UseVisualStyleBackColor = true;
            this.btnAllAge.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnSelectMultiTable
            // 
            this.btnSelectMultiTable.Location = new System.Drawing.Point(294, 60);
            this.btnSelectMultiTable.Name = "btnSelectMultiTable";
            this.btnSelectMultiTable.Size = new System.Drawing.Size(163, 29);
            this.btnSelectMultiTable.TabIndex = 0;
            this.btnSelectMultiTable.Tag = "";
            this.btnSelectMultiTable.Text = "SELECT PeopleNSale";
            this.btnSelectMultiTable.UseVisualStyleBackColor = true;
            this.btnSelectMultiTable.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(480, 70);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 29);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Tag = "";
            this.btnSelect.Text = "SELECT";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxDeleteName);
            this.groupBox2.Controls.Add(this.nudNewAge);
            this.groupBox2.Controls.Add(this.btnDeleteData);
            this.groupBox2.Controls.Add(this.tbxSelectedName);
            this.groupBox2.Controls.Add(this.btnReject);
            this.groupBox2.Controls.Add(this.btnAccept);
            this.groupBox2.Controls.Add(this.btnUpdateAge);
            this.groupBox2.Location = new System.Drawing.Point(12, 647);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 99);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "레코드 정보";
            // 
            // tbxDeleteName
            // 
            this.tbxDeleteName.Location = new System.Drawing.Point(13, 66);
            this.tbxDeleteName.Name = "tbxDeleteName";
            this.tbxDeleteName.Size = new System.Drawing.Size(112, 25);
            this.tbxDeleteName.TabIndex = 5;
            // 
            // nudNewAge
            // 
            this.nudNewAge.Location = new System.Drawing.Point(157, 25);
            this.nudNewAge.Name = "nudNewAge";
            this.nudNewAge.Size = new System.Drawing.Size(74, 25);
            this.nudNewAge.TabIndex = 7;
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Location = new System.Drawing.Point(157, 59);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(98, 35);
            this.btnDeleteData.TabIndex = 0;
            this.btnDeleteData.Tag = "Open";
            this.btnDeleteData.Text = "정보삭제";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.Button_Click);
            // 
            // tbxSelectedName
            // 
            this.tbxSelectedName.Location = new System.Drawing.Point(12, 25);
            this.tbxSelectedName.Name = "tbxSelectedName";
            this.tbxSelectedName.ReadOnly = true;
            this.tbxSelectedName.Size = new System.Drawing.Size(112, 25);
            this.tbxSelectedName.TabIndex = 5;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(514, 56);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(156, 35);
            this.btnReject.TabIndex = 0;
            this.btnReject.Tag = "Open";
            this.btnReject.Text = "REJECT";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(514, 15);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(156, 35);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Tag = "Open";
            this.btnAccept.Text = "ACCEPT";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnUpdateAge
            // 
            this.btnUpdateAge.Location = new System.Drawing.Point(257, 18);
            this.btnUpdateAge.Name = "btnUpdateAge";
            this.btnUpdateAge.Size = new System.Drawing.Size(98, 35);
            this.btnUpdateAge.TabIndex = 0;
            this.btnUpdateAge.Tag = "Open";
            this.btnUpdateAge.Text = "나이변경";
            this.btnUpdateAge.UseVisualStyleBackColor = true;
            this.btnUpdateAge.Click += new System.EventHandler(this.Button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudSearchAgeOver);
            this.groupBox3.Controls.Add(this.lbxResult);
            this.groupBox3.Controls.Add(this.btnSearchAgeOver);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.tbxSearch);
            this.groupBox3.Location = new System.Drawing.Point(12, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(699, 106);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "데이터조회결과";
            // 
            // nudSearchAgeOver
            // 
            this.nudSearchAgeOver.Location = new System.Drawing.Point(447, 65);
            this.nudSearchAgeOver.Name = "nudSearchAgeOver";
            this.nudSearchAgeOver.Size = new System.Drawing.Size(127, 25);
            this.nudSearchAgeOver.TabIndex = 4;
            // 
            // btnSearchAgeOver
            // 
            this.btnSearchAgeOver.Location = new System.Drawing.Point(595, 60);
            this.btnSearchAgeOver.Name = "btnSearchAgeOver";
            this.btnSearchAgeOver.Size = new System.Drawing.Size(75, 35);
            this.btnSearchAgeOver.TabIndex = 0;
            this.btnSearchAgeOver.Tag = "Open";
            this.btnSearchAgeOver.Text = "세 이상";
            this.btnSearchAgeOver.UseVisualStyleBackColor = true;
            this.btnSearchAgeOver.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(595, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Tag = "Open";
            this.btnSearch.Text = "의 나이";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Button_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(447, 25);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(127, 25);
            this.tbxSearch.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreateSale);
            this.groupBox4.Controls.Add(this.btnSortDESC);
            this.groupBox4.Controls.Add(this.btnCreatePeople);
            this.groupBox4.Controls.Add(this.btnSortASC);
            this.groupBox4.Controls.Add(this.dgvResult);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(711, 297);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "데이터테이블조회";
            // 
            // btnSortDESC
            // 
            this.btnSortDESC.Location = new System.Drawing.Point(611, 249);
            this.btnSortDESC.Name = "btnSortDESC";
            this.btnSortDESC.Size = new System.Drawing.Size(75, 35);
            this.btnSortDESC.TabIndex = 3;
            this.btnSortDESC.Tag = "DESC";
            this.btnSortDESC.Text = "내림차순";
            this.btnSortDESC.UseVisualStyleBackColor = true;
            this.btnSortDESC.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnSortASC
            // 
            this.btnSortASC.Location = new System.Drawing.Point(611, 208);
            this.btnSortASC.Name = "btnSortASC";
            this.btnSortASC.Size = new System.Drawing.Size(75, 35);
            this.btnSortASC.TabIndex = 3;
            this.btnSortASC.Tag = "ASC";
            this.btnSortASC.Text = "오름차순";
            this.btnSortASC.UseVisualStyleBackColor = true;
            this.btnSortASC.Click += new System.EventHandler(this.Button_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tbxBindingName);
            this.groupBox5.Controls.Add(this.btnNext);
            this.groupBox5.Controls.Add(this.btnPrev);
            this.groupBox5.Controls.Add(this.dgvAdtResult);
            this.groupBox5.Controls.Add(this.btnAdtMerge);
            this.groupBox5.Controls.Add(this.btnAdtUpdate);
            this.groupBox5.Controls.Add(this.btnAdtChangedData);
            this.groupBox5.Controls.Add(this.btnAdtSelect);
            this.groupBox5.Location = new System.Drawing.Point(12, 752);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(699, 207);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "데이터어댑터";
            // 
            // dgvAdtResult
            // 
            this.dgvAdtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdtResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdtResult.Location = new System.Drawing.Point(13, 29);
            this.dgvAdtResult.Name = "dgvAdtResult";
            this.dgvAdtResult.RowTemplate.Height = 27;
            this.dgvAdtResult.Size = new System.Drawing.Size(467, 171);
            this.dgvAdtResult.TabIndex = 20;
            // 
            // btnAdtUpdate
            // 
            this.btnAdtUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdtUpdate.Location = new System.Drawing.Point(595, 65);
            this.btnAdtUpdate.Name = "btnAdtUpdate";
            this.btnAdtUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnAdtUpdate.TabIndex = 0;
            this.btnAdtUpdate.Tag = "";
            this.btnAdtUpdate.Text = "UPDATE";
            this.btnAdtUpdate.UseVisualStyleBackColor = true;
            this.btnAdtUpdate.Click += new System.EventHandler(this.AdapterButton_Click);
            // 
            // btnAdtChangedData
            // 
            this.btnAdtChangedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdtChangedData.Location = new System.Drawing.Point(595, 139);
            this.btnAdtChangedData.Name = "btnAdtChangedData";
            this.btnAdtChangedData.Size = new System.Drawing.Size(75, 62);
            this.btnAdtChangedData.TabIndex = 0;
            this.btnAdtChangedData.Tag = "";
            this.btnAdtChangedData.Text = "변경된 데이터 조회";
            this.btnAdtChangedData.UseVisualStyleBackColor = true;
            this.btnAdtChangedData.Click += new System.EventHandler(this.AdapterButton_Click);
            // 
            // btnAdtSelect
            // 
            this.btnAdtSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdtSelect.Location = new System.Drawing.Point(595, 30);
            this.btnAdtSelect.Name = "btnAdtSelect";
            this.btnAdtSelect.Size = new System.Drawing.Size(75, 29);
            this.btnAdtSelect.TabIndex = 0;
            this.btnAdtSelect.Tag = "";
            this.btnAdtSelect.Text = "SELECT";
            this.btnAdtSelect.UseVisualStyleBackColor = true;
            this.btnAdtSelect.Click += new System.EventHandler(this.AdapterButton_Click);
            // 
            // btnAdtMerge
            // 
            this.btnAdtMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdtMerge.Location = new System.Drawing.Point(595, 100);
            this.btnAdtMerge.Name = "btnAdtMerge";
            this.btnAdtMerge.Size = new System.Drawing.Size(75, 29);
            this.btnAdtMerge.TabIndex = 0;
            this.btnAdtMerge.Tag = "";
            this.btnAdtMerge.Text = "MERGE";
            this.btnAdtMerge.UseVisualStyleBackColor = true;
            this.btnAdtMerge.Click += new System.EventHandler(this.AdapterButton_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(520, 62);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 35);
            this.btnPrev.TabIndex = 21;
            this.btnPrev.Tag = "";
            this.btnPrev.Text = "▲";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.BindingButton_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(520, 134);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 21;
            this.btnNext.Tag = "";
            this.btnNext.Text = "▼";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BindingButton_Click);
            // 
            // tbxBindingName
            // 
            this.tbxBindingName.Location = new System.Drawing.Point(489, 103);
            this.tbxBindingName.Name = "tbxBindingName";
            this.tbxBindingName.ReadOnly = true;
            this.tbxBindingName.Size = new System.Drawing.Size(100, 25);
            this.tbxBindingName.TabIndex = 22;
            // 
            // ADOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 966);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ADOForm";
            this.Text = "ADO.NET 기본";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ADOForm_FormClosed);
            this.Load += new System.EventHandler(this.ADOForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQueryAge)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewAge)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSearchAgeOver)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdtResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lbxResult;
        private System.Windows.Forms.Button btnCreatePeople;
        private System.Windows.Forms.Button btnCreateSale;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxHostName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudSearchAgeOver;
        private System.Windows.Forms.Button btnSearchAgeOver;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSortDESC;
        private System.Windows.Forms.Button btnSortASC;
        private System.Windows.Forms.TextBox tbxDeleteName;
        private System.Windows.Forms.NumericUpDown nudNewAge;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.TextBox tbxSelectedName;
        private System.Windows.Forms.Button btnUpdateAge;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox cbxQueryMale;
        private System.Windows.Forms.NumericUpDown nudQueryAge;
        private System.Windows.Forms.TextBox tbxQueryName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnSomeAge;
        private System.Windows.Forms.Button btnInsertCommandParams;
        private System.Windows.Forms.Button btnInsertCommandText;
        private System.Windows.Forms.Button btnAllAge;
        private System.Windows.Forms.ListBox lbxQueryResult;
        private System.Windows.Forms.Button btnSelectMultiTable;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAdtUpdate;
        private System.Windows.Forms.Button btnAdtChangedData;
        private System.Windows.Forms.Button btnAdtSelect;
        private System.Windows.Forms.DataGridView dgvAdtResult;
        private System.Windows.Forms.Button btnAdtMerge;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbxBindingName;
    }
}