using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTcpPort
{
    /// <summary>
    /// 활성화된 포트 번호를 검출하는 클래스
    /// </summary>
    public class Port
    {
        private Socket m_connect = null;
        private string m_servierIP = null;
        private frmTcpPort m_wnd = null;
        private int m_start, m_end;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP">접속할 서버 아이피 주소</param>
        /// <param name="wnd">프로그램 폼 객체 인스턴스</param>
        /// <param name="start">포트 검사 범위의 시작점 포트번호</param>
        /// <param name="end">포트 검사 범위의 끝점 포트번호</param>
        public Port(string serverIP, frmTcpPort wnd, int start, int end)
        {
            m_servierIP = serverIP;
            m_wnd = wnd;
            m_start = start;
            m_end = end;
        }

        /// <summary>
        /// 해당 서버의 시작 ~ 끝 포트번호 사이의 포트 연결상태를 체크한 후, 서버와의 연결 해제.
        /// </summary>
        public void Connect()
        {
            try
            {
                m_connect = new Socket(AddressFamily.InterNetwork
                                      , SocketType.Stream
                                      , ProtocolType.Tcp);

                m_wnd.AddMsg($"{m_start} ~ {m_end} : 포트 검사 시작!");

                for(int i=m_start; i<m_end; i++)
                {
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(m_servierIP), i);

                    try
                    {
                        m_connect.Connect(remoteEP);
                        m_wnd.AddPortInfo($"{i} 열려 있음!");
                    }
                    catch { }
                }
                m_wnd.AddMsg($"{m_start} ~ {m_end} : 포트 검사 완료!");
            }
            catch
            {
                m_wnd.AddMsg($"{m_start} ~ {m_end} : 포트 검사 오류 발생!");
            }
            finally
            {
                if (m_connect != null) m_connect.Close();
            }
        }
    }
}
