//#define SERIALIZE
//#define FILEINFO
//#define DIRECTORYINFO
//#define FILE_STREAM
//#define BUFFERED_STREAM
//#define STREAMREADER_STREAMWRITER
//#define MEMORY_STREAM
#define CRYPTO_STREAM

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    /// <summary>
    /// 
    /// 스트림 : 바이트의 연속. 파일 뿐 아니라 메모리나 네트워크로 입출력되는 데이터까지 포함
    ///   + BufferedStream : 버퍼를 이용 데이터 고속 입출력. 대용량의 데이터 처리에 적합. 임시 버퍼를 만들어 버퍼에 데이터가 차면 한번에 입출력 수행 (파일연결 오버헤드 감소로 성능향상).
    ///   + MemoryStream : 주기억 장치 대상 스트림 입출력.
    ///   + NetworkStream : 소켓기반 통신 프로그램에서 스트림 형태의 데이터 송수신 처리.
    ///   + CrpytoStream : 닷넷이 제공하는 보안 및 암호화 관련 스트림 처리.
    ///   + FileStream : 파일 입출력 스트림(파일 생성/변경/삭제). 바이트 배열로 입출력
    /// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ///   + StreamReader(~ Writer) : 입출력 과정에서 자동으로 문자열 변환
    ///   + BinaryReader(~ Writer) : 클래스나 임의의 이진 데이터 입출력. 입출력시 스트림을 인수로 요구. 
    /// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ///   + BinaryFormatter : 이진 형태로 시리얼라이즈 수행
    ///   + SoapFormatter : XML 방식으로 시리얼라이즈 수행
    /// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ///   ==> 시리얼라이즈 : 객체를 스트림에 저장 (네트워크나 파일은 일차원 형태의 배열만 전달 가능하므로 일차원의 배열형태로 만드는 과정)
    ///   ==> 디시리얼라이즈 : 스트림으로부터 읽은 데이터를 다시 객체의 형태로 입체적으로 조립
    ///   
    /// </summary>
    /// <example>
    /// 
    ///   Stream.CanRead (CanSeek/CanWrite) : 현재 스트림의 읽기 (탐색/쓰기) 가능여부
    ///   Stream.Length : 현재 스트림의 길이를 바이트 단위로 반환
    ///   Stream.Position : 현재 스트림의 위치
    /// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ///   Stream.Flush() : 버퍼에 저장된 데이터를 목적지에 전송하고 버퍼를 비움
    ///   Stream.Read() / Stream.ReadByte() : 현재 스트림의 연속된 바이트를 읽어들이고 스트림의 위치를 읽어들인만큼 앞으로 이동.
    ///   Stream.Write() / Stream.WriteByte() : 현재 스트림에 연속된 바이트를 쓰고, 스트림의 위치를 쓴 바이트 수만큼 앞으로 이동.
    ///   Stream.Seek() : 현재 스트림에서 위치를 지정. (SeekOrigin.Begin/SeekOrigin.Current/SeekOrigin.End 로 상대적 위치 지정가능)
    ///   Stream.SetLength() : 스트림 길이 지정
    ///   Stream.Close() : 스트림을 닫고 파일이나 소켓등의 관련된 리소스 해제
    ///   
    /// </example>
    public partial class FileStreamForm : Form
    {
#if SERIALIZE
        private readonly string m_SerializedBinaryFilePath = @"D:\downloads\temp\Gildong_Serialized.bin";
        private readonly string m_SerializedXmlFilePath = @"D:\downloads\temp\Gildong_Soap.bin";
#elif CRYPTO_STREAM

        // ================================================================================================================================
        // 비대칭 암호화 : 공개키로 데이터를 암호화하고 하나의 키를 다른 사용자에게 제공해 해독. (공개키 Public Key 방식)
        //                 공개키는 암호화에만 사용되고 개인키가 있어야만 해독가능. 
        //                 블럭단위 암호화가 불가능하여 네트워크 환경에서는 잘 사용되지 않음.
        //    + DSACryptoServiceProvider : DSA 비대칭 암호화 알고리즘을 구현하는 클래스
        //    + RSACryptoServiceProvider : RSA 비대칭 암호화 알고리즘을 구현하는 클래스
        // ---------------------------------------------------------------------------------------------------------------------------------
        // 대칭 암호화 : 단일키를 사용해 메시지를 암호화하고 해독 (개인키 Private Key 방식). 네트워크에서 데이터 암호화시 자주 사용.
        //    + DESCryptoServiceProvider : DES 대칭 암호화 알고리즘을 구현하는 클래스
        //    + RC2CryptoServiceProvider : RC2 대칭 암호화 알고리즘을 구현하는 크래스
        //    + RijndaeManaged : Rijndael 대칭 암호화 알고리즘을 구현하는 클래스
        //    + TripleDESCryptoServiceProvjder : Triple DES 대칭 암호화 알고리즘을 구현하는 클래스
        // ================================================================================================================================

        /// <summary>
        /// 원본파일
        /// </summary>
        private const string FILE_NORMAL = "Normal.txt";
        /// <summary>
        /// 원본파일을 공개키로 암호화한 파일
        /// </summary>
        private const string FILE_CRYPTO = "Crypto.txt";
        /// <summary>
        /// 암호화된 파일을 공개키로 복호화한 파일
        /// </summary>
        private const string FILE_DECRYPTO = "Decrypto.txt";
        /// <summary>
        /// DES 8바이트 대칭 암호화키 설정
        /// </summary>
        private readonly byte[] DES_KEY = { 1, 2, 3, 4, 5, 6, 7, 8 };
        /// <summary>
        /// DES 8바이트 벡터 키 설정
        /// </summary>
        private readonly byte[] DES_IV = { 20, 21, 10, 5, 7, 9, 10, 5 };
#else
        private readonly string m_FilePath = @"D:\downloads\temp\fs.txt";
        private readonly string m_BinaryFilePath = @"D:\downloads\temp\Gildong.bin";
#endif

        private Human Gildong = new Human("홍길동", 17);

        public FileStreamForm()
        {
            InitializeComponent();

#if SERIALIZE
            if (grbxFileStream.HasChildren)
            {
                grbxFileStream.Enabled = false;
            }
#elif CRYPTO_STREAM
#else
            if (grbxSerialize.HasChildren)
            {
                grbxSerialize.Enabled = false;
            }
#endif
            txtData.Text = Gildong.Name;
        }

        private void Form_Load(object sender, EventArgs e)
        {
#if CRYPTO_STREAM
            FileInfo file = new FileInfo(FILE_NORMAL);
            if (!file.Exists)
            {
                using(FileStream fs = new FileStream(FILE_NORMAL, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    for(int i=25; i<125; i++)
                    {
                        fs.WriteByte((byte)i);
                    }
                }
            }
            
#endif
        }

        /// <summary>
        /// FileStream 을 이용해 파일 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
#if SERIALIZE
#elif CRYPTO_STREAM
#else
           byte[] data = { 65, 66, 67, 68, 69, 70, 71, 72 };

            //string filePath = @"C:\Users\USER\fs.txt";//Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "fs.txt";
            FileStream fs = new FileStream(m_FilePath, FileMode.Create, FileAccess.Write);//@"c:\fs.txt"
            fs.Write(data, 0, data.Length);
            fs.Close();

            MessageBox.Show(@"사용자폴더 내의 fs.txt 파일에 기록했습니다.");         
#endif
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
#if SERIALIZE
#elif CRYPTO_STREAM
#else
            byte[] data = new byte[8];
            try
            {
                //string filePath = @"C:\Users\USER\fs.txt"; //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "fs.txt";
                using (FileStream fs = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read))//@"c:\fs.txt"
                {
                    fs.Read(data, 0, data.Length);
                }//fs.Close();

                StringBuilder result = new StringBuilder();
                for(int i=0; i<data.Length; i++)
                {
                    result.AppendFormat("{0}, ", data[i]);
                }

                MessageBox.Show(result.ToString(), "파일내용");
            } catch (FileNotFoundException)
            {
                MessageBox.Show("지정한 파일이 없습니다.");
            }
#endif
        }

        private void btnWriteString_Click(object sender, EventArgs e)
        {
#if SERIALIZE
#elif STREAMREADER_STREAMWRITER
            using (StreamWriter sw = new StreamWriter(m_FilePath))
            {
                sw.WriteLine("진달래꽃");
                sw.WriteLine("김영랑");
                sw.WriteLine("나 보기가 역겨워 가실 때에는");
                sw.WriteLine("죽어도 아니 눈물 흘리오리다.");
                sw.WriteLine("영변에 약산 진달래꽃");
                sw.WriteLine("아름따다 가실 길에 뿌리오리다.");
                sw.WriteLine("나 보기가 역겨워 가실 때에는");
                sw.WriteLine("죽어도 아니 눈물 흘리오리다.");
            }

#elif CRYPTO_STREAM
#else
            string str = "무궁화꽃이 피었습니다.";
            StreamWriter sw = new StreamWriter(m_FilePath);
            sw.Write(str);
            sw.Close();
#endif
        }

        private void btnReadString_Click(object sender, EventArgs e)
        {
#if SERIALIZE
#elif STREAMREADER_STREAMWRITER
            StringBuilder sb = new StringBuilder();
            using(StreamReader sr = new StreamReader(m_FilePath))
            {
                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine());
                }
            }

            MessageBox.Show(sb.ToString(), "파일내용 (" + sb.Length + " bytes)");
