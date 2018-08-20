using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class ThreadBgWorkerFibonacciForm : Form
    {
        public int NumberToCompute { get; private set; }
        public int HeighestPercentageReached { get; private set; }

        public ThreadBgWorkerFibonacciForm()
        {
            InitializeComponent();

            InitControl();
        }

        private void InitControl()
        {
            NumberToCompute = 0;
            HeighestPercentageReached = 0;
        }

        private void btnStartAsync_Click(object sender, EventArgs e)
        {
            lblResult.Text = String.Empty;

            numericUpDn.Enabled = false;
            btnStartAsync.Enabled = false;
            btnCancelAsync.Enabled = true;

            NumberToCompute = (int)numericUpDn.Value;
            HeighestPercentageReached = 0;

            bgWorker.RunWorkerAsync(NumberToCompute);
        }

        private void btnCancelAsync_Click(object sender, EventArgs e)
        {
            bgWorker.CancelAsync();
            btnCancelAsync.Enabled = false;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = ComputeFibonacci((int)e.Argument, worker, e);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbarPercentage.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if(e.Cancelled)
            {
                lblResult.Text = "Canceled";
                lblResultLabel.Text = "(n + 1) 번째항의 피보나치수:";
            }
            else
            {
                lblResult.Text = e.Result.ToString();
                lblResultLabel.Text = $"{NumberToCompute + 1} 번째항의 피보나치수:";
            }

            numericUpDn.Enabled = true;
            btnStartAsync.Enabled = true;
            btnCancelAsync.Enabled = false;
        }

        /// <summary>
        /// 피보나치 재귀함수
        /// </summary>
        /// <param name="num">피보나치 수열의 (num + 1) 번째 위치의 피보나치수
        ///  0번째 ~ 16번째항까지 피보나치 수열예 :
        ///  (0), 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987  ...
        ///         ↑ ↑ ↑ ↑ ↑ ↑  ↑  ↑  ↑  ↑   ↑   ↑   ↑   ↑   ↑
        ///    num : 1, 2, 3, 4, 5,  6,  7,  8,  9, 10,  11,  12,  13,  14,  15  ...
        /// </param>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private long ComputeFibonacci(int num, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if(num < 0 || num > 91)
            {
                throw new ArgumentException("value must be >=0 and <=91", $"{num}");
            }

            long result = 0;

            if (bgWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if(num < 2)
                {
                    result = 1;
                }
                else
                {
                    result = ComputeFibonacci(num - 1, worker, e) + ComputeFibonacci(num - 2, worker, e);
                }
            }

            int percentage = (int)((float)num / (float)NumberToCompute * 100);
            if(percentage > HeighestPercentageReached)
            {
                HeighestPercentageReached = percentage;
                bgWorker.ReportProgress(percentage);
            }

            return result;
        }
    }
}
