using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppNetClient
{
    /// <summary>
    /// WebClientWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WebClientWind : Window
    {
        public WebClientWind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnDownloadData":
                        DownloadDataForWebClient();
                        break;

                    case "btnDownloadFile":
                        DownloadFileForWebClient();
                        break;

                    case "btnDownloadHeader":
                        DownloadHeaderForWebClient();
                        break;

                    case "btnOpenWrite":
                        SendDataForOpenWrite();
                        break;

                    case "btnUploadFile":
                        UploadFileForWebClient();
                        break;

                    case "btnUploadValues":
                        SendGetDataForUploadValuse();
                        break;
                }
            }
        }


        private void DownloadDataForWebClient()
        {
            WebClient web = new WebClient();
            byte[] data = web.DownloadData(tbxUrl.Text.Trim());
            tbkResult.Text = Encoding.Default.GetString(data);
        }

        private void DownloadFileForWebClient()
        {
            WebClient web = new WebClient();
            web.DownloadFile(tbxUrl.Text.Trim(), tbxFileName.Text.Trim());
        }

        private void DownloadHeaderForWebClient()
        {
            WebClient web = new WebClient();
            byte[] data = web.DownloadData(tbxUrl.Text.Trim());
            WebHeaderCollection headers = web.ResponseHeaders;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(tbxUrl.Text.Trim() + " 페이지 HTTP 정보 출력");
            sb.AppendLine("헤더 정보 갯수: " + headers.Count);
            for(int i=0; i<headers.Count; i++)
            {
                sb.AppendLine($"{headers.GetKey(i)} = {headers.Get(i)}");
            }

            tbkResult.Text = sb.ToString();
        }

        /// <summary>
        /// Post 방식으로 웹페이지에 값을 전송하고 결과를 받음
        /// </summary>
        private void SendDataForOpenWrite()
        {
            string postData = tbxSearch.Text.Trim();
            byte[] data = Encoding.ASCII.GetBytes(postData);

            WebClient web = new WebClient();
            
            Stream streamPost = web.OpenWrite(tbxUrl.Text.Trim());
            StreamWriter writer = new StreamWriter(streamPost);
            //writer.WriteLine(postData);
            streamPost.Write(data, 0, data.Length);

            writer.Close();
            streamPost.Close();

            tbkResult.Text = Encoding.Default.GetString(data);
        }

        /// <summary>
        /// 파일을 특정 웹서버에 업로드
        /// </summary>
        private void UploadFileForWebClient()
        {
            WebClient web = new WebClient();
            web.UploadFile(tbxUrl.Text.Trim(), tbxFileName.Text.Trim());
        }

        /// <summary>
        /// Get 방식으로 웹페이지에 값을 전송하고 결과를 받음
        /// </summary>
        private void SendGetDataForUploadValuse()
        {
            string addr = "http://dic.daum.net/search.do";

            NameValueCollection nvc = new NameValueCollection();
            //nvc.Add("id", tbxID.Text.Trim());
            //nvc.Add("pwd", tbxPwd.Text.Trim());
            //nvc.Add("name", tbxName.Text.Trim());
            nvc.Add("q", "어린이 영화");

            WebClient web = new WebClient();
            byte[] data = web.UploadValues(addr, nvc);

            tbkResult.Text = Encoding.UTF8.GetString(data);
        }
    }
}
