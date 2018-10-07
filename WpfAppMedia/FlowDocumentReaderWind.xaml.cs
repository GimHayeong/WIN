using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppMedia
{
    /// <summary>
    /// FlowDocumentReaderWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FlowDocumentReaderWind : Window
    {
        FileStream m_stream;

        public FlowDocumentReaderWind()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            AnnotationService service = AnnotationService.GetService(reader);
            if (service == null)
            {
                m_stream = new FileStream("storage.xml", FileMode.OpenOrCreate);
                service = new AnnotationService(reader);
                AnnotationStore store = new XmlStreamStore(m_stream);
                store.AutoFlush = true;
                service.Enable(store);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            AnnotationService service = AnnotationService.GetService(reader);
            if(service != null && service.IsEnabled)
            {
                service.Disable();
                m_stream.Close();
            }
        }
    }
}
