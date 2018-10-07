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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppMedia
{
    /// <summary>
    /// MediaPlayerPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MediaPlayerPage : Page
    {
        public MediaPlayerPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 미디어는 비동기 방식을 사용하므로, 예외처리를 별도로 해 주어야 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Video_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.ToString());
        }
    }
}
