//#define TEST
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
    public partial class VRSMemberForm : Form
    {

        public Membership m_Member = new Membership();

        public VRSMemberForm()
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
                        where c.CodeGroupCode == "0001" && c.IsUse
                        select c;
            foreach(var q in query)
            {
                RadioButton rdo = grpbxGrade.Controls.Find($"rdo{q.CodeValue}", true)[0] as RadioButton;
                if(rdo != null)
                {
                    rdo.Text = q.CodeText;
                    rdo.Tag = q.Code;
                }
            }
            rdoAssociate.Checked = true;
#if TEST
            MembershipBLL biz = new MembershipBLL();
            foreach(var c in biz.GetGradeList())
            {
                RadioButton rdo = grpbxGrade.Controls.Find($"rdo{c.CodeValue}", true)[0] as RadioButton;
                if(rdo != null)
                {
                    rdo.Text = c.CodeText;
                    rdo.Tag = c;
                }
            }
#endif

        }

        private void VRSMemberForm_Load(object sender, EventArgs e)
        {
            if(m_Member != null)
            {
                SetMapping();
            }

#if TEST
            if (m_Member != null)
            {
                SetMapping();
                tbxName.Text = "강감찬";
                cbxMale.Checked = true;
                mskCellPhone.Text = "00112345678";
            }
#endif


            tip.SetToolTip(tbxName, "이름을 입력하세요.");
            tip.SetToolTip(dtpBirthday, "생년월일을 선택하세요.");
            tip.SetToolTip(mskZipcode, "우편번호를 검색 및 입력하세요.");
            tip.SetToolTip(tbxAddr, "주소를 검색 및 입력하세요.");
            tip.SetToolTip(tbxAddrDetail, "상세주소를 입력하세요.");
            tip.SetToolTip(mskCellPhone, "핸드폰번호를 입력하세요.");
            tip.SetToolTip(tbxDeposit, "예치금을 입력하세요.");
        }

        

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnSearchAddr":
                        SearchAddress();
                        break;

                    case "btnOK":
                        CreateMember();
                        break;
                }
            }
        }

        

        private void GradeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if(rdo != null && rdo.Checked)
            {
                m_Member.MGradeCode = Convert.ToInt32(rdo.Tag);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxBase tbx = sender as TextBoxBase;
            if (tbx != null && e.KeyCode == Keys.Enter)
            {
                switch (tbx.Name)
                {
                    case "tbxName":
                        cbxMale.Focus();
                        break;

                    case "mskZipcode":
                        btnSearchAddr.PerformClick();
                        break;

                    case "tbxAddr":
                        tbxAddrDetail.Focus();
                        break;

                    case "tbxAddrDetail":
                        mskCellPhone.Focus();
                        break;

                    case "mskCellPhone":
                        tbxDeposit.Focus();
                        break;

                    case "tbxDeposit":
                        btnOK.PerformClick();
                        break;

                }
            }
        }

        private void CreateMember()
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
                    tbxName.Focus();
                }
                return;
            }
        }


        private bool IsValidData(ref Control ctrlError)
        {
            if (!IsValidData(tbxName, tbxName.Text, ref ctrlError)) return false;
            if (!IsValidData(mskZipcode, mskZipcode.Text.Replace('-', ' '), ref ctrlError)) return false;
            if (!IsValidData(tbxAddr, tbxAddr.Text, ref ctrlError)) return false;
            if (!IsValidData(tbxAddrDetail, tbxAddrDetail.Text, ref ctrlError)) return false;
            if (!IsValidData(mskCellPhone, mskCellPhone.Text.Replace('-', ' '), ref ctrlError)) return false;
            if (!IsValidData(tbxDeposit, tbxDeposit.Text, ref ctrlError)) return false;

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

        private void SearchAddress()
        {
            ZipcodeForm dlg = new ZipcodeForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbxAddr.Text = m_Member.Addr = dlg.AddrPart1;
                tbxAddrDetail.Text = m_Member.AddrDetail = dlg.AddrPart2;
                mskZipcode.Text = m_Member.ZipCode = dlg.Zipcode;

                tbxAddrDetail.Focus();
            }
        }


        private void SetMapping()
        {
            tbxName.DataBindings.Add("Text", m_Member, "Name");
            cbxMale.DataBindings.Add("Checked", m_Member, "Male");
            dtpBirthday.DataBindings.Add("Value", m_Member, "Birthday");
            mskZipcode.DataBindings.Add("Text", m_Member, "Zipcode");
            tbxAddr.DataBindings.Add("Text", m_Member, "Addr");
            tbxAddrDetail.DataBindings.Add("Text", m_Member, "AddrDetail");
            mskCellPhone.DataBindings.Add("Text", m_Member, "Cellphone");
            tbxDeposit.DataBindings.Add("Text", m_Member, "MDeposit");
        }

        
    }
}
