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

namespace WpfAppPhotoGalleryDataBinding
{
    /// <summary>
    /// RenameDialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RenameDialog : Window
    {
        public string OldFileName { get; set; }
        public string NewFileName { get; private set; }

        public RenameDialog()
        {
            InitializeComponent();

            InitFileName();
        }

        public RenameDialog(string oldFileName)
        {
            InitializeComponent();

            OldFileName = oldFileName;

            InitFileName();
        }

        private void InitFileName()
        {
            tbxFileName.Text = OldFileName;
            tbxFileName.Focus();
            tbxFileName.SelectAll();
        }

        private void FileNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewFileName = tbxFileName.Text;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
