using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppWebBrowser
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Navigate();
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Navigate();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnBack":
                        if (webView.CanGoBack) webView.GoBack();
                        break;

                    case "btnHome":
                        GoHome();
                        break;

                    case "btnForward":
                        if (webView.CanGoForward) webView.GoForward();
                        break;

                    case "btnStop":
                        if (webView.CanGoBack)
                        {
                            webView.GoBack();
                        }
                        else
                        {
                            webView.Navigate("about:blank");
                        }
                        break;

                    case "btnRefresh":
                        webView.Refresh();
                        break;

                    case "btnGo":
                        Navigate();
                        break;
                }
            }
        }

        private void Navigate()
        {
            if (String.IsNullOrWhiteSpace(tbxUrl.Text)) return;
            //webView.Navigate(tbxUrl.Text.Trim());

            Uri uri = new Uri(tbxUrl.Text.Trim(), UriKind.RelativeOrAbsolute);

            Navigate(uri);
        }

        private void Navigate(Uri uri)
        {
            if (!uri.IsAbsoluteUri) return;

            webView.Navigate(uri);
        }

        private void GoHome()
        {
            webView.Navigate(Registry.GetValue(@"HKEY_CURRENT_USER\software\Microsoft\Internet Explorer\Main", "Start Page", "").ToString());
        }

        private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            Title = e.Uri.ToString();
        }

        

    }
}
