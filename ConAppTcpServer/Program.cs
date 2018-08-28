using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConAppTcpServer
{
    class Program
    {
        private const int SOCKET_PORT = 7000;

        static void Main(string[] args)
        {
            StartTcpServer();
        }

        static void StartTcpServer()
        {
            Socket socketTcpServer = null;
            Socket socketTcpClient = null;

            byte[] data = new byte[1024];
            // 1.
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, SOCKET_PORT);
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
                DisplayClientInfo(socketTcpClient);

                SendWelcomeMessage(socketTcpClient);

                // 6.
                data = ReceiveData(socketTcpClient);
                Console.WriteLine("received:" + Encoding.Default.GetString(data));

                // 7.
                socketTcpClient.Send(data);
                Console.WriteLine("send: " + Encoding.Default.GetString(data));

                Console.ReadLine();
            }
            catch(SocketException ex)
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
        private static byte[] ReceiveData(Socket socketTcpClient)
        {
            return ReceiveDataByCheckReceivedSize(socketTcpClient);
        }

        /// <summary>
        /// [ 문제 해결 ]
        /// </summary>
        /// <param name="socketTcpClient"></param>
        private static byte[] ReceiveDataByCheckReceivedSize(Socket socketTcpClient)
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

        


        private static void SendWelcomeMessage(Socket socketTcpClient)
        {
            byte[] data = Encoding.Default.GetBytes("접속성공! 환영합니다. ...");
            socketTcpClient.Send(data, data.Length, SocketFlags.None);
        }

        private static void DisplayClientInfo(Socket client)
        {
            IPEndPoint ipep = client.RemoteEndPoint as IPEndPoint;
            if(ipep != null)
            {
                Console.WriteLine($"접속한 클라이언트 주소: {ipep.Address}, 클라이언트 포트: {ipep.Port}");
            }
        }
    }
}
