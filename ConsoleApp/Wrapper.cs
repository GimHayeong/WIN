using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // 제네릭 : 문법을 복잡하게 만들고 컴파일을 느리게 만든다.
    //          ArrayList 가 object 형 요소로 인한 박싱과 언박싱할 때 메모리 소모와 속도 저하의 문제 발생 ==> 타입인수를 지정한 제네릭 컬렉션 사용.
    // 제네릭클래스: 타입만 다르고 내부 구조는 같은 WrapperX 클래스를 제네릭으로 선언할 수 있다.
    //   + where T:struct ==> T는 값타입만 가능.(Nullable타입은 값타입이라도 허용 안됨)
    //   + where T:class  ==> T는 참조타입만 가능.
    //   + where T:base   ==> base로부터 파생된 클래스만 가능.
    //   + where T:Ibase  ==> Ibase 인터페이스를 상속받는 클래스만 가능.(Ibase 인터페이스 구현 필수)
    //   + where T:U      ==> U 클래스로부터 파생된 클래스만 가능.
    //   + where T:new()  ==> 디폴트 생성자 필수. 제약조건 제일 뒤에 지정. (new T() 형태로 객체 생성 가능해야 함을 의미)

    class Wrapper<T> // where T:struct
    {
        public T Data { get; private set; }
        public Wrapper() : this(default(T))//default(T): T형의 기본값
        {
        }
        public Wrapper(T data)
        {
            Data = data;
        }
        public void OutValue()
        {
            Console.WriteLine(Data);
        }
    }

    class WrapperInt
    {
        public int Data { get; private set; }
        public WrapperInt() : this(0)
        {
        }
        public WrapperInt(int data)
        {
            Data = data;
        }
        public void OutValue()
        {
            Console.WriteLine(Data);
        }
    }

    class WrapperString
    {
        public string Data { get; private set; }
        public WrapperString() : this(null)
        {
        }
        public WrapperString(string data)
        {
            Data = data;
        }
        public void OutValue()
        {
            Console.WriteLine(Data);
        }
    }

    

    class WrapperTest
    {
        public void MainTest()
        {
            Human human = new Human("홍길동", 21);
            Student student = new Student("전우치", 19, 18);
            //String str = "나문자";

            OutValue(human);
            OutValue(student);
            //OutValue(str); //에러 ==> becase where T:Human 제약조건 위배

            List<string> ar = new List<string>(10);
            ar.Add("도룡룡");
            ar.Add("개구리");
            ar.Add("메뚜기");
            foreach (string s in ar)
            {
                Console.WriteLine(s);
            }

            LinkedList<string> link = new LinkedList<string>();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Dictionary<Human, string> htPosition = new Dictionary<Human, string>();
            Human humanA = new Human("이순신", 32);
            Human humanB = new Human("을지문덕", 35);
            Human humanC = new Human("김유신", 29);
            Human humanD = new Human("계백", 29);
            htPosition.Add(humanA, "과장");
            htPosition.Add(humanA, "부장");
            htPosition.Add(humanA, "대리");
            htPosition.Add(humanA, "대리");
        }

        public void NewWrapper()
        {
            Wrapper<int> wpi = new Wrapper<int>(1234);
            wpi.OutValue();
            Wrapper<string> wps = new Wrapper<string>("대한민국");
            wpi.OutValue();
        }

        public void OldWrapper()
        {
            WrapperInt wpi = new WrapperInt(1234);
            wpi.OutValue();
            WrapperString wps = new WrapperString("대한민국");
            wps.OutValue();
        }

        public void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        public void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        public void Swap(ref string a, ref string b)
        {
            string temp;
            temp = a;
            a = b;
            b = temp;
        }

        public void OutValue<T>(T man) where T : Human
        {
            man.Intro();
        }
    }
}
