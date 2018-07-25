using BLL;
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

namespace WinAppAddressBook
{
    public partial class AddressBookForm : Form
    {
        public AddressBookForm()
        {
            InitializeComponent();
        }

        private void AddressBookForm_Load(object sender, EventArgs e)
        {
            this.tblJusoTableAdapter.Connection.ConnectionString = SampleData.GetConnectionString();
            // TODO: 이 코드는 데이터를 'jusoDataSet.tblJuso' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tblJusoTableAdapter.Fill(this.jusoDataSet.tblJuso);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnAdd":
                    AddNewAddress();
                    break;

                case "btnMod":
                    ModifyAddress();
                    break;

                case "btnDel":
                    DeleteAddress();
                    break;

                case "btnSearch":
                    SearchAddress();
                    break;
            }
        }

        private void AddNewAddress()
        {
            AddressDetailForm dlg = new AddressDetailForm();
            dlg.Text = "새 친구 추가";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                JusoDataSet.tblJusoRow row = jusoDataSet.tblJuso.NewtblJusoRow();

                SetRowData(dlg.AddressDetail, ref row);

                jusoDataSet.tblJuso.Rows.Add(row);

                //데이터소스에 반영
                this.Validate();
                this.jusoDataSetBindingSource.EndEdit();
                this.tblJusoTableAdapter.Update(this.jusoDataSet.tblJuso);
            }
        }

        private void SetRowData(Address addressDetail, ref JusoDataSet.tblJusoRow row)
        {
            row.Name = addressDetail.Name;
            row.Male = addressDetail.Male;
            row.Birthday = addressDetail.Birthday;
            row.Zipcode = addressDetail.ZipCode;
            row.Addr = addressDetail.Addr;
            row.Addr2 = addressDetail.AddrDetail;
            row.Cellphone = addressDetail.Cellphone;
            row.Email = addressDetail.Email;
        }

        private void ModifyAddress()
        {
            DataGridViewRow currentRow = dgvAddressList.CurrentRow;
            if(currentRow == null)
            {
                MessageBox.Show("편집할 행을 먼저 선택하십시오.");
                return;
            }

            int id = (int)currentRow.Cells[0].Value;

            AddressDetailForm dlg = new AddressDetailForm();
            dlg.Text = "친구 정보 수정";

            dlg.AddressDetail.Name = (string)currentRow.Cells[1].Value;
            dlg.AddressDetail.Male = (bool)currentRow.Cells[2].Value;
            dlg.AddressDetail.Birthday = (DateTime)currentRow.Cells[3].Value;
            dlg.AddressDetail.Addr = (string)currentRow.Cells[4].Value;
            dlg.AddressDetail.AddrDetail = (string)currentRow.Cells[5].Value;
            dlg.AddressDetail.ZipCode = (string)currentRow.Cells[6].Value;
            dlg.AddressDetail.Cellphone = (string)currentRow.Cells[7].Value;
            dlg.AddressDetail.Email = (string)currentRow.Cells[8].Value;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                JusoDataSet.tblJusoRow row = jusoDataSet.tblJuso.FindById(id);
                SetRowData(dlg.AddressDetail, ref row);

                //데이터소스에 반영
                this.Validate();
                this.jusoDataSetBindingSource.EndEdit();
                this.tblJusoTableAdapter.Update(this.jusoDataSet.tblJuso);
            }
        }

        private void DeleteAddress()
        {
            DataGridViewRow currentRow = dgvAddressList.CurrentRow;

            if (currentRow == null)
            {
                MessageBox.Show("삭제할 행을 먼저 선택하십시오.");
                return;
            }

            int id = (int)currentRow.Cells[0].Value;
            JusoDataSet.tblJusoRow row = jusoDataSet.tblJuso.FindById(id);

            row.Delete();
        }

        private void SearchAddress()
        {
            if (!String.IsNullOrWhiteSpace(tbxSearchWord.Text))
            {
                jusoDataSetBindingSource.Filter = $"Name LIKE '%{tbxSearchWord.Text}%'";
            }
            else
            {
                jusoDataSetBindingSource.Filter = String.Empty;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
