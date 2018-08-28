using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConAppUdpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartUdpClient("127.0.0.1", 7000);
            StartUdpClient("127.0.0.1", 9009, "Hello, UDP CLIENT 서버!");
        }

        private static void StartUdpClient(string serverIP, int serverPort)
        {
            Socket socketUdpServer = null;

            // 1. IPEndPoint 개체 생성 
            //     (서버의 IP주소로 접근할 수 있는 n번 포트의 IPEndPoint)
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

            try
            {

                // 2. 소켓 개체 생성 (비연결지향 UDP 소켓)
                socketUdpServer = new Socket(AddressFamily.InterNetwork
                                            , SocketType.Dgram
                                            , ProtocolType.Udp);

                // 3. 소켓통신 처리
                SendDataToServer(socketUdpServer, ipep);

                Console.ReadLine();

                ReceiveDataFromServer(socketUdpServer);

                Console.ReadLine();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 4. 소켓 통신이 종료되면 소켓 리소스 해제
                if (socketUdpServer != null) socketUdpServer.Close();
            }
        }

        private static void StartUdpClient(string serverIP, int serverPort, string msg)
        {
            byte[] data = new byte[1024];

            UdpClient udpClientServer = null;

            // 1. IPEndPoint 개체 생성 

            try
            {

                // 2. 소켓 개체 생성 (비연결지향 UDP 소켓)


                // 3. 소켓통신 처리
                udpClientServer = new UdpClient(serverIP, serverPort);
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                data = Encoding.Default.GetBytes(msg);
                udpClientServer.Send(data, data.Length);

                for(int i=0; i<10; i++)
                {
                    data = udpClientServer.Receive(ref remoteEP);
                    Console.WriteLine(Encoding.Default.GetString(data));
                }

                Console.ReadLine();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 4. 소켓 통신이 종료되면 소켓 리소스 해제
                if (udpClientServer != null) udpClientServer.Close();
            }
        }

        private static void ReceiveDataFromServer(Socket socketUdpServer)
        {
            byte[] data = null;

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)sender;

            for(int i=0; i<10; i++)
            {
                data = new byte[1024];
                int receivedDataSize = socketUdpServer.ReceiveFrom(data, ref remote);
                Console.WriteLine($"{remote.ToString()} 수신데이터 : {Encoding.Default.GetString(data, 0, receivedDataSize)}");
            }
        }

        private static void SendDataToServer(Socket socketUdpServer, IPEndPoint ipep)
        {
            byte[] data = new byte[1024];

            data = Encoding.Default.GetBytes("Hello, UDP Server...");
            socketUdpServer.SendTo(data
                                 , data.Length
                                 , SocketFlags.None
                                 , ipep);

            Console.WriteLine("UDP 서버 접속 성공...");
        }
    }
}
