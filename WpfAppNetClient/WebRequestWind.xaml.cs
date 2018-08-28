using System;
using System.Collections.Generic;
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
    /// WebRequestWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WebRequestWind : Window
    {
        public WebRequestWind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                HttpWebRequest http = WebRequest.Create(tbxUrl.Text.Trim()) as HttpWebRequest;
                if(http != null)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)http.GetResponse();
                    WebHeaderCollection headers = httpResponse.Headers;

                    StringBuilder sb = new StringBuilder();
                    for(int i=0; i<headers.Count; i++)
                    {
                        sb.AppendLine($"{headers.GetKey(i)} = {headers.GetValues(i)}");
                    }
                    tbxHeaderInfo.Text = sb.ToString();
                    sb.Clear();

                    Stream stream = httpResponse.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);

                    while(reader.Peek() > -1)
                    {
                        sb.AppendLine(reader.ReadLine());
                    }
                    tbxHTML.Text = sb.ToString();
                    sb.Clear();

                    reader.Close();
                    stream.Close();
                }
            }
        }
    }
}
