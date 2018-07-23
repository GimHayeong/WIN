using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppVideoRentalStore
{
    public partial class VRSForm : Form
    {
        public VRSForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnNewMembership":
                        break;

                    case "btnEditMembership":
                        break;

                    case "btnWithdrawMembership":
                        break;

                    case "btnNewVideo":
                        break;

                    case "btnEditVideo":
                        break;

                    case "btnDeleteVideo":
                        break;

                    case "btnRend":
                        break;

                    case "btnReturn":
                        break;
                }
            }
        }
    }
}
