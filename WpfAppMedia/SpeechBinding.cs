using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Threading;

namespace WpfAppMedia
{
    public class SpeechBinding : InputBinding
    {
        protected static readonly SpeechRecognitionEngine m_recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));
        private static bool recognizerStarted = false;
        private static readonly Dispatcher mainThreadDispatcher = Dispatcher.CurrentDispatcher;

        static SpeechBinding()
        {
            m_recognizer.RecognizerUpdateReached += reconizer_RecognizerUpdateReached;
        }

        private static void reconizer_RecognizerUpdateReached(object sender, RecognizerUpdateReachedEventArgs e)
        {
            var grammar = e.UserToken as Grammar;
            m_recognizer.LoadGrammar(grammar);
            Debug.WriteLine("Loaded: " + grammar.Name);

            StartRecognizer();
        }

        private static void StartRecognizer()
        {
            if(recognizerStarted == false)
            {
                try
                {
                    m_recognizer.SetInputToDefaultAudioDevice();
                }
                catch(Exception ex)
                {
                    return;
                }

                m_recognizer.RecognizeAsync(RecognizeMode.Multiple);
                recognizerStarted = true;
            }
        }

        //[TypeConverterAttribute(typeof(SpeechGestureConverter))]
        public override InputGesture Gesture
        {
            get
            {
                return base.Gesture;
            }

            set
            {
                base.Gesture = value;
                LoadGrammar();
            }
        }

        protected virtual void LoadGrammar()
        {
            var gesture = Gesture.ToString();
            var grammarBuilder = new GrammarBuilder(gesture);
            grammarBuilder.Culture = m_recognizer.RecognizerInfo.Culture;
            var grammar = new Grammar(grammarBuilder) { Name = gesture };
            grammar.SpeechRecognized += grammar_SpeechRecognizer;
            Debug.WriteLine("Loading: " + gesture);

            m_recognizer.RequestRecognizerUpdate(grammar);
        }

        protected void grammar_SpeechRecognizer(object sender, SpeechRecognizedEventArgs e)
        {
            mainThreadDispatcher.Invoke(new Action(() =>
            {
                OnSpeechRecognized(sender, e);
            }), DispatcherPriority.Input);
        }

        protected virtual void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if(Command != null)
            {
                Command.Execute(e.Result.Text);
            }
        }
    }
}
