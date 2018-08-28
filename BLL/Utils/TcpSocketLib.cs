using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class TcpSocketLib
    {
        public void StartTcpServer(int serverPort)
        {
            Socket socketTcpServer = null;
            Socket socketTcpClient = null;

            byte[] data;
            // 1.
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, serverPort);
            try
            {
                // 2.
                socketTcpServer = new Socket(AddressFamily.InterNetwork
                                         , SocketType.Stream
                                         , ProtocolType.Tcp);

                // 3.
                socketTcpServer.Bind(ipep);

                // 4.
                socketTcpServer.Listen(20);

                Console.WriteLine("서버 시작.... 클라이언트 접속 대기중 ... ");

                // 5.
                socketTcpClient = socketTcpServer.Accept();

                // 6.
                data = ReceiveData(socketTcpClient);

                // 7.
                //socketTcpClient.Send(data);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 8. 소켓 통신이 종료되면 소켓 리소스 해제
                if (socketTcpClient != null) socketTcpClient.Close();
                if (socketTcpServer != null) socketTcpServer.Close();
            }
        }


        public void StartTcpClient(string serverIP, int serverPort, byte[] data)
        {
            Socket socketTcpServer = null;

            //byte[] data = null;

            IPAddress host = IPAddress.Parse(serverIP);

            // 1.
            IPEndPoint ipep = new IPEndPoint(host, serverPort);

            try
            {
                // 2.
                socketTcpServer = new Socket(AddressFamily.InterNetwork
                                        , SocketType.Stream
                                        , ProtocolType.Tcp);

                // 3.
                socketTcpServer.Connect(ipep);

                Console.WriteLine("서버에 접속 ...");

                // 4.
                SendData(socketTcpServer, data);

                // 5.
                //socketServer.Receive(data);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 6. 소켓 통신이 종료되면 소켓 리소스 해제
                socketTcpServer.Close();
            }
        }

        private void StartTcpClient(string serverUrl, int serverPort, string serverIP)
        {
            TcpListener server = new TcpListener(IPAddress.Parse(serverIP), serverPort);
            server.Start();

            // 클라이언트 접속이 발생하면 소켓 생성
            Socket client = server.AcceptSocket();
        }

        private TcpClient ConnectTcpClient(string serverUrl, int serverPort)
        {
            //TcpClient client = new TcpClient(serverUrl, serverPort);
            TcpClient client = new TcpClient();
            client.Connect(serverUrl, serverPort);

            return client;
        }

        private TcpClient ConnectTcpClient(string serverUrl, int serverPort, string serverIP)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            TcpClient client = new TcpClient(ipep);
            client.Connect(serverUrl, serverPort);

            return client;
        }

        


        #region [Receive Data]

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// TCP 프로토콜 문제점 및 해결
        ///   1. Receive() 메서드에 할당된 TCP 버퍼의 크기만큼 수신 ==> 읽어오려는 데이터보다 버퍼가 작으면 완전히 읽어오지 못하는 문제 발생 가능.
        ///   2. 데이터를 보내는 시점에 데이터 수신 불확실(n번 송신 == n번 송신 != 완전수신) ==> 보낸크기만큼 Receive 해야한다.
        ///   3. 통신환경이 불확실한경우, n번 송신 != n번 수신 (TCP프로토콜 수준에서 전송데이터 조작) ==> 전송 전 송신메시지 크기 먼저 송신
        /// </remarks>
        /// <param name="socketServer"></param>
        /// <param name="msg"></param>
        public byte[] ReceiveData(Socket socketTcpClient)
        {
            return ReceiveDataByCheckReceivedSize(socketTcpClient);
        }

        /// <summary>
        /// [ 문제 해결 ]
        /// </summary>
        /// <param name="socketTcpClient"></param>
        public byte[] ReceiveDataByCheckReceivedSize(Socket socketTcpClient)
        {
            // 받을 데이터
            byte[] receivedData = null;
            // 받을 데이터소스 전체 크기
            int dataSize = 0;
            // 받을 데이터소스 남은 크기
            int leftDataSize = 0;

            // 받을 데이터 전체 크기
            int receivedDataOffset = 0;
            // 직전 받은 데이터 크기
            int receivedDataSize = 0;

            // 받을 데이터 버퍼
            byte[] dataBuffer = new byte[4];

            // [수신데이터] 받을 데이터 크기 정보
            receivedDataSize = socketTcpClient.Receive(dataBuffer
                                                     , 0
                                                     , dataBuffer.Length
                                                     , SocketFlags.None);

            dataSize = BitConverter.ToInt32(dataBuffer, 0);

            leftDataSize = dataSize;

            receivedData = new byte[dataSize];

            // [송신데이터] 보낼 데이터크기를 모두 전송할때까지
            while (receivedDataOffset < dataSize)
            {
                receivedDataSize = socketTcpClient.Receive(receivedData
                                                         , receivedDataOffset
                                                         , leftDataSize
                                                         , SocketFlags.None);
                receivedDataOffset += receivedDataSize;
                leftDataSize -= receivedDataSize;
            }

            return receivedData;
        }

        /// <summary>
        /// [ 문제 내재 ]
        /// 클라이언트가 10번에 나눠 보낸 데이터를 서버가 10번 나눠 수신 ==> 완전수신 보장 안됨
        /// </summary>
        /// <param name="socketTcpClient"></param>
        /// <param name="dataSource"></param>
        private void ReceiveDataByCheckSendCount(Socket socketTcpClient)
        {
            byte[] dataBuffer = new byte[1024];
            int receivedDataSize;
            for (int i = 0; i < 10; i++)
            {
                receivedDataSize = socketTcpClient.Receive(dataBuffer);
                Console.WriteLine($"수신성공 데이터: {Encoding.Default.GetString(dataBuffer, 0, receivedDataSize)}");
            }
        }

        #endregion


        #region [Send Data]

        /// <summary>
        /// 데이터 전송
        /// </summary>
        /// <remarks>
        /// TCP 프로토콜 문제점 및 해결
        ///   1. Receive() 메서드에 할당된 TCP 버퍼의 크기만큼 수신 ==> 읽어오려는 데이터보다 버퍼가 작으면 완전히 읽어오지 못하는 문제 발생 가능.
        ///   2. 데이터를 보내는 시점에 데이터 수신 불확실(n번 송신 == n번 송신 != 완전수신) ==> 보낸크기만큼 Receive 해야한다.
        ///   3. 통신환경이 불확실한경우, n번 송신 != n번 수신 (TCP프로토콜 수준에서 전송데이터 조작) ==> 전송 전 송신메시지 크기 먼저 송신
        /// </remarks>
        /// <param name="socketServer"></param>
        /// <param name="msg"></param>
        public void SendData(Socket socketTcpServer, byte[] dataSource)
        {
            SendDataByCheckSendSize(socketTcpServer, dataSource);
        }


        /// <summary>
        /// [ 문제 해결 ]
        /// 보낼 데이터소스 크기를 먼저 전송하고, 전체 데이터크기를 전송할때까지 Send ...
        /// </summary>
        /// <param name="socketTcpServer"></param>
        /// <param name="dataSource"></param>
        public void SendDataByCheckSendSize(Socket socketTcpServer, byte[] dataSource)
        {
            // 보낼 데이터소스 전체 크기
            int dataSourceSize = dataSource.Length;
            // 보낼 데이터소스 남은 크기
            int leftDataSourceSize = dataSourceSize;

            // 보낸 데이터 전체 크기
            int sendDataOffset = 0;
            // 직전 보낸 데이터 크기
            int sendDataSize = 0;

            // 보낼 데이터 버퍼
            byte[] dataBuffer = new byte[4];

            // [송신데이터] 보낼 데이터 크기 정보
            dataBuffer = BitConverter.GetBytes(dataSourceSize);
            sendDataSize = socketTcpServer.Send(dataBuffer);

            // [송신데이터] 보낼 데이터크기를 모두 전송할때까지
            while (sendDataOffset < dataSourceSize)
            {
                sendDataSize = socketTcpServer.Send(dataSource
                                                  , sendDataOffset
                                                  , leftDataSourceSize
                                                  , SocketFlags.None);
                sendDataOffset += sendDataSize;
                leftDataSourceSize -= sendDataSize;
            }
        }




        /// <summary>
        /// [ 문제 내재 ]
        /// 송신측이 10번 송신 ==> 수신측이 10번 송신해도 완전수신 보장 안됨
        /// </summary>
        /// <param name="socketTcpServer"></param>
        /// <param name="dataSource"></param>
        private void SendDataByCheckSendCount(Socket socketTcpServer, byte[] dataSource)
        {
            // [송신데이터] 횟수만큼 송신
            for (int i = 0; i < 10; i++)
            {
                int receivedSize = socketTcpServer.Receive(dataSource);
                if (receivedSize != 0)
                {
                    Console.WriteLine($"수신 메시지: {Encoding.Default.GetString(dataSource)} - {receivedSize}바이트");
                }
                else
                {
                    Console.WriteLine("수신데이터 없음...");
                }
            }
        }

        #endregion


        #region [NetworkStream]

        private Socket GetTcpClientSocket()
        {
            Socket socketTcpServer = null;
            socketTcpServer = new Socket(AddressFamily.InterNetwork
                                        , SocketType.Stream
                                        , ProtocolType.Tcp);

            return socketTcpServer;
        }

        private string ReadNetworkStream(Socket socketTcpServer)
        {
            byte[] buffer = new byte[1024];
            StringBuilder sb = new StringBuilder();

            NetworkStream stream = new NetworkStream(socketTcpServer);
            if (stream.CanRead)
            {
                int offset = 0;

                do
                {
                    offset = stream.Read(buffer, 0, buffer.Length);
                    sb.Append(Encoding.ASCII.GetString(buffer, 0, offset));
                } while (stream.DataAvailable);

            }
            stream.Dispose();
            return sb.ToString();
        }

        private string ReadLineNetworkStream(Socket socketTcpServer)
        {
            StringBuilder sb = new StringBuilder();
            NetworkStream stream = new NetworkStream(socketTcpServer);
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            stream.Dispose();
            return sb.ToString();
        }

        private bool WriteNetworkStream(Socket socketTcpServer, string msg)
        {
            bool rtn = false;
            NetworkStream stream = new NetworkStream(socketTcpServer);
            if (stream.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                stream.Write(buffer, 0, buffer.Length);
                rtn = true;
            }
            stream.Dispose();
            return rtn;
        }

        private bool WriteLineNetworkStream(Socket socketTcpServer, string msg)
        {
            bool rtn = false;
            NetworkStream stream = new NetworkStream(socketTcpServer);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                if (stream.CanWrite)
                {
                    writer.WriteLine(msg);
                    writer.Flush();
                    rtn = true;
                }
            }
            stream.Dispose();
            return rtn;
        }

        #endregion
    }
}
