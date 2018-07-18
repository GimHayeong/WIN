using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp
{
    /// <summary>
    /// ControlWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            if (mnu != null)
            {
                string header = mnu.Header.ToString().TrimStart('_');
                switch (header)
                {
                    case "Exit":
                        Application.Current.Shutdown();
                        break;

                    case "Manage users":
                        MessageBox.Show("Manage users");
                        break;

                    case "Show gropus":
                        MessageBox.Show("Show groups");
                        break;
                }
                
            }
        }


        private void OpenCommand_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //string cmd, target;
            //cmd = ((RoutedCommand)e.Command).Name;
            //target = ((FrameworkElement)sender).Name;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//@"C:\temp\";
            dlg.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            if(dlg.ShowDialog() == true)
            {
                txtEditor.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void NewCommand_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Clear();
        }

        private void SaveCommand_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.FileName = "Document_" + DateTime.Now.ToString("yyyyMMddhms");
            dlg.DefaultExt = ".text";
            dlg.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            if(dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, txtEditor.Text);
            }
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(CustomCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt) });
    }
}
