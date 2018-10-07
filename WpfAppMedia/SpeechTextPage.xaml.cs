using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
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
    /// SpeechTextPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SpeechTextPage : Page
    {

        public SpeechTextPage()
        {
            InitializeComponent();


            InitSpeech();
        }

        private void InitSpeech()
        {
            SpeechRecognizer speechRecognizer = new SpeechRecognizer();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            tbxSpeech.Clear();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Command invoked : Open");
        }

        private void SaveButtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Command invoked : Save");
        }
    }
}
