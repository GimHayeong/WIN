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

namespace WpfPhotoGallery
{
    /// <summary>
    /// PagPhotoGallery.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PagPhotoGallery : Page
    {
        public PagPhotoGallery()
        {
            InitializeComponent();
        }

        private void Navi()
        {
            this.NavigationService.Refresh();
        }

        private void NaviButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnPrev":
                        pgFncAbout prevPage = new pgFncAbout();
                        this.NavigationService.Navigate(prevPage);
                        prevPage.Return += PrevPage_Return;
                        break;

                    case "btnNext":
                        //PagHistory nextPage = new PagHistory(10);
                        //this.NavigationService.Navigate(nextPage);

                        //타입안정성 취약 ==> 대안 PageFunction<T> 를 상속받은 페이지
                        //Application.Current.Properties["photoid"] = 15;
                        //this.NavigationService.Navigate(new PagHistory());
                        break;
                }
            }

        }

        private void PrevPage_Return(object sender, ReturnEventArgs<string> e)
        {
            string returnValue = e.Result;
            MessageBox.Show(returnValue);
        }
    }
}
