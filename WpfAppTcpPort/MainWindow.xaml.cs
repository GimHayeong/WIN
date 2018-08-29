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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTcpPort
{
    /// <summary>
    /// 네트워크에 연결된 특정 컴퓨터의 포터가 열려 있는지 검사하는 프로그램
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void SetTextCallback(string msg);

        private Port[] m_portArray = new Port[256];
        private Thread[] m_threadArray = new Thread[256];

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 프로그램이 종료될 때, 모든 스레드 중지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            for (int i = 0; i < m_threadArray.Length; i++)
            {
                try
                {
                    if (m_threadArray[i].IsAlive)
                    {
                        m_threadArray[i].Abort();
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 현재 포트검사중이 아니면, 해당 IP의 서버 포트검사 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxIP.Text))
            {
                MessageBox.Show("포트검사를 수행할 서버 IP를 입력해주세요.", "포트검사안내", MessageBoxButton.OK, MessageBoxImage.Information);
                tbxIP.SelectAll();
                //tbxIP.Focus();
                return;
            }

            if (m_threadArray[255] != null && m_threadArray[255].IsAlive)
            {
                MessageBox.Show("현재 포트번호 검사중입니다. 잠시만 기다려주십시오."
                                  , "포트검사안내"
                                  , MessageBoxButton.OK
                                  , MessageBoxImage.Error);
                return;
            }

            string serverIP = tbxIP.Text.Trim();

            CheckPort(serverIP);
        }

        /// <summary>
        /// 해당 서버의 포트번호를 256개씩 나눠 각 스레드에서 연결상태 체크
        /// </summary>
        /// <param name="serverIP">포트검사 대상 서버IP</param>
        private void CheckPort(string serverIP)
        {
            for (int i = 0; i < m_portArray.Length; i++)
            {
                m_portArray[i] = new Port(serverIP, this, i * 256, (i * 256 + 255));
                m_threadArray[i] = new Thread(new ThreadStart(m_portArray[i].Connect));
                m_threadArray[i].IsBackground = true;
                m_threadArray[i].Start();
            }
        }

        /// <summary>
        /// 연결(활성화)된 포트번호가 있으면 추가
        /// </summary>
        /// <param name="msg"></param>
        public void AddPortInfo(string msg)
        {
            try
            {
                if (tbxEnablePort.Dispatcher.CheckAccess())
                {
                    tbxEnablePort.AppendText($"\r\n **{msg}");
                    //tbxEnablePort.ScrollToEnd();
                }
                else
                {
                    SetTextCallback dgt = new SetTextCallback(AddPortInfo);
                    tbxEnablePort.Dispatcher.Invoke(dgt, new object[] { msg });
                }
            }
            catch { }
        }

        private void AddPortInfoByMonitor(string msg)
        {
            //bool lockTaken = false;
            //try
            //{
            //    Monitor.Enter(tbxEnablePort, ref lockTaken);
            //    tbxEnablePort.AppendText($"\r\n **{msg}");
            //}
            //catch { }
            //finally
            //{
            //    if (lockTaken) Monitor.Exit(tbxEnablePort);
            //}
        }

        private void AddPortInfoByLock(string msg)
        {
            //lock (tbxEnablePort)
            //{
            //    tbxEnablePort.AppendText($"\r\n **{msg}");
            //}
        }

        /// <summary>
        /// 포트검사 진행상황정보 추가
        /// </summary>
        /// <param name="msg">진행상황메시지</param>
        public void AddMsg(string msg)
        {
            try
            {
                if (tbxInfo.Dispatcher.CheckAccess())
                {
                    tbxInfo.AppendText($"\r\n **{msg}");
                    //tbxInfo.ScrollToEnd();
                }
                else
                {
                    SetTextCallback dgt = new SetTextCallback(AddMsg);
                    tbxInfo.Dispatcher.Invoke(dgt, new object[] { msg });
                }
            }
            catch { }
        }

        private void AddMsgByMonitor(string msg)
        {
            //bool lockTaken = false;
            //try
            //{
            //    Monitor.Enter(tbxInfo, ref lockTaken);
            //    tbxInfo.AppendText($"\r\n **{msg}");
            //}
            //catch { }
            //finally
            //{
            //    if (lockTaken) Monitor.Exit(tbxInfo);
            //}
        }

        private void AddMsgByLock(string msg)
        {
            //lock (tbxInfo)
            //{
            //    tbxInfo.AppendText($"\r\n **{msg}");
            //}
        }



    }

    
}
