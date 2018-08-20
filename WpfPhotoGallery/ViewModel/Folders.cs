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
        public DirectoryInfo FolderInfo { get; private set; }
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

        /// <summary>
        /// 손자까지 서브디렉토리 조회
        /// </summary>
        /// <param name="fullPath"></param>
        public Folder(string fullPath) 
            :this(fullPath, 1)
        {
            //FullPath = fullPath;
        }

        /// <summary>
        /// 서브디렉토리 조회하지 않음
        /// </summary>
        /// <param name="fullPath">현재폴더의 전체경로</param>
        /// <param name="depth"> 하위폴더 검색 깊이
        ///     default : 자식노드 조회하지 않음
        ///           1 : 손자 노드까지만 조회
        ///           2 : 모든 자식노드 조회
        /// </param>
        public Folder(string fullPath, int depth)
        {
            FullPath = fullPath;
            if(depth == 1)
            {
                InitData(0);
            }
            else if(depth == 2)
            {
                InitData(2);

            }
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
        private void InitData(int depth)
        {
            if (SubFolders == null)
            {
                try
                {
                    SubFolders = new ObservableCollection<Folder>();
                    foreach (var d in FolderInfo.GetDirectories())
                    {
                        Folder folder = new Folder(d.FullName, depth);
                        SubFolders.Add(folder);
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 트리뷰아이템 확장시 하위 손자폴더까지 목록에 추가
        /// </summary>
        /// <param name="parent"></param>
        public static void AddSubFolders(Folder parent)
        {
            if (parent.SubFolders == null)
            {
                try
                {
                    parent.SubFolders = new ObservableCollection<Folder>();
                    foreach (var d in parent.FolderInfo.GetDirectories())
                    {
                        Folder folder = new Folder(d.FullName, 1);
                        parent.SubFolders.Add(folder);
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
