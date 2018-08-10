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
    /// WinNickname.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinNickname : Window
    {
        Nicknames _names;

        public WinNickname()
        {
            InitializeComponent();

            this.btnAdd.Click += BtnAdd_Click;

            //this._names = new Nicknames();
            //dockPanel.DataContext = this._names;

            //this._names = (Nicknames)this.FindResource("name");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this._names.Add(new Nickname());
        }
    }
}
