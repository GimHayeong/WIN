using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    /// WebInfoWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WebInfoWind : Window
    {
        public WebInfoWind()
        {
            InitializeComponent();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxUrl.Text)) return;

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(tbxUrl.Text.Trim(), 80);
                }
                catch
                {
                    MessageBox.Show("서버에 접속할 수 없습니다.");
                    tbxUrl.Focus();
                    tbxUrl.SelectAll();
                    return;
                }

                using (Stream stream = client.GetStream())
                {
                    string msg = "GET /index.html HTTP/1.0\r\n\n";
                    byte[] data = Encoding.Default.GetBytes(msg.ToCharArray());
                    stream.Write(data, 0, data.Length);
                    stream.Flush();

                    byte[] response = new byte[256];
                    int size = stream.Read(response, 0, response.Length);
                    tbxInfo.AppendText($"받은 바이트수: {size} Byte \r\n");
                    tbxInfo.AppendText($"{tbxUrl.Text.Trim()}서버에서 보내준 메시지 --->\r\n\r\n");
                    tbxInfo.AppendText(Encoding.Default.GetString(response));
                }
            }
        }

        private void UrlTextBox_KenDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformClickByRaiseEvent();
            }
        }

        /// <summary>
        /// RaiseEvent 사용하여 OnClick 메서드 호출
        /// </summary>
        private void PerformClickByRaiseEvent()
        {
            btnSearch.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        /// <summary>
        /// Reflection 을 사용하여 OnClick 메서드 호출
        /// </summary>
        private void PerformClickByReflection()
        {
            typeof(System.Windows.Controls.Primitives.ButtonBase)
                .GetMethod("OnClick", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(btnSearch, new object[0]);
        }

        /// <summary>
        /// 버튼이 눌린 효과
        /// </summary>
        private void PressedButtonEffect()
        {
            //typeof(Button).GetMethod("set_IsPressed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(btnSearch, new object[] { true });
        }
    }

}
