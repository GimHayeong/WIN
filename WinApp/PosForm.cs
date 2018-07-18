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
    public partial class PosForm : Form
    {
        public event EventHandler Apply;
        public int PosLeft
        {
            get { return Convert.ToInt32(txtX.Text); }
            set { txtX.Text = value.ToString();  }
        }

        public int PosTop
        {
            get { return Convert.ToInt32(txtY.Text); }
            set { txtY.Text = value.ToString(); }
        }
        public string PosText
        {
            get { return txtString.Text; }
            set { txtString.Text = value; }
        }

        public PosForm()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(Apply != null)
            {
                Apply(this, new EventArgs());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
