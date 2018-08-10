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
    /// WinControlTransform.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinControlTransform : Window
    {
        public WinControlTransform()
        {
            InitializeComponent();

            InitControls();
        }

        private void InitControls()
        {
            Canvas.SetZIndex(btnYellow, 1);

            Button btn;
            for(int i=0; i<15; i++)
            {
                btn = new Button();
                btn.Content = $"{i}번째";
                btn.Margin = new Thickness(5);
                btn.Padding = new Thickness(5);

                lbxButtonList.Items.Add(btn);
            }
        }
    }
}
