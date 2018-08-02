using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
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
    }

    public class Photo
    {

    }
}