#elif CRYPTO_STREAM
#else
            char[] buffer = new char[1024];
            int read;
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(m_FilePath))
            {
                while (true)
                {
                    read = sr.Read(buffer, 0, 1024);
                    sb.Append(new string(buffer, 0, read));
                    if(read < 1024) { break; }
                }
            }//sr.Close();

            MessageBox.Show(sb.ToString(), "파일내용 (" + sb.Length + " bytes)");
#endif
        }

        /// <summary>
        /// 이진데이터 저장
        ///   + BinaryWriter : 파일의 경로 정보를 갖고 있는 FileStream 을 BinaryWriter의 매개변수로 넘김
        ///     [VS]
        ///   + BinaryFormatter : 이진 형태로 시리얼라이즈 수행. FileStream 을 BinaryFormatter의 매개변수로 넘김
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteBinary_Click(object sender, EventArgs e)
        {
#if SERIALIZE
            using(FileStream stream = new FileStream(m_SerializedBinaryFilePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter(); //using 블럭 사용불가(IDisposable 형으로 변환 불가), close 필요없음
                bf.Serialize(stream, Gildong);
            }
#elif CRYPTO_STREAM
#else
            using (FileStream stream = new FileStream(m_BinaryFilePath, FileMode.Create, FileAccess.Write))
            {
                using(BinaryWriter bw = new BinaryWriter(stream))
                {
                    Gildong.Write(bw);
                }
            }
#endif
        }

        /// <summary>
        /// 이진데이터 읽기
        ///   + BinaryReader : 파일의 경로 정보를 갖고 있는 FileStream 을 BinaryWriter의 매개변수로 넘김
        ///     [VS]
        ///   + BinaryFormatter : 이진 형태로 시리얼라이즈 수행. FileStream 을 BinaryFormatter의 매개변수로 넘김
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadBinary_Click(object sender, EventArgs e)
        {
            Text = "파일을 읽는 중";
            System.Threading.Thread.Sleep(1000);

#if SERIALIZE
            using (FileStream stream = new FileStream(m_SerializedBinaryFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();//using 블럭 사용불가(IDisposable 형으로 변환 불가), close 필요없음
                Gildong = (Human)bf.Deserialize(stream);
            }
#elif CRYPTO_STREAM
#else
            using(FileStream stream = new FileStream(m_BinaryFilePath, FileMode.Open, FileAccess.Read))
            {
                using(BinaryReader br = new BinaryReader(stream))
                {
                    Gildong = Human.Read(br);
                }
            }
#endif
            MessageBox.Show(Gildong.ToString(), "파일내용");
            Text = "";
        }


        /// <summary>
        /// SoapFormatter : XML방식으로 시리얼라이즈 수행. 파일정보를 갖고있는 FileStream 을 SoapFormatter의 매개변수로 넘김
        ///   + Soap.dll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteXMLForSoap_Click(object sender, EventArgs e)
        {
#if SERIALIZE
            using (FileStream stream = new FileStream(m_SerializedXmlFilePath, FileMode.Create, FileAccess.Write))
            {
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(stream, Gildong);//using 블럭 사용불가(IDisposable 형으로 변환 불가), close 필요없음
            }
#elif CRYPTO_STREAM
#else
#endif
        }

        /// <summary>
        /// SoapFormatter : XML방식으로 시리얼라이즈 수행. 파일정보를 갖고있는 FileStream 을 SoapFormatter의 매개변수로 넘김
        ///   + Soap.dll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadXMLForSoap_Click(object sender, EventArgs e)
        {
            Text = "파일을 읽는 중";
            System.Threading.Thread.Sleep(1000);
#if SERIALIZE
            using (FileStream stream = new FileStream(m_SerializedXmlFilePath, FileMode.Open, FileAccess.Read))
            {
                SoapFormatter sf = new SoapFormatter();
                Gildong = (Human)sf.Deserialize(stream);
            }
#elif CRYPTO_STREAM
#else
#endif
            MessageBox.Show(Gildong.ToString(), "파일내용");
            Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileCopy_Click(object sender, EventArgs e)
        {
#if SERIALIZE
#elif CRYPTO_STREAM
#else
            Button btn = sender as Button;
            if(btn != null)
            {
                string target;
                switch (btn.Name)
                {
                    case "btnFileCopy":
                        target = m_FilePath.Replace(@"\temp\", @"\backup\");
                        if (File.Exists(m_FilePath))
                        {
                            File.Copy(m_FilePath, target);
                        }
                        break;

                    case "btnFileInfoCopy":
                        FileInfo fileInfo = new FileInfo(m_BinaryFilePath);
                        if (fileInfo.Exists)
                        {
                            target = fileInfo.Directory.Parent.FullName + @"\backup\" + fileInfo.Name;
                            fileInfo.CopyTo(target);
                        }
                        break;
                }
            }
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirectory_Click(object sender, EventArgs e)
        {
#if SERIALIZE
#elif CRYPTO_STREAM
#else
            Button btn = sender as Button;
            if(btn != null)
            {
                txtData.Refresh();
                switch (btn.Name)
                {
                    case "btnDirectory":
                        Text = "Directory";
                        string[] files = Directory.GetFiles(Environment.SystemDirectory, "*.dll", SearchOption.TopDirectoryOnly);
                        foreach(string file in files)
                        {
                            txtData.AppendText(file + "\r\n");
                        }
                        txtData.AppendText(files.Length + "\r\n");
                        break;

                    case "btnDirectoryInfo":
                        Text = "DirectoryInfo";
                        DirectoryInfo dirInfo = new DirectoryInfo(Environment.SystemDirectory);
                        FileInfo[] fileInfo = dirInfo.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
                        foreach (FileInfo file in fileInfo)
                        {
                            txtData.AppendText(file.FullName + "\r\n");//경로를 포함한 파일명
                        }
                        txtData.AppendText(fileInfo.Length + "\r\n");
                        break;
                }

            }
#endif
        }

        private void fswFileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            txtData.Refresh();
            txtData.AppendText(e.FullPath + " 파일이 변경되었습니다.\r\n");
        }

        private void fswFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            txtData.Refresh();
            txtData.AppendText(e.FullPath + " 파일이 생성되었습니다.\r\n");
        }

        private void fswFileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            txtData.Refresh();
            txtData.AppendText(e.FullPath + " 파일이 삭제되었습니다.\r\n");
        }

        private void fswFileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            txtData.Refresh();
            txtData.AppendText(e.OldFullPath + " 파일이 " + e.FullPath + " 파일로 이름이 변경되었습니다.\r\n");
        }

        /// <summary>
        /// 폴더정보
        /// </summary>
        /// <example>
        /// DisplayDirectoryInfo(@"C:\Program Files\Internet Explorer");
        /// </example>
        /// <param name="folderPath">C:\Program Files\Internet Explorer</param>
        private string GetFolderInfo(string folderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);

            if (dir.Exists)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"전체경로: {dir.FullName}");//C:\Program Files\Internet Explorer
                sb.AppendLine($"디렉토리명: {dir.Name}");//Internet Expolorer
                sb.AppendLine($"생성일: {dir.CreationTime}");//2004-03-07 오전 11:23:05
                sb.AppendLine($"디렉토리속성: {dir.Attributes}");//Directory
                sb.AppendLine($"루트경로: {dir.Root}");//C:\
                sb.AppendLine($"부모경로: {dir.Parent}");//Program Files
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 파일정보
        /// </summary>
        /// <example>
        /// GetFileInfo(@"C:\test.txt");
        /// </example>
        /// <param name="filePath">C:\test.txt</param>
        /// <returns></returns>
        private string GetFileInfo(string filePath)
        {
            FileInfo file = new FileInfo(filePath);

            if (file.Exists)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"디렉토리명: {file.DirectoryName}");//C:\
                sb.AppendLine($"파일명: {file.Name}");//test.txt
                sb.AppendLine($"확장자: {file.Extension}");//.txt
                sb.AppendLine($"생성일: {file.CreationTime}");//2004-03-07 오전 11:23:05
                sb.AppendLine($"파일크기: {file.Length}");//5256 byte
                sb.AppendLine($"파일속성: {file.Attributes}");//Archive
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 하위 폴더와 파일 탐색
        /// </summary>
        /// <example>
        /// DisplayDirectoryInfo(@"C:\Program Files\Internet Explorer");
        /// </example>
        /// <param name="folderPath">C:\Program Files\Internet Explorer</param>
        private string GetFileExplorer(string folderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);

            if (dir.Exists)
            {
                StringBuilder sb = new StringBuilder();
                DirectoryInfo[] dirSub = dir.GetDirectories();
                foreach(DirectoryInfo d in dirSub)
                {
                    FileInfo[] files = d.GetFiles();
                    sb.AppendLine($"디렉토리: {d.FullName}, 포함된 파일수: {files.Length}");

                    for (int i=0; i<files.Length; i++)
                    {
                        sb.AppendLine($"[{i}] 파일명: {files[i].Name}, 확장자: {files[i].Extension}, 크기: {files[i].Length}");
                    }
                }

                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

#if FILEINFO
        /// <summary>
        /// 파일복사
        /// </summary>
        /// <param name="srcFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <returns></returns>
        private bool CoppyFile(string srcFilePath, string destFilePath)
        {
            FileInfo srcFile = new FileInfo(srcFilePath);
            if (srcFile.Exists)
            {
                FileInfo copiedFile = srcFile.CopyTo(destFilePath, true);
                //copiedFile.MoveTo(destFilePath);//생략가능

                if (copiedFile.Exists) return true;
            }

            return false;
        }

        private bool DeleteFile(string srcFilePath)
        {
            FileInfo srcFile = new FileInfo(srcFilePath);
            srcFile.Delete();

            return true;
        }
#endif

#if DIRECTORYINFO
        private bool CreateFolder(string folder, params string[] subFolder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            if (dir.Exists)
            {
                return false;
            }
            else
            {
                dir.Create();
                if(subFolder != null && subFolder.Length > 0)
                {
                    for(int i=0; i<subFolder.Length; i++)
                    {
                        dir.CreateSubdirectory(subFolder[i]);
                    }
                }
                return true;
            }
        }

        private bool DeleteFolder(string folder, bool isDeleteSubDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            if (dir.Exists)
            {
                dir.Delete(true);
                return true;
            }

            return false;
        }
#endif

#if FILE_STREAM
        /// <summary>
        /// 파일생성 -> 아스키코드 쓰기(저장) -> 읽기
        /// </summary>
        /// <example>
        ///  FileMode.Append : 파일이 존재하면 열고 EOF를 찾음. 만약 존재하지 않으면 새파일 생성. FileAccess.Write와 함께 사용.
        ///  FileMode.Create : 파일이 없으면 새파일 생성하고 존재하면 기존파일 덮어쓰기        ==> (새파일생성 또는 기존파일덮어쓰기)
        ///  FileMode.CreateNew : 파일이 없으면 새파일 생성하고 존재하면 IOException 예외발생  ==> (새파일생성만)
        ///  FileMode.Open : 지정파일 열기
        ///  FileMdoe.OpenOrCreate : 지정파일 열기. 존재하지 않으면 새파일 생성
        ///  
        ///  FileAccess.Read : 읽기전용 열기
        ///  FileAccess.ReadWrite : 읽기/쓰기 형태로 열기
        ///  FileAccess.Write : 쓰기전용 열기
        ///  
        ///  FileShare.None : 현재 파일 공유 거부
        ///  FileShare.Read : 현재 파일 연속적 열기요청 허용.
        ///  FileShare.Read/Write : 현재 파일 연속적 읽기/쓰기 형태의 열기요청 허용.
        ///  FileShare.Write : 현재 파일에 대해 연속적 쓰기요청 허용.
        /// </example>        
        /// <param name="fileName">example.txt</param>
        private void CreateAsciiFileByFileStream(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            for(int i=1; i<=127; i++)
            {
                file.WriteByte(Convert.ToByte(i));
            }

            file.Close();

            StringBuilder sb = new StringBuilder();

            using(file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                for(int i=0; i<file.Length; i++)
                {
                    sb.Append(Convert.ToChar(file.ReadByte()));
                }
            }
        }
#endif

#if BUFFERED_STREAM
        /// <summary>
        /// [권장] BufferedStream 을 함께 사용하여 파일생성 -> 아스키코드 쓰기(저장) -> 읽기
        /// </summary>
        /// <param name="fileName"></param>
        private void CreateAsciiFileByBufferedStream(string fileName)
        {
            byte[] data = new byte[127];
            for (int i = 1; i < 128; i++)
            {
                data[i] = (byte)(i);
            }

            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            BufferedStream buffer = new BufferedStream(file);
            buffer.Write(data, 0, data.Length);
            buffer.Close();

            using(buffer = new BufferedStream(file))
            {
                data = new byte[127];
                buffer.Read(data, 0, 127);
            }
        }
#endif

#if MEMORY_STREAM
        private void ExamMemoryStream(string str)
        {
            MemoryStream ms = new MemoryStream();
            ms.Capacity = 8;
            ms.Position = 0;

            byte[] data = Encoding.Default.GetBytes(str);
            ms.Write(data, 0, data.Length);     // 메모리버퍼에 쓰기

            ms.Position = 3;
            ms.WriteByte((byte)65);             // 메모리버퍼의 4번째(인덱스3) 위치에 쓰기 ==> INSERT

            data = ms.GetBuffer();              // 메모리버퍼의 내용 byte 배열로 반환

            MessageBox.Show($"메모리스트림내용: {Encoding.Default.GetString(data)}", "메모리스트림");
        }


#endif


        /// <summary>
        /// 암호화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncryptData_Click(object sender, EventArgs e)
        {
#if CRYPTO_STREAM

            // 스트림 열기
            FileStream fsNormal = new FileStream(FILE_NORMAL, FileMode.Open, FileAccess.Read);
            FileStream fsCrypto = new FileStream(FILE_CRYPTO, FileMode.OpenOrCreate, FileAccess.Write);

            // 출력대상 파일 초기화
            fsCrypto.SetLength(0);

            byte[] data = new byte[100];
            long fileSize =fsNormal.Length;
            long lenRead = 0;
            int len = 0;

            // DES 대칭 암호화 알고리즘
            DES desProvider = new DESCryptoServiceProvider();

            // 암호화 스트림 객체
            CryptoStream cs = new CryptoStream(fsCrypto
                                             , desProvider.CreateEncryptor(DES_KEY, DES_IV)
                                             , CryptoStreamMode.Write);

            // 100바이트 단위로 암호화
            while(lenRead < fileSize)
            {
                len = fsNormal.Read(data, 0, 100);
                cs.Write(data, 0, len);
                lenRead += len;
            }

            // 스트림 닫기
            cs.Close();
            fsCrypto.Close();
            fsNormal.Close();

#endif
        }

        /// <summary>
        /// 복호화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypto_Click(object sender, EventArgs e)
        {
#if CRYPTO_STREAM

            // 스트림 열기
            FileStream fsCrypto = new FileStream(FILE_CRYPTO, FileMode.Open, FileAccess.Read);
            FileStream fsDecrypto = new FileStream(FILE_DECRYPTO, FileMode.OpenOrCreate, FileAccess.Write);

            // 출력대상 파일 초기화
            fsDecrypto.SetLength(0);

            byte[] data = new byte[100];
            long fileSize = fsCrypto.Length;
            long lenRead = 0;
            int len = 0;

            // DES 대칭 암호화 알고리즘
            DES desProvider = new DESCryptoServiceProvider();

            // 복호화 스트림 객체
            CryptoStream cs = new CryptoStream(fsDecrypto
                                             , desProvider.CreateDecryptor(DES_KEY, DES_IV)
                                             , CryptoStreamMode.Write);

            // 100바이트 단위로 복호화
            while(lenRead < fileSize)
            {
                len = fsCrypto.Read(data, 0, 100);
                cs.Write(data, 0, len);
                lenRead += len;
            }

            // 스트림 닫기
            cs.Close();
            fsDecrypto.Close();
            fsCrypto.Close();

#endif
        }




    }


