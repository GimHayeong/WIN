//#define SERIALIZE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    /// <summary>
    /// 스트림 : 바이트의 연속. 파일 뿐 아니라 메모리나 네트워크로 입출력되는 데이터까지 포함
    ///   + FileStream : 바이트 배열로 입출력
    ///   + StreamReader(~ Writer) : 입출력 과정에서 자동으로 문자열 변환
    ///   + BinaryReader(~ Writer) : 클래스나 임의의 이진 데이터 입출력. 입출력시 스트림을 인수로 요구. 
    ///   
    ///   + BinaryFormatter : 이진 형태로 시리얼라이즈 수행
    ///   + SoapFormatter : XML 방식으로 시리얼라이즈 수행
    ///   
    ///   ==> 시리얼라이즈 : 객체를 스트림에 저장 (네트워크나 파일은 일차원 형태의 배열만 전달 가능하므로 일차원의 배열형태로 만드는 과정)
    ///   ==> 디시리얼라이즈 : 스트림으로부터 읽은 데이터를 다시 객체의 형태로 입체적으로 조립
    ///   
    /// </summary>
    public partial class FileStreamForm : Form
    {
#if SERIALIZE
        private readonly string m_SerializedBinaryFilePath = @"D:\downloads\temp\Gildong_Serialized.bin";
        private readonly string m_SerializedXmlFilePath = @"D:\downloads\temp\Gildong_Soap.bin";
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
#else
            if (grbxSerialize.HasChildren)
            {
                grbxSerialize.Enabled = false;
            }
#endif
            txtData.Text = Gildong.Name;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
#if SERIALIZE

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
            } catch (FileNotFoundException ex)
            {
                MessageBox.Show("지정한 파일이 없습니다.");
            }
#endif
        }

        private void btnWriteString_Click(object sender, EventArgs e)
        {
#if SERIALIZE

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirectory_Click(object sender, EventArgs e)
        {
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
