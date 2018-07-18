namespace WinApp
{
    partial class RegistryForm
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
            this.txtRegText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRegValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "문자열";
            // 
            // txtRegText
            // 
            this.txtRegText.Location = new System.Drawing.Point(119, 49);
            this.txtRegText.Name = "txtRegText";
            this.txtRegText.Size = new System.Drawing.Size(170, 25);
            this.txtRegText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "정  수";
            // 
            // nudRegValue
            // 
            this.nudRegValue.Location = new System.Drawing.Point(119, 94);
            this.nudRegValue.Name = "nudRegValue";
            this.nudRegValue.Size = new System.Drawing.Size(170, 25);
            this.nudRegValue.TabIndex = 4;
            this.nudRegValue.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // RegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 169);
            this.Controls.Add(this.nudRegValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegText);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WinApp.Properties.Settings.Default, "FormText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "RegistryForm";
            this.Text = global::WinApp.Properties.Settings.Default.FormText;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistryForm_FormClosed);
            this.Load += new System.EventHandler(this.RegistryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRegValue;
    }
}