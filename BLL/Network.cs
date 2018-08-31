using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 채팅을 처리하는 클래스 Ver1.0
    /// </summary>
    public class Network
    {
        /// <summary>
        /// 채팅서버 포트번호
        /// </summary>
        protected const int SERVER_PORT = 7000;
        
        protected Socket ChatServer = null;
        protected Socket ChatClient = null;
        protected Thread ChatThread = null;
        protected string ChatClientIP = null;

        

        /// <summary>
        /// 채팅서버 초기화
        /// </summary>
        protected virtual void InitServer()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, SERVER_PORT);
            ChatServer = new Socket(AddressFamily.InterNetwork
                                , SocketType.Stream
                                , ProtocolType.Tcp);
            ChatServer.Bind(ipep);
            ChatServer.Listen(10);
        }

        protected virtual void AcceptClient()
        {
            ChatClient = ChatServer.Accept();
            IPEndPoint remoteEP = (IPEndPoint)ChatClient.RemoteEndPoint;
            ChatClientIP = remoteEP.Address.ToString();
        }

        


        /// <summary>
        /// 클라이언트 접속 해제 및 스레드 종료
        /// </summary>
        protected virtual void CloseServer()
        {
            if (ChatClient != null && ChatClient.Connected)
            {
                ChatClient.Close();
            }

            ChatServer.Close();

            if (ChatThread != null && ChatThread.IsAlive)
            {
                ChatThread.Abort();
            }
        }


        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP"></param>
        protected virtual void ConnectByIP(string serverIP)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(serverIP), SERVER_PORT);
            ChatClient = new Socket(AddressFamily.InterNetwork
                                , SocketType.Stream
                                , ProtocolType.Tcp);
            ChatClient.Connect(ipep);
            ChatClientIP = serverIP;
        }

        

        

        /// <summary>
        /// 접속된 원격 서버 또는 클라이언트로부터 수신한 바이트 데이터 반환
        /// </summary>
        /// <returns></returns>
        protected byte[] ReceiveData()
        {
            int total = 0;
            int size = 0;
            int leftDataSize = 0;
            int receiveDataSize = 0;

            try
            {
                byte[] dataSize = new byte[4];
                receiveDataSize = ChatClient.Receive(dataSize
                                                 , 0
                                                 , 4
                                                 , SocketFlags.None);

                size = BitConverter.ToInt32(dataSize, 0);
                leftDataSize = size;

                byte[] data = new byte[size];
                while (total < size)
                {
                    receiveDataSize = ChatClient.Receive(data
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
        /// 접속된 원격 서버 또는 클라이언트로 바이트 데이터 송신
        /// </summary>
        /// <param name="data"></param>
        protected void SendData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int leftDataSize = size;
                int sendDataSize = 0;

                byte[] dataSize = new byte[4];
                dataSize = BitConverter.GetBytes(size);
                sendDataSize = ChatClient.Send(dataSize);

                while(total < size)
                {
                    sendDataSize = ChatClient.Send(data
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
