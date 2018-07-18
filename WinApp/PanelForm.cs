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
    public partial class PanelForm : Form
    {
        public PanelForm()
        {
            InitializeComponent();

            InitFolderTreeView();
        }

        private void InitFolderTreeView()
        {
        }

        private void PanelForm_Load(object sender, EventArgs e)
        {

        }

        private void tvwFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tvwFolder_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnNewFolder":
                        break;

                    case "btnCurrentFolder":
                        break;
                }
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btnReply":
                        break;

                    case "btnIgnore":
                        break;

                    case "btnRegSpam":
                        break;

                    case "btnReject":
                        break;
                }
            }
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwList_ItemActivate(object sender, EventArgs e)
        {

        }

        private void pnlTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "tstTableLayout":
                        tabPanel.SelectedIndex = 1;
                        break;

                    case "tstFlowLayout":
                        BackColor = (btn.Checked) ? Color.Red : DefaultBackColor;
                        break;

                    case "tstSearch":
                        Text = tstSearchText.Text;
                        break;
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = sender as ToolStripMenuItem;
            if(itm != null)
            {
                switch (itm.Tag.ToString())
                {
                    case "R":
                        BackColor = Color.Red;
                        break;

                    case "G":
                        BackColor = Color.Green;
                        break;

                    case "B":
                        BackColor = Color.Blue;
                        break;
                }
            }
        }

        private void PanelForm_MouseMove(object sender, MouseEventArgs e)
        {
            tssX.Text = e.X.ToString();
            tssY.Text = e.Y.ToString();
        }

        private void PanelForm_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tssButton.Text = "왼쪽 버튼을 눌렀습니다";
                    break;

                case MouseButtons.Middle:
                    tssButton.Text = "가운데 버튼을 눌렀습니다";
                    break;

                case MouseButtons.Right:
                    tssButton.Text = "오른쪽 버튼을 눌렀습니다";
                    break;

            }
        }

        private void TabPage_Click(object sender, EventArgs e)
        {
            TabPage tab = sender as TabPage;
            if(tab != null)
            {

            }
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "tsbtnBack":
                        if (webSite.CanGoBack)
                        {
                            webSite.GoBack();
                        }
                        break;

                    case "tsbtnPrevious":
                        if (webSite.CanGoForward)
                        {
                            webSite.GoForward();
                        }
                        break;

                    case "tsbtnGo":
                        if (!String.IsNullOrWhiteSpace(tstxtUrl.Text))
                        {
                            webSite.Navigate(tstxtUrl.Text);
                        }
                        break;

                }
            }
        }

        private void ToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                tsbtnGo.PerformClick();
            }
        }
    }
}
