using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfAppPhotoCooperative.BLL
{
    public class PrintBase : INotifyPropertyChanged
    {
        private BitmapSource m_photo;
        private PrintType m_printType;
        private int m_quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public BitmapSource Photo
        {
            get { return m_photo; }
            set
            {
                m_photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public PrintType PrintType
        {
            get { return m_printType; }
            set
            {
                m_printType = value;
                OnPropertyChanged("PrintType");
            }
        }

        public int Quantity
        {
            get { return m_quantity; }
            set
            {
                m_quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }

        public PrintBase(BitmapSource photo, string description, double cost) 
            : this(photo, new PrintType(description, cost), 0) { }

        public PrintBase(BitmapSource photo, PrintType printType, int quantity)
        {
            m_photo = photo;
            m_printType = printType;
            m_quantity = quantity;
        }

        public override string ToString()
        {
            return PrintType.ToString();
        }
    }
}
