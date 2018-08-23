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
    public class FavoriteFolder : ObservableCollection<Folder>
    {
        private const string FILE_PATH = "myFile";

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

        public void SaveFavoriteList(IList<Folder> folders)
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, System.IO.FileMode.Create, isfile))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var filePath in folders)
                    {
                        sw.WriteLine(filePath.FullPath);
                    }
                }
            }
        }

    }
}
