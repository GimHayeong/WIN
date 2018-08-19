using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery.ViewModel
{
    public class ViewModel
    {
        public static Favorites FavoriteList { get; set; }
        public static Folders FolderList { get; set; }

        public ViewModel()
        {
            if (FolderList == null)
            {
                FavoriteList = new Favorites();
                FolderList = new Folders();
            }
        }
    }
}
