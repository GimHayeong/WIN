namespace WinApp
{
    partial class ThreadBgWorkerForm
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
            this.btnSafeThread = new System.Windows.Forms.Button();
            this.tbxBgDoWorker = new System.Windows.Forms.TextBox();
            this.btnUnsafeThread = new System.Windows.Forms.Button();
            this.btnRunBgWorkerAsync = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnSafeThread
            // 
            this.btnSafeThread.Location = new System.Drawing.Point(12, 241);
            this.btnSafeThread.Name = "btnSafeThread";
            this.btnSafeThread.Size = new System.Drawing.Size(393, 49);
            this.btnSafeThread.TabIndex = 0;
            this.btnSafeThread.Text = "안전한 스레드 시작";
            this.btnSafeThread.UseVisualStyleBackColor = true;
            this.btnSafeThread.Click += new System.EventHandler(this.btnSafeThread_Click);
            // 
            // tbxBgDoWorker
            // 
            this.tbxBgDoWorker.Location = new System.Drawing.Point(35, 88);
            this.tbxBgDoWorker.Name = "tbxBgDoWorker";
            this.tbxBgDoWorker.Size = new System.Drawing.Size(370, 25);
            this.tbxBgDoWorker.TabIndex = 1;
            // 
            // btnUnsafeThread
            // 
            this.btnUnsafeThread.Location = new System.Drawing.Point(12, 186);
            this.btnUnsafeThread.Name = "btnUnsafeThread";
            this.btnUnsafeThread.Size = new System.Drawing.Size(393, 49);
            this.btnUnsafeThread.TabIndex = 0;
            this.btnUnsafeThread.Text = "안전하지 않은 스레드 시작";
            this.btnUnsafeThread.UseVisualStyleBackColor = true;
            this.btnUnsafeThread.Click += new System.EventHandler(this.btnUnsafe_Click);
            // 
            // btnRunBgWorkerAsync
            // 
            this.btnRunBgWorkerAsync.Location = new System.Drawing.Point(12, 296);
            this.btnRunBgWorkerAsync.Name = "btnRunBgWorkerAsync";
            this.btnRunBgWorkerAsync.Size = new System.Drawing.Size(393, 49);
            this.btnRunBgWorkerAsync.TabIndex = 0;
            this.btnRunBgWorkerAsync.Text = "안전한 백그라운드 스레드 시작";
            this.btnRunBgWorkerAsync.UseVisualStyleBackColor = true;
            this.btnRunBgWorkerAsync.Click += new System.EventHandler(this.btnRunBgWorkerAsync_Click);
            // 
            // ThreadBgWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 403);
            this.Controls.Add(this.tbxBgDoWorker);
            this.Controls.Add(this.btnUnsafeThread);
            this.Controls.Add(this.btnRunBgWorkerAsync);
            this.Controls.Add(this.btnSafeThread);
            this.Name = "ThreadBgWorkerForm";
            this.Text = "스레드로부터 안전한 호출(BgWorker)";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSafeThread;
        private System.Windows.Forms.TextBox tbxBgDoWorker;
        private System.Windows.Forms.Button btnUnsafeThread;
        private System.Windows.Forms.Button btnRunBgWorkerAsync;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}