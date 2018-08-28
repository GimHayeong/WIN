using System;
using System.Collections.Generic;
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

namespace WpfAppChatSocket
{
    /// <summary>
    /// ChatStreamWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChatStreamWind : Window
    {
        private const string READY_CONNECT = "연결";
        private const string CONNECT_TEXT = "접속중 ...";

        private ChatNetworkStream m_net = null;
        private Thread m_thread = null;
        private string m_localIP = null;

        delegate void SetTextCallback(string msg);
        public string ConnectButtonText
        {
            get
            {
                return (string)btnConnect.Content;
            }
        }

        public ChatStreamWind()
        {
            InitializeComponent();

            InitChat();
        }

        private void InitChat()
        {
            m_net = new ChatNetworkStream(this);
        }

        /// <summary>
        /// 채팅창이 출력되기 전
        /// </summary>
        /// <remarks>
        ///  1. 자신의 IP정보 조회
        ///  2. 채팅서버 스레드 시작
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_localIP = m_net.GetLocalIP();
            m_thread = new Thread(new ThreadStart(m_net.StartServer));
            m_thread.Start();
        }

        /// <summary>
        /// 윈도우 종료시
        /// </summary>
        /// <remarks>
        ///  1. 채팅서버 접속중이면, 접속해제
        ///  2. 채팅서버 종료
        ///  3. 스레드가 실행중이면 스레드종료
        ///  (4. 스레드가 참조하는 컨트롤 해제)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (ConnectButtonText == CONNECT_TEXT)
                {
                    m_net.DisConnect();
                }

                m_net.StopServer();

                if (m_thread.IsAlive)
                {
                    m_thread.Abort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 연결 버튼 클릭
        /// </summary>
        /// <remarks>
        ///  1. 채팅서버에 연결되지 않은 상태이면 입력IP 유효성체크 후, 채팅서버에 접속
        ///     (접속실패하면 에러메시지 출력하고, 성공하면 버튼 텍스트 '접속중...'으로 변경)
        ///  2. 채팅서버에 이미 연결된 상태이면 접속해제
        ///     (버튼 텍스트 '연결'로 변경)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Name == "btnConnect")
            {
                if (ConnectButtonText == READY_CONNECT)
                {
                    string ip = tbxIP.Text.Trim();
                    if (String.IsNullOrWhiteSpace(ip))
                    {
                        MessageBox.Show("IP 번호를 입력하세요!");
                        tbxIP.Clear();
                        tbxIP.Focus();
                        return;
                    }

                    if (!m_net.Connect(ip))
                    {
                        MessageBox.Show("서버 IP번호가 틀리거나 \r\n서버가 작동중이지 않습니다.");
                    }
                    else
                    {
                        btnConnect.Content = CONNECT_TEXT;
                    }

                }
                else
                {
                    //채팅서버와 연결 해제
                    m_net.DisConnect();
                    btn.Content = READY_CONNECT;
                }
            }
        }

        /// <summary>
        /// 작업표시 컨트롤에 메시지 출력
        /// </summary>
        /// <remarks>
        ///  1. 해당 스레드가 UI스레드이면 컨트롤에 메시지 출력
        ///  2. 해당 스레드가 UI스레드가 아니면 접근가능할 때까지 대기
        /// </remarks>
        /// <param name="msg"></param>
        public void AddMsg(string msg)
        {
            try
            {
                if (tbxInfo.Dispatcher.CheckAccess())
                {
                    tbxInfo.AppendText($"{msg}\r\n");
                    tbxInfo.ScrollToEnd();
                    tbxInfo.Focus();
                }
                else
                {
                    SetTextCallback dgt = new SetTextCallback(AddMsg);
                    tbxInfo.Dispatcher.Invoke(dgt, new object[] { msg });
                    //tbxInfo.Dispatcher.BeginInvoke(dgt, new object[] { msg });
                }
            }
            catch { }
        }

        /// <summary>
        /// 메시지를 입력하고 엔터키를 치면 상대방에게 메시지 전송
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddMsg($"[{m_localIP}] {tbxInput.Text.Trim()}");
                m_net.Send(tbxInput.Text.Trim());
                tbxInput.Clear();
                tbxInput.Focus();
            }
        }
    }
}
