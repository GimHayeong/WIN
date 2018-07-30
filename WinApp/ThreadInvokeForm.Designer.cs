namespace WinApp
{
    partial class ThreadInvokeForm
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
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.tbxBalance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnsafe = new System.Windows.Forms.Button();
            this.btnSafe = new System.Windows.Forms.Button();
            this.btnSafeParam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxInfo
            // 
            this.tbxInfo.Location = new System.Drawing.Point(36, 65);
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.Size = new System.Drawing.Size(136, 25);
            this.tbxInfo.TabIndex = 0;
            // 
            // tbxBalance
            // 
            this.tbxBalance.Location = new System.Drawing.Point(36, 120);
            this.tbxBalance.Name = "tbxBalance";
            this.tbxBalance.Size = new System.Drawing.Size(136, 25);
            this.tbxBalance.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "메시지:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "잔액:";
            // 
            // btnUnsafe
            // 
            this.btnUnsafe.Location = new System.Drawing.Point(178, 64);
            this.btnUnsafe.Name = "btnUnsafe";
            this.btnUnsafe.Size = new System.Drawing.Size(92, 23);
            this.btnUnsafe.TabIndex = 2;
            this.btnUnsafe.Text = "Unsafe";
            this.btnUnsafe.UseVisualStyleBackColor = true;
            this.btnUnsafe.Click += new System.EventHandler(this.btnUnsafe_Click);
            // 
            // btnSafe
            // 
            this.btnSafe.Location = new System.Drawing.Point(178, 107);
            this.btnSafe.Name = "btnSafe";
            this.btnSafe.Size = new System.Drawing.Size(92, 23);
            this.btnSafe.TabIndex = 2;
            this.btnSafe.Text = "Safe";
            this.btnSafe.UseVisualStyleBackColor = true;
            this.btnSafe.Click += new System.EventHandler(this.btnSafe_Click);
            // 
            // btnSafeParam
            // 
            this.btnSafeParam.Location = new System.Drawing.Point(178, 136);
            this.btnSafeParam.Name = "btnSafeParam";
            this.btnSafeParam.Size = new System.Drawing.Size(92, 23);
            this.btnSafeParam.TabIndex = 2;
            this.btnSafeParam.Text = "Safe";
            this.btnSafeParam.UseVisualStyleBackColor = true;
            this.btnSafeParam.Click += new System.EventHandler(this.btnSafeParam_Click);
            // 
            // ThreadInvokeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 203);
            this.Controls.Add(this.btnSafeParam);
            this.Controls.Add(this.btnSafe);
            this.Controls.Add(this.btnUnsafe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxBalance);
            this.Controls.Add(this.tbxInfo);
            this.Name = "ThreadInvokeForm";
            this.Text = "ThreadInvokeForm";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.TextBox tbxBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnsafe;
        private System.Windows.Forms.Button btnSafe;
        private System.Windows.Forms.Button btnSafeParam;
    }
}