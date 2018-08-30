using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppFTP
{
    /// <summary>
    /// 파일 전송 클래스
    /// </summary>
    public class FileTransfer
    {
        private const int BUFFER = 4096;
        private const int FTP_PORT = 7500;

        private MainWindow m_wnd = null;
        private Socket m_server = null;
        private Socket m_client = null;
        /// <summary>
        /// 원격지로부터 메시지를 받는 스레드
        /// </summary>
        private Thread m_thread = null;
        private string m_clientIP = null;
        public FileInfo ReceiveFileInfo { get; set; }

        /// <summary>
        /// [파일전송메시지] 전송할 파일정보
        /// </summary>
        private const string CTOC_FILE_TRANS_INFO = "CTOC_FILE_TRANS_INFO";
        /// <summary>
        /// [파일전송메시지] 파일전송 수락
        /// </summary>
        private const string CTOC_FILE_TRANS_YES = "CTOC_FILE_TRANS_YES";
        /// <summary>
        /// [파일전송메시지] 파일전송 거부
        /// </summary>
        private const string CTOC_FILE_TRANS_NO = "CTOC_FILE_NO";

        public FileTransfer(MainWindow wnd)
        {
            m_wnd = wnd;
        }

        /// <summary>
        /// 파일서버 시작
        /// </summary>
        public void StartFTPServer()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, FTP_PORT);
                m_server = new Socket(AddressFamily.InterNetwork
                                    , SocketType.Stream
                                    , ProtocolType.Tcp);
                m_server.Bind(ipep);
                m_server.Listen(10);

                m_wnd.AddMsg("파일 서버 시작 ...");

                m_client = m_server.Accept();

                IPEndPoint remoteEP = (IPEndPoint)m_client.RemoteEndPoint;
                m_clientIP = remoteEP.Address.ToString();
                m_wnd.AddMsg($"{m_clientIP} 접속 ...");

                m_thread = new Thread(new ThreadStart(Receive));
                m_thread.IsBackground = true;
                m_thread.Start();
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"[서버시작오류] {ex.Message}");
            }
        }

        /// <summary>
        /// 파일서버 중지
        /// </summary>
        public void StopFTPServer()
        {
            try
            {
                if(m_client != null)
                {
                    if (m_client.Connected) m_client.Close();
                    if (m_thread.IsAlive) m_thread.Abort();
                }

                m_server.Close();
                m_wnd.AddMsg("파일서버 종료 ...");
            }
            catch (Exception ex)
            {
                m_wnd.AddMsg($"[서버종료오류] {ex.Message}");
            }
        }

        /// <summary>
        /// 파일서버 연결시도
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns>연결 성공여부</returns>
        public bool Connect(string serverIP)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(serverIP), FTP_PORT);
                m_client = new Socket(AddressFamily.InterNetwork
                                    , SocketType.Stream
                                    , ProtocolType.Tcp);
                m_client.Connect(ipep);
                m_wnd.AddMsg($"{serverIP} 서버에 접속 성공 ...");
                m_clientIP = serverIP;

                m_thread = new Thread(new ThreadStart(Receive));
                m_thread.IsBackground = true;
                m_thread.Start();

                return true;
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 파일서버 연결해제
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if(m_client != null)
                {
                    if (m_client.Connected) m_client.Close();
                    if (m_thread.IsAlive) m_thread.Abort();
                }

                m_wnd.AddMsg("파일서버 연결 종료!");
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"[서버연결해제오류: {ex.Message}");
            }
        }

        /// <summary>
        /// 원격지로부터 메시지 받기
        /// </summary>
        public void Receive()
        {
            try
            {
                while(m_client != null && m_client.Connected)
                {
                    byte[] data = ReceiveData();
                    string msg = Encoding.Default.GetString(data);
                    string[] token = msg.Split('\a');

                    switch (token[0])
                    {
                        case CTOC_FILE_TRANS_INFO:
                            FileInfo(token[1], Convert.ToInt64(token[2].Trim()));
                            break;

                        case CTOC_FILE_TRANS_YES:
                            long currentSize = Convert.ToInt64(token[1].Trim());
                            SendFileData(ReceiveFileInfo, currentSize);
                            break;

                        case CTOC_FILE_TRANS_NO:
                            m_wnd.AddMsg("상대방이 파일전송을 거부했습니다.");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"[수신오류] {ex.Message}");
            }
        }

        /// <summary>
        /// 원격지로부터 받은 이진 데이터 수신 및 반환
        /// </summary>
        /// <returns></returns>
        private byte[] ReceiveData()
        {
            try
            {
                int offset = 0;
                int size = 0;
                int leftDataSize = 0;
                int readDataSize = 0;

                byte[] dataSize = new byte[8];
                readDataSize = m_client.Receive(dataSize, 0, 8, SocketFlags.None);
                size = BitConverter.ToInt32(dataSize, 0);
                leftDataSize = size;

                byte[] data = new byte[size];
                while(offset < size)
                {
                    readDataSize = m_client.Receive(data, offset, leftDataSize, SocketFlags.None);
                    if (readDataSize == 0) break;
                    offset += readDataSize;
                    leftDataSize -= readDataSize;
                }

                return data;
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"[수신오류] {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 원격지로부터 파일 수신
        /// </summary>
        /// <param name="fs">수신대상 파일스트림</param>
        /// <param name="fileSize">수신대상 파일 전체 크기</param>
        /// <param name="remainedSize">수신대상 파일 남은 크기</param>
        private void ReceiveFileData(FileStream fs, long fileSize, long remainedSize)
        {
            long offset = 0;
            long leftSize = remainedSize;
            int readSize = 0;

            long progressValue = 0;
            long time = 0;

            BinaryWriter writer = null;
            byte[] data = new byte[BUFFER];

            m_wnd.InitProgressBar();

            try
            {
                writer = new BinaryWriter(fs);
                if(fileSize > remainedSize)
                {
                    writer.Seek((int)(fileSize - remainedSize), SeekOrigin.Begin);
                    m_wnd.AddMsg("파일 이어받기 처리중 ...");
                    progressValue += fileSize - remainedSize;
                }

                while(offset < remainedSize)
                {
                    if(DateTime.Now.Ticks - time > 10E7)
                    {
                        time = DateTime.Now.Ticks;
                        m_wnd.SetProgressBar(progressValue + offset, fileSize);
                    }

                    if(leftSize > BUFFER)
                    {
                        readSize = m_client.Receive(data, BUFFER, SocketFlags.None);
                    }
                    else
                    {
                        readSize = m_client.Receive(data, (int)leftSize, SocketFlags.None);
                    }

                    if (readSize == 0) break;
                    writer.Write(data, 0, readSize);
                    offset += readSize;
                    leftSize -= readSize;
                }

                m_wnd.SetProgressBar(fileSize, fileSize);
                m_wnd.AddMsg("파일전송완료!");
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"[파일수신오류] {ex.Message}");
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        /// <summary>
        /// 원격지에서 전송한 파일정보 조회 및 파일 수신
        /// </summary>
        /// <param name="fileName">수신대상 파일명</param>
        /// <param name="fileSize">수신대상 파일크기</param>
        private void FileInfo(string fileName, long fileSize)
        {
            string msg = $"{m_clientIP} 님이 보내는 파일명: {fileName}({fileSize} byte)을 다운받으시겠습니까?";
            m_wnd.AddMsg(msg);

            if(System.Windows.MessageBox.Show(msg, "파일 전송 확인", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                Send($"{CTOC_FILE_TRANS_YES}\a{fs.Length.ToString()}");
                ReceiveFileData(fs, fileSize, fileSize - fs.Length);
                fs.Close();
            }
            else
            {
                m_wnd.AddMsg($"{m_clientIP} 님이 보낸 파일에 대해 사용자가 수신을 거부했습니다.");
                Send($"{CTOC_FILE_TRANS_NO}\a");
            }
        }

        /// <summary>
        /// 원격지로 메시지 보내기
        /// </summary>
        public void Send(string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            SendData(data);
        }

        /// <summary>
        /// 원격지로 이진데이터 보내기
        /// </summary>
        /// <param name="data">송신대상 이진데이터</param>
        private void SendData(byte[] data)
        {
            try
            {
                int offset = 0;
                int size = data.Length;
                int leftDataSize = size;
                int sendDataSize = 0;

                byte[] dataSize = new byte[4];
                dataSize = BitConverter.GetBytes(size);
                sendDataSize = m_client.Send(dataSize);

                while(offset < size)
                {
                    sendDataSize = m_client.Send(data, offset, leftDataSize, SocketFlags.None);
                    offset += sendDataSize;
                    leftDataSize -= sendDataSize;
                }
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"[송신오류] {ex.Message}");
            }
        }

        /// <summary>
        /// 원격지로 파일 보내기
        /// </summary>
        /// <param name="file">송신대상 파일정보</param>
        /// <param name="offset">송신대상 파일포인터</param>
        private void SendFileData(FileInfo file, long offset)
        {
            long fileSize = file.Length;
            long size = fileSize - offset;
            long count = size / BUFFER;
            long remainedByte = size % BUFFER;

            long index = 0;
            long progressValue = 0;
            long time = 0;

            FileStream fs = null;
            BinaryReader reader = null;

            m_wnd.InitProgressBar();

            try
            {
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
                if(offset > 0)
                {
                    fs.Seek(offset, SeekOrigin.Begin);
                    m_wnd.AddMsg("파일 이어보내기 처리중 ...");
                    progressValue += offset;
                }

                reader = new BinaryReader(fs);
                byte[] data = new byte[BUFFER];

                while(index < count)
                {
                    if(DateTime.Now.Ticks - time > 10E7)
                    {
                        time = DateTime.Now.Ticks;
                        m_wnd.SetProgressBar(progressValue + index * BUFFER, fileSize);
                    }
                    reader.Read(data, 0, BUFFER);
                    m_client.Send(data, 0, BUFFER, SocketFlags.None);
                    index++;
                }

                if(remainedByte > 0)
                {
                    reader.Read(data, 0, (int)remainedByte);
                    m_client.Send(data, 0, (int)remainedByte, SocketFlags.None);
                }

                m_wnd.SetProgressBar(fileSize, fileSize);
                m_wnd.AddMsg("파일전송완료!");
            }
            catch(Exception ex)
            {
                m_wnd.AddMsg($"[파일전송오류] {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                if (fs != null) fs.Close();
            }
        }
    }
}
