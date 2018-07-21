using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinAppAddressBook
{
    public partial class ZipcodeForm : Form
    {
        public string AddrPart1 { get; private set; }
        public string AddrPart2 { get; private set; }
        public string Zipcode { get; private set; }
        private int m_SelectedIndex = -1;

        public ZipcodeForm()
        {
            InitializeComponent();

            InitControl();
        }

        private void InitControl()
        {
            tbxAddr.KeyDown += SearchTextBox_KeyDown;
            tbxAddr.Enter += SearchTextBox_Enter;
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbxAddr.Text))
            {
                tbxAddr.SelectAll();
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearchAddr.PerformClick();
            }
        }



        private void btnSearchAddr_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxAddr.Text))
            {
                MessageBox.Show("검색할 주소의 읍/면/동을 입력하세요.", "주소검색안내");
                tbxAddr.Focus();
                return;
            }

            m_SelectedIndex = -1;
            ApiData api = new ApiData();
            string apiurlNcnt;
            dgvResult.DataSource = api.OpenApiSampleForJusoGoKr(tbxAddr.Text, out apiurlNcnt);

            if(dgvResult.DataSource == null)
            {
                MessageBox.Show("검색결과가 없습니다.", "주소검색결과안내");
                tbxAddr.Focus();
            }
            else
            {
                dgvResult.Focus();
            }
        }

        private void dgvResult_SelectionChanged(object sender, EventArgs e)
        {
            SelectedAddress();
        }

        private void SelectedAddress()
        {
            if(dgvResult.SelectedRows != null && dgvResult.SelectedRows.Count > 0)
            {
                SelectedAddress(dgvResult.SelectedRows[0].Index);
            }
        }

        private void SelectedAddress(int selectedIndex)
        {
            if (m_SelectedIndex == selectedIndex) return;
            m_SelectedIndex = selectedIndex;

            AddrPart1 = dgvResult.Rows[selectedIndex].Cells["roadAddrPart1"].Value.ToString();
            AddrPart2 = dgvResult.Rows[selectedIndex].Cells["roadAddrPart2"].Value.ToString();
            Zipcode = dgvResult.Rows[selectedIndex].Cells["ZipNo"].Value.ToString();

            lblResult.Text = $"({Zipcode}) {AddrPart1} {AddrPart2}";
        }

        private void dgvResult_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectedAddress(e.RowIndex);
        }

        private void SetHeaderText()
        {
            dgvResult.Columns[0].HeaderText = "주소";
            dgvResult.Columns[0].Width = 200;
            dgvResult.Columns[1].HeaderText = "주소상세";
            dgvResult.Columns[1].Width = 150;
            dgvResult.Columns[2].HeaderText = "우편번호";
        }

        private void dgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetHeaderText();
            if(dgvResult.Rows != null && dgvResult.Rows.Count > 0 && m_SelectedIndex == -1)
            {
                dgvResult.Rows[0].Selected = true;
            }
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            btnConfirm.PerformClick();
        }

        private void dgvResult_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            string str = e.Row.Cells[0].ToolTipText;
        }

        private void dgvResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedAddress(e.RowIndex);
        }
    }
}
