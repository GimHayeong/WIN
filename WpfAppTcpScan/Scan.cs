using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTcpScan
{
    /// <summary>
    /// 가짜 포트를 열어 해킹 시도 IP를 추적하는 클래스
    /// </summary>
    public class Scan
    {
        private TcpListener m_listener = null;
        private MainWindow m_wnd = null;
        int m_port;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wnd">프로그램 폼 객체 인스턴스</param>
        /// <param name="port">가짜 포트번호</param>
        public Scan(MainWindow wnd, int port)
        {
            m_wnd = wnd;
            m_port = port;
        }

        /// <summary>
        /// 특정 포트를 열어놓고 감시
        /// </summary>
        public void ScanPort()
        {
            try
            {
                m_listener = new TcpListener(IPAddress.Any, m_port);
                m_listener.Start();
                m_wnd.AddMsg($"{m_port} 서버 포트 실행!");
            }
            catch
            {
                m_wnd.AddMsg($"{m_port} 서버 포트 열기 실패!");
            }

            while (true)
            {
                Socket socket = m_listener.AcceptSocket();
                if (socket.Connected)
                {
                    m_wnd.AddMsg($"{m_port}포트에 {socket.RemoteEndPoint.ToString()}의 접속 시도!");
                }
            }
        }
    }
}
