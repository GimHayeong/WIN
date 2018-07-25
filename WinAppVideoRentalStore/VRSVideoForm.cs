using BLL;
using DAL;
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
        public Video m_Video = new Video();

        public VRSVideoForm()
        {
            InitializeComponent();

            InitControl();
        }

        /// <summary>
        /// 컨트롤 사용자 초기화
        /// </summary>
        private void InitControl()
        {
            tblCodeTableAdt.Connection.ConnectionString = SampleData.GetConnectionString();
            tblCodeTableAdt.Fill(vrsDataSet.tblCode);

            var query = from c in vrsDataSet.tblCode
                        where c.CodeGroupCode == "0002" && c.IsUse
                        select c;
            foreach (var q in query)
            {
                RadioButton rdo = grpbxVideoType.Controls.Find($"rdo{q.CodeValue}", true)[0] as RadioButton;
                if (rdo != null)
                {
                    rdo.Text = q.CodeText;
                    rdo.Tag = q.Code;
                }
            }
            rdoAction.Checked = true;
#if TEST
            MembershipBLL biz = new MembershipBLL();
            foreach (var c in biz.GetVideoTypeList())
            {
                RadioButton rdo = grpbxVideoType.Controls.Find($"rdo{c.CodeValue}", true)[0] as RadioButton;
                if (rdo != null)
                {
                    rdo.Text = c.CodeText;
                    rdo.Tag = c;
                }
            }
#endif
        }

        private void VRSVideoForm_Load(object sender, EventArgs e)
        {
            if (m_Video != null)
            {
                SetMapping();
            }

            tip.SetToolTip(tbxTitle, "비디오 제목을 입력하세요.");
            tip.SetToolTip(mskStock, "재고수량을 입력하세요.");
            tip.SetToolTip(tbxProducer, "제작사를 입력하세요.");
            tip.SetToolTip(tbxDirector, "감독을 입력하세요.");
            tip.SetToolTip(tbxStarring, "주연을 입력하세요.");
            tip.SetToolTip(mskProductionYear, "제작연도를 입력하세요.");
        }



        private void Button_Click(object sender, EventArgs e)
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxBase tbx = sender as TextBoxBase;
            if (tbx != null && e.KeyCode == Keys.Enter)
            {
                tbx.SelectAll();
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

        private void VideoType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo != null && rdo.Checked)
            {
                m_Video.VideoType = Convert.ToInt32(rdo.Tag);
            }
        }

        private void RadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtbDescription.Focus();
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

        
        private void SetMapping()
        {
            tbxTitle.DataBindings.Add("Text", m_Video, "Title");
            mskStock.DataBindings.Add("Text", m_Video, "Stock");
            tbxProducer.DataBindings.Add("Text", m_Video, "Producer");
            tbxDirector.DataBindings.Add("Text", m_Video, "Director");
            tbxStarring.DataBindings.Add("Text", m_Video, "Starring");
            mskProductionYear.DataBindings.Add("Text", m_Video, "ProductionYear");
            rtbDescription.DataBindings.Add("Text", m_Video, "Description");
        }

        
    }
}
