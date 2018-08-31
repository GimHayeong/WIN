using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppChat
{
    /// <summary>
    /// 이모티콘 채팅 프로그램 Ver 1.0
    /// </summary>
    public partial class ChatWind : Window
    {
        delegate void SetRichTextBoxCallback(string msg);

        private const string START_TEXT = "서버 시작";
        private const string STOP_TEXT = "서버 멈춤";
        private const string CONNECTING_TEXT = "접속중...";
        private const string CANCONNECT_TEXT = "서버 연결";

        /// <summary>
        /// [메시지전송신호] 메시지 전송 알림신호
        /// </summary>
        private const string CTOC_CHAT_MESSAGE_INFO = "CTOC_CHAT_MESSAGE_INFO";
        /// <summary>
        /// [메시지전송신호] 새로운 메시지 입력시작 알림신호
        /// </summary>
        private const string CTOC_CHAT_NEWTEXT_INFO = "CTOC_CHAT_NEWTEXT_INFO";


        private ChatNetwork m_net = null;
        /// <summary>
        /// 채팅서버 스레드
        /// </summary>
        private Thread m_thread = null;
        private string m_clientIP = null;

        private bool IsConnected
        {
            get
            {
                return (btnConnect.Content.Equals(CONNECTING_TEXT));
            }
        }

        private bool IsStarted
        {
            get
            {
                return (btnStart.Content.Equals(STOP_TEXT));
            }
        }

        private Font m_chatFont;
        private System.Drawing.Color m_chatColor;
        /// <summary>
        /// 메시지 입력중인지 여부
        /// </summary>
        private bool IsInputMsg = false;

        public ChatWind()
        {
            InitializeComponent();

            InitChat();
        }

        private void InitChat()
        {
            m_net = new ChatNetwork(this);
            m_clientIP = m_net.GetLocalIP();
            
            m_chatFont = new Font("굴림체", 10);
            m_chatColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// 프로그램 종료
        /// </summary>
        /// <remarks>
        ///   1. 채팅서버에 접속중이면 채팅서버와의 연결 해제
        ///   2. 채팅서버 종료
        ///   3. 채팅스레드 종료
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (IsConnected)
                {
                    m_net.DisConnect();
                }

                m_net.StopServer();

                if (m_thread != null && m_thread.IsAlive) m_thread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 서버 시작/종료 버튼
        /// </summary>
        /// <remarks>
        ///  1. 채팅서버가 운행중이면
        ///     채팅서버를 종료하고, 채팅스레드 종료 후, 채팅서버를 재가동할 수 있게 버튼텍스트를 변경한다.
        ///  2. 채팅서버가 운행중이 아니면
        ///     채팅스레드를 생성하고 채팅서버를 가동시킨 후, 채팅서버를 중지할 수 있게 버튼텍스트를 변경한다.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsStarted)
                {
                    m_net.StopServer();

                    if (m_thread != null && m_thread.IsAlive) m_thread.Abort();

                    btnStart.Content = START_TEXT;
                }
                else
                {
                    m_thread = new Thread(new ThreadStart(m_net.StartServer));
                    m_thread.IsBackground = true;
                    m_thread.Start();

                    btnStart.Content = STOP_TEXT;
                }
            }
            catch (Exception ex)
            {
                AddMsg(ex.Message);
            }
        }

        /// <summary>
        /// 서버 연결 버튼
        /// </summary>
        /// <remarks>
        ///   1. 채팅서버에 접속중이면
        ///      채팅서버 연결 해제후, 재연결할 수 있게 버튼텍스트를 변경한다.
        ///   2. 채팅서버에 접속중이 아니면
        ///      채팅서버 아이피 입력 유효성을 검사하고, 해당 아이피로 접속을 시도해 연결에 성공하면 연결을 해제할 수 있게 버튼텍스트를 변경한다.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsConnected)
            {
                m_net.DisConnect();

                btnConnect.Content = CANCONNECT_TEXT;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(tbxIP.Text))
                {
                    MessageBox.Show("아이피 번호를 입력하세요!");
                    tbxIP.Focus();
                    tbxIP.SelectAll();
                    return;
                }

                if (m_net.Connect(tbxIP.Text.Trim()))
                {
                    btnConnect.Content = CONNECTING_TEXT;
                }
                else
                {
                    MessageBox.Show("서버 IP가 틀리거나\r\n서버가 작동중이지 않습니다.");
                }

            }
        }

        private void IPTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnConnect.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        /// <summary>
        /// 폰트 선택 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FontDialog();
            dlg.ShowColor = true;
            dlg.Font = m_chatFont;
            dlg.Color = m_chatColor;

            var result = dlg.ShowDialog();

            if(result == System.Windows.Forms.DialogResult.OK)
            {
                rtbxInput.FontFamily = new System.Windows.Media.FontFamily(dlg.Font.FontFamily.Name);
                rtbxInput.FontSize = dlg.Font.Size;
                if (dlg.Font.Bold) rtbxInput.FontWeight = FontWeights.Bold;
                rtbxInput.Selection.Select(rtbxInput.Document.ContentStart, rtbxInput.Document.ContentEnd);
                if (dlg.Font.Underline) rtbxInput.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                if (dlg.Font.Italic) rtbxInput.FontStyle = FontStyles.Italic; 
                rtbxInput.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));

                m_chatFont = dlg.Font;
                m_chatColor = dlg.Color;
            }
        }

        /// <summary>
        /// 이모티콘 선택 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmoticonButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// 메시지 입력박스 키입력
        /// </summary>
        /// <remarks>
        ///   1. 엔터키를 누르면, 
        ///      입력된 메시지를 전송하고 새로운 메시지입력을 위한 초기화
        ///   2. 엔터키외의 키를 누르면,
        ///      새로운 입력이면 최초 1회 새로운 메시지 입력 신호 전송
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputRichTexBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextRange txtRange = new TextRange(rtbxInput.Document.ContentStart, rtbxInput.Document.ContentEnd);

                m_net.Send($"{CTOC_CHAT_MESSAGE_INFO}\a{txtRange.Text}");
                AddMsg($"[{m_clientIP}] 님의 말");
                AddRichData(txtRange.Text);

                IsInputMsg = false;
                txtRange.Text = String.Empty;
                rtbxInput.Focus();

                e.Handled = true;
            }
            else
            {
                if (IsInputMsg == false)
                {
                    m_net.Send($"{CTOC_CHAT_NEWTEXT_INFO}\a");
                    IsInputMsg = true;
                }
            }
        }

        /// <summary>
        /// 스타일이 적용된 메시지 추가
        /// </summary>
        /// <param name="msg"></param>
        public void AddRichData(string msg)
        {
            if (rtbxInfo.Dispatcher.CheckAccess())
            {
                SetParagraph(rtbxInfo.Document
                           , msg
                           , rtbxInput.FontFamily
                           , rtbxInput.FontSize
                           , rtbxInput.Foreground
                           , rtbxInput.FontWeight
                           , rtbxInput.FontStyle);
            }
            else
            {
                SetRichTextBoxCallback dgt = new SetRichTextBoxCallback(AddRichData);
                rtbxInfo.Dispatcher.Invoke(dgt, new object[] { msg });
            }
        }

        /// <summary>
        /// 입력 메시지가 아닌 일반 정보는 표준 글꼴로 표시
        /// </summary>
        /// <param name="msg"></param>
        public void AddMsg(string msg)
        {
            if (rtbxInfo.Dispatcher.CheckAccess())
            {
                SetParagraph(rtbxInfo.Document, msg);

                rtbxInfo.ScrollToEnd();
                rtbxInput.Focus();
            }
            else
            {
                SetRichTextBoxCallback dgt = new SetRichTextBoxCallback(AddMsg);
                rtbxInfo.Dispatcher.Invoke(dgt, new object[] { msg });
            }
        }

        private void SetParagraph(FlowDocument doc, string msg)
        {
            SetParagraph(doc
                       , msg
                       , new System.Windows.Media.FontFamily("굴림체")
                       , 10
                       , System.Windows.Media.Brushes.Black
                       , FontWeights.Normal
                       , FontStyles.Normal);
        }

        /// <summary>
        /// 스타일이 적용된 문자열 Paragraph 추가
        /// </summary>
        /// <param name="msg">문자열 내용</param>
        /// <param name="fontName">글꼴이름</param>
        /// <param name="fontSize">글씨크기</param>
        /// <param name="foreground">글씨색상</param>
        /// <param name="fontWeight">강조스타일</param>
        /// <param name="fontStyle">기울임스타일</param>
        /// <returns></returns>
        private void SetParagraph(FlowDocument doc, string msg, System.Windows.Media.FontFamily fontFamily, double fontSize, System.Windows.Media.Brush foreground, FontWeight fontWeight, System.Windows.FontStyle fontStyle)
        {
            Paragraph pgp = new Paragraph();
            pgp.FontSize = fontSize;
            pgp.Foreground = foreground;
            pgp.FontFamily = fontFamily;
            pgp.FontWeight = fontWeight;
            pgp.FontStyle = fontStyle;
            pgp.Inlines.Add(new Run(msg));

            doc.Blocks.Add(pgp);
        }

        public void AddStatus(string msg)
        {
            if (sbarStatus.Dispatcher.CheckAccess())
            {
                tbkCurrentStatus.Text = msg;
            }
            else
            {
                SetRichTextBoxCallback dgt = new SetRichTextBoxCallback(AddStatus);
                sbarStatus.Dispatcher.Invoke(dgt, new object[] { msg });
            }
        }

    }
}
