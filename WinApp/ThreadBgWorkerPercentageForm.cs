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
    public partial class ThreadBgWorkerPercentageForm : Form
    {
        public ThreadBgWorkerPercentageForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(bgWorker.IsBusy != true)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(bgWorker.WorkerSupportsCancellation == true)
            {
                bgWorker.CancelAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for(int i=1; i<=10; i++)
            {
                if(bgWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    bgWorker.ReportProgress(i * 10);
                }
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblResult.Text = $"{e.ProgressPercentage}%";
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled == true)
            {
                lblResult.Text = "Canceled!";
            }
            else if(e.Error != null)
            {
                lblResult.Text = $"Error: {e.Error.Message}";
            }
            else
            {
                lblResult.Text = "Done!";
            }
        }
    }
}
