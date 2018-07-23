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
    public partial class VRSVideoForm : Form
    {
        public VRSVideoForm()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxBase tbx = sender as TextBoxBase;
            if (tbx != null && e.KeyCode == Keys.Enter)
            {
                switch (tbx.Name)
                {
                    case "tbxTitle":
                        mskStock.Focus();
                        break;

                    case "mskStock":
                        tbxProducer.Focus();
                        break;

                    case "tbxProducer":
                        tbxDirector.Focus();
                        break;

                    case "tbxDirector":
                        tbxStarring.Focus();
                        break;

                    case "tbxStarring":
                        mskProductionYear.Focus();
                        break;

                    case "mskProductionYear":
                        rdoAction.Focus();
                        break;

                }
            }
        }

        private bool IsValidData(ref Control ctrlError)
        {
            if (!IsValidData(tbxTitle, tbxTitle.Text, ref ctrlError)) return false;
            if (!IsValidData(mskStock, mskStock.Text.Replace('-', ' '), ref ctrlError)) return false;
            if (!IsValidData(tbxProducer, tbxProducer.Text, ref ctrlError)) return false;
            if (!IsValidData(tbxDirector, tbxDirector.Text, ref ctrlError)) return false;
            if (!IsValidData(tbxStarring, tbxStarring.Text, ref ctrlError)) return false;
            if (!IsValidData(mskProductionYear, mskProductionYear.Text.Replace('-', ' '), ref ctrlError)) return false;

            return true;
        }

        private bool IsValidData(Control ctr, string str, ref Control ctrlError)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                ctrlError = ctr;
                return false;
            }

            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Control ctrlError = null;
            if (IsValidData(ref ctrlError))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (ctrlError != null && !String.IsNullOrWhiteSpace(tip.GetToolTip(ctrlError)))
                {
                    MessageBox.Show(tip.GetToolTip(ctrlError));
                    ctrlError.Focus();
                }
                else
                {
                    tbxTitle.Focus();
                }
                return;
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("KK");
        }

        private void RadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                rtbDescription.Focus();
            }
        }

        private void VRSVideoForm_Load(object sender, EventArgs e)
        {
            tip.SetToolTip(tbxTitle, "비디오 제목을 입력하세요.");
            tip.SetToolTip(mskStock, "재고수량을 입력하세요.");
            tip.SetToolTip(tbxProducer, "제작사를 입력하세요.");
            tip.SetToolTip(tbxDirector, "감독을 입력하세요.");
            tip.SetToolTip(tbxStarring, "주연을 입력하세요.");
            tip.SetToolTip(mskProductionYear, "제작연도를 입력하세요.");
        }

        private void SetMapping()
        {
            //tbxTitle.DataBindings.Add("Text", m_Video, "Title");
            //mskStock.DataBindings.Add("Text", m_Video, "Stock");
            //tbxProducer.DataBindings.Add("Text", m_Video, "Producer");
            //tbxDirector.DataBindings.Add("Text", m_Video, "Director");
            //tbxStarring.DataBindings.Add("Text", m_Video, "Starring");
            //mskProductionYear.DataBindings.Add("Text", m_Video, "ProductionYear");
            //rtbDescription.DataBindings.Add("Text", m_Video, "ProductionYear");
        }
    }
}
