using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3DPhotoGallery.ViewModel
{
    public class Photos : ObservableCollection<Photo> 
    {
        Dictionary<string, FileSystemWatcher> m_watchers = new Dictionary<string, FileSystemWatcher>();
        public event EventHandler ItemsUpdated;

        protected override void ClearItems()
        {
            base.ClearItems();
            m_watchers.Clear();
        }

        protected override void InsertItem(int index, Photo item)
        {
            base.InsertItem(index, item);
            if (!m_watchers.ContainsKey(item.Path))
            {
                FileSystemWatcher watcher = new FileSystemWatcher(item.Path, "*.jpg");
                watcher.EnableRaisingEvents = true;
                watcher.Created += OnPhotoCreated;
                watcher.Deleted += OnPhotoDeleted;
                watcher.Renamed += OnPhtoRenamed;
                m_watchers.Add(item.Path, watcher);
            }
        }

        private void OnPhotoCreated(object sender, FileSystemEventArgs e)
        {
            Items.Add(new ViewModel.Photo(e.FullPath));

            if(ItemsUpdated != null)
            {
                ItemsUpdated(this, new EventArgs());
            }
        }

        private void OnPhotoDeleted(object sender, FileSystemEventArgs e)
        {
            int index = GetPhotoIndex(e.FullPath);

            if(index >= 0) { Items.RemoveAt(index); }

            if(ItemsUpdated != null)
            {
                ItemsUpdated(this, new EventArgs());
            }
        }

        private void OnPhtoRenamed(object sender, RenamedEventArgs e)
        {
            int index = GetPhotoIndex(e.OldFullPath);

            if(index >= 0) { Items[index] = new Photo(e.FullPath); }

            if(ItemsUpdated != null)
            {
                ItemsUpdated(this, new EventArgs());
            }
        }

        private int GetPhotoIndex(string path)
        {
            int index = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].FullPath == path)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
