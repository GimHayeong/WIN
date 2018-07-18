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

namespace ORDesigner
{
    public partial class AccessForm : Form
    {
        private OleDbConnection m_Con;
        private OleDbDataAdapter m_Adt;
        private DataTable m_TblPeople;

        public AccessForm()
        {
            InitializeComponent();
        }

        private void AccessForm_Load(object sender, EventArgs e)
        {
            m_Con = new OleDbConnection();
            m_Con.ConnectionString = "Provider = Microsoft.JET.OLEDB.4.0; Data Source = " + Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Resources\" + Properties.Resources.ADOSamplePath;
        }

        private void tsBtnConnect_Click(object sender, EventArgs e)
        {
            m_Adt = new OleDbDataAdapter("SELECT * FROM tblPeople", m_Con);
            m_TblPeople = new DataTable("tblPeople");
            m_Adt.Fill(m_TblPeople);
            dgvPeople.DataSource = m_TblPeople;
        }
    }
}
