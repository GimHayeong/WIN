using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace ConAppReceiveSerialData
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
            server.Start();

            Console.WriteLine("서버 시작 ...");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream netStream = client.GetStream();
            MemoryStream memStream = new MemoryStream();

            byte[] data = new byte[4];
            int recv_size = netStream.Read(data, 0, 4);
            if(recv_size > 0)
            {
                int size = BitConverter.ToInt32(data, 0);

                while(size > 0)
                {
                    data = new byte[1024];
                    recv_size = netStream.Read(data, 0, recv_size);
                    memStream.Write(data, 0, recv_size);

                    size -= recv_size;
                }

                memStream.Position = 0;
                IFormatter formatter;

                formatter = new SoapFormatter();
                StudentScore ss = formatter.Deserialize(memStream) as StudentScore;
                if(ss != null)
                {
                    Console.WriteLine(ss.ToString());
                }
            }

            memStream.Close();
            netStream.Close();
            client.Close();
            server.Stop();

            Console.ReadLine();
        }
    }
}
