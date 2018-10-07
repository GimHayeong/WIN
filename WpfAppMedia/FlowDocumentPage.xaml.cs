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

namespace WpfAppMedia
{
    /// <summary>
    /// FlowDocumentPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FlowDocumentPage : Page
    {
        public FlowDocumentPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// Paragraph : 인라인 컬렉션을 포함. 인라인(Run)을 호출해서 컨텐트를 만들고 이를 Paragraph의 Inlines 컬렉션에 추가
        /// Run : 텍스트를 좀 더 다양한 컨텐트로 만들어주는 인라인 엘리먼트
        /// </remarks>
        /// <param name="msg"></param>
        private void AddInline(string msg)
        {
            Paragraph prgp = new Paragraph(new Run(msg));
        }

        
    }
}
