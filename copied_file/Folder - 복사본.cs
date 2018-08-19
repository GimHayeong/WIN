using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery.ViewModel
{
    public class ViewModel
    {
        public static Folders FolderList { get; set; }

        public ViewModel()
        {
            if(FolderList == null) {
                FolderList = new Folders();
            }
        }
    }

    public class Folders : ObservableCollection<Folder>
    {
        private const string FILE_PATH = "myFile";

        public Folders() : base()
        {

            this.Items.Clear();
            this.Add(new Folder { ID = 1, FolderPath = "Favorites", ParentID = 0 });
            GetFavoriteList();

            //GetSubFolderList(Directory.GetLogicalDrives().First(), FolderList.Count + 1, 0);

            DirectoryInfo dir;
            int id;

            foreach (var d in Directory.GetLogicalDrives())
            {
                dir = new DirectoryInfo(d);
                id = this.Count + 1;
                this.Add(new Folder { ID = id, FolderPath = dir.ToString(), ParentID = 0 });

                if (dir.GetDirectories().Count() > 0)
                {
                    GetSubFolderList(dir, id);
                }
            }
        }

        


        public void GetFavoriteList()
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, FileMode.OpenOrCreate, isfile))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        this.Add(new Folder { ID = this.Count + 1, FolderPath = line, ParentID = 1 });
                        line = sr.ReadLine();
                    }
                }
            }

            var query = from f in this
                        where f.ParentID == 1
                        select f;

            if (query.Count() == 0)
            {
                this.Add(new Folder { ID = this.Count + 1, FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), ParentID = 1 });
            }
        }

        public void SetFavoriteList(string[] favorites)
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, System.IO.FileMode.Create, isfile))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var filePath in this.Where(o => o.ID == 1))
                    {
                        sw.WriteLine(filePath);
                    }
                }
            }
        }

        /// <summary>
        /// 해당 폴더의 하위 폴더가 TreeViewControl의 데이터소스에 로드되어 있지 않은 경우, 하위 폴더 로드
        /// </summary>
        /// <param name="parentPath"></param>
        public Folders GetSubFolderList(string parentPath)
        {
            int parentId = this.Where(o => o.FolderPath == parentPath).Select(o => o.ID).First();
            if (parentId < 2) return null;

            try
            {
                foreach (var d in Directory.GetDirectories(parentPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(d);

                    if (this.Select(o => o.FolderPath == d).Count() == 0)
                    {
                        int id = this.Count + 1;
                        this.Add(new Folder { ID = id, FolderPath = d, ParentID = parentId });
                    }

                    if (dir.GetDirectories().Count() > 0)
                    {
                        GetSubFolderList(d);
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { }

            return this;
        }

        private void GetSubFolderList(DirectoryInfo dirParent, int parentId)
        {
            if (dirParent.Parent != null && dirParent.Parent.Parent != null && dirParent.Parent.Parent.Parent != null) return;

            int id;
            foreach (var d in Directory.GetDirectories(dirParent.FullName, "*.*", SearchOption.TopDirectoryOnly))
            {
                if (d.IndexOf('$') > 0) continue;

                DirectoryInfo folder = new DirectoryInfo(d);
                id = this.Count + 1;

                this.Add(new Folder { ID = id, FolderPath = folder.ToString(), ParentID = parentId });

                try
                {
                    if (folder.GetDirectories().Count() > 0)
                    {
                        GetSubFolderList(folder, id);
                    }
                }
                catch { }
            }
        }
    }



    public class Folder
    {
        public int ID { get; set; }
        public string FolderPath { get; set; }
        public int ParentID { get; set; }
    }


#region [ FOLDER ]

    //public class Folder
    //{
    //    private const string FILE_PATH = "myFile";

    //    public int ID { get; set; }
    //    public string FolderPath { get; set; }
    //    public int ParentID { get; set; }
    //    private static List<Folder> m_FolderList;
    //    public static List<Folder> FolderList
    //    {
    //        get
    //        {
    //            if (m_FolderList == null)
    //            {
    //                m_FolderList = new List<Folder>();
    //                FolderList.Add(new Folder { ID = 1, FolderPath = "Favorites", ParentID = 0 });
    //                GetFavoriteList();

    //                //GetSubFolderList(Directory.GetLogicalDrives().First(), FolderList.Count + 1, 0);

    //                DirectoryInfo dir;
    //                int id;

    //                foreach (var d in Directory.GetLogicalDrives())
    //                {
    //                    dir = new DirectoryInfo(d);
    //                    id = m_FolderList.Count + 1;
    //                    m_FolderList.Add(new Folder { ID = id, FolderPath = dir.ToString(), ParentID = 0 });

    //                    if (dir.GetDirectories().Count() > 0)
    //                    {
    //                        GetSubFolderList(dir, id);
    //                    }
    //                }
    //            }

    //            return m_FolderList;
    //        }
    //    }



    //    public static void GetFavoriteList()
    //    {
    //        IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
    //        using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, FileMode.OpenOrCreate, isfile))
    //        {
    //            using (StreamReader sr = new StreamReader(fs))
    //            {
    //                string line = sr.ReadLine();
    //                while (line != null)
    //                {
    //                    //AddFavoritesTreeViewItem(line);
    //                    m_FolderList.Add(new Folder { ID = m_FolderList.Count + 1, FolderPath = line, ParentID = 1 });
    //                    line = sr.ReadLine();
    //                }
    //            }
    //        }

    //        var query = from f in m_FolderList
    //                    where f.ParentID == 1
    //                    select f;

    //        // 기존 즐겨찾기 목록이 없으면 MyPictures 의 이미지로 초기화
    //        //if (!trvItmFavorites.HasItems)
    //        //{
    //        //    AddFavoritesTreeViewItem(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
    //        //}
    //        if(query.Count() == 0)
    //        {
    //            m_FolderList.Add(new Folder { ID = m_FolderList.Count + 1, FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), ParentID = 1 });
    //        }

    //        //(trvFolderExplorer.Items[0] as TreeViewItem).IsSelected = true;
    //    }

    //    public static void SetFavoriteList(string[] favorites)
    //    {
    //        IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
    //        using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, System.IO.FileMode.Create, isfile))
    //        {
    //            using (StreamWriter sw = new StreamWriter(fs))
    //            {
    //                foreach (var filePath in m_FolderList.Where(o=>o.ID==1))
    //                {
    //                    sw.WriteLine(filePath);
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 해당 폴더의 하위 폴더가 TreeViewControl의 데이터소스에 로드되어 있지 않은 경우, 하위 폴더 로드
    //    /// </summary>
    //    /// <param name="parentPath"></param>
    //    public static List<Folder> GetSubFolderList(string parentPath)
    //    {
    //        int parentId = m_FolderList.Where(o => o.FolderPath == parentPath).Select(o => o.ID).First();
    //        if (parentId < 2) return null;

    //        try
    //        {
    //            foreach (var d in Directory.GetDirectories(parentPath))
    //            {
    //                DirectoryInfo dir = new DirectoryInfo(d);

    //                if(!m_FolderList.Exists(o => o.FolderPath == d))
    //                {
    //                    int id = m_FolderList.Count + 1;
    //                    m_FolderList.Add(new Folder { ID = id, FolderPath = d, ParentID = parentId });
    //                }

    //                if (dir.GetDirectories().Count() > 0)
    //                {
    //                    GetSubFolderList(d);
    //                }
    //            }
    //        }
    //        catch (UnauthorizedAccessException ex) { }
    //        catch (Exception ex) { }

    //        return m_FolderList;
    //    }

    //    private static void GetSubFolderList(DirectoryInfo dirParent, int parentId)
    //    {
    //        if (dirParent.Parent != null && dirParent.Parent.Parent != null && dirParent.Parent.Parent.Parent != null) return;

    //        int id;
    //        foreach (var d in Directory.GetDirectories(dirParent.FullName, "*.*", SearchOption.TopDirectoryOnly))
    //        {
    //            if (d.IndexOf('$') > 0) continue;

    //            DirectoryInfo folder = new DirectoryInfo(d);
    //            id = m_FolderList.Count + 1;

    //            m_FolderList.Add(new Folder { ID = id, FolderPath = folder.ToString(), ParentID = parentId });

    //            try
    //            {
    //                if (folder.GetDirectories().Count() > 0)
    //                {
    //                    GetSubFolderList(folder, id);
    //                }
    //            }
    //            catch { }
    //        }
    //    }
    //}
    #endregion

}
