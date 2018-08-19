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
        public Folders() : base()
        {
            this.Items.Clear();
            InitFolder();
        }

        public void InitFolder()
        {
            //DirectoryInfo dir;

            foreach (var d in Directory.GetLogicalDrives())
            {
                DirectoryInfo dir = new DirectoryInfo(d);
                Folder child = new Folder { FolderPath = dir.ToString() };

                if (dir.GetDirectories().Count() > 0)
                {
                    GetSubFolderList(child);
                }

                this.Add(child);
            }
        }


        /// <summary>
        /// 해당 폴더의 하위 폴더가 TreeViewControl의 데이터소스에 로드되어 있지 않은 경우, 하위 폴더 로드
        /// </summary>
        /// <param name="parentPath"></param>
        public void GetSubFolderList(Folder parent)
        {
            try
            {
                foreach (var d in Directory.GetDirectories(parent.FolderPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(d);

                    Folder child = new Folder { FolderPath = d };
                    parent.AddFolder(child);

                    if (dir.GetDirectories().Count() > 0)
                    {
                        GetSubFolderList(child);
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { }
        }
    }



    public class Folder : FolderBase
    {
        /// <summary>
        /// 하위 폴더 목록
        /// </summary>
        public List<Folder> Children { get; set; }
        public Folder() : base()
        {
            Children = new List<Folder>();
        }

        public void AddFolder(Folder folder)
        {
            Children.Add(folder);
        }
    }


    public class FolderBase
    {
        //public int ID { get; set; }
        public string FolderPath { get; set; }
        //public int ParentID { get; set; }

        public override string ToString()
        {
            return FolderPath;
        }
    }
}
