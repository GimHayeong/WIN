using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class SocketSample
    {

        /// <summary>
        /// TCP 방식 소켓 프로그래밍
        /// </summary>
        private void InitTcpServerSample()
        {
            Socket socketTcpServer = null;
            Socket socketTcpClient = null;

            byte[] data = new byte[10];

            // 1. IPEndPoint 개체 생성 
            //     (로컬의 모든 IP주소로 접근할 수 있는 9999번 포트의 IPEndPoint)
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9999);

            try
            {
                // 2. 소켓 개체 생성 (연결지향 TCP 소켓)
                socketTcpServer = new Socket(AddressFamily.InterNetwork
                                           , SocketType.Stream
                                           , ProtocolType.Tcp);

                // 3. 네트워크 장치에서 IP 주소를 기반으로 서비스 준비
                socketTcpServer.Bind(ipep);

                // 4. 클라이언트 연결 요청 대기 (10: 최대 접속 처리 클라이언트 수 설정값)
                socketTcpServer.Listen(10);

                // 5. 클라이언트가 서버에 접속을 요청하면 클라이언트와 통신할 수 있는 소켓 개체 반환
                socketTcpClient = socketTcpServer.Accept();

                // 6. 클라이언트로부터 데이터 수신
                socketTcpClient.Receive(data);

                // 7. 클라이언트로 확인 데이터 전송
                socketTcpClient.Send(data);
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




        private void InitTcpClientSample(string msg)
        {
            Socket socketServer = null;

            byte[] data = new byte[10];

            IPAddress host = IPAddress.Parse("192.168.0.1");

            // 1. IPEndPoint 개체 생성 
            IPEndPoint ipep = new IPEndPoint(host, 9999);

            try
            {
                // 2. 소켓 개체 생성 (연결지향 TCP 소켓)
                socketServer = new Socket(AddressFamily.InterNetwork
                                        , SocketType.Stream
                                        , ProtocolType.Tcp);

                // 3. 서버에 접속 요청
                socketServer.Connect(ipep);

                // 4. 서버로 메시지 전송
                socketServer.Send(Encoding.ASCII.GetBytes(msg));

                // 5. 서버로부터 확인 데이터 수신
                socketServer.Receive(data);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 6. 소켓 통신이 종료되면 소켓 리소스 해제
                if (socketServer != null) socketServer.Close();
            }
        }







        /// <summary>
        /// 소켓 반환
        /// </summary>
        /// <param name="networkType">네트워크 유형</param>
        /// <param name="socketType">데이터 연결 (TCP/UDP 설정)
        ///    - Dgram : UDP(비연결 통신)
        ///    - Stream : TCP(연결지향 통신)
        ///    - Raw : ICMP(Internet Control Message Protocol)
        /// </param>
        /// <param name="protocolType">특정 네트워크 프로토콜
        ///    - Udp : UDP((SocketType == Dgram 인경우))
        ///    - Tcp : TCP((SocketType == Stream 인경우)
        ///    - Icmp : ICMP(SocketType == Raw 인경우)
        ///    - Raw : 패킷 통신((SocketType == Raw 인경우)
        /// </param>
        /// <example>
        ///     Socket socketTcp    = GetSocket(AddressFamily.InterNetwork  , SocketType.Stream , ProtocolType.Tcp);
        ///     Socket socketUdp    = Socket(AddressFamily.InterNetwork     , SocketType.Dgram  , ProtocolType.Udp);
        ///     Socket socketIcmp   = Socket(AddressFamily.InterNetwork     , SocketType.Raw    , ProtocolType.Icmp);
        ///     Socket socketPacket = Socket(AddressFamily.InterNetwork     , SocketType.Raw    , ProtocolType.Raw);
        /// </example> 
        private Socket GetSocket(AddressFamily networkType, SocketType socketType, ProtocolType protocolType)
        {
            return new Socket(networkType
                            , socketType
                            , protocolType);
        }

        /// <summary>
        /// 소켓옵션 설정
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="opLevel">SocketOptionLevel
        ///    IP       : AddMemberShip, BlockSource, IpTimeToLive, MulticastLoopback 등
        ///    Socket   : Broadcast, Linger, SendTimeout 등
        ///    Tcp      : NoDelay 등
        ///    Udp      : NoChecksum 등
        /// </param>
        /// <param name="opName">
        ///    IP 인 경우, 
        ///         AddMemberShip       : 소스 그룹에 포함 여부
        ///         BlockSource         : 소스로부터 데이터 블록 처리 여부
        ///         IpTimeToLive        : IP TTL 값 설정 여부
        ///         MulticastLoopback   : IP 멀티캐스트 루프백 처리 여부
        ///    Socket 인 경우,
        ///         Broadcast           : 브로드캐스트 메시지 전송 여부
        ///         Linger              : 소켓을 닫은 후 추가적인 데이터 대기 여부
        ///         SendTimeout         : 전송 타임아웃 값 설정 여부
        ///    Tcp 인 경우,
        ///         NoDelay             : TCP 패킷의 지연 전송 알고리즘 해제 여부
        ///    Udp 인 경우,
        ///         NoChecksum          : 체크섬 기능 해제 여부
        /// </param>
        /// <param name="opValue"></param>
        /// <example>
        ///     SetOption(socketTcp, SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
        ///     SetOption(socketUdp, SocketOptionLevel.Udp, SocketOptionName.NoChecksum, true)
        /// </example>
        private void SetOption(Socket socket, SocketOptionLevel opLevel, SocketOptionName opName, bool opValue)
        {
            socket.SetSocketOption(opLevel, opName, opValue);
        }




        /// <summary>
        /// UDP 방식 소켓 프로그래밍
        /// </summary>
        private void InitUdpServerSample()
        {
            Socket socketUdpServer;

            // 1. IPEndPoint 개체 생성 
            //     (로컬의 모든 IP주소로 접근할 수 있는 9999번 포트의 IPEndPoint)
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9999);

            // 2. 소켓 개체 생성 (비연결지향 UDP 소켓)
            socketUdpServer = new Socket(AddressFamily.InterNetwork
                                       , SocketType.Dgram
                                       , ProtocolType.Udp);

            // 3. 네트워크 장치에서 IP 주소를 기반으로 서비스 준비
            socketUdpServer.Bind(ipep);
        }
    }
}
