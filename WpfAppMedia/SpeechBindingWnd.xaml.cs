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
using System.Windows.Shapes;

namespace WpfAppMedia
{
    /// <summary>
    /// SpeechBindingWnd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SpeechBindingWnd : Window
    {
        public SpeechBindingWnd()
        {
            InitializeComponent();

            InitSpeech();
        }

        private void InitSpeech()
        {
            var voiceEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            voiceEngine.LoadGrammar(new Grammar(new GrammarBuilder("Hello")) { Name = "TestGrammar" });
            voiceEngine.SpeechRecognized += voiceEngine_SpeechRecognized;
            voiceEngine.SetInputToDefaultAudioDevice();
            voiceEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void voiceEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if(e.Result.Text == "Hello")
            {
                Console.WriteLine("I know you said: " + e.Result.Text);
            }
        }
    }
}
