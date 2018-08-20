using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class DirectorySearcherForm : Form
    {
        private CCDirectorySearcher m_directorySearcher;

        public DirectorySearcherForm()
        {
            InitializeComponent();

            InitCustomControl();
        }

        private void InitCustomControl()
        {
            m_directorySearcher = new CCDirectorySearcher();
            m_directorySearcher.Location = new System.Drawing.Point(8, 72);
            m_directorySearcher.SearchCriteria = null;
            m_directorySearcher.Size = new System.Drawing.Size(271, 173);
            m_directorySearcher.TabIndex = 2;
            m_directorySearcher.SearchComplete += DirectorySearcher_SearchComplete;

        }

        private void DirectorySearcher_SearchComplete(object sender, EventArgs e)
        {
            lblSearch.Text = String.Empty;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            m_directorySearcher.SearchCriteria = tbxSearch.Text;
            lblSearch.Text = "Searching ...";
            m_directorySearcher.BeginSearch();
        }
    }
}
