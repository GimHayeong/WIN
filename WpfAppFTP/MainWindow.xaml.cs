using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppFTP
{
    /// <summary>
    /// 파일 전송 프로그램 Ver 1.0
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void SetTextCallback(string msg);
        delegate void InitProgressBarCallback();
        delegate void SetProgressBarCallback(double index, long totalSize);

        private const string START_TEXT = "서버 시작";
        private const string STOP_TEXT = "서버 멈춤";
        private const string CONNECTING_TEXT = "접속중...";
        private const string CANCONNECT_TEXT = "서버 연결";

        /// <summary>
        /// [파일전송메시지] 전송할 파일정보
        /// </summary>
        private const string CTOC_FILE_TRANS_INFO = "CTOC_FILE_TRANS_INFO";
 
        private FileTransfer m_ftp = null;
        /// <summary>
        /// FTP 서버 시작 스레드
        /// </summary>
        private Thread m_thread = null;

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

        public MainWindow()
        {
            InitializeComponent();

            InitFTP();
        }

        private void InitFTP()
        {
            m_ftp = new FileTransfer(this);
        }

        /// <summary>
        /// 프로그램 종료시 FTP 연결 해제, FTP 서버 작동중지, 스레드 중지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (IsConnected)
                {
                    m_ftp.Disconnect();
                }

                m_ftp.StopFTPServer();

                if (m_thread != null && m_thread.IsAlive) m_thread.Abort();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// FTP 서버 시작 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsStarted)
                {
                    m_ftp.StopFTPServer();
                    if (m_thread.IsAlive) m_thread.Abort();

                    btnStart.Content = START_TEXT;
                }
                else
                {
                    m_thread = new Thread(new ThreadStart(m_ftp.StartFTPServer));
                    m_thread.IsBackground = true;
                    m_thread.Start();

                    btnStart.Content = STOP_TEXT;
                }
            }
            catch(Exception ex)
            {
                AddMsg(ex.Message);
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
        /// 서버에 연결된 경우 연결해제하고, 아니면 서버에 연결시도
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsConnected)
            {
                m_ftp.Disconnect();
                btnConnect.Content = CANCONNECT_TEXT;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(tbxIP.Text))
                {
                    MessageBox.Show("연결할 서버 IP를 입력하세요.");
                    tbxIP.Focus();
                    tbxIP.SelectAll();
                    return;
                }

                if (m_ftp.Connect(tbxIP.Text.Trim()))
                {
                    btnConnect.Content = CONNECTING_TEXT;
                }
                else
                {
                    MessageBox.Show("서버 IP 주소가 틀리거나 \r\n서버가 작동중이지 않습니다.");
                    tbxIP.Focus();
                    tbxIP.SelectAll();
                    return;
                }
            }
        }

        /// <summary>
        /// 전송할 파일 선택 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "전송할 파일을 선택하세요!";

            bool? result = dlg.ShowDialog();

            if(result == true)
            {
                FileInfo file = new FileInfo(dlg.FileName);
                string msg = $"{CTOC_FILE_TRANS_INFO}\a{file.Name}\a{file.Length.ToString()}";
                m_ftp.Send(msg);
                m_ftp.ReceiveFileInfo = file;
            }
        }

        /// <summary>
        /// 상태메시지 출력
        /// </summary>
        /// <param name="msg"></param>
        public void AddMsg(string msg)
        {
            try
            {
                if (tbxInfo.Dispatcher.CheckAccess())
                {
                    tbxInfo.AppendText($"{msg}\r\n");
                    tbxInfo.ScrollToEnd();
                }
                else
                {
                    SetTextCallback dgt = new SetTextCallback(AddMsg);
                    tbxInfo.Dispatcher.Invoke(dgt, new object[] { msg });
                }
            }
            catch { }
        }

        /// <summary>
        /// 진행상태바 초기화
        /// </summary>
        public void InitProgressBar()
        {
            try
            {
                if (pgbTrans.Dispatcher.CheckAccess())
                {
                    pgbTrans.Minimum = 0;
                    pgbTrans.Maximum = 100;
                }
                else
                {
                    InitProgressBarCallback dgt = new InitProgressBarCallback(InitProgressBar);
                    pgbTrans.Dispatcher.Invoke(dgt);
                }
            }
            catch { }
        }

        /// <summary>
        /// 진행상태값 반영
        /// </summary>
        /// <param name="index"></param>
        /// <param name="totalSize"></param>
        public void SetProgressBar(double index, long totalSize)
        {
            try
            {
                if (pgbTrans.Dispatcher.CheckAccess())
                {
                    pgbTrans.Value = (int)(index * 100 / totalSize);
                }
                else
                {
                    SetProgressBarCallback dgt = new SetProgressBarCallback(SetProgressBar);
                    pgbTrans.Dispatcher.Invoke(dgt, new object[] { index, totalSize });
                }
            }
            catch { }
        }
    }
}
