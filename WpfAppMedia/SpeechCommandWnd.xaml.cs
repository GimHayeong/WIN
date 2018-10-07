using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
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
    /// SpeechCommandWnd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SpeechCommandWnd : Window
    {
        SpeechRecognitionEngine m_speechRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        private SpeechSynthesizer m_tts;
        private string m_voice = "Microsoft Zira Desktop";

        public SpeechCommandWnd()
        {
            InitializeComponent();

            InitSpeech();

            InitTTS();
        }

        private void InitTTS()
        {
            try
            {
                m_tts = new SpeechSynthesizer();
                m_tts.SelectVoice(m_voice);
                m_tts.SetOutputToDefaultAudioDevice();
                m_tts.Volume = 100;

                m_tts.SpeakAsync("Hello, world!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"init TTS Error: {ex.ToString()}");
            }
        }

        private void InitSpeech()
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Culture = new System.Globalization.CultureInfo("en-US");
            Choices commandChoices = new Choices("weight", "color", "size");
            grammarBuilder.Append(commandChoices);

            Choices valueChoices = new Choices();
            valueChoices.Add("normal", "bold");
            valueChoices.Add("red", "green", "blue");
            valueChoices.Add("small", "medium", "large");
            grammarBuilder.Append(valueChoices);

            m_speechRecognizer.SpeechRecognized += speechRecognizer_SpeechRecognized;
            m_speechRecognizer.LoadGrammar(new Grammar(grammarBuilder));
            m_speechRecognizer.SetInputToDefaultAudioDevice();

            
        }

        private void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            lblDemo.Content = e.Result.Text;

            if (e.Result.Words.Count == 2)
            {
                string command = e.Result.Words[0].Text.ToLower();
                string value = e.Result.Words[1].Text.ToLower();

                switch (command)
                {
                    case "weight":
                        FontWeightConverter weightConverter = new FontWeightConverter();
                        try
                        {
                            lblDemo.FontWeight = (FontWeight)weightConverter.ConvertFromString(value);
                        }
                        catch { }
                        break;

                    case "color":
                        try
                        {
                            lblDemo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
                        }
                        catch { }
                        break;

                    case "size":
                        switch (value)
                        {
                            case "small":
                                lblDemo.FontSize = 12;
                                break;

                            case "medium":
                                lblDemo.FontSize = 24;
                                break;

                            case "large":
                                lblDemo.FontSize = 48;
                                break;
                        }
                        break;
                }
            }
        }

        private void ListeningToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (btnToggleListening.IsChecked == true)
            {
                m_speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                m_speechRecognizer.RecognizeAsyncStop();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_speechRecognizer.Dispose();
        }
    }
}
