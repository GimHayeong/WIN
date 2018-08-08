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

namespace WpfApp
{
    /// <summary>
    /// PagHistory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PagHistory : Page
    {
        public int PhotoId { get; private set; }

        public PagHistory()
        {
            InitializeComponent();

            if(Application.Current.Properties["photoid"] != null)
            {
                PhotoId = (int)Application.Current.Properties["photoid"];
                this.Content = PhotoId;
            }
        }

        public PagHistory(int photoId) 
            : this()
        {
            PhotoId = photoId;

            this.Content = PhotoId;
        }
    }
}
