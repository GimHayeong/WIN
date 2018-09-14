using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPhotoGalleryDataBinding
{
    public class Photos : ObservableCollection<Photo>
    {
        public event EventHandler ItemsUpdated;

        private Dictionary<string, FileSystemWatcher> m_watchers = new Dictionary<string, FileSystemWatcher>();


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
                watcher.Created += new System.IO.FileSystemEventHandler(OnPhotoCreated);
                watcher.Deleted += OnPhotoDeleted;
                watcher.Renamed += OnPhotoRenamed;
            }
        }


        private void OnPhotoCreated(object sender, FileSystemEventArgs e)
        {
            Items.Add(new Photo(e.FullPath));

            if (ItemsUpdated != null) { ItemsUpdated(this, new EventArgs()); }
        }

        private void OnPhotoDeleted(object sender, FileSystemEventArgs e)
        {
            int index = -1;
            for(int i=0; i<Items.Count; i++)
            {
                if(Items[i].FullPath == e.FullPath)
                {
                    index = i;
                    break;
                }
            }

            if (index > 0) Items.RemoveAt(index);

            if (ItemsUpdated != null) { ItemsUpdated(this, new EventArgs()); }
        }

        private void OnPhotoRenamed(object sender, RenamedEventArgs e)
        {
            int index = -1;
            for(int i=0; i<Items.Count; i++)
            {
                if(Items[i].FullPath == e.OldFullPath)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0) Items[index] = new Photo(e.FullPath);

            if (ItemsUpdated != null) { ItemsUpdated(this, new EventArgs()); }
        }

    }
}
