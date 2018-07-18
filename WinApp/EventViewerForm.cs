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
    public partial class EventViewerForm : Form
    {
        public int Cnt { get; private set; }
        public EventViewerForm()
        {
            InitializeComponent();
        }

        private void AddEvent(string name)
        {
            if(chkIsWatch.Checked == false)
            {
                txtEventViewer.Text += String.Format("({0} : {1})\r\n", Cnt, name);
                txtEventViewer.SelectionStart = txtEventViewer.TextLength;
                txtEventViewer.ScrollToCaret();
                Cnt++;
            }
        }


        private void EventViewerForm_Load(object sender, EventArgs e)
        {
            AddEvent("Load");
        }

        private void EventViewerForm_Layout(object sender, LayoutEventArgs e)
        {
            AddEvent("Layout");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEventViewer.Text = "";
            Cnt = 1;
        }

        private void EventViewerForm_Shown(object sender, EventArgs e)
        {
            AddEvent("Shown");
        }

        private void EventViewerForm_Enter(object sender, EventArgs e)
        {
            AddEvent("Enter");
        }

        private void EventViewerForm_Leave(object sender, EventArgs e)
        {
            AddEvent("Leave");
        }

        private void EventViewerForm_Resize(object sender, EventArgs e)
        {
            AddEvent("Resize");
        }
    }
}
