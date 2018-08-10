using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery
{
    class Sample
    {
        ///**
        // * 구조체(값타입)끼리의 대입은 멤버 전체를 복사하는 느린 연산 ---> 내장형타입, 열거형, 구조체 ===> 함수의 인수로 사용하면 호출속도가 느려짐
        // * VS
        // * 배열(참조타입)끼리의 대입은 참조만 복사하는 빠른 연산 ---> 문자열, 클래스, 배열 ===> new 로 초기화하면 힙에 메모리를 할당받아 사용가능해짐
        //**/

        enum Origin : byte { East, West, South, North}//1, 2, 3, 4
        //enum Origin2 : byte { East = 1, West = 1, South, North }//1, 1, 2, 3
        //enum Origin3 : byte { East, West, South, North, Dong = East}//1, 2, 3, 4, 1

        // 구조체: 이형변수의 집합 VS 배열: 동형변수의 집합
        struct Book
        {
            public string Name;
            public int Price;
            public Book(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public void OutBook()
            {
                Console.WriteLine("책 제목: {0, 40}, 가격: {1, 10, C}");
            }
        }

        // 배열: 참조형이므로 배열명은 힙의 저장소를 가리키는 주소만 가지며, 실제 메모리는 주소가 가리키는 힙에 위치함
        //       초기화시 할당받은 크기는 중간에 변경 불가
        int[] arScore;
        int[,] arSung;
        string[,,] arName;

        string str = @"개행된
문자열이다.";

        
         //암시적 형변환 : 타입이 다른 변수나 상수의 연산에서 암시적으로 양쪽의 타입을 맞춘 후 계산 ==> short나 byte 형은 수식내에서 int로 변환되어 연산되므로 그 결과는 int 형이다.
         //명시적 형변환 : double과 decimal 사이에도 명시적 형변환이 필요하며, 문자열은 명시적 형변환으로 숫자형으로 변환 불가 ==> Convert.ToX 사용, 각 타입이 제공하는 Parse() 사용
         
        // 박싱: 값타입을 참조타입으로 변환하여 값을 포함하는 객체를 힙에 생성 ==> 클래스에 포함된 값타입 멤버
        // 언박싱 : 박싱된 참조타입으로부터 원래의 값을 추출 ==> 캐스스트 연산자를 통해 추출 ==> 느리고 비효율적
        class AgeBoxing{
            public int age;
        }
        // 내부타입: 클래스에 포함된 클래스, 구조체, 열거형, 델리게이트
        // 외부타입: 네임스페이스 소속

        public void unBoxing()
        {
            AgeBoxing box = new AgeBoxing();
            box.age = 5;
            //int k = (int)box;
        }


        // 사용자가 만든 클래스도 IEnumerable 인터페이스를 구현하면 foreach로 요소 순회가능
        // if 조건식은 C#은 반드시 논리형
        // 무한루프는 보통 for(;;)이용 ==> while, do~whie 도 가능
        // 반복횟수가 가변적일 경우, while(조건식) { 블럭내부에 조건식을 변경하는 문장 필요 } ==> 최소 1회실행되는 경우, do{ 블럭내부에 조건식 변경 } while(조건식)
        // 특정 집합의 요소 반복 처리하는 경우, foreach(타입 변수명 in 배열) { 명령들; }
        // switch (제어변수) { case 값 : 처리 ; break; ... default: 처리; break; } ==> case 다음에는 상수만 가능. (빈문자열에 대한 처리는 case null: 사용가능)
        // 나누기 연산자는 양쪽 피연산자 중 하나라도 실수여야 실수연산 가능
        // 실수끼리 나머지 연산을 하면 좌변을 우변의 정수배로 나누고 남은 값을 구한다. 6.3 % 2.5 = 6.3 % (2.5 * 2) = 6.3 % 5.0 = 6.3 - 5.0 = 1.3

        private static bool UseAmPm;
        // 정적필드는 개별 객체에 소속되지 않으며 클래스 직속.
        // 정적생성자는 정적필드만 초기화하며 인수를 가질수 없으며 액세스 지정자도 붙이지 않음. 클래스가 로드될 때 딱 한번 자동 호출됨.


        public const int DAY = 24;
        // 상수는 컴파일시 한번 초기화되며 변경불가. 선언시 초기값 설정.

        private readonly AgeBoxing box;
        // 읽기전용은 생성자에서 한번 초기화가능하며 변경불가. 부주의한 변경방지 목적.

        
        public void initArray()
        {
            arScore = new int[5] { 1, 2, 3, 4, 5 };//배열 초기화시, 크기를 할당하면서 초기값 설정 가능

            //배열 선언시 초기값이 있을 경우 new 없이 초기값만 나열 가능
            int[] myScore = { 1, 2, 3, 4, 5 };

            string[,]arSung = {
                { "서울", "인천", "부산", "대구"},
                { "춘천", "홍천", "평창", "양구"}
            };

            // 부분 배열의 요소 개수가 현저한 차이를 보이는 경우 
            int[][] arTotal = new int[3][];
            arTotal[0] = new int[] { 1, 2, 3, 4 };
            arTotal[1] = new int[2] { 1, 2 };
            arTotal[2] = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            int[][] arSum = new int[][] {
                arTotal[0] = new int[] { 1, 2, 3, 4 },
                arTotal[1] = new int[2] { 1, 2 },
                arTotal[2] = new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };

        }

        public void AscArray(int[] score)
        {
            Array.Sort(score);
        }

        public void DescArray(int[] score)
        {
            Array.Sort(score);
            Array.Reverse(score);
        }

        public int Search(int[] score, int search)
        {
            Array.Sort(score);
            return Array.BinarySearch(score, search);
        }

        public void Sum()
        {
            int[] arr = { 3, 4, 5 };
            AddAll(new int[2] { 1, 2 });
            AddAll(arr);
            AddAll(6, 7, 8, 9);
        }

        public int AddAll(params int[] nums)
        {
            var sum = nums.Sum();
            return sum;                        
        }

        public void ConverType()
        {
            short a = 1, b = 2, c;
            c = (short)(a + b);
            int i = Convert.ToInt32("1234");
            int j = int.Parse("1234");
        }

        public void CheckedOverflow()
        {
            int i = 123456;
            short s;
            checked
            {
                s = (short)i;
            }
        }

        public void UnCheckedOverflow()
        {
            int i = 123456;
            short s;
            unchecked
            {
                s = (short)i;
            }
        }

        public void SwitchCaseBreak(int a)
        {
            // a==3 일경우, case 3 => case 1을 처리한다.
            switch (a)
            {
                case 1:
                    //
                    break;

                case 2:
                    //
                    break;

                case 3:
                    //
                    goto case 1;
            }
        }

        public int GotoSum()
        {
            int i = 1;
            int sum = 0;

        start:
            sum += i;
            i++;
            if (i <= 100) goto start;

            return sum;
        }

        public int OddSum()
        {
            int sum = 0;
            for (int i=0; i<=60; i++)
            {
                if (i % 2 == 1) continue;
                sum += i;
            }

            return sum;
        }

        public void callIndexer()
        {
            Time c;
            Time first = new Time(1, 1, 1);
            Time now = new Time(12, 34, 56);
            String time = now.OutTime();//12시 34분 56초
            now[1] = 19;
            time = now.OutTime();//12시 19분 56초

            GuGu gugu = new GuGu();
            int a = gugu[3, 8];//24

            c = first + now;
        }
        
    }

    class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Time() : this(DateTime.Now)
        {
        }

        public Time(DateTime time) : this(time.Year, time.Month, time.Second)
        {
        }

        public Time(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }

        public string OutTime()
        {
            return String.Format("{0}시 {1}분 {2}초", Hour, Minute, Second);
        }

        // 인덱서: 객체를 배열처럼 사용할 수 있도록 하는 메서드. 참조용(ref)나 출력용(out) 인수를 전달받을 수 없다.
        public int this[int what]
        {
            get
            {
                switch (what)
                {
                    case 0: return Hour;
                    case 1: return Minute;
                    case 2: return Second;
                    default: return -1;
                }
            }
            set
            {
                switch (what)
                {
                    case 0: Hour = value; break; 
                    case 1: Minute = value; break;
                    case 2: Second = value; break;
                    default: break;
                }
            }
        }

        public int this[string what]
        {
            get
            {
                switch (what)
                {
                    case "시": return Hour;
                    case "분": return Minute;
                    case "초": return Second;
                    default: return -1;
                }
            }
            set
            {
                switch (what)
                {
                    case "시": Hour = value; break;
                    case "분": Minute = value; break;
                    case "초": Second = value; break;
                    default: break;
                }
            }
        }

        // 연산자 오버로딩 public, static, operator
        public static Time operator +(Time a, Time b)
        {
            Time t = new Time(a.Hour + b.Hour, a.Minute + b.Minute, a.Second + b.Second);

            t.Minute += t.Second / 60;
            t.Second %= 60;

            t.Hour += t.Minute / 60;
            t.Minute %= 60;

            return t;
        }

        public static Time operator +(Time a, int b)
        {
            Time t = new Time(a.Hour, a.Minute, a.Second + b);

            t.Minute += t.Second / 60;
            t.Second %= 60;

            t.Hour += t.Minute / 60;
            t.Minute %= 60;

            return t;
        }

        public static Time operator ++(Time a)
        {
            //return new Time(a.Hour, a.Minute, a.Second) + 1;

            Time t = new Time(a.Hour, a.Minute, a.Second);
            t.Second++;

            t.Minute += t.Second / 60;
            t.Second %= 60;

            t.Hour += t.Minute / 60;
            t.Minute %= 60;

            return t;
        }

        public static bool operator ==(Time a, Time b)
        {
            return (a.Hour == b.Hour && a.Minute == b.Minute && a.Second == b.Second);
        }
        public static bool operator !=(Time a, Time b)
        {
            return !(a == b);
        }


        // implicit 캐스트연산자(암시적 변환) : 별다른 위험없이 항상 안전한 형변환 가능한 경우.(단항연산자이므로, 매개변수도 하나)
        public static implicit operator int(Time t)
        {
            return t.Hour * 3600 + t.Minute * 60 + t.Second;
        }
        public static implicit operator double(Time t)
        {
            return t.Hour + t.Minute / 100.0;
        }
        // explicit 캐스트연산자(명시적 변환) : 매개변수에 따라 TIme형으로 안전한 형변환이 불확실한 경우.(단항연산자이므로, 매개변수도 하나)
        public static explicit operator Time(int time)
        {
            Time t = new Time();
            t.Hour = time / 3600;
            t.Minute = (time / 60) % 60;
            t.Second = time % 60;

            return t;
        }

    }

    class Inch
    {
        public double Length { get; set; }
        public Inch(double len) { Length = len; }
        public string OutValue()
        {
            return String.Format("{0:F2} 인치", Length);
        }
        public static implicit operator Mili(Inch i)
        {
            return new Mili((uint)(i.Length * 25.4));
        }
        public static implicit operator Inch(Mili m)
        {
            return new Inch(m.Length / 25.4);
        }
    }

    class Mili
    {
        public uint Length { get; set; }
        public Mili(uint len) { Length = len; }
        public string OutValue()
        {
            return String.Format("{0:F2} 밀리", Length);
        }
    }

    class GuGu
    {
        public int this[int a, int b]
        {
            get { return a * b; }
        }
    }
}
