using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //InitSound();
        }

        private void InitSound()
        {
            SoundPlayer player = new SoundPlayer("Sound/click.wav");
            player.Play();
        }

        private void PlayWma(string wmaFilename)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(wmaFilename, UriKind.Relative));
            player.Play();
        }
    }
}
