//#define NAVI_INSTANCE
//#define NAVI_INSTANCE_ByPARAMS
#define NAVI_INSTANCE_ByPROP
//#define NAVI_URI
//#define NAVI_URI_ByPARAMS
//#define NAVI_HTML
//#define NAVI_CONTENT
//#define NAVI_SOURCE
//#define NAVI_LINK
//#define NAVI_PAGEFUNCTION
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
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

namespace WpfApp
{
    /// <summary>
    /// NaviWin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NaviWin : NavigationWindow
    {
        public NaviWin()
        {
            InitializeComponent();
#if NAVI_INSTANCE_ByPARAMS || NAVI_URI_ByPARAMS
            this.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
#endif
        }

        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if(e.ExtraData != null)
            {
                int photoId = (int)e.ExtraData;
            }
        }

        /// <summary>
        /// 현재 페이지 새로고침
        /// </summary>
        private void Reload()
        {
            this.NavigationService.Refresh();
        }

        private void NextPage()
        {
#if NAVI_INSTANCE
            PagHistory nextPage = new PagHistory();
            this.NavigationService.Navigate(nextPage);
#elif NAVI_INSTANCE_ByPARAMS
            //int photoId = 10;
            //PagHistory nextPage = new PagHistory();
            //this.NavigationService.Navigate(nextPage, photoId);

            PagHistory nextPage = new PagHistory(10);
            this.NavigationService.Navigate(nextPage);
#elif NAVI_INSTANCE_ByPROP
            Application.Current.Properties["photoid"] = 15;
            this.NavigationService.Navigate(new PagHistory());
#elif NAVI_URI
            this.NavigationService.Navigate(new Uri("PageHistory.xaml", UriKind.Relative));
#elif NAVI_URI_ByPARAMS
            int photoId = 10;
            this.NavigationService.Navigate(new Uri("PageHistory.xaml", UriKind.Relative), photoId);
#elif NAVI_HTML
            this.NavigationService.Navigate(new Uri("http://www.daum.net"));
#elif NAVI_CONTENT
            PagHistory nextPage = new PagHistory();
            this.NavigationService.Content = nextPage;
#elif NAVI_SOURCE
            this.NavigationService.Source = new Uri("PageHistory.xaml", UriKind.Relative);
#elif NAVI_LINK
            Hyperlink link = new Hyperlink();
            link.NavigateUri = new Uri("PageHistory.xaml");

            TextBlock tbk = new TextBlock();
            tbk.Text = $"Click {link} to view the photo.";
#elif NAVI_PAGEFUNCTION

#endif
        }

        private void NavigationWindow_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            
        }
    }
}
