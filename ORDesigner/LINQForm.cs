﻿using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORDesigner
{
    public partial class LINQForm : Form
    {
        public LINQForm()
        {
            InitializeComponent();
        }

        private void LINQForm_Load(object sender, EventArgs e)
        {
            //GetPeopleListAll();


            this.tblPeopleTableAdapter.Connection.ConnectionString = SampleData.GetConnectionString();
            this.tblSaleTableAdapter.Connection.ConnectionString = SampleData.GetConnectionString();


            // TODO: 이 코드는 데이터를 'aDOPeopleDataSet.tblPeople' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tblPeopleTableAdapter.Fill(this.adoPeopleDataSet.tblPeople);

            // TODO: 이 코드는 데이터를 'adoPeopleDataSet.tblSale' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            //this.tblSaleTableAdapter.Fill(this.adoPeopleDataSet.tblSale);
        }

        private void GetPeopleListAll()
        {
            DataPeopleDataContext dcxt = new DataPeopleDataContext();
            dcxt.Connection.ConnectionString = SampleData.GetConnectionString();
            Table<tblPeople> people = dcxt.GetTable<tblPeople>();

            var query = from p in people
                        select p;
            foreach (tblPeople q in query)
            {
                lbxResult.Items.Add(String.Format("이름: {0}, 나이: {1}, 성별: {2}", q.Name, q.Age, q.Male ? "남자" : "여자"));
            }

            int? age = 0;
            dcxt.IncSomeAge("최강우", ref age);
            query = from p in people
                    where p.Name == "최강우"
                    select p;

            foreach (tblPeople q in query)
            {
                lbxResult.Items.Add(String.Format("[변경] 이름: {0}, 나이: {1}, 성별: {2}", q.Name, age, q.Male ? "남자" : "여자"));
            }
        }

        private void tsbTblPeopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        private void TblPeopleBindingNavigatorButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "tsbTblPeopleBindingNavigatorSaveItem":
                        this.Validate();
                        this.tblPeopleBindingSource.EndEdit();
                        this.tblPeopleTableAdapter.Update(this.adoPeopleDataSet.tblPeople);
                        break;

                    case "tsBtnSearchByName":
                        if (!String.IsNullOrWhiteSpace(tsTbxName.Text))
                        {
                            this.tblPeopleTableAdapter.FillByName(this.adoPeopleDataSet.tblPeople, tsTbxName.Text);
                        }
                        else
                        {
                            this.tblPeopleTableAdapter.Fill(this.adoPeopleDataSet.tblPeople);
                        }
                        break;
                }
            }
        }



        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnFillBy35":
                        this.tblPeopleTableAdapter.FillBy35(this.adoPeopleDataSet.tblPeople);
                        break;

                    case "btnGetCount":
                        int cnt = this.tblPeopleTableAdapter.GetPeopleCount().Value;
                        MessageBox.Show(String.Format("총 인원은 {0} 명 입니다.", cnt));
                        break;

                    case "brnUpdateByName":
                        if (!String.IsNullOrWhiteSpace(nameTextBox.Text))
                        {
                            this.tblPeopleTableAdapter.UpdateByName(60, true, nameTextBox.Text);
                            this.tblPeopleTableAdapter.Fill(this.adoPeopleDataSet.tblPeople);
                        }
                        break;

                    case "btnGetToday":
                        MessageBox.Show(String.Format("오늘날짜: {0}", this.tblPeopleTableAdapter.GetToday()));
                        break;
                }
            }
        }

        private void dgvPeople_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.Name == "dgvPeople" && dgv.SelectedRows != null && dgv.SelectedRows.Count > 0)
            {
                this.tblSaleTableAdapter.FillByName(this.adoPeopleDataSet.tblSale, dgv.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int k = this.adoPeopleDataSet.Add(5, 3);
            MessageBox.Show(String.Format("5 + 3 = {0}", k));
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            tblPeopleTableAdapter.UserMessage();
        }

        private void dgvPeople_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "에러발생");
        }
    }
}
