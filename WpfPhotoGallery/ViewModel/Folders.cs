using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery.ViewModel
{
    public class Folders : ObservableCollection<Folder>
    {
        public ObservableCollection<Folder> FolderList { get; private set; }

        public Folders()
        {

            if (FolderList == null)
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
        /// <summary>
        /// 현재 폴더 정보 객체
        /// </summary>
        public DirectoryInfo FolderInfo { get; set; }
        /// <summary>
        /// 하위 폴더 목록
        /// </summary>
        public ObservableCollection<Folder> SubFolders { get; private set; }

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

        /// <summary>
        /// 하위폴더 목록 추가
        /// </summary>
        private void InitData()
        {
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
