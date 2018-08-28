using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppChatSocket
{
    /// <summary>
    /// 채팅을 처리하는 클래스 Ver1.0
    /// </summary>
    public class ChatNetwork
    {
        /// <summary>
        /// 채팅서버 포트번호
        /// </summary>
        protected const int SERVER_PORT = 7000;
        
        protected ChatWind m_wnd = null;
        protected ChatStreamWind m_wndStream = null;
        protected ChatHelperWind m_wndHelper = null;
        protected Socket m_server = null;
        protected Socket m_client = null;
        protected Thread m_thread = null;
        protected string m_clientIp = null;

        public ChatNetwork(ChatWind wnd)
        {
            m_wnd = wnd;
        }

        public ChatNetwork(ChatStreamWind wnd)
        {
            m_wndStream = wnd;
        }

        public ChatNetwork(ChatHelperWind wnd)
        {
            m_wndHelper = wnd;
        }

        /// <summary>
        /// 채팅서버 시작
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public virtual void StartServer()
        {
            try
            {
                InitServer();
                m_wnd.AddMsg("채팅서버 시작 ...");

                AcceptClient();
                m_wnd.AddMsg($"{m_clientIp} 접속 ...");

                m_thread = new Thread(new ThreadStart(Receive));
                m_thread.Start();
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 시작 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 채팅서버 초기화
        /// </summary>
        protected virtual void InitServer()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, SERVER_PORT);
            m_server = new Socket(AddressFamily.InterNetwork
                                , SocketType.Stream
                                , ProtocolType.Tcp);
            m_server.Bind(ipep);
            m_server.Listen(10);
        }

        protected virtual void AcceptClient()
        {
            m_client = m_server.Accept();
            IPEndPoint remoteEP = (IPEndPoint)m_client.RemoteEndPoint;
            m_clientIp = remoteEP.Address.ToString();
        }

        /// <summary>
        /// 채팅서버 중지
        /// </summary>
        /// <remarks>
        ///  1. 클라이언트가 접속된 상태면 클라이언트 접속 끊기
        ///  2. 채팅서버 소켓 닫기
        ///  3. 스레드가 실행중이면 스레드 종료
        /// </remarks>
        public virtual void StopServer()
        {
            try
            {
                CloseServer();
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 종료 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 클라이언트 접속 해제 및 스레드 종료
        /// </summary>
        protected virtual void CloseServer()
        {
            if (m_client != null && m_client.Connected)
            {
                m_client.Close();
            }

            m_server.Close();

            if (m_thread != null && m_thread.IsAlive)
            {
                m_thread.Abort();
            }
        }

        /// <summary>
        /// 해당 IP의 채팅서버에 접속
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        public virtual bool Connect(string serverIP)
        {
            try
            {
                ConnectByIP(serverIP);
                m_wnd.AddMsg($"{serverIP} 서버에 접속 성공 ...");
               
                m_thread = new Thread(new ThreadStart(Receive));
                m_thread.Start();

                return true;
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 연결 오류: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP"></param>
        protected virtual void ConnectByIP(string serverIP)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(serverIP), SERVER_PORT);
            m_client = new Socket(AddressFamily.InterNetwork
                                , SocketType.Stream
                                , ProtocolType.Tcp);
            m_client.Connect(ipep);
            m_clientIp = serverIP;
        }

        /// <summary>
        /// 채팅 서버와의 접속 해제
        /// </summary>
        public virtual void DisConnect()
        {
            try
            {
                if(m_client != null)
                {
                    if(m_client.Connected)
                    {
                        m_client.Close();
                    }

                    if (m_thread.IsAlive)
                    {
                        m_thread.Abort();
                    }
                }
                m_wnd.AddMsg("채팅서버 연결 종료");
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 연결종료 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 접속된 원격 서버 또는 클라이언트의 메시지 수신
        /// </summary>
        public virtual void Receive()
        {
            try
            {
                while(m_client != null && m_client.Connected)
                {
                    byte[] data = ReceiveData();
                    m_wnd.AddMsg($"[{m_clientIp}] {Encoding.Default.GetString(data)}");
                }
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"데이터 수신 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 접속된 원격 서버 또는 클라이언트로부터 수신한 바이트 데이터 반환
        /// </summary>
        /// <returns></returns>
        private byte[] ReceiveData()
        {
            int total = 0;
            int size = 0;
            int leftDataSize = 0;
            int receiveDataSize = 0;

            try
            {
                byte[] dataSize = new byte[4];
                receiveDataSize = m_client.Receive(dataSize
                                                 , 0
                                                 , 4
                                                 , SocketFlags.None);

                size = BitConverter.ToInt32(dataSize, 0);
                leftDataSize = size;

                byte[] data = new byte[size];
                while (total < size)
                {
                    receiveDataSize = m_client.Receive(data
                                                     , total
                                                     , leftDataSize
                                                     , SocketFlags.None);

                    total += receiveDataSize;
                    leftDataSize -= receiveDataSize;
                }

                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 접속된 원격 서버 또는 클라이언트로 메시지 송신
        /// </summary>
        /// <param name="msg"></param>
        public virtual void Send(string msg)
        {
            try
            {
                if (m_client.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(msg);
                    SendData(data);
                }
                else
                {
                    m_wnd.AddMsg("메시지 전송 실패");
                }
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"메시지 전송 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 접속된 원격 서버 또는 클라이언트로 바이트 데이터 송신
        /// </summary>
        /// <param name="data"></param>
        private void SendData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int leftDataSize = size;
                int sendDataSize = 0;

                byte[] dataSize = new byte[4];
                dataSize = BitConverter.GetBytes(size);
                sendDataSize = m_client.Send(dataSize);

                while(total < size)
                {
                    sendDataSize = m_client.Send(data
                                               , total
                                               , leftDataSize
                                               , SocketFlags.None);

                    total += sendDataSize;
                    leftDataSize -= sendDataSize;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 로컬 컴퓨터의 IP 조회
        /// </summary>
        /// <returns></returns>
        public string GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string ip = host.AddressList[0].ToString();

            return ip;
        }
    }
}
