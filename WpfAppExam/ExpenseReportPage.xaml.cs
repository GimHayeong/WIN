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

namespace WpfAppExam
{
    /// <summary>
    /// ExpenseReportPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 해당 임직원의 비용보고서
        /// </summary>
        /// <param name="data">선택한 사람의 비용보고서</param>
        public ExpenseReportPage(object data) : this()
        {
            this.DataContext = data;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridColumn col = e.Column as DataGridColumn;
            if(col != null)
            {
                switch (col.Header.ToString())
                {
                    case "경비유형":
                        break;

                    case "금액":
                        break;

                    default:
                        col.Visibility = Visibility.Hidden;
                        break;

                }
            }
        }
    }
}
