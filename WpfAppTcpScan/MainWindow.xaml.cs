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

namespace WpfAppTcpScan
{
    /// <summary>
    /// 해킹시도 감지 프로그램
    /// </summary>
    /// <remarks>
    ///  사용하지 않는 가짜포트를 만들어 해당 포트로 접속을 시도하는 컴퓨터에 대해 해킹을 의심하고 접속시도 아이피주소와 접속시간, 접속경로에 대한 로그를 남겨 추후 발생가능 문제에 대응.
    ///  (단, 해킹의도 없이 잘못된 접근이나 예기치 못한 오류 대처방안 마련 필요. 추가의 가짜포트와 특정 포트접속회수 체크하는 방법도 가능.)
    /// </remarks>
    public partial class MainWindow : Window
    {
        delegate void SetTextCallback(string msg);

        private int[] m_fakePortArray = { 1, 2, 3, 7777, 65380 };
        private Thread[] m_threadArray;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            m_threadArray = new Thread[m_fakePortArray.Length];

            for(int i=0; i<m_fakePortArray.Length; i++)
            {
                Scan scan = new Scan(this, m_fakePortArray[i]);
                m_threadArray[i] = new Thread(new ThreadStart(scan.ScanPort));
                m_threadArray[i].Name = i.ToString();
                m_threadArray[i].IsBackground = true;
                m_threadArray[i].Start();
            }
            btnStart.IsEnabled = false;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!btnStart.IsEnabled)
            {
                for(int i=0; i<m_fakePortArray.Length; i++)
                {
                    try
                    {
                        if (m_threadArray[i].IsAlive) m_threadArray[i].Abort();
                    }
                    catch { }
                }
            }

            this.Close();
        }

        public void AddMsg(string msg)
        {
            try
            {
                if (tbxInfo.Dispatcher.CheckAccess())
                {
                    tbxInfo.AppendText($"\r\n{msg}");
                }
                else
                {
                    SetTextCallback dgt = new SetTextCallback(AddMsg);
                    tbxInfo.Dispatcher.Invoke(dgt, new object[] { msg });
                }
            }
            catch { }
        }
    }
}
