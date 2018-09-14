using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfAppPhotoGalleryDataBinding
{
    public class CountToBackgroundConverter : IValueConverter
    {
        /// <summary>
        /// 대상 객체의 대상 속성값(value)이 0 이면 ConverterParameter로 전달받은 값(색상) 반환하고 아니면 투명색 반환
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush)) throw new InvalidOperationException("The target must be a Brush!");

            int num = int.Parse(value.ToString());

            return num == 0 ? parameter : Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class RawCountToDescriptionConverter : IValueConverter
    {
        /// <summary>
        /// 대상 객체의 대상 속성값(value)이 1이면 '속성값 Item' 반환하고 아니면 '속성값 Items' 반환
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = int.Parse(value.ToString());
            return num + (num == 1 ? " item" : " items");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class DateTimeToDateConverter : IValueConverter
    {
        /// <summary>
        /// 대상 객체의 대상 속성값(value)를 yyyy/MM/dd의 날짜형식으로 반환
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("MM/dd/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class VisibleToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value.ToString() == "Hidden") ? "Visible" : "Hidden";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
