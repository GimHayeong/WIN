using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
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
    /// SpeechWnd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SpeechWnd : Window
    {
        private const string VOICE_ZIRA = "Microsoft Zira Desktop";
        private const string VOICE_HEAMI = "Microsoft Heami Desktop";
        SpeechSynthesizer m_synthesizer;
        SpeechRecognitionEngine m_speechRecognizer;

        public SpeechWnd()
        {
            InitializeComponent();

            InitSpeech();
            InitVoice();
        }

        private void InitSpeech()
        {
            if (m_synthesizer == null) { m_synthesizer = new SpeechSynthesizer(); }
            m_synthesizer.SetOutputToDefaultAudioDevice();

            Speech("I love WPF");
        }

        private void InitVoice()
        {
            ComboBoxItem item;
            foreach (InstalledVoice voice in m_synthesizer.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                //ComboBoxItem item = new ComboBoxItem();
                //item.Content = info.Description;
                //item.Tag = info.Name;
                item = new ComboBoxItem();
                item.Content = info.Name;
                item.Tag = info;
                cbxVoice.Items.Add(item);
            }
            cbxVoice.SelectedIndex = 0;
        }

        private void Speech(string msg)
        {
            m_synthesizer.SelectVoice(GetSelectedVoice());
            //m_synthesizer.SelectVoice(VOICE_ZIRA);//음성 변경
            m_synthesizer.Speak(msg);
        }

        private void SpeechAsync(string msg)
        {
            m_synthesizer.SpeakAsyncCancelAll();

            m_synthesizer.SelectVoice(GetSelectedVoice());
            //m_synthesizer.SelectVoice(VOICE_HEAMI);//음성 변경
            //m_synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);//성별과 연령대 선택
            m_synthesizer.SpeakAsync(msg);
        }

        private void SpeechAsync(PromptBuilder promptBuilder)
        {
            m_synthesizer.Speak(promptBuilder);
        }

        private void SpeakButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxMsg.Text)) return;

            SpeechAsync(tbxMsg.Text.Trim());
        }

        private void WPFButton_Click(object sender, RoutedEventArgs e)
        {
            m_synthesizer.SpeakAsyncCancelAll();
            //m_synthesizer.SetOutputToWaveFile("Sound/click.wav");//wav 파일을 통해 음성 출력
            //m_synthesizer.SpeakAsync(new FilePrompt("Sound/click.wav", SynthesisMediaType.WaveAudio));
            m_synthesizer.SpeakCompleted += SpeeachCompleted;
            m_synthesizer.SpeakAsync("");
        }

        private void SpeeachCompleted(object sender, SpeakCompletedEventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer("Sound/hover.wav");
            soundPlayer.Play();
            m_synthesizer.SpeakCompleted -= SpeeachCompleted;
        }

        /// <summary>
        /// 프롬프트빌더 : 복잡한 음성 입력 데이터를 프로그램적으로 처리하도록 도와주는 클래스
        ///  + StartVoice() 로 시작해서 EndVoice로 끝나야 한다.
        /// </summary>
        /// <remarks>
        ///  Hemi 음성이 기본값
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PromptButton_Click(object sender, RoutedEventArgs e)
        {
            PromptBuilder promptBuilder = new PromptBuilder();

            //promptBuilder.AppendAudio("Sound/click.wav");

            promptBuilder.AppendTextWithHint("WPF", SayAs.SpellOut);//발음을 더 정확하게 한 글자씩
            promptBuilder.AppendText("sounds better than WPF.");

            promptBuilder.AppendBreak(new TimeSpan(0, 0, 2));

            promptBuilder.AppendText("The time is");
            promptBuilder.AppendTextWithHint(DateTime.Now.ToString("hh:mm"), SayAs.Time);//시간을 자연스럽게

            promptBuilder.AppendBreak(new TimeSpan(0, 0, 2));

            promptBuilder.AppendText("Hey Zira, can you spell queue?");

            promptBuilder.StartVoice(VOICE_ZIRA);//음성설정
            promptBuilder.AppendTextWithHint("queue", SayAs.SpellOut);//발음을 더 정확하게 한 글자씩
            promptBuilder.EndVoice();//음성종료

            promptBuilder.AppendText("Do it faster!");

            promptBuilder.StartVoice(VOICE_ZIRA);//음성설정
            promptBuilder.StartStyle(new PromptStyle(PromptRate.ExtraFast));//속도를 빠르게
            promptBuilder.AppendTextWithHint("queue", SayAs.SpellOut);//발음을 더 정확하게 한 글자씩
            promptBuilder.EndStyle();
            promptBuilder.EndVoice();//음성종료

            tbxResult.AppendText(promptBuilder.ToXml());//ToXml() : 프롬프트빌더의 컨텐트를 SSML로 전환

            SpeechAsync(promptBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///  Zira 음성이 기본값
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSMLButton_Click(object sender, RoutedEventArgs e)
        {
            m_synthesizer.SpeakAsync(new FilePrompt("content/content.ssml", SynthesisMediaType.Ssml));
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            m_synthesizer.SpeakAsyncCancelAll();
            m_synthesizer.SelectVoice(VOICE_HEAMI);
            m_synthesizer.SpeakAsync(new FilePrompt("content/jindalrae.txt", SynthesisMediaType.Text));
            //string alltext = System.IO.File.ReadAllText("content/jindalrae.txt");
            //SpeechAsync(alltext);
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            m_synthesizer.SpeakAsync(tbxResult.Text);
            InitSpeechRecognition(new System.Globalization.CultureInfo("en-US"));
        }

        /// <summary>
        /// SpeechRecognizer는 SRGS에 기반한 입력규칙을 설정하여 
        /// 유효한 입력만을 설정한 입력규칙을 사용하여 음
        /// 성인식엔진이 입력규칙에 정의되지 않은 단어는 자동으로 무시하여 
        /// 인식의 정확성 향상
        /// </summary>
        private void InitSpeechRecognition()
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();

            // 입력규칙
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Culture = new System.Globalization.CultureInfo("en-US");
            grammarBuilder.Append(new Choices("two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace"));//해당 문자열 배열 중 하나
            grammarBuilder.Append("of", 0, 1);//of 가 0번 또는 1회 들어감
            grammarBuilder.Append(new Choices("clubs", "diamonds", "spades", "hearts"));//해당 문자열 배열 중 하나
            recognizer.LoadGrammar(new Grammar(grammarBuilder));

            recognizer.SpeechRecognized += recognizer_SpeechRecognized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">new System.Globalization.CultureInfo("eu-US")</param>
        private void InitSpeechRecognition(CultureInfo info)
        {
            m_speechRecognizer = new SpeechRecognitionEngine(info);

            // 입력규칙
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Culture = new System.Globalization.CultureInfo("en-US");
            grammarBuilder.Append(new Choices("two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace"));//해당 문자열 배열 중 하나
            //grammarBuilder.Append("of", 0, 1);//of 가 0번 또는 1회 들어감
            //grammarBuilder.Append(new Choices("clubs", "diamonds", "spades", "hearts"));//해당 문자열 배열 중 하나
            m_speechRecognizer.LoadGrammar(new Grammar(grammarBuilder));

            m_speechRecognizer.SpeechRecognized += recognizer_SpeechRecognized;
            m_speechRecognizer.SetInputToDefaultAudioDevice();
            m_speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
        }


        /// <summary>
        /// W3C의 음성인식 권고안인 SRGS를 정의한 xml 파일을 로딩해서 입력규칙 추가
        /// </summary>
        /// <param name="xmlFilename"></param>
        private void InitSpeechRecognition(string xmlFilename)
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();
            SrgsDocument doc = new SrgsDocument(xmlFilename);
            recognizer.LoadGrammar(new Grammar(doc));
        }

        /// <summary>
        /// W3C의 음성인식 권고안인 SRGS를 사용하여 해당 문자열만 인식할 수 있도록 메모리에서 생성해서 입력규칙 추가
        /// </summary>
        /// <param name="rules">new string[] { "stop", "go" }</param>
        private void InitSpeechRecognition(string[] rules)
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();

            SrgsDocument doc = new SrgsDocument();
            SrgsRule command = new SrgsRule("command", new SrgsOneOf(rules));
            doc.Rules.Add(command);
            doc.Root = command;

            recognizer.LoadGrammar(new Grammar(doc));
        }

        /// <summary>
        /// W3C의 음성인식 권고안인 SRGS를 사용하여 GrammarBuilder를 통해 해당 문자열만 인식할 수 있도록 메모리에서 생성해서 입력규칙 추가
        /// </summary>
        /// <param name="rules">new string[] { "stop", "go" }</param>
        private void InitSpeechRecognitionByGrammarBuilder(string[] rules)
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();

            GrammarBuilder builder = new GrammarBuilder(new Choices(rules));

            recognizer.LoadGrammar(new Grammar(builder));
        }

        /// <summary>
        /// W3C의 음성인식 권고안인 SRGS를 사용하여 문자열배열들과 전치사가 조합된 단어만을 인식할 수 있도록 메모리에서 생성해 입력규칙 추가
        /// </summary>
        /// <param name="rankArray">new string[] { "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace" }</param>
        /// <param name="preposition">"of"</param>
        /// <param name="suitArray">new string[] { "clubs", "diamonds", "spades", "hearts" }</param>
        private void InitSpeechRecognition(string[] rankArray, string preposition, string[] suitArray)
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();

            SrgsDocument doc = new SrgsDocument();
            SrgsRule command = new SrgsRule("command");
            SrgsRule rank = new SrgsRule("rank");
            SrgsItem of = new SrgsItem(preposition);
            SrgsRule suit = new SrgsRule("suit");
            SrgsItem card = new SrgsItem(new SrgsRuleRef(rank), of, new SrgsRuleRef(suit));
            command.Add(card);

            rank.Add(new SrgsOneOf(rankArray));
            of.SetRepeat(0, 1);
            suit.Add(new SrgsOneOf(suitArray));

            doc.Rules.Add(command, rank, suit);
            doc.Root = command;

            recognizer.LoadGrammar(new Grammar(doc));
        }

        /// <summary>
        /// W3C의 음성인식 권고안인 SRGS를 사용하여 GrammarBuilder를 통해 문자열배열들과 전치사가 조합된 단어만을 인식할 수 있도록 메모리에서 생성해 입력규칙 추가
        /// </summary>
        /// <param name="rankArray">new string[] { "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace" }</param>
        /// <param name="preposition">"of"</param>
        /// <param name="suitArray">new string[] { "clubs", "diamonds", "spades", "hearts" }</param>
        private void InitSpeechRecognitionByGrammarBuilder(string[] rankArray, string preposition, string[] suitArray)
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();

            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(new Choices(rankArray));//해당 문자열 배열 중 하나
            builder.Append(preposition, 0, 1);//해당 문자열이 0번 또는 1회 들어감
            builder.Append(new Choices(suitArray));//해당 문자열 배열 중 하나

            recognizer.LoadGrammar(new Grammar(builder));
        }

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            tbxResult.AppendText($"{e.Result.Text}\n");
        }

        private string GetSelectedVoice()
        {
            ComboBoxItem item = cbxVoice.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                return item.Content.ToString();
            }

            return VOICE_ZIRA;
        }

        #region GetSrgs

        /// <summary>
        /// XML 파일을 사용해 SRGS를 이용한 입력규칙 생성
        /// </summary>
        /// <param name="fileName">"grammar.xml"</param>
        /// <returns></returns>
        private SrgsDocument GetSrgs(string fileName)
        {
            SrgsDocument doc = new SrgsDocument(fileName);
            return doc;
        }

        /// <summary>
        /// 메모리에서 직접 SRGS를 이용한 입력규칙 생성
        /// </summary>
        /// <param name="rule">new SrgsRule("command", new SrgsOneOf("stop", "go"))</param>
        /// <returns></returns>
        private SrgsDocument GetSrgs(SrgsRule rule)
        {
            SrgsDocument doc = new SrgsDocument();
            doc.Rules.Add(rule);
            doc.Root = rule;

            return doc;
        }

        /// <summary>
        /// GrammarBuilder를 사용해 SRGS를 이용한 입력규칙 생성
        /// </summary>
        /// <param name="choices">new Choices("stop", "go")</param>
        /// <returns></returns>
        private GrammarBuilder GetSrgs(Choices choices)
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
            return grammarBuilder;
        }

        /// <summary>
        /// 메모리에서 직접 SRGS를 이용한 여러 입력규칙 생성
        /// </summary>
        /// <param name="ruleArray">
        /// SrgsRule command = new SrgsRule("command");
        /// SrgsRule rank = new SrgsRule("rank");
        /// SrgsItem of = new SrgsItem("of");
        /// SrgsRule suit = new SrgsRule("suit");
        /// SrgsItem card = new SrgsItem(new SrgsRuleRef(rank), of, new SrgsRuleRef(suit));
        /// command.Add(card);
        /// rank.Add(new SrgsOneOf("two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace"));
        /// of.SetRepeat(0, 1);
        /// suit.Add(new SrgsOneOf("clubs", "diamonds", "spades", "hearts"));
        /// </param>
        /// <returns></returns>
        private SrgsDocument GetSrgs(SrgsRule[] ruleArray)
        {
            SrgsDocument doc = new SrgsDocument();
            doc.Rules.Add(ruleArray);
            doc.Root = doc.Rules[0];

            return doc;
        }

        /// <summary>
        /// GrammarBuilder를 사용해 SRGS를 이용한 여러 입력규칙 생성
        /// </summary>
        /// <param name="choicesArray">
        /// new {
        ///     new Choices("two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace")
        ///     , new Choices("clubs", "diamonds", "spades", "hearts")
        /// }
        /// </param>
        /// <returns></returns>
        private GrammarBuilder GetSrgs(Choices[] choicesArray)
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(choicesArray[0]);
            grammarBuilder.Append("of", 0, 1);
            grammarBuilder.Append(choicesArray[1]);

            return grammarBuilder;
        }

        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(m_speechRecognizer != null)
            {
                m_speechRecognizer.Dispose();
            }
        }
    }
}
