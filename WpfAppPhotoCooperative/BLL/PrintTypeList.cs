using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPhotoCooperative.BLL
{
    public class PrintTypeList : ObservableCollection<PrintType>
    {
        public PrintTypeList()
        {
            Add(new PrintType("5x7 Print", 0.49));
            Add(new PrintType("Holliday Card", 1.99));
            Add(new PrintType("Sweatshirt", 19.99));
        }
    }
}
