using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3DPhotoGallery.ViewModel
{
    public class Photo
    {
        public string Name { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Size { get; private set; }
        public string Path { get; private set; }
        public string FullPath
        {
            get { return System.IO.Path.Combine(Path, Name); }
        }

        public Photo(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            Size = (file.Length / 1024).ToString("N0") + " KB";
            DateTime = file.LastWriteTime;
            Name = file.Name;
            Path = file.DirectoryName;
        }

        public override string ToString()
        {
            return FullPath;
        }
    }
}
