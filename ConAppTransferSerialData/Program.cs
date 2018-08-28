using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace ConAppTransferSerialData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("학사정보를 저장하시겠습니까(Y/N) ===>");
            ConsoleKeyInfo key = Console.ReadKey();

            if(key.Key == ConsoleKey.Y)
            {
                SaveSerialData();
                Console.WriteLine();
                Console.WriteLine("학사정보를 저장하였습니다.");
            }

            Console.WriteLine("저장된 학사정보를 조회하려면 아무키나 누르십시오...");
            Console.ReadLine();

            Console.WriteLine("학사정보 조회 결과 ===>");

            LoadSerialData();

            Console.Write("네트워크 서버로 데이터를 전송하시겠습니까?(Y/N) ===>");
            key = Console.ReadKey();
            if(key.Key == ConsoleKey.Y)
            {
                TransSerialData();
            }
            Console.ReadLine();
        }

        private static void SaveSerialData()
        {
            StudentScore ssHong = new StudentScore { Id = 1, Name = "홍길동", Kor = 80, Math = 50, Eng = 100, RegDate = DateTime.Now };
            StudentScore ssChoi = new StudentScore { Id = 2, Name = "최재규", Kor = 100, Math = 85, Eng = 90, RegDate = DateTime.Now };

            Stream streamBinary = new FileStream("binary.txt", FileMode.Create, FileAccess.ReadWrite);
            Stream streamSoap = new FileStream("soap.txt", FileMode.Create, FileAccess.ReadWrite);

            IFormatter formatter;

            formatter = new BinaryFormatter();
            formatter.Serialize(streamBinary, ssHong);

            formatter = new SoapFormatter();
            formatter.Serialize(streamSoap, ssChoi);

            streamSoap.Close();
            streamBinary.Close();
        }


        private static void LoadSerialData()
        {
            Stream streamBinary = new FileStream("binary.txt", FileMode.Open, FileAccess.ReadWrite);
            Stream streamSoap = new FileStream("soap.txt", FileMode.Open, FileAccess.ReadWrite);

            IFormatter formatter;

            formatter = new BinaryFormatter();
            StudentScore ssBinary = formatter.Deserialize(streamBinary) as StudentScore;
            if(ssBinary != null)
            {
                DisplayInfo(ssBinary);
            }

            formatter = new SoapFormatter();
            StudentScore ssSoap = formatter.Deserialize(streamSoap) as StudentScore;
            if(ssSoap != null)
            {
                DisplayInfo(ssSoap);
            }

            streamSoap.Close();
            streamBinary.Close();
        }

        private static void TransSerialData()
        {
            TcpClient server = new TcpClient("127.0.0.1", 7000);
            NetworkStream netStream = server.GetStream();

            StudentScore ssChoi = new StudentScore { Id = 2, Name = "최재규", Kor = 100, Math = 85, Eng = 90, RegDate = DateTime.Now };

            IFormatter formatter = new SoapFormatter();
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, ssChoi);

            byte[] data = memStream.GetBuffer();
            int dataSize = (int)memStream.Length;
            byte[] totalSize = BitConverter.GetBytes(dataSize);

            netStream.Write(totalSize, 0, 4);
            netStream.Write(data, 0, dataSize);
            netStream.Flush();

            memStream.Close();
            netStream.Close();
            server.Close();
        }

        private static void DisplayInfo(StudentScore student)
        {
            Console.WriteLine($"학번: {student.Id}");
            Console.WriteLine($"이름: {student.Name}");
            Console.WriteLine($"국어: {student.Kor}");
            Console.WriteLine($"수학: {student.Math}");
            Console.WriteLine($"영어: {student.Eng}");
            Console.WriteLine($"입력일: {student.RegDate}");
        }
    }
}
