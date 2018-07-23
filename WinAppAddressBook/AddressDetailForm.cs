using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Net.Http;
using System.Net;
using System.Xml;
using BLL;

namespace WinAppAddressBook
{
    public partial class AddressDetailForm : Form
    {
        public Address AddressDetail = new Address();

        public AddressDetailForm()
        {
            InitializeComponent();
        }

        private void AddressDetailForm_Load(object sender, EventArgs e)
        {
            this.tblJusoTableAdapter.Connection.ConnectionString = SampleData.GetConnectionString();

            // TODO: 이 코드는 데이터를 'jusoDataSet.tblJuso' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tblJusoTableAdapter.Fill(this.jusoDataSet.tblJuso);
#if TEST
            tbxName.Text = "홍길동";
            cbxMale.Checked = true;
            mskCellPhone.Text = "01012345678";
            tbxEmail.Text = "gildong";
#endif
            if(AddressDetail != null)
            {
                SetMapping();
            }
            
            tip.SetToolTip(tbxName, "이름을 입력하세요.");
            tip.SetToolTip(dtpBirthday, "생년월일을 선택하세요.");
            tip.SetToolTip(mskZipcode, "우편번호를 검색 및 입력하세요.");
            tip.SetToolTip(tbxAddr, "주소를 검색 및 입력하세요.");
            tip.SetToolTip(tbxAddrDetail, "상세주소를 입력하세요.");
            tip.SetToolTip(mskCellPhone, "핸드폰번호를 입력하세요.");
            tip.SetToolTip(tbxEmail, "이메일주소를 입력하세요.");
        }

        private void SetMapping()
        {
            tbxName.DataBindings.Add("Text", AddressDetail, "Name");
            cbxMale.DataBindings.Add("Checked", AddressDetail, "Male");
            dtpBirthday.DataBindings.Add("Value", AddressDetail, "Birthday");
            mskZipcode.DataBindings.Add("Text", AddressDetail, "Zipcode");
            tbxAddr.DataBindings.Add("Text", AddressDetail, "Addr");
            tbxAddrDetail.DataBindings.Add("Text", AddressDetail, "AddrDetail");
            mskCellPhone.DataBindings.Add("Text", AddressDetail, "Cellphone");
            tbxEmail.DataBindings.Add("Text", AddressDetail, "EmailID");
            cbxEmailHost.DataBindings.Add("SelectedItem", AddressDetail, "EmailHost");
        }

        private void btnSearchAddr_Click(object sender, EventArgs e)
        {
            ZipcodeForm dlg = new ZipcodeForm();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                tbxAddr.Text = AddressDetail.Addr = dlg.AddrPart1;
                tbxAddrDetail.Text = AddressDetail.AddrDetail = dlg.AddrPart2;
                mskZipcode.Text = AddressDetail.ZipCode = dlg.Zipcode;

                tbxAddrDetail.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Control ctrlError = null;
            if (IsValidData(ref ctrlError))
            {
#if TEST
                AddressDetail.Name = tbxName.Text.Trim();
                AddressDetail.Male = cbxMale.Checked;
                AddressDetail.Birthday = dtpBirthday.Value;
                AddressDetail.ZipCode = mskZipcode.Text;
                AddressDetail.Addr = tbxAddr.Text.Trim();
                AddressDetail.AddrDetail = tbxAddrDetail.Text.Trim();
                AddressDetail.CellPhone = mskCellPhone.Text;
#endif
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if(ctrlError != null && !String.IsNullOrWhiteSpace(tip.GetToolTip(ctrlError)))
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

            string email = $"{tbxEmail.Text.Trim()}{GetEmailHost(cbxEmailHost.SelectedIndex)}";
            Util util = new Util();
            ctrlError = tbxEmail;
            if (!util.IsValidEmail(email)) return false;

            AddressDetail.Email = email;
            return true;
        }

        private bool IsValidData(Control ctr, string str, ref Control ctrlError)
        {
            if(String.IsNullOrWhiteSpace(str)){
                ctrlError = ctr;             
                return false;
            }

            return true;
        }

        private string GetEmailHost(int idx)
        {
            return $"@{cbxEmailHost.SelectedItem}";
#if TEST
            if(idx >  0)
            {
                return $"@{cbxEmailHost.SelectedItem}";
            }

            return String.Empty;
#endif
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxBase tbx = sender as TextBoxBase;
            if(tbx != null && e.KeyCode == Keys.Enter)
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
                        tbxEmail.Focus();
                        break;

                    case "tbxEmail":
                        cbxEmailHost.Focus();
                        break;

                }
            }
        }

        private void tbxEmail_Leave(object sender, EventArgs e)
        {
#if TEST
            if (cbxEmailHost.SelectedIndex == 0 && !String.IsNullOrWhiteSpace(tbxEmail.Text))
            {
                int mailSplitIndex = tbxEmail.Text.IndexOf('@');
                if (mailSplitIndex > 0)
                {
                    cbxEmailHost.Items[0] = tbxEmail.Text.Substring(mailSplitIndex + 1);
                }
            }
#endif
        }
    }
}
