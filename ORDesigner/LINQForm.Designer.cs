namespace ORDesigner
{
    partial class LINQForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label ageLabel;
            System.Windows.Forms.Label maleLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LINQForm));
            this.lbxResult = new System.Windows.Forms.ListBox();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tblPeopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adoPeopleDataSet = new ORDesigner.ADOPeopleDataSet();
            this.tblBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTblPeopleBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbxName = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearchByName = new System.Windows.Forms.ToolStripButton();
            this.tblSaleDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblSaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.maleCheckBox = new System.Windows.Forms.CheckBox();
            this.btnFillBy35 = new System.Windows.Forms.Button();
            this.btnGetCount = new System.Windows.Forms.Button();
            this.brnUpdateByName = new System.Windows.Forms.Button();
            this.btnGetToday = new System.Windows.Forms.Button();
            this.tblPeopleTableAdapter = new ORDesigner.ADOPeopleDataSetTableAdapters.tblPeopleTableAdapter();
            this.tblSaleTableAdapter = new ORDesigner.ADOPeopleDataSetTableAdapters.tblSaleTableAdapter();
            this.tblAdapterManager = new ORDesigner.ADOPeopleDataSetTableAdapters.TableAdapterManager();
            nameLabel = new System.Windows.Forms.Label();
            ageLabel = new System.Windows.Forms.Label();
            maleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adoPeopleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBindingNavigator)).BeginInit();
            this.tblBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSaleDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSaleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(592, 45);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(42, 15);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "이름:";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new System.Drawing.Point(592, 76);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new System.Drawing.Size(42, 15);
            ageLabel.TabIndex = 6;
            ageLabel.Text = "나이:";
            // 
            // maleLabel
            // 
            maleLabel.AutoSize = true;
            maleLabel.Location = new System.Drawing.Point(592, 109);
            maleLabel.Name = "maleLabel";
            maleLabel.Size = new System.Drawing.Size(42, 15);
            maleLabel.TabIndex = 8;
            maleLabel.Text = "성별:";
            // 
            // lbxResult
            // 
            this.lbxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxResult.FormattingEnabled = true;
            this.lbxResult.ItemHeight = 15;
            this.lbxResult.Location = new System.Drawing.Point(12, 42);
            this.lbxResult.Name = "lbxResult";
            this.lbxResult.Size = new System.Drawing.Size(193, 289);
            this.lbxResult.TabIndex = 0;
            // 
            // dgvPeople
            // 
            this.dgvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeople.AutoGenerateColumns = false;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.maleDataGridViewCheckBoxColumn});
            this.dgvPeople.DataSource = this.tblPeopleBindingSource;
            this.dgvPeople.Location = new System.Drawing.Point(220, 45);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.RowTemplate.Height = 27;
            this.dgvPeople.Size = new System.Drawing.Size(349, 289);
            this.dgvPeople.TabIndex = 1;
            this.dgvPeople.SelectionChanged += new System.EventHandler(this.dgvPeople_SelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.FillWeight = 60F;
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.Width = 60;
            // 
            // maleDataGridViewCheckBoxColumn
            // 
            this.maleDataGridViewCheckBoxColumn.DataPropertyName = "Male";
            this.maleDataGridViewCheckBoxColumn.FillWeight = 60F;
            this.maleDataGridViewCheckBoxColumn.HeaderText = "Male";
            this.maleDataGridViewCheckBoxColumn.Name = "maleDataGridViewCheckBoxColumn";
            this.maleDataGridViewCheckBoxColumn.Width = 60;
            // 
            // tblPeopleBindingSource
            // 
            this.tblPeopleBindingSource.DataMember = "tblPeople";
            this.tblPeopleBindingSource.DataSource = this.adoPeopleDataSet;
            // 
            // adoPeopleDataSet
            // 
            this.adoPeopleDataSet.DataSetName = "ADOPeopleDataSet";
            this.adoPeopleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblBindingNavigator
            // 
            this.tblBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tblBindingNavigator.BindingSource = this.tblPeopleBindingSource;
            this.tblBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tblBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tblBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tblBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tsbTblPeopleBindingNavigatorSaveItem,
            this.toolStripLabel1,
            this.tsTbxName,
            this.tsBtnSearchByName});
            this.tblBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tblBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tblBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tblBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tblBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tblBindingNavigator.Name = "tblBindingNavigator";
            this.tblBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tblBindingNavigator.Size = new System.Drawing.Size(1147, 27);
            this.tblBindingNavigator.TabIndex = 2;
            this.tblBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem.Text = "새로 추가";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(33, 24);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "전체 항목 수";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem.Text = "삭제";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "처음으로 이동";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "이전으로 이동";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "위치";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "현재 위치";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "다음으로 이동";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "마지막으로 이동";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbTblPeopleBindingNavigatorSaveItem
            // 
            this.tsbTblPeopleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTblPeopleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbTblPeopleBindingNavigatorSaveItem.Image")));
            this.tsbTblPeopleBindingNavigatorSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTblPeopleBindingNavigatorSaveItem.Name = "tsbTblPeopleBindingNavigatorSaveItem";
            this.tsbTblPeopleBindingNavigatorSaveItem.Size = new System.Drawing.Size(24, 24);
            this.tsbTblPeopleBindingNavigatorSaveItem.Text = "저장";
            this.tsbTblPeopleBindingNavigatorSaveItem.Click += new System.EventHandler(this.TblPeopleBindingNavigatorButton_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 24);
            this.toolStripLabel1.Text = "검색할사람이름:";
            // 
            // tsTbxName
            // 
            this.tsTbxName.Name = "tsTbxName";
            this.tsTbxName.Size = new System.Drawing.Size(100, 27);
            // 
            // tsBtnSearchByName
            // 
            this.tsBtnSearchByName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSearchByName.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSearchByName.Image")));
            this.tsBtnSearchByName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSearchByName.Name = "tsBtnSearchByName";
            this.tsBtnSearchByName.Size = new System.Drawing.Size(24, 24);
            this.tsBtnSearchByName.Text = "toolStripButton1";
            this.tsBtnSearchByName.Click += new System.EventHandler(this.TblPeopleBindingNavigatorButton_Click);
            // 
            // tblSaleDataGridView
            // 
            this.tblSaleDataGridView.AutoGenerateColumns = false;
            this.tblSaleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSaleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.tblSaleDataGridView.DataSource = this.tblSaleBindingSource;
            this.tblSaleDataGridView.Location = new System.Drawing.Point(756, 45);
            this.tblSaleDataGridView.Name = "tblSaleDataGridView";
            this.tblSaleDataGridView.RowTemplate.Height = 27;
            this.tblSaleDataGridView.Size = new System.Drawing.Size(371, 289);
            this.tblSaleDataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderNo";
            this.dataGridViewTextBoxColumn1.FillWeight = 60F;
            this.dataGridViewTextBoxColumn1.HeaderText = "OrderNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Customer";
            this.dataGridViewTextBoxColumn2.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn3.HeaderText = "Item";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "OrderDate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // tblSaleBindingSource
            // 
            this.tblSaleBindingSource.DataMember = "tblSale";
            this.tblSaleBindingSource.DataSource = this.adoPeopleDataSet;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblPeopleBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(646, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(90, 25);
            this.nameTextBox.TabIndex = 5;
            // 
            // ageTextBox
            // 
            this.ageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblPeopleBindingSource, "Age", true));
            this.ageTextBox.Location = new System.Drawing.Point(646, 73);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(57, 25);
            this.ageTextBox.TabIndex = 7;
            // 
            // maleCheckBox
            // 
            this.maleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tblPeopleBindingSource, "Male", true));
            this.maleCheckBox.Location = new System.Drawing.Point(646, 104);
            this.maleCheckBox.Name = "maleCheckBox";
            this.maleCheckBox.Size = new System.Drawing.Size(104, 24);
            this.maleCheckBox.TabIndex = 9;
            this.maleCheckBox.Text = "남자";
            this.maleCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnFillBy35
            // 
            this.btnFillBy35.Location = new System.Drawing.Point(595, 176);
            this.btnFillBy35.Name = "btnFillBy35";
            this.btnFillBy35.Size = new System.Drawing.Size(141, 38);
            this.btnFillBy35.TabIndex = 10;
            this.btnFillBy35.Text = "35세이상";
            this.btnFillBy35.UseVisualStyleBackColor = true;
            this.btnFillBy35.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnGetCount
            // 
            this.btnGetCount.Location = new System.Drawing.Point(595, 216);
            this.btnGetCount.Name = "btnGetCount";
            this.btnGetCount.Size = new System.Drawing.Size(141, 38);
            this.btnGetCount.TabIndex = 10;
            this.btnGetCount.Text = "회원수조회";
            this.btnGetCount.UseVisualStyleBackColor = true;
            this.btnGetCount.Click += new System.EventHandler(this.Button_Click);
            // 
            // brnUpdateByName
            // 
            this.brnUpdateByName.Location = new System.Drawing.Point(595, 256);
            this.brnUpdateByName.Name = "brnUpdateByName";
            this.brnUpdateByName.Size = new System.Drawing.Size(141, 38);
            this.brnUpdateByName.TabIndex = 10;
            this.brnUpdateByName.Text = "이름으로 수정";
            this.brnUpdateByName.UseVisualStyleBackColor = true;
            this.brnUpdateByName.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnGetToday
            // 
            this.btnGetToday.Location = new System.Drawing.Point(595, 296);
            this.btnGetToday.Name = "btnGetToday";
            this.btnGetToday.Size = new System.Drawing.Size(141, 38);
            this.btnGetToday.TabIndex = 10;
            this.btnGetToday.Text = "시스템날짜";
            this.btnGetToday.UseVisualStyleBackColor = true;
            this.btnGetToday.Click += new System.EventHandler(this.Button_Click);
            // 
            // tblPeopleTableAdapter
            // 
            this.tblPeopleTableAdapter.ClearBeforeFill = true;
            // 
            // tblSaleTableAdapter
            // 
            this.tblSaleTableAdapter.ClearBeforeFill = true;
            // 
            // tblAdapterManager
            // 
            this.tblAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tblAdapterManager.tblPeopleTableAdapter = this.tblPeopleTableAdapter;
            this.tblAdapterManager.tblSaleTableAdapter = this.tblSaleTableAdapter;
            this.tblAdapterManager.UpdateOrder = ORDesigner.ADOPeopleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // LINQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 348);
            this.Controls.Add(this.btnGetToday);
            this.Controls.Add(this.brnUpdateByName);
            this.Controls.Add(this.btnGetCount);
            this.Controls.Add(this.btnFillBy35);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(ageLabel);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(maleLabel);
            this.Controls.Add(this.maleCheckBox);
            this.Controls.Add(this.tblSaleDataGridView);
            this.Controls.Add(this.tblBindingNavigator);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.lbxResult);
            this.Name = "LINQForm";
            this.Text = "LINQ to SQL";
            this.Load += new System.EventHandler(this.LINQForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adoPeopleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBindingNavigator)).EndInit();
            this.tblBindingNavigator.ResumeLayout(false);
            this.tblBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSaleDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSaleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxResult;
        private System.Windows.Forms.DataGridView dgvPeople;
        private ADOPeopleDataSet adoPeopleDataSet;
        private System.Windows.Forms.BindingSource tblPeopleBindingSource;
        private ADOPeopleDataSetTableAdapters.tblPeopleTableAdapter tblPeopleTableAdapter;
        private System.Windows.Forms.BindingNavigator tblBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tsbTblPeopleBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingSource tblSaleBindingSource;
        private ADOPeopleDataSetTableAdapters.tblSaleTableAdapter tblSaleTableAdapter;
        private ADOPeopleDataSetTableAdapters.TableAdapterManager tblAdapterManager;
        private System.Windows.Forms.DataGridView tblSaleDataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.CheckBox maleCheckBox;
        private System.Windows.Forms.Button btnFillBy35;
        private System.Windows.Forms.Button btnGetCount;
        private System.Windows.Forms.Button brnUpdateByName;
        private System.Windows.Forms.Button btnGetToday;
        private System.Windows.Forms.ToolStripTextBox tsTbxName;
        private System.Windows.Forms.ToolStripButton tsBtnSearchByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn maleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

