namespace WinAppVideoRentalStore
{
    partial class VRSVideoForm
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
            this.grpbxVideoType = new System.Windows.Forms.GroupBox();
            this.rdoEtc = new System.Windows.Forms.RadioButton();
            this.rdoMelo = new System.Windows.Forms.RadioButton();
            this.rdoKids = new System.Windows.Forms.RadioButton();
            this.rdoComedy = new System.Windows.Forms.RadioButton();
            this.rdoErotic = new System.Windows.Forms.RadioButton();
            this.rdoAction = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxProducer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDirector = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxStarring = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskStock = new System.Windows.Forms.MaskedTextBox();
            this.mskProductionYear = new System.Windows.Forms.MaskedTextBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.vrsDataSet = new WinAppVideoRentalStore.VRSDataSet();
            this.tblVideoTableAdt = new WinAppVideoRentalStore.VRSDataSetTableAdapters.tblVideoTableAdapter();
            this.tblCodeTableAdt = new WinAppVideoRentalStore.VRSDataSetTableAdapters.tblCodeTableAdapter();
            this.grpbxVideoType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vrsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbxVideoType
            // 
            this.grpbxVideoType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbxVideoType.Controls.Add(this.rdoEtc);
            this.grpbxVideoType.Controls.Add(this.rdoMelo);
            this.grpbxVideoType.Controls.Add(this.rdoKids);
            this.grpbxVideoType.Controls.Add(this.rdoComedy);
            this.grpbxVideoType.Controls.Add(this.rdoErotic);
            this.grpbxVideoType.Controls.Add(this.rdoAction);
            this.grpbxVideoType.Location = new System.Drawing.Point(307, 53);
            this.grpbxVideoType.Name = "grpbxVideoType";
            this.grpbxVideoType.Size = new System.Drawing.Size(263, 166);
            this.grpbxVideoType.TabIndex = 7;
            this.grpbxVideoType.TabStop = false;
            this.grpbxVideoType.Text = "비디오 유형";
            // 
            // rdoEtc
            // 
            this.rdoEtc.AutoSize = true;
            this.rdoEtc.Location = new System.Drawing.Point(152, 111);
            this.rdoEtc.Name = "rdoEtc";
            this.rdoEtc.Size = new System.Drawing.Size(58, 19);
            this.rdoEtc.TabIndex = 12;
            this.rdoEtc.Text = "기타";
            this.rdoEtc.UseVisualStyleBackColor = true;
            this.rdoEtc.CheckedChanged += new System.EventHandler(this.VideoType_CheckedChanged);
            this.rdoEtc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_KeyDown);
            // 
            // rdoMelo
            // 
            this.rdoMelo.AutoSize = true;
            this.rdoMelo.Location = new System.Drawing.Point(152, 76);
            this.rdoMelo.Name = "rdoMelo";
            this.rdoMelo.Size = new System.Drawing.Size(58, 19);
            this.rdoMelo.TabIndex = 10;
            this.rdoMelo.Text = "멜로";
            this.rdoMelo.UseVisualStyleBackColor = true;
            this.rdoMelo.CheckedChanged += new System.EventHandler(this.VideoType_CheckedChanged);
            this.rdoMelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_KeyDown);
            // 
            // rdoKids
            // 
            this.rdoKids.AutoSize = true;
            this.rdoKids.Location = new System.Drawing.Point(36, 111);
            this.rdoKids.Name = "rdoKids";
            this.rdoKids.Size = new System.Drawing.Size(73, 19);
            this.rdoKids.TabIndex = 11;
            this.rdoKids.Text = "어린이";
            this.rdoKids.UseVisualStyleBackColor = true;
            this.rdoKids.CheckedChanged += new System.EventHandler(this.VideoType_CheckedChanged);
            this.rdoKids.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_KeyDown);
            // 
            // rdoComedy
            // 
            this.rdoComedy.AutoSize = true;
            this.rdoComedy.Location = new System.Drawing.Point(152, 41);
            this.rdoComedy.Name = "rdoComedy";
            this.rdoComedy.Size = new System.Drawing.Size(73, 19);
            this.rdoComedy.TabIndex = 8;
            this.rdoComedy.Text = "코미디";
            this.rdoComedy.UseVisualStyleBackColor = true;
            this.rdoComedy.CheckedChanged += new System.EventHandler(this.VideoType_CheckedChanged);
            this.rdoComedy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_KeyDown);
            // 
            // rdoErotic
            // 
            this.rdoErotic.AutoSize = true;
            this.rdoErotic.Location = new System.Drawing.Point(36, 76);
            this.rdoErotic.Name = "rdoErotic";
            this.rdoErotic.Size = new System.Drawing.Size(58, 19);
            this.rdoErotic.TabIndex = 9;
            this.rdoErotic.Text = "에로";
            this.rdoErotic.UseVisualStyleBackColor = true;
            this.rdoErotic.CheckedChanged += new System.EventHandler(this.VideoType_CheckedChanged);
            this.rdoErotic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_KeyDown);
            // 
            // rdoAction
            // 
            this.rdoAction.AutoSize = true;
            this.rdoAction.Location = new System.Drawing.Point(36, 41);
            this.rdoAction.Name = "rdoAction";
            this.rdoAction.Size = new System.Drawing.Size(58, 19);
            this.rdoAction.TabIndex = 7;
            this.rdoAction.Text = "액션";
            this.rdoAction.UseVisualStyleBackColor = true;
            this.rdoAction.CheckedChanged += new System.EventHandler(this.VideoType_CheckedChanged);
            this.rdoAction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(322, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(193, 403);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 36);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // tbxTitle
            // 
            this.tbxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTitle.Location = new System.Drawing.Point(104, 18);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(466, 25);
            this.tbxTitle.TabIndex = 1;
            this.tbxTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "제　　목 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "수　　량 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "제 작 사 :";
            // 
            // tbxProducer
            // 
            this.tbxProducer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxProducer.Location = new System.Drawing.Point(104, 90);
            this.tbxProducer.Name = "tbxProducer";
            this.tbxProducer.Size = new System.Drawing.Size(179, 25);
            this.tbxProducer.TabIndex = 3;
            this.tbxProducer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "감　　독 :";
            // 
            // tbxDirector
            // 
            this.tbxDirector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDirector.Location = new System.Drawing.Point(104, 126);
            this.tbxDirector.Name = "tbxDirector";
            this.tbxDirector.Size = new System.Drawing.Size(112, 25);
            this.tbxDirector.TabIndex = 4;
            this.tbxDirector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "주　　연 :";
            // 
            // tbxStarring
            // 
            this.tbxStarring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxStarring.Location = new System.Drawing.Point(104, 162);
            this.tbxStarring.Name = "tbxStarring";
            this.tbxStarring.Size = new System.Drawing.Size(179, 25);
            this.tbxStarring.TabIndex = 5;
            this.tbxStarring.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "제작연도 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "년";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "개";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(104, 234);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(466, 150);
            this.rtbDescription.TabIndex = 13;
            this.rtbDescription.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "작품설명 :";
            // 
            // mskStock
            // 
            this.mskStock.Location = new System.Drawing.Point(104, 54);
            this.mskStock.Mask = "99999";
            this.mskStock.Name = "mskStock";
            this.mskStock.Size = new System.Drawing.Size(66, 25);
            this.mskStock.TabIndex = 2;
            this.mskStock.ValidatingType = typeof(int);
            this.mskStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // mskProductionYear
            // 
            this.mskProductionYear.Location = new System.Drawing.Point(104, 198);
            this.mskProductionYear.Mask = "9999";
            this.mskProductionYear.Name = "mskProductionYear";
            this.mskProductionYear.Size = new System.Drawing.Size(66, 25);
            this.mskProductionYear.TabIndex = 6;
            this.mskProductionYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // vrsDataSet
            // 
            this.vrsDataSet.DataSetName = "VRSDataSet";
            this.vrsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblVideoTableAdt
            // 
            this.tblVideoTableAdt.ClearBeforeFill = true;
            // 
            // tblCodeTableAdt
            // 
            this.tblCodeTableAdt.ClearBeforeFill = true;
            // 
            // VRSVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.mskProductionYear);
            this.Controls.Add(this.mskStock);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.grpbxVideoType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxStarring);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxDirector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxProducer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "VRSVideoForm";
            this.Text = "비디오등록";
            this.Load += new System.EventHandler(this.VRSVideoForm_Load);
            this.grpbxVideoType.ResumeLayout(false);
            this.grpbxVideoType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vrsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxVideoType;
        private System.Windows.Forms.RadioButton rdoEtc;
        private System.Windows.Forms.RadioButton rdoMelo;
        private System.Windows.Forms.RadioButton rdoKids;
        private System.Windows.Forms.RadioButton rdoComedy;
        private System.Windows.Forms.RadioButton rdoErotic;
        private System.Windows.Forms.RadioButton rdoAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxProducer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDirector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxStarring;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskStock;
        private System.Windows.Forms.MaskedTextBox mskProductionYear;
        private System.Windows.Forms.ToolTip tip;
        private VRSDataSet vrsDataSet;
        private VRSDataSetTableAdapters.tblVideoTableAdapter tblVideoTableAdt;
        private VRSDataSetTableAdapters.tblCodeTableAdapter tblCodeTableAdt;
    }
}