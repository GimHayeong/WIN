using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// SpeechSampleWnd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SpeechSampleWnd : Window
    {
        private SpeechSynthesizer m_tts;
        SpeechRecognitionEngine m_speechRecognizer;
        private string m_voice;

        public SpeechSampleWnd()
        {
            InitializeComponent();

            //InitRS(new CultureInfo("ko-KR"));
            InitRS(new System.Globalization.CultureInfo("en-US"));
            InitTTS();
        }

        private void InitRS(System.Globalization.CultureInfo info)
        {
            try
            {
                m_speechRecognizer = new SpeechRecognitionEngine(info);
                Grammar grammar;

                if (info.TwoLetterISOLanguageName.Equals("en"))
                {
                    grammar = new Grammar("Content\\input-en.xml");
                    m_speechRecognizer.LoadGrammar(grammar);

                    m_speechRecognizer.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
                    m_speechRecognizer.SetInputToDefaultAudioDevice();
                    m_speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);

                    m_voice = "Microsoft Zira Desktop";
                }
                else if (info.TwoLetterISOLanguageName.Equals("ko"))
                {
                    grammar = new Grammar("Content\\input.xml");
                    m_speechRecognizer.LoadGrammar(grammar);

                    m_speechRecognizer.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
                    m_speechRecognizer.SetInputToDefaultAudioDevice();
                    m_speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);

                    m_voice = "Microsoft Heami Desktop";
                }
            }
            catch (Exception ex)
            {
                lblResult.Content = $"init RS Error: {ex.ToString()}";
            }
        }

        private void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            lblResult.Content = e.Result.Text;

            switch (e.Result.Text)
            {
                case "컴퓨터":
                    m_tts.SpeakAsync("네 컴퓨터입니다.");
                    break;

                case "Computer":
                    m_tts.SpeakAsync("Yes, I'm a computer.");
                    break;

                case "안녕":
                    m_tts.SpeakAsync("반갑습니다. 음성인식 테스터입니다.");
                    break;

                case "Hi":
                    m_tts.SpeakAsync("Nice to meet you. I'm a voice recognition tester.");
                    break;

                case "종료":
                    m_tts.Speak("프로그램을 종료합니다.");
                    break;

                case "Exit":
                    m_tts.Speak("Shut down the program.");
                    break;

                case "계산기":
                    m_tts.SpeakAsync("계산기를 실행합니다.");
                    doProgram("c:\\Windows\\system32\\calc.exe", "");
                    break;

                case "Calculator":
                    m_tts.SpeakAsync("Run the calculator");
                    doProgram("c:\\Windows\\system32\\calc.exe", "");
                    break;

                case "메모장":
                    m_tts.SpeakAsync("메모장을 실행합니다.");
                    doProgram("c:\\Windows\\system32\\notepad.exe", "");
                    break;

                case "Notepad":
                    m_tts.SpeakAsync("Run the notepad");
                    doProgram("c:\\Windows\\system32\\notepad.exe", "");
                    break;

                case "콘솔":
                    m_tts.SpeakAsync("콘솔을 실행합니다.");
                    doProgram("c:\\Windows\\system32\\cmd.exe", "");
                    break;

                case "Console":
                    m_tts.SpeakAsync("Run the console");
                    doProgram("c:\\Windows\\system32\\cmd.exe", "");
                    break;

                case "그림판":
                    m_tts.SpeakAsync("그림판을 실행합니다.");
                    doProgram("c:\\Windows\\system32\\mspaint.exe", "");
                    break;

                case "Painter":
                    m_tts.SpeakAsync("Run the painter");
                    doProgram("c:\\Windows\\system32\\mspaint.exe", "");
                    break;

                case "계산기 닫기":
                    m_tts.SpeakAsync("계산기를 종료합니다.");
                    closeProcess("calc");
                    break;

                case "Close Calculator":
                    m_tts.SpeakAsync("Shut down the calculator");
                    closeProcess("calc");
                    break;
            }
        }

        private void InitTTS()
        {
            try
            {
                m_tts = new SpeechSynthesizer();
                //tts.SelectVoice("Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)");
                m_tts.SelectVoice(m_voice);
                m_tts.SetOutputToDefaultAudioDevice();
                m_tts.Volume = 100;

                m_tts.SpeakAsync("Hi, my name is Heami.");
            }
            catch (Exception ex)
            {
                lblResult.Content = $"init TTS Error: {ex.ToString()}";
            }
        }

        private void doProgram(string fileName, string arg)
        {
            ProcessStartInfo psi;
            if (arg.Length != 0)
            {
                psi = new ProcessStartInfo(fileName, arg);
            }
            else
            {
                psi = new ProcessStartInfo(fileName);
            }

            Process.Start(psi);
        }

        private void closeProcess(string fileName)
        {
            Process[] processes;
            processes = Process.GetProcessesByName(fileName);
            foreach (Process proc in processes)
            {
                proc.CloseMainWindow();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_speechRecognizer.Dispose();
        }
    }
}
