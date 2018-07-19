using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using DAL;
using BLL;

namespace ORDesigner
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  (1) ORDesigner 의 XXXDataSet 인스턴스 디자인모드에서 추가하기
    ///                    : 데이터소스에서 추가한 것 중에 선택하여 추가
    ///  (2) BindingSource 컨트롤 인스턴스의 DataSource 속성 디자인모드에서 설정   
    ///                    : (1)의 인스턴스명 / DataMember : (1)의 인스턴스에 속하는 테이블명
    ///  (3) DataGridView 컨트롤 DataSource 속성 디자인모드에서 설정
    ///                    : (2)의 BindingSource 인스턴스명
    ///  (4) BindingNavigator 컨트롤 인스턴스의 DataSource 속성 디자인모드에서 설정
    ///                    : (2)의 BindingSource 인스턴스명
    ///  (5) 어댑터의 Fill 메서드를 통해 (1)의 인스턴스의 데이터멤버에 결과채우기
    /// </remarks>

    public partial class AccessForm : Form
    {
        private OleDbConnection m_Con;
        private OleDbDataAdapter m_Adt;

        private MySqlConnection m_ConMySql;
        private MySqlDataAdapter m_AdtMySql;

        public AccessForm()
        {
            InitializeComponent();
        }

        private void AccessForm_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'adoSampleDS.tblPeople' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tblPeopleTableAdapter.Fill(this.adoSampleDS.tblPeople);
            m_Con = new OleDbConnection();
            m_Con.ConnectionString = ConfigurationManager.ConnectionStrings["ORDesigner.Properties.Settings.ADOAccessConnectionString"].ConnectionString;
            //m_Con.ConnectionString = SampleData.GetOleDbConnectionString(Application.StartupPath, "Resources", "ADOSample.mdb");

            m_ConMySql = new MySqlConnection();
            m_ConMySql.ConnectionString = SampleData.GetMySqlConnectionString();

        }

        private void tsBtnConnect_Click(object sender, EventArgs e)
        {
            m_Adt = new OleDbDataAdapter("SELECT * FROM tblPeople", m_Con);
            m_Adt.Fill(adoSampleDS.tblPeople);
        }

        private void tsBtnConnectMySql_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            m_AdtMySql = new MySqlDataAdapter("SELECT * FROM tblPeople", m_ConMySql);
            m_AdtMySql.Fill(adoSampleDS.tblPeople);
        }


    }
}
