using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf
{
    /// <summary>
    ///  INotityPropertyChanged 인터페이스의 PropertyChanged이벤트를 구현하는 방법을 도와주는 ObservableCollection 클래스를 상속받으면 더 간단하다.
    /// </summary>
    /// <remarks>
    /// 데이터 바인딩 소스로 사용하기 위해 
    ///   1. INotityPropertyChanged 인터페이스를 구현(PropertyChanged이벤트)해야 한다.
    ///   2. 또는 XXChanged 이벤트를 구현해야 한다.(구클래스와 호환위해 제공됨)
    /// </remarks>
    public class Photos : ObservableCollection<Photo>
    {
        public Dictionary<string, FileSystemWatcher> Watchers { get; private set; }
        public event EventHandler PhotoItemUpdateEvent;

        public Photos()
        {
            Watchers = new Dictionary<string, FileSystemWatcher>();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            Watchers.Clear();
        }

        protected override void InsertItem(int index, Photo item)
        {
            base.InsertItem(index, item);
            if (!Watchers.ContainsKey(item.Dir))
            {
                FileSystemWatcher fsw = new FileSystemWatcher(item.Dir, "*.jpg");
                fsw.EnableRaisingEvents = true;
                fsw.Created += Photo_Created;
                fsw.Deleted += Photo_Deleted;
                fsw.Renamed += Photo_Renamed;
                Watchers.Add(item.Dir, fsw);
            }
        }

        private void OnUpdateItem()
        {
            if (PhotoItemUpdateEvent != null)
            {
                PhotoItemUpdateEvent(this, new EventArgs());
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

        private void Photo_Renamed(object sender, RenamedEventArgs e)
        {
            int idxRename = GetIndex(e.OldFullPath);

            if(idxRename >= 0)
            {
                Items[idxRename] = new Photo(e.FullPath);
            }

            OnUpdateItem();
        }

        private void Photo_Deleted(object sender, FileSystemEventArgs e)
        {
            int idxDelete = GetIndex(e.FullPath);
            
            if(idxDelete >= 0)
            {
                Items.RemoveAt(idxDelete);
            }

            OnUpdateItem();
        }

        private void Photo_Created(object sender, FileSystemEventArgs e)
        {
            Items.Add(new Photo(e.FullPath));

            OnUpdateItem();
        }
    }

    public class Photo
    {
        public string Name { get; private set; }
        public DateTime RegDate { get; private set; }
        public string Size { get; private set; }
        public string Dir { get; private set; }
        public string FullPath
        {
            get { return Path.Combine(Dir, Name); }
        }

        public Photo(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            Size = (file.Length / 1024).ToString("NO") + " KB";
            RegDate = file.LastWriteTime;
            Name = file.Name;
            Dir = file.DirectoryName;
        }

        public override string ToString()
        {
            return FullPath;
        }
    }
}
