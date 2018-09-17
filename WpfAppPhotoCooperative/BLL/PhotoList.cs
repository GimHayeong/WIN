using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPhotoCooperative.BLL
{
    public class PhotoList : ObservableCollection<ImageFile>
    {
        private DirectoryInfo m_directoryInfo;
        public string Path
        {
            get { return m_directoryInfo.FullName; }
            set
            {
                m_directoryInfo = new DirectoryInfo(value);
                Update();
            }
        }

        public DirectoryInfo Directory
        {
            get { return m_directoryInfo; }
            set
            {
                m_directoryInfo = value;
                Update();
            }
        }

        public PhotoList() { }

        public PhotoList(string path) : this(new DirectoryInfo(path)) { }

        public PhotoList(DirectoryInfo directoryInfo)
        {
            m_directoryInfo = directoryInfo;
            Update();
        }

        private void Update()
        {
            foreach (FileInfo file in m_directoryInfo.GetFiles("*.jpg"))
            {
                Add(new ImageFile(file.FullName));
            }
        }
    }
}
