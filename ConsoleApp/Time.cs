using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // 깊은 복사 : 클래스에 포함된 멤버까지 복사하기 위해 ICloneable를 상속받아 구현해야 함.
    class CloneData : ICloneable
    {
        public int DataValue { get; set; }
        public CloneData(int v)
        {
            // 깊은 복사를 해야 하는 대상 멤버를 복사한다.
            DataValue = v;
        }
        public object Clone()
        {
            return new CloneData(DataValue);
        }
    }

    class CTest
    {
        void Main()
        {
            CloneData a = new CloneData(1234);
            CloneData b = (CloneData)a.Clone(); // Clone()은 object를 반환하므로 명시적 캐스팅 필요
            b.DataValue = 5678;
            Console.WriteLine("a = {0}, b = {1}", a.DataValue, b.DataValue);// a = 5678, b = 5678
        }
    }

    class GuGu
    {
        public static IEnumerable<int> IntIterator(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                yield return i;
            }
        }

        void Main()
        {
            foreach (int i in IntIterator(1, 9))
            {
                Console.WriteLine("{0} 단", i);
                foreach (int j in IntIterator(1, 9))
                {
                    Console.WriteLine("{0} × {1} = {2}", i, j, i * j);
                }
            }
        }
    }



    class HanBridge
    {
        static string[] Bridge = { "팔당", "강동", "광진", "천호", "올림픽", "잠실", "청담", "영동", "성수", "동호", "한남", "반포", "동작", "한강", "원효", "마포", "서강", "양화", "성산", "가양", "방화", "행주", "김포", "일산" };
        public IEnumerator<string> GetEnumerator()
        {
            for(int i=0; i<Bridge.Length; i++)
            {
                yield return Bridge[i];
            }
        }

        // 메서드로 반복기 구현가능
        public IEnumerable<string> EastToWest()
        {
            for (int i = 0; i < Bridge.Length; i++)
            {
                yield return Bridge[i];
            }
        }

        // 메서드로 반복기 구현가능
        public IEnumerable<string> WestToEast()
        {
            for (int i = 0; i < Bridge.Length; i++)
            {
                yield return Bridge[i];
            }
        }
    }

    class HandBridgeTest
    {
        void Main()
        {
            HanBridge hb = new HanBridge();
            foreach(string bridge in hb)
            {
                Console.WriteLine("{0} 대교", bridge);
            }

            Console.WriteLine("한강 다리(동쪽 ~ 서쪽)");
            foreach (string bridge in hb.EastToWest())
            {
                Console.WriteLine("{0} 대교", bridge);
            }

            Console.WriteLine("한강 다리(서쪽 ~ 동쪽)");
            foreach (string bridge in hb.WestToEast())
            {
                Console.WriteLine("{0} 대교", bridge);
            }
        }
    }

    // 2.0 이후 버전에서는 IEnumerator<T> GetEnumerator()만 구현하면 됨
    class Time : IFormattable
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        // foreach 로 접근가능하도록 GetEnumerator 메서드 구현
        public IEnumerator<int> GetEnumerator()
        {
            yield return Hour;
            yield return Minute;
            yield return Second;
        }
        public Time(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }
        public override bool Equals(object obj)
        {
            //if (obj == null || obj.GetType() != this.GetType()) return false;
            //Time other = (Time)obj;

            Time other = obj as Time;
            if (other == null) return false;

            return (other.Hour == Hour && other.Minute == Minute && other.Second == Second);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "A":
                    return String.Format("{0}시 {1}분 {2}초", Hour, Minute, Second);
                case "B":
                    return String.Format("{0}:{1}:{2}", Hour, Minute, Second);
                case "C":
                    return String.Format("{0}.{1}.{2}", Hour, Minute, Second);
                default:
                    return "Invalid Format";

            }
        }

        public TimeSpan GetTimeSpan(DateTime a, DateTime b)
        {
            TimeSpan tsp = b - a;
            return tsp;
        }

        public DateTime GetDateTime(DateTime a, int afterDays)
        {
            TimeSpan tsp = new TimeSpan(afterDays, 0, 0, 0);
            return a + tsp;
        }

        public TimeSpan GetElapsedTime()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                Console.Write(i + ", ");
            }
            stw.Stop();

            return stw.Elapsed;
        }
    }

    class TimeTest
    {
        void Main()
        {
            Time now = new Time(18, 25, 55);
            foreach(var hms in now)
            {
                Console.WriteLine("{0}:", hms);
            }

            Time other = now;
            bool isSameContents = other.Equals(now);//after [ public override bool Equals(object obj) ]

            bool isSameAddress = Object.Equals(other, null);
            isSameAddress = Object.ReferenceEquals(now, other);

            GetInfoByReflection(now);

            Console.WriteLine("지금 시각은 {0:A} 입니다.", now);
            Console.WriteLine("지금 시각은 {0:B} 입니다.", now);
            Console.WriteLine("지금 시각은 {0:C} 입니다.", now);
            Console.WriteLine("지금 시각은 {0:20} 입니다.", now); //지금 시각은 ____________________________18:25:55 입니다.
            Console.WriteLine("지금 시각은 {0:-20} 입니다.", now);//지금 시각은 18:25:55____________________________ 입니다.

            GetFindByRegex("간장 공장 공장장은 강공장장이고 된장 공장 공장장은 장공장장이다.", "공장");
            GetFindByRegex("김상형, 김상민, 김철수, 박상형, 김미형, 김철부지형, 김형, 김상형님", @"\김\S+형\b");//"김*형" ==> 김상형, 김미형, 김철부지형
        }

        // \S : 임의의문자
        // + : 하나이상
        // \b : 단어구분
        // [ 가능한 문자의 종류나 범위 ]
        // { 일치해야 하는 개수 }
        void GetFindByRegex(string str, string pattern)
        {
            MatchCollection finds = Regex.Matches(str, pattern);
            foreach(Match f in finds)
            {
                Console.WriteLine("[{0}] : {1}", f.Index, f.Value);
            }
        }

        void GetInfoByReflection(Time time)
        {
            Type tp = time.GetType();
            //tp = Type.GetType("ConsoleApp.Time");
            //tp = typeof(ConsoleApp.Time);
            Console.WriteLine("타입명: {0}", tp.Name);
            Console.WriteLine("네임스페이스 포함한 타입명: {0}", tp.FullName);
            Console.WriteLine("네임스페이스: {0}", tp.Namespace);
            Console.WriteLine("부모클래스 타입명: {0}", tp.BaseType.Name);
            Console.WriteLine("CLR이 제공하는 내부 시스템의 타입명: {0}", tp.UnderlyingSystemType);
            if (tp.IsValueType)
            {
                Console.WriteLine("{0}은 값 타입입니다.", tp.Name);
            }

            System.Reflection.FieldInfo[] tpFields = tp.GetFields();
            for(int i=0; i<tpFields.Length; i++)
            {
                Console.WriteLine("{0}번째 필드명: {1}", i, tpFields[i].Name);
            }

            System.Reflection.MethodInfo[] tpMethods = tp.GetMethods();
            for(int i=0; i<tpMethods.Length; i++)
            {
                Console.WriteLine("{0}번째 메소드명: {1}", tp.Name);
            }
            
        }
    }

    // 닷넷 2.0 미만 버전에서 foreach로 접근할 수 있게 구현하려면 [ IEnumerable 를 상속받은 클래스 ] 를 위한 [ IEnumerator를 상속받은 열거자 클래스 ] 를 구현해야 했음 
    //    ==> 2.0 이후 버전에서는 IEnumerator<T> GetEnumerator()만 구현하면 됨
    class OldTime : IEnumerable
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public IEnumerator GetEnumerator()
        {
            return new OldTimeEnum(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    // 열거자 클래스 : IEnumerable 를 상속받은 클래스의 열거를 위해 필요(because 이중 foreach 지원을 위해 루프 위치 기억 필요)
    class OldTimeEnum : IEnumerator
    {
        public OldTime MTime { get; private set; }
        private int m_Index;
        public OldTimeEnum(OldTime time)
        {
            MTime = time;
            Reset();
        }
        public object Current
        {
            get
            {
                switch (m_Index)
                {
                    case 0: return MTime.Hour;
                    case 1: return MTime.Minute;
                    case 2: return MTime.Second;
                    default: return null;
                }
            }
        }

        public bool MoveNext()
        {
            if(m_Index < 2)
            {
                m_Index++;
                return true;
            }else
            {
                return false;
            }
        }

        public void Reset()
        {
            m_Index = -1;
        }
    }


}
