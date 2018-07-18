//#define 기본키조회
//#define SQLCOMMANDBUILDER
#define LINQ

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using System.Data.Common;
using System.Data.Linq;

namespace WinApp
{
    /// <summary>
    /// ADO(ActiveX Data Objects) : IDAPI, DAO, RDO, JDBC 등 DB접속 인터페이스 이후 최근의 DB접속 인터페이스로 OLE DB를 좀 더 쉽게 쓸 수 있도록 래핑.
    ///                             서버와의 연결을 항상 유지한 채 동작하는 연결형으로 서버에 연결된 상태에서 SQL문을 실행하거나 저장프로시저 호출하는 방식
    /// ADO.NET : 기존의 연결형 외에 비연결형을 추가로 지원. 
    ///           비연결형은 데이터를 가져올 필요가 있을 때 서버에 연결하여 데이터를 가져오고 연결을 끊고, 
    ///           가져온 데이터 사본을 연결이 끊긴 상태에서 조작하여 결과를 서버에 반영할 때 다시 연결하여 데이터를 보내는 방식.
    ///           비연결형은 서버에 부담이 적어 훨씬 더 많은 동시 사용자 지원 가능.
    ///           응용프로그램은 DBMS와 직접 통신하지 않으며 ADO.NET과 통신하고, ADO.NET은 각 공급자를 통해 DBMS에 액세스.
    ///           DBMS에 종속적인 각 공급자가 중간에서 완충역할을 하므로 응용프로그램은 DBMS에 독립적이다.
    ///   + DataSet : 관계형 DB 하나에 대응되는 메모리상의 비연결 DB. 
    ///               관계형 DB뿐 아니라 엑셀워크시트, XML파일, 텍스트 파일까지도 하나의 DataSet에 넣어 관리 가능.
    ///               클라이언트가 많은 리소스를 소모하며, 기동 속도가 느리고, 새로운 개체를 생성하는 DDL 명령은 수행불가하며, 연결형에 비해 데이터의 현재성도 떨어진다.
    ///               
    ///   + System.Data.SqlClient : SQL 서버 공급자. SQL 7.0 이상 버전에 연결.
    ///   + System.Data.OracleClient : Oracle 공급자. Oracle 8.1.7 이상 버전에 연결.
    ///   + System.Data.OleDb : OLE DB 공급자. OLE DB를 통해 DBMS에 연결.
    ///   + System.Data.Odbc : ODBC 공급자. ODBC를 통해 DBMS에 연결.
    ///   
    ///   + Connection : 데이터 소스와 연결
    ///   + Command : SQL 명령이나 저장프로시저 실행
    ///   + DataReader : 읽기전용. 전진전용 결과셋.
    ///   + DataAdapter : 데이터 원본을 읽거나 수정.
    ///   
    /// </summary>

    public partial class ADOForm : Form
    {
        private SqlConnection m_Con;
        private SqlDataAdapter m_Adt;
        private DataSet m_Ds;
        private DataTable m_TblPeople;
        private DataTable m_TblNewPeople;

        public ADOForm()
        {
            InitializeComponent();
        }

        private void ADOForm_Load(object sender, EventArgs e)
        {
#if LINQ
            DataContext dctx = new DataContext(SampleData.GetConnectionString());

            Table<People> people = dctx.GetTable<People>();

            var query = from p in people
                        select p;

            foreach(People q in query)
            {
                lbxResult.Items.Add(String.Format("이름: {0}, 나이: {1}, 성별: {2}"
                                                        , q.Name
                                                        , q.Age
                                                        , q.Male ? "남자" : "여자"));
            }
#else
            m_Con = new SqlConnection();
            m_Con.ConnectionString = SampleData.GetConnectionString();
            m_Con.StateChange += SqlConnection_StateChange;
            m_Con.InfoMessage += SqlConnection_InfoMessage;

            FillAdapterByDataSet();

            InitBindingTextBox(tbxBindingName,"Text", m_Ds, "tblPeople.Name");
#endif
        }

