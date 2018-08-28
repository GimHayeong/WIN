using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConAppTcpClient
{
    class Program
    {
        private const string SERVER_IP = "127.0.0.1";
        private const int SOCKET_PORT = 7000;

        static void Main(string[] args)
        {
            StartTcpClient("데이터 전송...");
        }

        private static void StartTcpClient(string msg)
        {
            Socket socketTcpServer = null;

            byte[] data = new byte[1024];

            IPAddress host = IPAddress.Parse(SERVER_IP);

            // 1.
            IPEndPoint ipep = new IPEndPoint(host, SOCKET_PORT);

            try
            {
                // 2.
                socketTcpServer = new Socket(AddressFamily.InterNetwork
                                        , SocketType.Stream
                                        , ProtocolType.Tcp);

                // 3.
                socketTcpServer.Connect(ipep);

                Console.WriteLine("서버에 접속 ...");
                ReceiveWelcomeMessage(socketTcpServer);

                // 4.
                SendData(socketTcpServer, msg);

                // 5.
                socketTcpServer.Receive(data);
                Console.WriteLine(Encoding.Default.GetString(data));

                Console.ReadLine();
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 6.
                socketTcpServer.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// TCP 프로토콜 문제점 및 해결
        ///   1. Receive() 메서드에 할당된 TCP 버퍼의 크기만큼 수신 ==> 읽어오려는 데이터보다 버퍼가 작으면 완전히 읽어오지 못하는 문제 발생 가능.
        ///   2. 데이터를 보내는 시점에 데이터 수신 불확실. ==> 보낸크기만큼 Receive 해야한다.
        /// </remarks>
        /// <param name="socketServer"></param>
        /// <param name="msg"></param>
        private static void SendData(Socket socketTcpServer, string msg)
        {
            byte[] dataSource = new byte[10];

            for(int i=0; i<10; i++)
            {
                dataSource[i] = Convert.ToByte(i);
            }
            SendData(socketTcpServer, dataSource);

            //for (int i = 0; i < 10; i++)
            //{
            //    socketTcpServer.Send(Encoding.Default.GetBytes($"{msg} : {i}"));
            //}
        }

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
        private static void SendData(Socket socketTcpServer, byte[] dataSource)
        {
            SendDataByCheckSendSize(socketTcpServer, dataSource);
        }


        /// <summary>
        /// [ 문제 해결 ]
        /// 보낼 데이터소스 크기를 먼저 전송하고, 전체 데이터크기를 전송할때까지 Send ...
        /// </summary>
        /// <param name="socketTcpServer"></param>
        /// <param name="dataSource"></param>
        private static void SendDataByCheckSendSize(Socket socketTcpServer, byte[] dataSource)
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

        private static void ReceiveWelcomeMessage(Socket socketTcpServer)
        {
            byte[] buffer = new byte[1024];

            socketTcpServer.Receive(buffer);

            Console.WriteLine($"수신데이터: {Encoding.Default.GetString(buffer)}");
        }

        

        
    }
}
