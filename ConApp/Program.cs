using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetInfoByIPAddress();

            //GetInfoByIPEndPoint();

            //GetHostInfoByGetHostAddresses();

            //Console.WriteLine($"MyIP: {GetLocalIpAddress()}");

            GetNetworkInfoByIPInterfaceProperties();

            Console.ReadLine();
        }

        /// <summary>
        /// IPInterfaceProperties 를 이용해 컴퓨터에 설치된 네트워크 인터페이스(랜카드) 정보 조회
        /// </summary>
        private static void GetNetworkInfoByIPInterfaceProperties()
        {
            NetworkInterface[] adtNetworks = NetworkInterface.GetAllNetworkInterfaces();

            foreach(var adt in adtNetworks)
            {
                IPInterfaceProperties adtProperties = adt.GetIPProperties();

                GatewayIPAddressInformationCollection gatewayIPs = adtProperties.GatewayAddresses;
                IPAddressCollection dhcpServers = adtProperties.DhcpServerAddresses;
                IPAddressCollection dnsServers = adtProperties.DnsAddresses;

                Console.WriteLine($"네트워크 카드: {adt.Description}");
                Console.WriteLine($"  Physical Address .......... : {adt.GetPhysicalAddress()}");
                Console.WriteLine($"  IP Address ................ : {GetLocalIpAddress()}");

                if (gatewayIPs.Count > 0)
                {
                    foreach (GatewayIPAddressInformation gateway in gatewayIPs)
                    {
                        Console.WriteLine($"  Gateway Address ........... : {gateway.Address.ToString()}");
                    }
                }

                if(dhcpServers.Count > 0)
                {
                    foreach(IPAddress dhcp in dhcpServers)
                    {
                        Console.WriteLine($"  DHCP Servers .............. : {dhcp.ToString()}");
                    }
                }

                if (dnsServers.Count > 0)
                {
                    foreach (IPAddress dns in dhcpServers)
                    {
                        Console.WriteLine($"  DNS Servers ............... : {dns.ToString()}");
                    }
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 로컬 IP 정보 조회
        /// </summary>
        static string GetLocalIpAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList[0].ToString();
        }

        /// <summary>
        /// GetHostAddresses() 메서드: 호스트 정보 조회
        /// </summary>
        static void GetHostInfoByGetHostAddresses()
        {
            Console.Write("주소를 입력하세요 -> ");
            string str = Console.ReadLine();

            IPAddress[] host = Dns.GetHostAddresses(str);
            try
            {
                 //Console.WriteLine($"호스트명: {Dns.GetHostEntry(host[0]).HostName}");
                Console.WriteLine($"호스트명: {Dns.GetHostEntry(str).HostName}");
                Console.WriteLine("IP주소 리스트:");
                for(int i=0; i<host.Length; i++)
                {
                    IPAddress ip = host[i];
                    Console.WriteLine($"\t[{ip.ToString()}]");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// IPEndPoint 클래스 : MaxPort, MinPort 속성을 이용해 사용가능한 포트번호 조회
        /// </summary>
        static void GetInfoByIPEndPoint()
        {
            IPAddress ipParse = IPAddress.Parse("192.168.0.1");
            IPEndPoint ipep = new IPEndPoint(ipParse, 8000);

            Console.WriteLine($"ToString()      : {ipep.ToString()}");
            Console.WriteLine($"AddressFamily   : {ipep.AddressFamily}");
            Console.WriteLine($"Address         : {ipep.Address}");
            Console.WriteLine($"Port            : {ipep.Port}");
            Console.WriteLine($"MaxPort         : {IPEndPoint.MaxPort}");
            Console.WriteLine($"MinPort         : {IPEndPoint.MinPort}");

            Console.ReadLine();
        }

        /// <summary>
        /// IPAddress 클래스 : 주로 단일 IP 주소를 나타낼 때 사용
        /// </summary>
        static void GetInfoByIPAddress()
        {
            //문자열 형태의 IP주소를 IPAddress로 파싱
            IPAddress ipParse = IPAddress.Parse("207.46.156.156");
            // 로컬 시스템에서 사용할 수 있는 IP
            IPAddress ipAny = IPAddress.Any;
            // 로컬 네트워크의 IP 브로드캐스트 주소
            IPAddress ipBroadcast = IPAddress.Broadcast;
            // 시스템의 루프백 주소
            IPAddress ipLoopback = IPAddress.Loopback;
            // 시스템의 네트워크 인터페이스가 없음
            IPAddress ipNone = IPAddress.None;

            Console.WriteLine($"문자열[207.46.156.156] = {ipParse}");
            Console.WriteLine($"로컬 시스템에서 사용가능 IP = {ipAny}");
            Console.WriteLine($"로컬 네트워크의 IP 브로드캐스트 주소 = {ipBroadcast}");
            Console.WriteLine($"시스템의 루프백 주소 = {ipLoopback}");
            Console.WriteLine($"시스템의 인테페이스 바운드 되지 않은 더미 소켓 = {ipNone}");

            Console.ReadLine();
        }


    }
}