#if SERIALIZE
    [Serializable]
    class Human
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        [NonSerialized]
        private float m_Temp;

        public Human(string name, int age) : this(name, age, 1.2f) { }
        public Human(string name, int age, float temp)
        {
            Name = name;
            Age = age;
            m_Temp = temp;
        }

        public override string ToString()
        {
            m_Temp++;
            return String.Format("이름: {0}, 나이: {1}", Name, Age);
        }
    }
#else
    class Human
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        private float m_Temp;

        public Human(string name, int age) : this(name, age, 1.2f) { }
        public Human(string name, int age, float temp)
        {
            Name = name;
            Age = age;
            m_Temp = temp;
        }

        public override string ToString()
        {
            m_Temp++;
            return String.Format("이름: {0}, 나이: {1}", Name, Age);
        }

        /// <summary>
        /// 이진데이터 저장
        ///   + Write(데이터) : 데이터타입별로 오버로딩되어 있어 타입의 길이만큼 스트림 저장 
        /// </summary>
        /// <param name="bw"></param>
        public void Write(BinaryWriter bw)
        {
            bw.Write(Name);
            bw.Write(Age);
        }

        /// <summary>
        /// 저장한 순서대로 복구 (순서중요)
        ///   + 객체가 없는 상태에서 객체를 생성해야 하므로 반드시 static
        ///   + ReadXXX : 데이터타입의 길이만큼 읽어들인 후 해당 타입으로 캐스팅해서 리턴
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static Human Read(BinaryReader br)
        {
            return new Human(br.ReadString(), br.ReadInt32());
        }
    }
#endif
}
