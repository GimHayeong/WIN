namespace WinApp
{
    partial class ValidationForm
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
            this.tbxAlphaOrDigit = new System.Windows.Forms.TextBox();
            this.btnAlphaOrDigit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPhone = new System.Windows.Forms.TextBox();
            this.btnPhone = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSSN = new System.Windows.Forms.TextBox();
            this.btnSSN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "영숫자:";
            // 
            // tbxAlphaOrDigit
            // 
            this.tbxAlphaOrDigit.Location = new System.Drawing.Point(103, 26);
            this.tbxAlphaOrDigit.Name = "tbxAlphaOrDigit";
            this.tbxAlphaOrDigit.Size = new System.Drawing.Size(214, 25);
            this.tbxAlphaOrDigit.TabIndex = 1;
            this.tbxAlphaOrDigit.Text = "6pa3";
            // 
            // btnAlphaOrDigit
            // 
            this.btnAlphaOrDigit.Location = new System.Drawing.Point(334, 16);
            this.btnAlphaOrDigit.Name = "btnAlphaOrDigit";
            this.btnAlphaOrDigit.Size = new System.Drawing.Size(75, 40);
            this.btnAlphaOrDigit.TabIndex = 2;
            this.btnAlphaOrDigit.Text = "체크";
            this.btnAlphaOrDigit.UseVisualStyleBackColor = true;
            this.btnAlphaOrDigit.Click += new System.EventHandler(this.btnAlphaOrDigit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "전화번호:";
            // 
            // tbxPhone
            // 
            this.tbxPhone.Location = new System.Drawing.Point(103, 84);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.Size = new System.Drawing.Size(214, 25);
            this.tbxPhone.TabIndex = 1;
            this.tbxPhone.Text = "02-1234-5678";
            // 
            // btnPhone
            // 
            this.btnPhone.Location = new System.Drawing.Point(334, 74);
            this.btnPhone.Name = "btnPhone";
            this.btnPhone.Size = new System.Drawing.Size(75, 40);
            this.btnPhone.TabIndex = 2;
            this.btnPhone.Text = "체크";
            this.btnPhone.UseVisualStyleBackColor = true;
            this.btnPhone.Click += new System.EventHandler(this.btnPhone_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "전자우편:";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(103, 143);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(214, 25);
            this.tbxEmail.TabIndex = 1;
            this.tbxEmail.Text = "abc@abc.com";
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(334, 133);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 40);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.Text = "체크";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "주민번호:";
            // 
            // tbxSSN
            // 
            this.tbxSSN.Location = new System.Drawing.Point(103, 203);
            this.tbxSSN.Name = "tbxSSN";
            this.tbxSSN.Size = new System.Drawing.Size(214, 25);
            this.tbxSSN.TabIndex = 1;
            this.tbxSSN.Text = "6785215863216";
            // 
            // btnSSN
            // 
            this.btnSSN.Location = new System.Drawing.Point(334, 193);
            this.btnSSN.Name = "btnSSN";
            this.btnSSN.Size = new System.Drawing.Size(75, 40);
            this.btnSSN.TabIndex = 2;
            this.btnSSN.Text = "체크";
            this.btnSSN.UseVisualStyleBackColor = true;
            this.btnSSN.Click += new System.EventHandler(this.btnSSN_Click);
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 403);
            this.Controls.Add(this.btnSSN);
            this.Controls.Add(this.tbxSSN);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.btnPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAlphaOrDigit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxAlphaOrDigit);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "ValidationForm";
            this.Text = "문자열 유효성검사 프로그램";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAlphaOrDigit;
        private System.Windows.Forms.Button btnAlphaOrDigit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.Button btnPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxSSN;
        private System.Windows.Forms.Button btnSSN;
    }
}