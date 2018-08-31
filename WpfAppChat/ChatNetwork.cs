using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppChat
{
    /// <summary>
    /// 채팅 서버와 클라이언트 처리를 담당하는 클래스
    /// </summary>
    public class ChatNetwork : Network, INetwork
    {
        /// <summary>
        /// [메시지전송신호] 메시지 전송 알림신호
        /// </summary>
        private const string CTOC_CHAT_MESSAGE_INFO = "CTOC_CHAT_MESSAGE_INFO";
        /// <summary>
        /// [메시지전송신호] 새로운 메시지 입력시작 알림신호
        /// </summary>
        private const string CTOC_CHAT_NEWTEXT_INFO = "CTOC_CHAT_NEWTEXT_INFO";

        private ChatWind m_wnd = null;

        public ChatNetwork(ChatWind wnd)
        {
            m_wnd = wnd;
        }


        #region [ INetwork 인터페이스 구현 ]

        /// <summary>
        /// 채팅서버 시작
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public void StartServer()
        {
            try
            {
                base.InitServer();
                m_wnd.AddMsg("채팅서버 시작 ...");

                base.AcceptClient();
                m_wnd.AddMsg($"{ChatClientIP} 접속 ...");

                base.ChatThread = new Thread(new ThreadStart(Receive));
                base.ChatThread.Start();
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 시작 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 채팅서버 중지
        /// </summary>
        /// <remarks>
        ///  1. 클라이언트가 접속된 상태면 클라이언트 접속 끊기
        ///  2. 채팅서버 소켓 닫기
        ///  3. 스레드가 실행중이면 스레드 종료
        /// </remarks>
        public void StopServer()
        {
            try
            {
                base.CloseServer();
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 종료 오류: {ex.Message}");
            }
        }


        /// <summary>
        /// 해당 IP의 채팅서버에 접속
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        public bool Connect(string serverIP)
        {
            try
            {
                base.ConnectByIP(serverIP);
                m_wnd.AddMsg($"{serverIP} 서버에 접속 성공 ...");

                base.ChatThread = new Thread(new ThreadStart(Receive));
                base.ChatThread.Start();

                return true;
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 연결 오류: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 채팅 서버와의 접속 해제
        /// </summary>
        public void DisConnect()
        {
            try
            {
                if (base.ChatClient != null && base.ChatClient.Connected)
                {
                    base.ChatClient.Close();
                }

                if (base.ChatThread.IsAlive)
                {
                    base.ChatThread.Abort();
                }

                m_wnd.AddMsg("채팅서버 연결 종료");
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"채팅서버 연결종료 오류: {ex.Message}");
            }
        }

       /// <summary>
        /// 접속된 원격 서버 또는 클라이언트의 메시지 수신
        /// </summary>
        public void Receive()
        {
            try
            {
                while (base.ChatClient != null && base.ChatClient.Connected)
                {
                    byte[] data = base.ReceiveData();
                    //m_wnd.AddMsg($"[{ChatClientIP}] {Encoding.Default.GetString(data)}");
                    string msg = $"[{ChatClientIP}] {Encoding.Default.GetString(data)}";
                    string[] token = msg.Split('\a');
                    switch (token[0])
                    {
                        case "CTOC_CHAT_NEWTEXT_INFO":
                            m_wnd.AddStatus($"[{ChatClientIP}] 님이 메시지를 입력합니다!");
                            break;

                        case "CTOC_CHAT_MESSAGE_INFO":
                            int index = msg.IndexOf('\a');
                            msg = msg.Substring(index + 1, msg.Length - index - 1);
                            m_wnd.AddMsg($"[{ChatClientIP}] 님의 말");
                            m_wnd.AddRichData(msg);
                            m_wnd.AddStatus($"마지막 메시지: {DateTime.Now.ToString()}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"데이터 수신 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 접속된 원격 서버 또는 클라이언트로 메시지 송신
        /// </summary>
        /// <param name="msg"></param>
        public void Send(string msg)
        {
            try
            {
                if (base.ChatClient.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(msg);
                    base.SendData(data);
                }
                else
                {
                    m_wnd.AddMsg("메시지 전송 실패");
                }
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"메시지 전송 오류: {ex.Message}");
            }
        }

        #endregion

    }
}
