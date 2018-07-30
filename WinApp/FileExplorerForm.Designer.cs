namespace WinApp
{
    partial class FileExplorerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDir = new System.Windows.Forms.TextBox();
            this.btnSearchDir = new System.Windows.Forms.Button();
            this.lvwResult = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.btnSearchFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "검색할 디렉토리명:";
            // 
            // tbxDir
            // 
            this.tbxDir.Location = new System.Drawing.Point(158, 20);
            this.tbxDir.Name = "tbxDir";
            this.tbxDir.Size = new System.Drawing.Size(231, 25);
            this.tbxDir.TabIndex = 1;
            // 
            // btnSearchDir
            // 
            this.btnSearchDir.Location = new System.Drawing.Point(395, 17);
            this.btnSearchDir.Name = "btnSearchDir";
            this.btnSearchDir.Size = new System.Drawing.Size(75, 31);
            this.btnSearchDir.TabIndex = 2;
            this.btnSearchDir.Text = "검색";
            this.btnSearchDir.UseVisualStyleBackColor = true;
            this.btnSearchDir.Click += new System.EventHandler(this.btnSearchDir_Click);
            // 
            // lvwResult
            // 
            this.lvwResult.Location = new System.Drawing.Point(18, 65);
            this.lvwResult.Name = "lvwResult";
            this.lvwResult.Size = new System.Drawing.Size(452, 331);
            this.lvwResult.TabIndex = 3;
            this.lvwResult.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "검색할 파일명:";
            // 
            // tbxFileName
            // 
            this.tbxFileName.Location = new System.Drawing.Point(131, 414);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(258, 25);
            this.tbxFileName.TabIndex = 1;
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Location = new System.Drawing.Point(395, 411);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(75, 31);
            this.btnSearchFile.TabIndex = 2;
            this.btnSearchFile.Text = "검색";
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // FileExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.lvwResult);
            this.Controls.Add(this.btnSearchFile);
            this.Controls.Add(this.btnSearchDir);
            this.Controls.Add(this.tbxFileName);
            this.Controls.Add(this.tbxDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FileExplorerForm";
            this.Text = "파일 검색 프로그램";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDir;
        private System.Windows.Forms.Button btnSearchDir;
        private System.Windows.Forms.ListView lvwResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Button btnSearchFile;
    }
}