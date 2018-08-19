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
    public class Favorites : ObservableCollection<Favorite>
    {
        private const string FILE_PATH = "myFile";

        public Dictionary<string, FileSystemWatcher> Watchers { get; private set; }
        public event EventHandler FavoriteItemUpdateEvent;

        public Favorites()
        {
            Watchers = new Dictionary<string, FileSystemWatcher>();
        }

        
        protected override void ClearItems()
        {
            base.ClearItems();
            Watchers.Clear();
        }

        protected override void InsertItem(int index, Favorite item)
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
            Items.Add(new Favorite { FullPath = e.FullPath });
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

            if(idxDelete >= 0)
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
                        this.Add(new Favorite { FullPath = line });
                        line = sr.ReadLine();
                    }
                }
            }

            if (this.Count() == 0)
            {
                this.Add(new Favorite { FullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) });
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

    public class Favorite
    {
        public string FullPath { get; set; }

        public override string ToString()
        {
            return FullPath;
        }
    }
}
