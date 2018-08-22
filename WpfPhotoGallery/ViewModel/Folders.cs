using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery.ViewModel
{
    public class Folders : ObservableCollection<Folder>
    {
        public static ObservableCollection<Folder> FolderList { get; private set; }

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
        private const string ROOT_FAVORITE = "Favorites";
        private const string ROOT_FOLDERS = "Folders";
       
        /// <summary>
        /// 현재 폴더 정보 객체
        /// </summary>
        public DirectoryInfo FolderInfo { get; private set; }
        /// <summary>
        /// 하위 폴더 목록
        /// </summary>
        public ObservableCollection<Folder> SubFolders { get; private set; }
        public bool IsFavorite { get; private set; }

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
                else if(value == ROOT_FOLDERS)
                {
                    FolderInfo = new DirectoryInfo(ROOT_FOLDERS);
                }
                else if(value == ROOT_FAVORITE)
                {
                    FolderInfo = new DirectoryInfo(ROOT_FAVORITE);
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
            : this(fullPath, 1) { }

        public Folder(string fullPath, int depth) 
            : this(fullPath, depth, false) { }
        /// <summary>
        /// depth 가 1또는 2가 아니면, 서브디렉토리 조회하지 않음
        /// </summary>
        /// <param name="fullPath">현재폴더의 전체경로</param>
        /// <param name="depth"> 하위폴더 검색 깊이
        ///     default : 자식노드 조회하지 않음
        ///          -1 : Favorites 와 Folders 데이터 소스인 경우, 하위 폴더 인스턴스 생성해 초기화하고 자식 노드는 조회하지 않음.
        ///           1 : 손자 노드까지만 조회
        ///           2 : 모든 자식노드 조회
        /// </param>
        public Folder(string fullPath, int depth, bool isFavorite)
        {
            IsFavorite = isFavorite;
            FullPath = fullPath;
            if(depth == 1)
            {
                InitData(0);
            }
            else if(depth == 2)
            {
                InitData(2);
            }
            else if(depth == -1)
            {
                if (SubFolders == null)
                    SubFolders = new ObservableCollection<Folder>();
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
        /// <param name="depth"> 하위폴더 검색 깊이
        ///           0 : 손자 노드 조회하지 않음
        ///           1 : 손자 노드까지만 조회
        ///           2 : 모든 자식노드 조회
        /// </param>
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
            parent.InitData(1);
        }
    }


    /// <summary>
    /// DevExpress 바인딩 시, 바인딩 데이터 변환
    /// </summary>
    public class FolderToShortPathConverter : System.Windows.Markup.MarkupExtension, System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var obj = value as Folder;
            if (obj != null)
            {
                return (obj.IsFavorite && obj.FullPath != null && obj.FullPath != "Favorites") ? obj.FullPath : obj.ToString();
            }

            return System.Windows.Data.Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }


    public class FavoriteFolder : ObservableCollection<Folder>
    {
        private const string FILE_PATH = "myFile";

        public Dictionary<string, FileSystemWatcher> Watchers { get; private set; }
        public event EventHandler FavoriteItemUpdateEvent;

        public FavoriteFolder()
        {
            Watchers = new Dictionary<string, FileSystemWatcher>();
        }


        protected override void ClearItems()
        {
            base.ClearItems();
            Watchers.Clear();
        }

        protected override void InsertItem(int index, Folder item)
        {
            base.InsertItem(index, item);
            if (!Watchers.ContainsKey(item.FullPath))
            {
                FileSystemWatcher fsw = new FileSystemWatcher(item.FullPath, "*.jpg");
                fsw.EnableRaisingEvents = true;
                fsw.Created += Favorite_Created;
                fsw.Deleted += Favorite_Deleted;
                Watchers.Add(item.FullPath, fsw);
            }
        }



        /// <summary>
        /// 즐겨찾기에 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Favorite_Created(object sender, FileSystemEventArgs e)
        {
            Items.Add(new Folder(e.FullPath, 0));
            OnUpdateItem();
        }

        /// <summary>
        /// 즐겨찾기에서 제거
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Favorite_Deleted(object sender, FileSystemEventArgs e)
        {
            int idxDelete = GetIndex(e.FullPath);

            if (idxDelete >= 0)
            {
                RemoveAt(idxDelete);
            }

            OnUpdateItem();
        }


        private void OnUpdateItem()
        {
            if (FavoriteItemUpdateEvent != null)
            {
                FavoriteItemUpdateEvent(this, new EventArgs());
            }
        }

        private int GetIndex(string tgtFullPath)
        {
            int index = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].FullPath == tgtFullPath)
                {
                    index = i;
                }
            }

            return index;
        }

        public void LoadFavoriteList()
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, FileMode.OpenOrCreate, isfile))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        this.Add(new Folder(line, 0));
                        line = sr.ReadLine();
                    }
                }
            }

            if (this.Count() == 0)
            {
                this.Add(new Folder(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), 0));
            }
        }

        public void SaveFavoriteList()
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, System.IO.FileMode.Create, isfile))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var filePath in this)
                    {
                        sw.WriteLine(filePath);
                    }
                }
            }
        }

    }

}
