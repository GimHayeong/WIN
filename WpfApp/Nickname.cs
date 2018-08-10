using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery
{
    public class Nickname : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        string _nick;
        public string Nick
        {
            get { return _nick;  }
            set
            {
                _nick = value;
                Notify("Nick");
            }
        }

        public Nickname() : this("", "")
        {
            //
        }

        public Nickname(string name, string nick)
        {
            this._name = name;
            this._nick = nick;
        }
    }

    public class Nicknames : ObservableCollection<Nickname>
    {
        //
    }
}
