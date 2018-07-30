#define TEST
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class FileExplorerForm : Form
    {
        public FileExplorerForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            lvwResult.Clear();
            lvwResult.View = View.Details;
            lvwResult.LabelEdit = false;
            lvwResult.CheckBoxes = true;
            lvwResult.FullRowSelect = true;
            lvwResult.GridLines = true;
            lvwResult.Sorting = SortOrder.Ascending;
            lvwResult.Columns.Add("파일명", 170, HorizontalAlignment.Left);
            lvwResult.Columns.Add("파일크기", 80, HorizontalAlignment.Right);
            lvwResult.Columns.Add("생성일자", 150, HorizontalAlignment.Left);

#if TEST
            tbxDir.Text = @"C:\";
#endif
        }

        private void btnSearchDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                tbxDir.Text = dlg.SelectedPath.Trim();
            }
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxDir.Text))
            {
                MessageBox.Show("검색대상 디렉토리를 입력하세요", "파일검색안내");
                tbxDir.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(tbxFileName.Text))
            {
                MessageBox.Show("검색대상 파일을 입력하세요", "파일검색안내");
                tbxFileName.Focus();
                return;
            }

            string dirPath = tbxDir.Text.Trim();
            string fileSearchPattern = tbxFileName.Text.Trim();
            lvwResult.Items.Clear();

            string[] files;
            try
            {
                files = Directory.GetFiles(dirPath, fileSearchPattern);
                if (files == null || files.Length < 1)
                {
                    MessageBox.Show("파일이 존재하지 않습니다.", "파일검색안내");
                    return;
                }

                ListViewItem item;
                for (int i=0; i<files.Length; i++)
                {
                    item = new ListViewItem(files[i], 0);//리스트뷰 아이템텍스트

                    FileInfo file = new FileInfo(files[i]);
                    item.SubItems.Add($"{file.Length} Byte");
                    item.SubItems.Add(file.CreationTime.ToString());
                    lvwResult.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("파일검색 중 예외가 발생했습니다.", "파일검색안내");
            }
        }
    }
}
