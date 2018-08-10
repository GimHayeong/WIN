using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPhotoGallery
{
    /// <summary>
    /// 파일 이름 바꾸기 사용자정의 다이얼로그상자
    /// </summary>
    public partial class DlgRename : Window
    {
        public string FileName { get; private set; }
        public string NewFileName { get; private set; }
        public DlgRename()
        {
            InitializeComponent();
        }

        public DlgRename(string fileName)
            : this()
        {
            FileName = fileName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnOK":
                        if (String.IsNullOrWhiteSpace(tbxNewName.Text))
                        {
                            MessageBox.Show("변경할 파일 이름을 입력하세요.");
                            tbxNewName.SelectAll();
                            tbxNewName.Focus();
                            return;
                        }

                        NewFileName = tbxNewName.Text.Trim();
                        this.DialogResult = true;
                        break;

                    case "btnCancel":
                        this.DialogResult = false;
                        break;
                }
            }

            this.Close();
        }
    }
}
