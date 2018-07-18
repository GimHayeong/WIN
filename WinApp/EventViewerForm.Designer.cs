namespace WinApp
{
    partial class EventViewerForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.chkIsWatch = new System.Windows.Forms.CheckBox();
            this.txtEventViewer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(379, 166);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(141, 46);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "모두지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkIsWatch
            // 
            this.chkIsWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsWatch.AutoSize = true;
            this.chkIsWatch.Location = new System.Drawing.Point(379, 242);
            this.chkIsWatch.Name = "chkIsWatch";
            this.chkIsWatch.Size = new System.Drawing.Size(89, 19);
            this.chkIsWatch.TabIndex = 2;
            this.chkIsWatch.Text = "감시중지";
            this.chkIsWatch.UseVisualStyleBackColor = true;
            // 
            // txtEventViewer
            // 
            this.txtEventViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventViewer.Location = new System.Drawing.Point(12, 12);
            this.txtEventViewer.Multiline = true;
            this.txtEventViewer.Name = "txtEventViewer";
            this.txtEventViewer.Size = new System.Drawing.Size(346, 449);
            this.txtEventViewer.TabIndex = 3;
            // 
            // EventViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 473);
            this.Controls.Add(this.txtEventViewer);
            this.Controls.Add(this.chkIsWatch);
            this.Controls.Add(this.btnClear);
            this.Name = "EventViewerForm";
            this.Text = "EventViewerForm";
            this.Load += new System.EventHandler(this.EventViewerForm_Load);
            this.Shown += new System.EventHandler(this.EventViewerForm_Shown);
            this.Enter += new System.EventHandler(this.EventViewerForm_Enter);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.EventViewerForm_Layout);
            this.Leave += new System.EventHandler(this.EventViewerForm_Leave);
            this.Resize += new System.EventHandler(this.EventViewerForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkIsWatch;
        private System.Windows.Forms.TextBox txtEventViewer;
    }
}