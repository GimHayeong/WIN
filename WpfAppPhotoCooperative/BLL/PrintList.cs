using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfAppPhotoCooperative.BLL
{
    public class PrintList : ObservableCollection<PrintBase> { }

    public class Print : PrintBase
    {
        public Print(BitmapSource photo) : base(photo, "5x7 Print", 0.49) { }
    }

    public class GreetingCard : PrintBase
    {
        public GreetingCard(BitmapSource photo) : base(photo, "Greeting Card", 1.99) { }
    }

    public class SShirt : PrintBase
    {
        public SShirt(BitmapSource photo) : base(photo, "Sweatshirt", 19.99) { }
    }
}
