using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                Notify("Id");
            }
        }

        string _name;
        public string Name
        {
            get { return _name;  }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        string _specialNumber;
        public string SpecialNumber
        {
            get { return _specialNumber; }
            set
            {
                _specialNumber = value;
                Notify("SpecialNumber");
            }
        }

        string _vender;
        public string Vender
        {
            get { return _vender; }
            set
            {
                _vender = value;
                Notify("Vender");
            }
        }


        string _dept;
        public string Dept
        {
            get { return _dept; }
            set
            {
                _dept = value;
                Notify("Dept");
            }
        }

        string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                Notify("Position");
            }
        }

        string _taskInCharge;
        public string TaskInCharge
        {
            get { return _taskInCharge; }
            set
            {
                _taskInCharge = value;
                Notify("TaskInCharge");
            }
        }

        string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                Notify("ZipCode");
            }
        }

        string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                Notify("Address");
            }
        }

        string _detailedAddress;
        public string DetailedAddress
        {
            get { return _detailedAddress; }
            set
            {
                _detailedAddress = value;
                Notify("DetailedAddress");
            }
        }

        string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                Notify("Telephone");
            }
        }

        string _cellPhone;
        public string CellPhone
        {
            get { return _cellPhone; }
            set
            {
                _cellPhone = value;
                Notify("CellPhone");
            }
        }

        string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                Notify("Email");
            }
        }

        string _userType;
        public string UserType
        {
            get { return _userType; }
            set
            {
                _userType = value;
                Notify("UserType");
            }
        }

        string _statusType;
        public string StatusType
        {
            get { return _statusType; }
            set
            {
                _statusType = value;
                Notify("StatusType");
            }
        }

        string _withdrawal;
        public string Withdrawal
        {
            get { return _withdrawal; }
            set
            {
                _withdrawal = value;
                Notify("Withdrawal");
            }
        }

        string _registrationDate;
        public string RegistrationDate
        {
            get { return _registrationDate; }
            set
            {
                _registrationDate = value;
                Notify("RegistrationDate");
            }
        }

        public User() : this("", "")
        {
            //
        }

        public User(string id, string name)
        {
            this._id = id;
            this._name = name;
        }
    }

    public class Users : ObservableCollection<User>
    {
        //
    }
}
