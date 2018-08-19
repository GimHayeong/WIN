using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExam.ViewModel
{
    public class Folders : ObservableCollection<Folder>
    {
        public ObservableCollection<Folder> FolderList { get; private set; }
        public Folders()
        {
            if(FolderList == null)
            {
                FolderList = new ObservableCollection<Folder>();
            }
            foreach (var dir in Directory.GetLogicalDrives())
            {
                Folder folder = new Folder(dir);
                FolderList.Add(folder);
            }
        }

    }

    public class Folder
    {
        public DirectoryInfo FolderInfo { get; set; }
        public ObservableCollection<Folder> SubFolders { get; private set; }
        public ObservableCollection<FileInfo> Files { get; private set; }
        public string FullPath
        {
            get
            {
                return FolderInfo.FullName;
            }

            set
            {
                if (Directory.Exists(value))
                {
                    FolderInfo = new DirectoryInfo(value);
                }
                else
                {
                    throw new ArgumentException("must exist", "fullPath");
                }
            }
        }

        //public Folder()
        //    : this("C:") { }

        public Folder()
        {
            if (SubFolders == null)
            {
                SubFolders = new ObservableCollection<Folder>();
            }
            foreach (var dir in Directory.GetLogicalDrives())
            {
                Folder folder = new Folder(dir);
                SubFolders.Add(folder);
            }
        }

        public Folder(string fullPath)
        {
            FullPath = fullPath;
            InitData();
        }

        public override string ToString()
        {
            int idx = FullPath.LastIndexOf('\\');
            if (FullPath.Length > 3)
            {
                return FullPath.Substring(idx + 1);
            }
            else
            {
                return FullPath;
            }
        }

        private void InitData()
        {
            if (Files == null)
            {
                Files = new ObservableCollection<FileInfo>();

                foreach (var f in FolderInfo.GetFiles())
                {
                    Files.Add(f);
                }
            }

            if (SubFolders == null)
            {
                try
                {
                    SubFolders = new ObservableCollection<Folder>();
                    foreach (var d in FolderInfo.GetDirectories())
                    {
                        Folder folder = new Folder(d.FullName);
                        SubFolders.Add(folder);
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
            }
        }
    }
}
