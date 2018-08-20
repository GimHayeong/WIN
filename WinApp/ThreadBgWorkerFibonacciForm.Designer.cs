namespace WinApp
{
    partial class ThreadBgWorkerFibonacciForm
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
            this.numericUpDn = new System.Windows.Forms.NumericUpDown();
            this.pbarPercentage = new System.Windows.Forms.ProgressBar();
            this.btnStartAsync = new System.Windows.Forms.Button();
            this.btnCancelAsync = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblResultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDn)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDn
            // 
            this.numericUpDn.Location = new System.Drawing.Point(31, 38);
            this.numericUpDn.Maximum = new decimal(new int[] {
            91,
            0,
            0,
            0});
            this.numericUpDn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDn.Name = "numericUpDn";
            this.numericUpDn.Size = new System.Drawing.Size(79, 25);
            this.numericUpDn.TabIndex = 0;
            this.numericUpDn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pbarPercentage
            // 
            this.pbarPercentage.Location = new System.Drawing.Point(31, 86);
            this.pbarPercentage.Name = "pbarPercentage";
            this.pbarPercentage.Size = new System.Drawing.Size(375, 8);
            this.pbarPercentage.Step = 2;
            this.pbarPercentage.TabIndex = 4;
            // 
            // btnStartAsync
            // 
            this.btnStartAsync.Location = new System.Drawing.Point(31, 132);
            this.btnStartAsync.Name = "btnStartAsync";
            this.btnStartAsync.Size = new System.Drawing.Size(181, 39);
            this.btnStartAsync.TabIndex = 1;
            this.btnStartAsync.Text = "Start Async";
            this.btnStartAsync.UseVisualStyleBackColor = true;
            this.btnStartAsync.Click += new System.EventHandler(this.btnStartAsync_Click);
            // 
            // btnCancelAsync
            // 
            this.btnCancelAsync.Enabled = false;
            this.btnCancelAsync.Location = new System.Drawing.Point(225, 132);
            this.btnCancelAsync.Name = "btnCancelAsync";
            this.btnCancelAsync.Size = new System.Drawing.Size(181, 39);
            this.btnCancelAsync.TabIndex = 2;
            this.btnCancelAsync.Text = "Cancel Async";
            this.btnCancelAsync.UseVisualStyleBackColor = true;
            this.btnCancelAsync.Click += new System.EventHandler(this.btnCancelAsync_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("맑은 고딕", 12.8F);
            this.lblResult.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblResult.Location = new System.Drawing.Point(172, 29);
            this.lblResult.MinimumSize = new System.Drawing.Size(230, 32);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(5);
            this.lblResult.Size = new System.Drawing.Size(230, 40);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "(no result)";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultLabel
            // 
            this.lblResultLabel.AutoSize = true;
            this.lblResultLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResultLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblResultLabel.Location = new System.Drawing.Point(173, 9);
            this.lblResultLabel.Name = "lblResultLabel";
            this.lblResultLabel.Size = new System.Drawing.Size(195, 20);
            this.lblResultLabel.TabIndex = 5;
            this.lblResultLabel.Text = "(n+1) 번째항의 피보나치값:";
            // 
            // ThreadBgWorkerFibonacciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 186);
            this.Controls.Add(this.lblResultLabel);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCancelAsync);
            this.Controls.Add(this.btnStartAsync);
            this.Controls.Add(this.pbarPercentage);
            this.Controls.Add(this.numericUpDn);
            this.Name = "ThreadBgWorkerFibonacciForm";
            this.Text = "Fibonacci Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDn;
        private System.Windows.Forms.ProgressBar pbarPercentage;
        private System.Windows.Forms.Button btnStartAsync;
        private System.Windows.Forms.Button btnCancelAsync;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblResultLabel;
    }
}