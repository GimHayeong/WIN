﻿namespace WinApp
{
    partial class FormLoadForm
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
            this.SuspendLayout();
            // 
            // FormLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 411);
            this.Name = "FormLoadForm";
            this.Text = "FormLoadForm";
            this.Activated += new System.EventHandler(this.FormLoadForm_Activated);
            this.Deactivate += new System.EventHandler(this.FormLoadForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoadForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLoadForm_FormClosed);
            this.Load += new System.EventHandler(this.FormLoadForm_Load);
            this.Shown += new System.EventHandler(this.FormLoadForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormLoadForm_Paint);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FormLoadForm_Layout);
            this.ResumeLayout(false);

        }

        #endregion
    }
}