        /// <summary>
        /// 바인딩 : 데이터 소스를 폼의 컨트롤과 연결하여 폼에 데이터를 출력
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataMember"></param>
        private void InitBindingTextBox(Control control, string propertyName, object dataSource, string dataMember)
        {
            //tbxBindingName.DataBindings.Add("Text", m_Ds, "tblPeople.Name");
            control.DataBindings.Add(propertyName, dataSource, dataMember);
        }

        private void ADOForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnection();
        }

        /// <summary>
        /// State 속성이 변경될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        ///   + e.OriginalState : 이전상태
        ///   + e.CurrentState  : 현재상태
        /// </param>
        private void SqlConnection_StateChange(object sender, StateChangeEventArgs e)
        {
            string msg = String.Format("원래상태: {0}, 현재상태: {1}", e.OriginalState, e.CurrentState);
            lbxResult.Items.Add(msg);
        }

        /// <summary>
        /// SQL 서버로부터 경고나 정보메시지가 리턴될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqlConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            lbxResult.Items.Add(e.Message);
        }

        /// <summary>
        /// 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                DataTable tbl;
                switch (btn.Name)
                {
                    case "btnCreatePeople":
                        tbl = CreatePeopleTable();
                        dgvResult.DataSource = tbl;
                        break;

                    case "btnCreateSale":
                        tbl = CreateSaleTable();
                        dgvResult.DataSource = tbl;
                        break;

                    case "btnSearch":
                        FindData();
                        break;

                    case "btnSearchAgeOver":
                        SelectDataFilter();
                        break;

                    case "btnSortASC":
                        SortData(true);
                        break;

                    case "btnSortDESC":
                        SortData(false);
                        break;

                    case "btnUpdateAge":
                        UpdateData(tbxSelectedName.Text);
                        break;

                    case "btnDeleteData":
                        DeleteData(tbxDeleteName.Text);
                        break;

                    case "btnAccept":
                        AcceptData();
                        break;

                    case "btnReject":
                        RejectData();
                        break;

                }
            }
        }

        /// <summary>
        /// 데이터 그리드의 선택 변경시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvResult_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    tbxSelectedName.Text = Convert.ToString(dgv.SelectedRows[0].Cells["Name"].Value);
                    nudNewAge.Value = Convert.ToInt32(dgv.SelectedRows[0].Cells["Age"].Value);
                }
            }
        }

        /// <summary>
        /// 리스트박싀의 선택 변경시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            if (lbx != null && lbx.SelectedItem != null)
            {
                tbxSearch.Text = lbx.SelectedItem.ToString();
            }
        }


        private void QueryButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnConnect":
                        OpenConnection();
                        break;

                    case "btnClose":
                        CloseConnection();
                        break;

                    case "btnSelect":
                        GetPeopleListAll();
                        break;

                    case "btnSelectMultiTable":
                        break;

                    case "btnUpdate":
                        UpdatePeople();
                        break;

                    case "btnDelete":
                        DeletePeople();
                        break;

                    case "btnSum":
                        SumAgePeople();
                        break;

                    case "btnInsertCommandText":
                        InsertPeople();
                        break;

                    case "btnInsertCommandParams":
                        InsertPeopleByParams();
                        break;

                    case "btnAllAge":
                        ExecuteSP("IncAllAge");
                        break;

                    case "btnSomeAge":
                        ExecuteSP("IncSomeAge");
                        break;

                    case "btnRollback":
                        ExecuteTransaction(false);
                        break;

                    case "btnCommit":
                        ExecuteTransaction(true);
                        break;
                }
            }
        }

        /// <summary>
        /// 모든 데이터 조회하여 반환 받은 결과셋 읽기
        /// </summary>
        private void GetPeopleListAll()
        {
            SqlCommand cmd = new SqlCommand("SELECT Name, Age, Male FROM tblPeople", m_Con);
            SqlDataReader reader = cmd.ExecuteReader();
            lbxQueryResult.Items.Clear();
            while (reader.Read())
            {
                //열의 타입을 정확히 알고 NULL값이 아님을 확신하며 인덱스를 알고 있는 경우 
                //reader.GetXXX(인덱스) 메서드로 읽으면 별도 변환이 필요 없어 속도는 더 빠르다.
                //그렇지 않은 경우, reader[인덱스 또는 컬럼명] 로 읽는다.
                lbxQueryResult.Items.Add(String.Format("이름: {0}, 나이: {1}, 성별: {2}"
                                                        , reader.GetString(0)
                                                        , reader.GetInt32(1)
                                                        , reader.GetBoolean(2) ? "남자" : "여자"));
            }
            reader.Close();//반드시 필요
        }

        private void AdapterButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnAdtSelect":
                        FillAdapterByTable();
                        break;

                    case "btnAdtUpdate":
                        m_Adt.Update(m_TblPeople);
                        break;

                    case "btnAdtMerge":
                        MergeDataSet();
                        break;

                    case "btnAdtChangedData":
                        GetChangedAdapterData();
                        break;

                }
            }
        }

        private void BindingButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnPrev":
                        BindingContext[m_Ds, "tblPeople"].Position--;
                        break;

                    case "btnNext":
                        BindingContext[m_Ds, "tblPeople"].Position++;
                        break;
                }
            }
        }



        /// <summary>
        /// Merge 메서드 : 원본과 새 테이블의 키 비교하여 같으면 새 데이터로 덮어쓰고, 다르면 추가한다.
        ///   + preserveChanges(원본유지여부 = 기본값은 false) : true로 하면 키가 같아도 덮어쓰지 않고 원본값 유지.
        ///   + missingSchemaAction(스키마 다를 경우 처리 = 기본값은 Add) : 
        ///      * MissingSchemaAction.Add : 새 테이블의 스키마 정보 추가
        ///      * MissingSchemaAction.AddWithKey : 새 테이블의 스키마와 기본키 정보 추가
        ///      * MissingSchemaAction.Error : 에러 발생
        ///      * MissingSchemaActionIgnore : 새 테이블의 다른 스키마 정보 무시
        /// </summary>
        private void MergeDataSet()
        {
            Person[] people = new Person[] { new Person("정우성", 41, true), new Person("송혜교", 33, false) };
            m_TblNewPeople = SampleData.GetPeople(people);
            m_Ds.Merge(m_TblNewPeople);
            dgvAdtResult.DataSource = m_Ds.Tables["tblPeople"];

        }

        /// <summary>
        /// 어댑터 : DB 연결 없이 어댑터를 이용해 필요시만 DB 연결하고 바로 연결 끊기
        /// </summary>
        private void FillAdapterByTable()
        {
            m_Adt = new SqlDataAdapter("SELECT Name, Age, Male FROM tblPeople", m_Con);
            m_TblPeople = new DataTable("tblPeople");

#if SQLCOMMANDBUILDER
            // 어댑터의 SELECT 문을 참조하여 나머지 쿼리문 자동 생성
            // 조건) 단일 테이블에 기본키가 있고, SELECT 문의 필드리스트에 기본키가 지정된 경우만 사용
            SqlCommandBuilder builder = new SqlCommandBuilder(m_Adt);
#else

            CreateAdapterCommand();
#endif
            m_TblPeople.ColumnChanging += TablePeople_ColumnChanging;
            m_TblPeople.RowChanging += TablePeople_RowChanging;

            //SetDataTableMapping();

            m_Adt.Fill(m_TblPeople);
            dgvAdtResult.DataSource = m_TblPeople;
        }


        /// <summary>
        /// 행이 편집될 때마다
        /// </summary>
        /// <remarks>
        ///   + RowChanging : 편집 중에 이벤트 발생. 편집되는 컬럼정보는 알 수 없음.
        ///   + RowChanged : 편집이 완료된 후에 발생
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablePeople_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            if((bool)e.Row["Male"] == false)
            {
                if((int)e.Row["Age"] > 40){
                    e.Row.SetColumnError("Age", "여성의 나이는 40세이하여야 합니다.");
                }
                else
                {
                    e.Row.SetColumnError("Age", "");
                }
            }
            else
            {
                if((int)e.Row["Age"] > 45)
                {
                    e.Row.SetColumnError("Age", "남성의 나이는 45세이하여야 합니다.");
                }
                else
                {
                    e.Row.SetColumnError("Age", "");
                }
            }
        }

        /// <summary>
        /// 열이 편집될 때마다
        /// </summary>
        /// <remarks>
        ///   + ColumnChanging : 편집 중에 이벤트 발생하므로 유효성 점검은 여기에서
        ///   + ColumnChanged : 편집이 완료된 후에 발생
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablePeople_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if(e.Column.ColumnName == "Age")
            {
                if((int)e.ProposedValue < 0 || (int)e.ProposedValue > 100)
                {
                    e.Row.SetColumnError("Age", "나이는 0~100 사이여야 합니다.");
                }
                else
                {
                    e.Row.SetColumnError("Age", "");
                }
            }
        }

        private void CreateAdapterCommand()
        {
            SqlCommand cmd;
            cmd = new SqlCommand("INSERT INTO tblPeople VALUES (@Name, @Age, @Male)", m_Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10, "Name");
            cmd.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            cmd.Parameters.Add("@Male", SqlDbType.Bit, 0, "Male");
            m_Adt.InsertCommand = cmd;

            cmd = new SqlCommand("UPDATE tblPeople SET Name = @Name, Age = @Age, Male = @Male WHERE Name = @OldName", m_Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10, "Name");
            cmd.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            cmd.Parameters.Add("@Male", SqlDbType.Bit, 0, "Male");
            cmd.Parameters.Add("@OldName", SqlDbType.NVarChar, 10, "Name");
            m_Adt.UpdateCommand = cmd;

            cmd = new SqlCommand("DELETE FROM tblPeople WHERE Name = @Name", m_Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10, "Name");
            m_Adt.DeleteCommand = cmd;
        }

        /// <summary>
        /// 맵핑 : 데이터 원본의 이름과 별명의 짝을 관리
        /// </summary>
        private void SetDataTableMapping()
        {
            DataTableMapping mapper = m_Adt.TableMappings.Add("tblPeople", "tblPeople");
            mapper.ColumnMappings.Add("Name", "이름");
            mapper.ColumnMappings.Add("Age", "나이");
            mapper.ColumnMappings.Add("Male", "성별");
        }

        private void FillAdapterByDataSet()
        {
            m_Adt = new SqlDataAdapter("SELECT * FROM tblPeople", m_Con);
            m_Ds = new DataSet();

            CreateAdapterCommand();

            m_Adt.Fill(m_Ds, "tblPeople");
            dgvAdtResult.DataSource = m_Ds.Tables["tblPeople"];
        }

        private void GetChangedAdapterData()
        {
            if (m_Ds.HasChanges())
            {
                DataSet dsChanged = m_Ds.GetChanges();
                DataTable tblChanged = dsChanged.Tables["tblPeople"];
                lbxResult.Items.Clear();

                foreach(DataRow row in tblChanged.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            lbxResult.Items.Add(String.Format("추가: {0}", row["Name"]));
                            break;

                        case DataRowState.Deleted:
                            lbxResult.Items.Add(String.Format("삭제: {0}", row["Name", DataRowVersion.Original]));
                            break;

                        case DataRowState.Modified:
                            lbxResult.Items.Add(String.Format("수정: {0} -> {1}", row["Name", DataRowVersion.Original], row["Name"]));
                            break;

                    }
                }
            }
        }


        /// <summary>
        /// 여러 개의 테이블을 하나의 쿼리 연결(;)해 조회하여 반환 받은 여러 개의 결과셋 읽기
        /// </summary>
        private void GetPeopleNSaleListAll()
        {
            SqlCommand cmd = new SqlCommand("SELECT Name, Age, Male FROM tblPeople; SELECT OrderNo, Customer, Item, OrderDate FROM tblSale", m_Con);
            SqlDataReader reader = cmd.ExecuteReader();
            lbxQueryResult.Items.Clear();
            while (reader.Read())
            {
                lbxQueryResult.Items.Add(String.Format("이름: {0}, 나이: {1}, 성별: {2}"
                                                        , reader.GetString(0)
                                                        , reader.GetInt32(1)
                                                        , reader.GetBoolean(2) ? "남자" : "여자"));
            }
            reader.NextResult();//다음 결과셋 읽기준비
            while (reader.Read())
            {
                lbxQueryResult.Items.Add(String.Format("번호: {0}, 고객: {1}, 상품: {2}, 날짜: {3}"
                                                        , reader.GetInt32(0)
                                                        , reader.GetString(1)
                                                        , reader.GetString(2)
                                                        , reader.GetDateTime(3)));
            }
        }

        /// <summary>
        /// 특정 이름의 회원의 나이정보 업데이트(+1)
        /// </summary>
        private void UpdatePeople()
        {
            if(!String.IsNullOrWhiteSpace(tbxQueryName.Text))
            {
                SqlCommand cmd = new SqlCommand(String.Format("UPDATE tblPeople SET Age = Age + 1 WHERE Name = N'{0}'", tbxQueryName.Text), m_Con);
                cmd.ExecuteNonQuery();
                GetPeopleListAll();
            }
        }

        /// <summary>
        /// 특정 이름의 회원정보 삭제
        /// </summary>
        private void DeletePeople()
        {
            if (!String.IsNullOrWhiteSpace(tbxQueryName.Text))
            {
                SqlCommand cmd = new SqlCommand(String.Format("DELETE tblPeople WHERE Name = N'{0}'", tbxQueryName.Text), m_Con);
                cmd.ExecuteNonQuery();
                GetPeopleListAll();
            }
        }

        /// <summary>
        /// 전체 회원 나이합계와 평균나이
        /// </summary>
        /// <remarks>
        /// ExecuteScalar() : 하나의 단일값 반환
        /// </remarks>
        private void SumAgePeople()
        {
#if ExecuteScalar메서드는_IsDBNull체크불가하므로_ExecuteReader메서드를_사용해_IsDBNull체크
                        SqlCommand cmd = new SqlCommand("SELECT SUM(Age) FROM tblPeople;SELECT AVG(Age) FROM tblPeople;SELECT COUNT(Name) FROM tblPeople", m_Con);
            SqlDataReader reader = cmd.ExecuteReader();
            int sum = 0, avg = 0, cnt = 0;
            while (reader.Read())
            {
                sum = (reader.IsDBNull(0)) ? 0 : reader.GetInt32(0);
            }
            reader.NextResult();
            while (reader.Read())
            {
                avg = (reader.IsDBNull(0)) ? 0 : reader.GetInt32(0);
            }
            reader.NextResult();
            while (reader.Read())
            {
                cnt = (reader.IsDBNull(0)) ? 0 : reader.GetInt32(0);
            }
            reader.Close();//반드시 필요

            MessageBox.Show("총 " + cnt + " 명의 회원들의 나이의 합은 " + sum + " 이며, 평균나이는 " + avg + " 입니다.");
#else
            SqlCommand cmd = new SqlCommand("SELECT SUM(Age) FROM tblPeople", m_Con);
            int sum = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT AVG(Age) FROM tblPeople";
            int avg = (int)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT COUNT(Name) FROM tblPeople";
            int cnt = (int)cmd.ExecuteScalar();
            MessageBox.Show("총 " + cnt + " 명의 회원들의 나이의 합은 " + sum + " 이며, 평균나이는 " + avg + " 입니다.");
#endif
        }

        /// <summary>
        /// 신규 회원 등록
        /// </summary>
        private void InsertPeople()
        {
            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO tblPeople VALUES (N'{0}', {1}, {2})"
                                                        , tbxQueryName.Text
                                                        , nudQueryAge.Value
                                                        , cbxQueryMale.Checked ? 1 : 0), m_Con);

            cmd.ExecuteNonQuery();
            GetPeopleListAll();
        }

        /// <summary>
        /// 신규 회원 등록 : SqlParameter
        /// </summary>
        private void InsertPeopleByParams()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tblPeople VALUES (@Name, @Age, @Male)", m_Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@Age", SqlDbType.Int);
            cmd.Parameters.Add("@Male", SqlDbType.Bit);
            cmd.Parameters["@Name"].Value = tbxQueryName.Text;
            cmd.Parameters["@Age"].Value = nudQueryAge.Value;
            cmd.Parameters["@Male"].Value = cbxQueryMale.Checked ? 1 : 0;

            cmd.ExecuteNonQuery();
            GetPeopleListAll();
        }

        /// <summary>
        /// 저장프로시저
        /// </summary>
        /// <param name="spName"></param>
        private void ExecuteSP(string spName)
        {
            SqlCommand cmd = new SqlCommand(spName, m_Con);
            cmd.CommandType = CommandType.StoredProcedure;//저장프로시저임을 선언

            switch (spName)
            {
                case "IncAllAge":
                    int row = cmd.ExecuteNonQuery();
                    GetPeopleListAll();
                    MessageBox.Show("영향받은 행의 수: " + row);
                    break;

                case "IncSomeAge":
                    if (!String.IsNullOrWhiteSpace(tbxQueryName.Text))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10);
                        cmd.Parameters.Add("@Age", SqlDbType.Int);
                        cmd.Parameters["@Age"].Direction = ParameterDirection.Output;//저장프로시저로부터 반환받을 OUTPUT 매개변수 선언
                        cmd.Parameters["@Name"].Value = tbxQueryName.Text;//저정프로시저로 전달할 값 설정
                        cmd.ExecuteNonQuery();
                        GetPeopleListAll();

                        int age = (int)cmd.Parameters["@Age"].Value;//저장프로시저로부터 반환받은 OUTPUT 매개변수 값 읽기
                        MessageBox.Show("변경 후 나이: " + age);
                    }
                    break;
            }
        }

        private void ExecuteTransaction(bool isCommit)
        {
            SqlTransaction trans = m_Con.BeginTransaction();
            SqlCommand cmd = m_Con.CreateCommand();
            cmd.Connection = m_Con;
            cmd.Transaction = trans;
            cmd.CommandText = "UPDATE tblPeople SET Age = Age + 1 WHERE Name = N'정우성'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE tblPeople SET Age = Age - 1 WHERE Name = N'배용준'";
            cmd.ExecuteNonQuery();

            if (isCommit)
            {
                trans.Commit();
            }
            else
            {
                trans.Rollback();
            }

            GetPeopleListAll();
        }






        /// <summary>
        /// 원본에서 변경되거나 삭제된 내용을 원본에 반영
        /// </summary>
        private void AcceptData()
        {
            DataTable tbl = dgvResult.DataSource as DataTable;
            if (tbl != null && tbl.TableName == "tblPeople")
            {
                tbl.AcceptChanges();
            }
        }

        /// <summary>
        /// 원본에서 변경되거나 삭제된 내용을 원본에 반영하지 않고 취소
        /// </summary>
        private void RejectData()
        {
            DataTable tbl = dgvResult.DataSource as DataTable;
            if (tbl != null && tbl.TableName == "tblPeople")
            {
                tbl.RejectChanges();
            }
        }

        /// <summary>
        /// 선택된 사람의 나이를 변경
        /// </summary>
        /// <param name="selectedName"></param>
        private void UpdateData(string selectedName)
        {
#if 기본키조회
            DataRow row = FindData(selectedName);
            if(row != null)
            {
                row["Age"] = Convert.ToInt32(nudNewAge.Value);
            }
#else
            DataRow[] rows = SelectDataFilter(selectedName);
            if (rows != null && rows.Length != 0)
            {
                rows[0]["Age"] = Convert.ToInt32(nudNewAge.Value);
            }
#endif
        }

        /// <summary>
        /// 해당 이름의 사람을 조회하여 삭제
        /// </summary>
        /// <param name="searchName"></param>
        private void DeleteData(string searchName)
        {
#if 기본키조회
            DataRow row = FindData(searchName);
            if (row != null)
            {
                row.Delete();//삭제 예정임을 표시
            }
#else
            DataRow[] rows = SelectDataFilter(searchName);
            if(rows != null && rows.Length != 0)
            {
                rows[0].Delete();//삭제 예정임을 표시
            }
#endif
        }

        /// <summary>
        /// 오름차순/내림차순 정렬
        /// </summary>
        /// <param name="isAscending"></param>
        private void SortData(bool isAscending)
        {
            DataTable tbl = dgvResult.DataSource as DataTable;
            if (tbl != null && tbl.TableName == "tblPeople")
            {
                DataRow[] rows;
                if (isAscending)
                {
                    rows = tbl.Select("", "Name");
                    DisplayResult(rows);
                }
                else
                {
                    rows = tbl.Select("", "Name DESC");
                    DisplayResult(rows);
                }
            }

        }

        /// <summary>
        /// 해당 이름의 사람을 조회하여 조회결과 반환
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private DataRow[] SelectDataFilter(string name)
        {
            DataRow[] rows = null;
            if (!String.IsNullOrWhiteSpace(name))
            {
                DataTable tbl = dgvResult.DataSource as DataTable;
                if (tbl != null && tbl.TableName == "tblPeople")
                {
                    string filter = String.Format("Name = '{0}'", name);
                    rows = tbl.Select(filter);
                }
            }

            return rows;
        }

        /// <summary>
        /// 기본키 조회가 아닌 경우, DataTable 의 Select 메서드 이용
        /// </summary>
        /// <remarks>
        /// 입력한 나이 이상의 사람을 조회하여 리스트박스에 표시
        /// </remarks>
        private void SelectDataFilter()
        {
            string filter = "Age >= " + nudSearchAgeOver.Value;
            DataTable tbl = dgvResult.DataSource as DataTable;
            if (tbl != null && tbl.TableName == "tblPeople")
            {
                DataRow[] rows = tbl.Select(filter);
                DisplayResult(rows);
            }
        }


        /// <summary>
        /// 기본키 조회: 해당 이름의 사람을 조회하여 나이정보를 메시지박스로 표시
        /// </summary>
        private void FindData()
        {
            DataRow row = FindData(tbxSearch.Text);
            if (row == null)
            {
                MessageBox.Show("테이블에 존재하지 않는 사람입니다.");
            }
            else
            {
                MessageBox.Show(String.Format("{0} 정보 : 나이 {1}세", row["Name"], row["Age"]));
            }
        }

        /// <summary>
        /// 기본키로 조회하는 경우, DataRowCollection 의 Find 메서드 이용
        /// </summary>
        private DataRow FindData(string primaryKey)
        {
            DataRow row = null;
            if (!string.IsNullOrWhiteSpace(primaryKey))
            {
                DataTable tbl = dgvResult.DataSource as DataTable;
                if (tbl != null && tbl.TableName == "tblPeople")
                {
                    row = tbl.Rows.Find(primaryKey);
                }
            }

            return row;
        }


        /// <summary>
        /// 리스트박스에 표시
        /// </summary>
        /// <param name="rows"></param>
        private void DisplayResult(DataRow[] rows)
        {
            lbxResult.Items.Clear();
            foreach (DataRow row in rows)
            {
                lbxResult.Items.Add(row["Name"]);
            }
        }


        /// <summary>
        /// tblPeople 테이블 생성 및 샘플 데이터
        /// </summary>
        /// <returns></returns>
        private DataTable CreatePeopleTable()
        {
            return SampleData.GetPeople();
        }

        

        /// <summary>
        /// tblSale 테이블 생성 및 샘플 데이터
        /// </summary>
        /// <returns></returns>
        private DataTable CreateSaleTable()
        {
            return SampleData.GetSale();
        }



        /// <summary>
        /// DB 연결
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                m_Con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DB 연결끊기
        /// </summary>
        private void CloseConnection()
        {
            if(m_Con.State == ConnectionState.Open)
            {
                m_Con.Close();
            }
        }

        
    }

    
}
