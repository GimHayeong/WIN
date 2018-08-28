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

namespace WpfAppNetClient
{
    /// <summary>
    /// TimeClientWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TimeClientWind : Window
    {
        private const int SERVER_PORT = 7007;
        public TimeClientWind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                client = new TcpClient(tbxTimeServerIP.Text.Trim(), SERVER_PORT);
                stream = client.GetStream();
                reader = new StreamReader(stream);
                DateTime data = DateTime.Parse(reader.ReadLine());
                tbxCurrentTime.Text = data.ToLongTimeString();
            }
            catch (SocketException) { }
            catch (Exception) { }
            finally
            {
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (client != null) client.Close();
            }
        }
    }
}
