using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class UdpSocketLib
    {

        public void StartUdpServer(int serverPort)
        {
            Socket socketUdpServer = null;

            // 1. IPEndPoint 개체 생성 
            //     (로컬의 모든 IP주소로 접근할 수 있는 n번 포트의 IPEndPoint)
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, serverPort);

            try
            {
                // 2. 소켓 개체 생성 (비연결지향 UDP 소켓)
                socketUdpServer = new Socket(AddressFamily.InterNetwork
                                           , SocketType.Dgram
                                           , ProtocolType.Udp);

                // 3. 네트워크 장치에서 IP 주소를 기반으로 서비스 준비
                socketUdpServer.Bind(ipep);

                // 4. 소켓통신 처리
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 5. 소켓 통신이 종료되면 소켓 리소스 해제
                if (socketUdpServer != null) socketUdpServer.Close();
            }
        }

        public void StartUdpClient(string serverIP, int serverPort)
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

        public void SendDataToRemote(Socket socketUdpServer, int remotePort, string msg)
        {
            SendDataToRemote(socketUdpServer
                            , new IPEndPoint(IPAddress.Any, remotePort)
                            , msg);
        }

        public void SendDataToRemote(Socket socketUdpServer, string remoteIP, int remotePort, string msg)
        {
            SendDataToRemote(socketUdpServer
                            , new IPEndPoint(IPAddress.Parse(remoteIP), remotePort)
                            , msg);
        }

        public void SendDataToRemote(Socket socketUdpServer, EndPoint epRemote, string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            SendDataToRemote(socketUdpServer
                            , epRemote
                            , data);
        }

        /// <summary>
        /// 서버(socketUdpServer) 송신 ===> 원격 컴퓨터(remoteEP) 수신
        /// </summary>
        /// <remarks>
        ///   Socket.Send() 메서드 사용불가 ==> SendTo() 메서드 : EndPoint에 해당하는 컴퓨터로 바이트 배열형태의 데이터 전송
        /// </remarks>
        /// <param name="remoteEP"></param>
        /// <param name="data"></param>
        public void SendDataToRemote(Socket socketUdpServer, EndPoint remoteEP, byte[] data)
        {
            socketUdpServer.SendTo(data
                                 , data.Length
                                 , SocketFlags.None
                                 , remoteEP);
        }


        /// <summary>
        /// 원격 컴퓨터(remoteEP) 송신 ===> 서버(socketUdpServer) 수신
        /// </summary>
        /// <remarks>
        ///   Socket.Receive() 메서드 사용불가 ==> ReceiveFrom() 메서드 : EndPoint에 해당하는 컴퓨터로부터 바이트 배열형태의 데이터 수신
        /// </remarks>
        /// <param name="socketUdpServer"></param>
        /// <param name="remoteEP">송신 원격 컴퓨터 EendPoint</param>
        public void ReceiveDataFromRemote(Socket socketUdpServer, EndPoint remoteEP)
        {
            byte[] data = new byte[1024];

            int receivedDataSize = socketUdpServer.ReceiveFrom(data, ref remoteEP);

            Console.WriteLine($"{remoteEP.ToString()} 수신데이터: {Encoding.Default.GetString(data, 0, receivedDataSize)}");
        }
    }
}
