namespace WinApp
{
    partial class KeyDownForm
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
            // KeyDownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 391);
            this.Name = "KeyDownForm";
            this.Text = "KeyDownForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.KeyDownForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}