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

namespace WpfAppWebInfo
{
    /// <summary>
    /// 특정 웹페이지의 HTML 코드를 읽어와 출력
    /// </summary>
    public partial class WebReaderWind : Window
    {
        public WebReaderWind()
        {
            InitializeComponent();
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnRead.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxUrl.Text)) return;

            WebRequest request = WebRequest.Create(tbxUrl.Text.Trim());
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            StringBuilder sb = new StringBuilder();

            while(reader.Peek() > -1)
            {
                sb.AppendLine(reader.ReadLine());
            }

            reader.Close();
            stream.Close();
            response.Close();
            request.Abort();

            tbxInfo.Text = sb.ToString();
        }
    }
}
