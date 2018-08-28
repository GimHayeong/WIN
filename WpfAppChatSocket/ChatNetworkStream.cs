using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppChatSocket
{
    /// <summary>
    /// 채팅을 처리하는 클래스 Ver2.0
    /// </summary>
    public class ChatNetworkStream : ChatNetwork
    {
        protected NetworkStream m_stream = null;
        protected StreamReader m_reader = null;
        protected StreamWriter m_writer = null;


        public ChatNetworkStream(ChatStreamWind wnd) : base(wnd) { }

        public ChatNetworkStream(ChatHelperWind wnd) : base(wnd) { }

        /// <summary>
        /// 채팅서버 시작
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public override void StartServer()
        {
            try
            {
                base.InitServer();
                m_wndStream.AddMsg("채팅서버 시작 ...");

                base.AcceptClient();
                m_wndStream.AddMsg($"{m_clientIp} 접속 ...");

                InitStream();

                m_thread = new Thread(new ThreadStart(Receive));
                m_thread.Start();
            }
            catch(Exception ex)
            {
                m_wndStream.AddMsg($"채팅서버 시작 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// [Ver 2.0 추가] 스트림 초기화
        /// </summary>
        protected virtual void InitStream()
        {
            m_stream = new NetworkStream(m_client);
            m_reader = new StreamReader(m_stream);
            m_writer = new StreamWriter(m_stream);
        }

        /// <summary>
        /// 채팅서버 중지
        /// </summary>
        /// <remarks>
        ///  1. 클라이언트가 접속된 상태면 클라이언트 접속 끊기
        ///  2. 채팅서버 소켓 닫기
        ///  3. 스레드가 실행중이면 스레드 종료
        /// </remarks>
        public override void StopServer()
        {
            try
            {
                CloseStream();

                base.CloseServer();
            }
            catch(Exception ex)
            {
                m_wndStream.AddMsg($"채팅서버 종료 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// [Ver 2.0 추가] 스트림 해제
        /// </summary>
        private void CloseStream()
        {
            if (m_reader != null) m_reader.Close();
            if (m_writer != null) m_writer.Close();
            if (m_stream != null) m_stream.Close();
        }

        /// <summary>
        /// 해당 IP의 채팅서버에 접속
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        public override bool Connect(string serverIP)
        {
            try
            {
                base.ConnectByIP(serverIP);
                m_wndStream.AddMsg($"{serverIP} 서버에 접속 성공 ...");

                InitStream();

                m_thread = new Thread(new ThreadStart(Receive));
                m_thread.Start();

                return true;
            }
            catch(Exception ex)
            {
                m_wndStream.AddMsg($"채팅서버 연결 오류: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 채팅 서버와의 접속 해제
        /// </summary>
        public override void DisConnect()
        {
            try
            {
                if(m_client != null)
                {
                    if(m_client.Connected)
                    {
                        CloseStream();
                        m_client.Close();
                    }

                    if (m_thread.IsAlive)
                    {
                        m_thread.Abort();
                    }
                }
                m_wndStream.AddMsg("채팅서버 연결 종료");
            }
            catch(Exception ex)
            {
                m_wndStream.AddMsg($"채팅서버 연결종료 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// [Ver 2.0 수정] 접속된 원격 서버 또는 클라이언트의 메시지 수신
        /// </summary>
        public override void Receive()
        {
            try
            {
                while(m_client != null && m_client.Connected)
                {
                    string msg = m_reader.ReadLine();
                    m_wndStream.AddMsg($"[{m_clientIp}] {msg}");
                }
            }
            catch(Exception ex)
            {
                m_wndStream.AddMsg($"데이터 수신 오류: {ex.Message}");
            }
        }

        

        /// <summary>
        /// [Ver 2.0 수정] 접속된 원격 서버 또는 클라이언트로 메시지 송신
        /// </summary>
        /// <param name="msg"></param>
        public override void Send(string msg)
        {
            try
            {
                if (m_client.Connected)
                {
                    m_writer.WriteLine(msg);
                    m_writer.Flush();
                }
                else
                {
                    m_wndStream.AddMsg("메시지 전송 실패");
                }
            }
            catch(Exception ex)
            {
                m_wndStream.AddMsg($"메시지 전송 오류: {ex.Message}");
            }
        }
    }
}
