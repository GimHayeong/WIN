using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfAppPhotoCooperative.BLL
{
    public class ImageFile
    {
        public string Path { get; set; }
        public Uri TheUri { get; set; }
        public BitmapFrame Image { get; set; }

        public ImageFile(string path)
        {
            Path = path;
            TheUri = new Uri(Path);
            Image = BitmapFrame.Create(TheUri);
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
