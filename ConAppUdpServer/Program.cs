using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConAppUdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartUdpServer(7000);
            StartUdpClientServer("127.0.0.1", 9009);
        }

        static void StartUdpServer(int serverPort)
        {
            Socket socketUdpServer = null;

            // 1. IPEndPoint 개체 생성 
            //     (서버의 IP주소로 접근할 수 있는 n번 포트의 IPEndPoint)
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, serverPort);

            try
            {

                // 2. 소켓 개체 생성 (비연결지향 UDP 소켓)
                socketUdpServer = new Socket(AddressFamily.InterNetwork
                                            , SocketType.Dgram
                                            , ProtocolType.Udp);

                // 3. 소켓통신
                socketUdpServer.Bind(ipep);
                Console.WriteLine("UDP 서버 시작 ...");

                EndPoint remoteEP = ReceiveDataFromRemote(socketUdpServer);

                Console.ReadLine();

                SendDataToRemote(socketUdpServer, remoteEP);

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

        static void StartUdpClientServer(string serverIP, int serverPort)
        {
            UdpClient udpClientServer = null;
            byte[] data = new byte[1024];

            // 1. IPEndPoint 개체 생성 
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

            try
            {

                // 2. 소켓 개체 생성 (비연결지향 UDP 소켓)


                // 3. 소켓통신

                udpClientServer = new UdpClient(ipep);
                
                Console.WriteLine("UDP CLIENT 서버 시작 ...");

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                data = udpClientServer.Receive(ref remoteEP);

                string msg = Encoding.Default.GetString(data);

                Console.WriteLine($"{remoteEP.ToString()}에서 보낸 데이터: {msg}");
                
                for(int i=0; i<10; i++)
                {
                    data = Encoding.Default.GetBytes($"Send data: [{i}]");
                    udpClientServer.Send(data, data.Length, remoteEP);
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

        private static void SendDataToRemote(Socket socketUdpServer, EndPoint remoteEP)
        {
            byte[] data = new byte[1024];

            for (int i=0; i< 10; i++)
            {
                data = Encoding.Default.GetBytes($"Send data: {i}");
                socketUdpServer.SendTo(data
                                     , data.Length
                                     , SocketFlags.None
                                     , remoteEP);
            }
        }

        private static EndPoint ReceiveDataFromRemote(Socket socketUdpServer)
        {
            byte[] data = new byte[1024];
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);

            int receivedDataSize = socketUdpServer.ReceiveFrom(data
                                                             , ref remote);

            Console.WriteLine($"{remote.ToString()} 클라이언트로부터 수신: {Encoding.Default.GetString(data, 0, receivedDataSize)}");

            return remote;
        }
    }
}
