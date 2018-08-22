using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery.ViewModel
{
    public class ViewModel 
    {
        private const string ROOT_FAVORITE = "Favorites";
        private const string ROOT_FOLDER = "Folders";

        public static ObservableCollection<Folder> SubFolders { get; private set; }
        Folder m_favorite;
        Folder m_parent;


        public ViewModel()
        {
            if (SubFolders == null)
            {
                SubFolders = new ObservableCollection<Folder>();
                //즐겨찾기 추가

                FavoriteFolder favorite = new FavoriteFolder();
                favorite.LoadFavoriteList();

                m_favorite = new Folder(ROOT_FAVORITE, -1);
                SubFolders.Add(m_favorite);

                foreach(var f in favorite)
                {
                    m_favorite.SubFolders.Add(new Folder(f.FullPath, -1, true));
                }

                m_parent = new Folder(ROOT_FOLDER, -1);
                SubFolders.Add(m_parent);
            }
          
            foreach (var dir in Directory.GetLogicalDrives())
            {
                Folder folder = new Folder(dir);
                
                m_parent.SubFolders.Add(folder);
            }
        }

    }
}
