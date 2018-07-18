//#define 관계객체없이제약조건직접걸기
//#define VIEWMANAGER
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinApp
{
    public partial class DataSetForm : Form
    {
        private DataSet m_dsADO;
        private DataTable m_tblPeople, m_tblSale;
        
        private DataRelation m_relationBuy;
        private const string RELATION_BUY = "Buy";

        public DataSetForm()
        {
            InitializeComponent();
        }

        private void DataSetForm_Load(object sender, EventArgs e)
        {
            m_dsADO = new DataSet("ADONET");

            m_tblPeople = SampleData.GetPeople();
            m_tblSale = SampleData.GetSale();

            BindingDataSource(m_tblPeople, m_tblSale, "Name", "Customer");

        }

        private void BindingDataSource(DataTable tblParent, DataTable tblChild, string colParent, string colChild)
        {
            m_dsADO.Tables.Add(tblParent);
            m_dsADO.Tables.Add(tblChild);

#if 관계객체없이제약조건직접걸기

            ForeignKeyConstraint fk = new ForeignKeyConstraint(RELATION_BUY
                                                            , m_dsADO.Tables["tblPeople"].Columns["Name"]
                                                            , m_dsADO.Tables["tblSale"].Columns["Customer"]);

            //fk.DeleteRule = Rule.Cascade;
            //fk.UpdateRule = Rule.Cascade;
            //fk.AcceptRejectRule = AcceptRejectRule.None;

            m_dsADO.Tables["tblSale"].Constraints.Add(fk);//자식테입블의 키에 ForeignKey제약조건 걸어 자식 키가 유효한 부모키를 가리킬 것을 강제.
            m_dsADO.EnforceConstraints = true;

#else

            m_relationBuy = new DataRelation(RELATION_BUY
                                        , m_dsADO.Tables[tblParent.TableName].Columns[colParent]
                                        , m_dsADO.Tables[tblChild.TableName].Columns[colChild]);

            m_dsADO.Relations.Add(m_relationBuy);

            //관계의 룰 기본값을 변경할 경우, 아래 코드 실행하면 변경 가능
            //ForeignKeyConstraint fk = (ForeignKeyConstraint)m_dsADO.Tables["tblSale"].Constraints[RELATION_BUY];
            //fk.DeleteRule = Rule.None;

#endif

#if VIEWMANAGER
            //DataViewManager : 다수의 뷰를 중앙에서 관리. 개별 뷰의 설정 상태인 DataViewSetting 을 보유.
            //  + 여러 테이블의 보기 상태 일괄 수정 가능
            //  + 컨트롤에 바인딩시 매니저를 통해 가능
            //  + 일부 열만 가지는 수직뷰 생성 불가
            //  + 테이블에 대한 동적뷰만 제공 : 조인결과 가질 수 없음
            //  + 레코드의 상태에 따라 필터 구성 가능

            DataViewManager dvmManager = new DataViewManager(m_dsADO);
            dvmManager.DataViewSettings["tblPeople"].Sort = "Name";
            dvmManager.DataViewSettings["tblSale"].RowFilter = "OrderNo > 1";

            DataView dvPeople = dvmManager.CreateDataView(m_tblPeople);
            dvPeople.RowFilter = "Male = true";
            dvPeople.Sort = "Age DESC";

            foreach(DataViewSetting dvs in dvmManager.DataViewSettings)
            {
                lbxSale.Items.Add(String.Format("테이블: {0}, 필터: {1}, 정렬: {2}, 상태: {3}", dvs.Table, dvs.RowFilter, dvs.Sort, dvs.RowStateFilter));
            }

            //그리드 출력: (1)매니저 바인딩 ==> (2)뷰의 DataMember 지정
            dgvPeople.DataSource = dvmManager;
            dgvPeople.DataMember = "tblPeople";
            dgvSale.DataSource = dvmManager;
            dgvSale.DataMember = "tblSale";
#else
            dgvPeople.DataSource = m_dsADO.Tables[tblParent.TableName];
            dgvSale.DataSource = m_dsADO.Tables[tblChild.TableName];
#endif
        }

        private void btnSaleInfo_Click(object sender, EventArgs e)
        {
            DataRow[] items;
            DataRow[] selectedCustomer;

            string currentName = (string)dgvPeople.CurrentRow.Cells[0].Value;
            selectedCustomer = m_dsADO.Tables["tblPeople"].Select(String.Format("Name = '{0}'", currentName));
            items = selectedCustomer[0].GetChildRows(m_dsADO.Relations[RELATION_BUY]);

            lbxSale.Items.Clear();
            foreach(DataRow row in items)
            {
                lbxSale.Items.Add(row["Item"]);
            }
        }

        

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            DataRow[] items;
            DataRow selectedCustomer;

            string currentName = (string)dgvSale.CurrentRow.Cells[1].Value;
            items = m_dsADO.Tables["tblSale"].Select(String.Format("Customer = '{0}'", currentName));
            selectedCustomer = items[0].GetParentRow(m_dsADO.Relations[RELATION_BUY]);
            lblName.Text = selectedCustomer["Name"].ToString();
            lblAge.Text = selectedCustomer["Age"].ToString();
            lblMale.Text = (bool)selectedCustomer["Male"] ? "남자" : "여자";
        }


        private void btnLoadXmlForPeople_Click(object sender, EventArgs e)
        {
            m_tblPeople = ReadDataTableFromXml("people.xml");
            if (m_tblPeople != null)
            {
                m_dsADO.Reset();
                m_tblSale = SampleData.GetSale();
                BindingDataSource(m_tblPeople, m_tblSale, "Name", "Customer");
            }
            else
            {
                MessageBox.Show("XML 파일이 없습니다.");
            }
        }

        private void btnXmlForPeople_Click(object sender, EventArgs e)
        {
            WriteDataTableToXml(m_tblPeople, "people.xml");
        }

        private void btnLoadXmlForSale_Click(object sender, EventArgs e)
        {
            dgvPeople.DataSource = ReadDataTableFromXml("sale.xml");
        }

        private void btnXmlForSale_Click(object sender, EventArgs e)
        {
            WriteDataTableToXml(m_tblPeople, "sale.xml");
        }

        private void btnLoadXmlForDataSet_Click(object sender, EventArgs e)
        {
            m_dsADO = ReadDataSetFromXml("ado.xml");
            if(m_dsADO != null && m_dsADO.Tables.Contains("tblPeople") && m_dsADO.Tables.Contains("tblSale"))
            {
                m_dsADO.Tables["tblPeople"].DefaultView.Sort = "Name";
                dgvPeople.DataSource = m_dsADO.Tables["tblPeople"];
                dgvSale.DataSource = m_dsADO.Tables["tblSale"];
            }
        }

        private void btnXmlForDataSet_Click(object sender, EventArgs e)
        {
            WriteDataSetToXml(m_dsADO, "ado.xml");
        }

        private void dgvPeople_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if(dgv != null && dgv.SelectedRows != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Cells["Name"].Value != null)
            {
                tbxNewName.Text = dgv.SelectedRows[0].Cells["Name"].Value.ToString();
                nudNewAge.Value = (int)dgv.SelectedRows[0].Cells["Age"].Value;
                cbxNewMale.Checked = (bool)dgv.SelectedRows[0].Cells["Male"].Value;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DataRowView row = m_dsADO.Tables["tblPeople"].DefaultView.AddNew();
            row["Name"] = tbxNewName.Text;
            row["Age"] = nudNewAge.Value;
            row["Male"] = cbxNewMale.Checked;
            if(MessageBox.Show("새로운 데이터를 추가하시겠습니까?", "데이터추가", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                row.EndEdit();
            } 
            else
            {
                row.CancelEdit();
            }
            
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            if(dgvPeople.SelectedRows != null && dgvPeople.SelectedRows.Count > 0)
            {
                string selectedName = dgvPeople.SelectedRows[0].Cells["Name"].Value.ToString();
                m_dsADO.Tables["tblPeople"].DefaultView.Sort = "Name";//Find로 조회하려면 정렬기준 설정 필요.
                int idx = m_dsADO.Tables["tblPeople"].DefaultView.Find(selectedName);
                if (idx != -1)
                {
                    DataRowView row = m_dsADO.Tables["tblPeople"].DefaultView[idx];
                    row.BeginEdit();
                    row["Name"] = tbxNewName.Text;
                    row["Age"] = nudNewAge.Value;
                    row["Male"] = cbxNewMale.Checked;
                    if (MessageBox.Show("데이터를 변경하시겠습니까?", "데이터수정", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        row.EndEdit();
                    }
                    else
                    {
                        row.CancelEdit();
                    }
                }
            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            if(dgvPeople.SelectedRows != null && dgvPeople.SelectedRows.Count > 0)
            {
                string selectedName = dgvPeople.SelectedRows[0].Cells["Name"].Value.ToString();
                m_dsADO.Tables["tblPeople"].DefaultView.Sort = "Name";//Find로 조회하려면 정렬기준 설정 필요
                int idx = m_dsADO.Tables["tblPeople"].DefaultView.Find(selectedName);
                if(idx != -1)
                {
                    if (MessageBox.Show("데이터를 삭제하시겠습니까?", "데이터삭제", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        m_dsADO.Tables["tblPeople"].DefaultView[idx].Delete();
                    }
                }
            }
        }

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if(cbx != null)
            {
                DataView view = null;
                switch (cbx.SelectedItem.ToString())
                {
                    case "전체":
                        view = m_dsADO.Tables["tblPeople"].DefaultView;
                        view.Sort = "Age";
                        break;

                    case "남자":
                        view = new DataView(m_dsADO.Tables["tblPeople"]);
                        view.RowFilter = "Male = true";
                        view.Sort = "Name";
                        break;

                    case "여자":
                        view = new DataView(m_dsADO.Tables["tblPeople"]);
                        view.RowFilter = "Male = false";
                        view.Sort = "Age";
                        break;
                }

                dgvPeople.DataSource = view;
            }
        }

        private void dgvPeople_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            DataView view = new DataView(m_dsADO.Tables["tblPeople"]);
            view.RowStateFilter = DataViewRowState.Added;
            dgvNewPeople.DataSource = view;

            view = new DataView(m_dsADO.Tables["tblPeople"]);
            view.RowStateFilter = DataViewRowState.Deleted;
            dgvDeletedPeople.DataSource = view;
        }

        


        private void WriteDataSetToXml(DataSet ds, string fileName)
        {
            ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
            MessageBox.Show("데이터셋을 XML 파일로 저장했습니다.");
        }

        private DataSet ReadDataSetFromXml(string fileName)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(fileName);
            }
            catch
            {
                MessageBox.Show("XML 파일이 없습니다.");
            }

            return ds;
        }

        private void WriteDataTableToXml(DataTable tbl, string fileName)
        {
            tbl.WriteXml(fileName, XmlWriteMode.WriteSchema);//DataTable 스키마구조와 동일하게 XML 생성
            MessageBox.Show("데이터테이블을 XML 파일로 저장했습니다.");
        }

        

        private DataTable ReadDataTableFromXml(string fileName)
        {
            DataTable tbl = new DataTable();
            try
            {
                tbl.ReadXml(fileName);
            }
            catch
            {
                MessageBox.Show("XML 파일이 없습니다.");
            }

            return tbl;
        }
    }
}
