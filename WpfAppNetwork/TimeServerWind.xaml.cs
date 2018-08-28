using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppNetwork
{
    /// <summary>
    /// TimeServerWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TimeServerWind : Window
    {
        public NetworkStream NetStream { get; set; }
        public const string SERVER_IP = "127.0.0.1";
        public const int SERVER_PORT = 7007;

        private TcpListener m_listener = null;
        private StreamWriter m_writer = null;
        private Thread m_thread = null;

        public TimeServerWind()
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
                    case "btnStart":
                        m_thread = new Thread(new ThreadStart(StartServer));
                        m_thread.Start();

                        btnStart.IsEnabled = false;
                        btnStop.IsEnabled = true;

                        break;

                    case "btnStop":
                        StopServer();
                        try
                        {
                            m_thread.Abort();

                            btnStart.IsEnabled = true;
                            btnStop.IsEnabled = false;
                        }
                        catch (SocketException) { }
                        catch { }
                        break;
                }
            }
        }

        private void StartServer()
        {
            try
            {
                m_listener = new TcpListener(IPAddress.Parse(SERVER_IP), SERVER_PORT);
                m_listener.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"에러메시지: {ex.StackTrace}");
            }

            Socket client = m_listener.AcceptSocket();
            if (client.Connected)
            {
                NetStream = new NetworkStream(client);
                m_writer = new StreamWriter(NetStream);
                m_writer.WriteLine(DateTime.Now);
                m_writer.Flush();
            }

        }

        private void StopServer()
        {
            try
            {
                m_listener.Stop();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"에러메시지: {ex.StackTrace}");
            }
        }
    }
}
