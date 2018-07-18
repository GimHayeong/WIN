namespace WinApp
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.btnPrintOption = new System.Windows.Forms.Button();
            this.prtDlg = new System.Windows.Forms.PrintDialog();
            this.lbxData = new System.Windows.Forms.ListBox();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.pgsDlg = new System.Windows.Forms.PageSetupDialog();
            this.prtDoc = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.prtPrvDlg = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnPrintOption
            // 
            this.btnPrintOption.Location = new System.Drawing.Point(12, 12);
            this.btnPrintOption.Name = "btnPrintOption";
            this.btnPrintOption.Size = new System.Drawing.Size(93, 39);
            this.btnPrintOption.TabIndex = 0;
            this.btnPrintOption.Text = "인쇄설정";
            this.btnPrintOption.UseVisualStyleBackColor = true;
            this.btnPrintOption.Click += new System.EventHandler(this.btnPrintOption_Click);
            // 
            // prtDlg
            // 
            this.prtDlg.UseEXDialog = true;
            // 
            // lbxData
            // 
            this.lbxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxData.FormattingEnabled = true;
            this.lbxData.ItemHeight = 15;
            this.lbxData.Location = new System.Drawing.Point(12, 241);
            this.lbxData.Name = "lbxData";
            this.lbxData.Size = new System.Drawing.Size(653, 319);
            this.lbxData.TabIndex = 1;
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.Location = new System.Drawing.Point(116, 12);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(93, 39);
            this.btnPageSetup.TabIndex = 0;
            this.btnPageSetup.Text = "페이지설정";
            this.btnPageSetup.UseVisualStyleBackColor = true;
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // prtDoc
            // 
            this.prtDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prtDoc_BeginPrint);
            this.prtDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.prtDoc_EndPrint);
            this.prtDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDoc_PrintPage);
            this.prtDoc.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.prtDoc_QueryPageSettings);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(324, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 39);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "인쇄하기";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Location = new System.Drawing.Point(428, 12);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(93, 39);
            this.btnPrintAll.TabIndex = 0;
            this.btnPrintAll.Text = "전체인쇄";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(220, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 39);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "미리보기";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // prtPrvDlg
            // 
            this.prtPrvDlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prtPrvDlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prtPrvDlg.ClientSize = new System.Drawing.Size(400, 300);
            this.prtPrvDlg.Enabled = true;
            this.prtPrvDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("prtPrvDlg.Icon")));
            this.prtPrvDlg.Name = "prtPrvDlg";
            this.prtPrvDlg.Visible = false;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 572);
            this.Controls.Add(this.lbxData);
            this.Controls.Add(this.btnPrintAll);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPageSetup);
            this.Controls.Add(this.btnPrintOption);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintOption;
        private System.Windows.Forms.PrintDialog prtDlg;
        private System.Windows.Forms.ListBox lbxData;
        private System.Windows.Forms.Button btnPageSetup;
        private System.Windows.Forms.PageSetupDialog pgsDlg;
        private System.Drawing.Printing.PrintDocument prtDoc;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.PrintPreviewDialog prtPrvDlg;
    }
}