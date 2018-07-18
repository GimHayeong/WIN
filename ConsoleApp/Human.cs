using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 네임스페이스 : 클래스들을 기능이나 용도에 따라 분류해 정의.
namespace ConsoleApp
{
    // typeof 연산자 : 리플렉션 ==> 실행중에 타입에 대한 상세한 정보 조사 가능. 
    //                 이 연산자를 통해 is 연산자와 as 연산자 사용 가능.
    class Haksa
    {
        // is 연산자 : 타입점검 ==> 형변환 가능한지 여부
        public void IsRegister(Human human)
        {
            if(human is Student || human is Assistant)
            {
                // 강의 등록
            }
            else
            {
                // 학생이 아니므로 강의 등록 거부
            }
        }

        // as 연산자 : 타입점검 후 변환 ==> 안전하게 형변환 가능한 is a 관계성립하면 변환, 아니면 null
        // as 의 피연산자는 반드시 참조형 (because 값타입은 null값을 가질 수 없음)
        public void AsRegister(Human human)
        {
            Student student = human as Student;
            Assistant assident = human as Assistant;

            if(student != null || assident != null)
            {
                // 강의 등록
            }
            else
            {
                // 학생이 아니므로 강의 등록 거부
            }
        }

    }


    // 클래스 : 다수의 함수들을 하나의 범주에 캡슐화
    class Human
    {
        //protected: 파생클래스에서 액세스할 필요가 있는 멤버들
        protected string Name { get; set; }
        protected int Age { get; set; }
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
        // virtual : 자식 클래스에서 재정의 가능함 표시
        public virtual string Intro()
        {
            return String.Format("이름: {0}\r\n나이: {1}", Name, Age);
        }

        public override bool Equals(object obj)
        {
            Human other = obj as Human;
            if (other == null) return false;

            return (other.Name == Name && other.Age == Age);
        }

        public override int GetHashCode()
        {
            return Age + Name[0];
        }
    }

    class HumanTest
    {
        // ArrayList : 빈 배열을 생성가능. 초기 크기 지정가능. 다른 컬렉션의 사본으로 생성가능.
        //             (대용량의 자료를 저장한다면 실행 중 재할당하는 것보다 생성할 때 미리 할당해 놓는 것이 성능상 유리)
        //             object 형 요소를 가지므로 박싱과 언박싱으로 인한 메모리 소모와 속도 저하 문제 ==> 해결: List<T> 제네릭 컬렉션으로 타입 인수 지정
        //   + Count : 현재 저장되어 있는 요소 개수
        //   + Capacity : 할당된 총 용량
        //   + Add, Inseert, Remove, RemoveAt, RemoveRange : 배열 저장 요소의 루트 클래스가 object 타입이므로 다양한 타입의 요소를 가질 수 있음. (비교. 배열은 동형 요소만 가능)
        //   + Clear : 모든 요소 삭제
        //   + TrimToSize : 여유분으로 할당해 놓은 메모리 해제하여 실제 저장된 요소 크기만큼만.
        //   + Sort, Reverse
        //   + ToArray : 정적인 배열에 복사
        public void SetArrayList()
        {
            ArrayList ar = new ArrayList(10);
            ar.Add(1);
            ar.Add(2.34);
            ar.Add("대한민국");
            ar.Add(new DateTime(2005, 3, 1));
            ar.Insert(1, 1234);
            foreach (object item in ar)
            {
                Console.WriteLine(item.ToString());//1, 1234, 2.34, "대한민국", 2005/03/01 12:00:00
            }
            Console.WriteLine("요소개수: {0}", ar.Count);//5
            Console.WriteLine("배열용량: {0}", ar.Capacity);//10
        }

        public void SetGenericList()
        {
            List<string> ar = new List<string>(10);
            ar.Add("도룡룡");
            ar.Add("개구리");
            ar.Add("메뚜기");
            foreach(string s in ar)
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

        // HashTable : 키와 값을 한 쌍으로 하여 저장하는 자료 구조.
        // Hash : 자료의 고유한 해시값으로부터 저장할 위치를 선택하는 기법
        public void SetHashTable()
        {
            Hashtable ht = new Hashtable();
            ht.Add("boy", "아저씨");
            ht.Add("girl", "소녀");
            ht["school"] = "학교"; // 키가 없으면 추가
            ht["boy"] = "소년"; // 키가 있으면 수정

            Hashtable htPosition = new Hashtable();
            Human humanA = new Human("이순신", 32);
            Human humanB = new Human("을지문덕", 35);
            Human humanC = new Human("김유신", 29);
            Human humanD = new Human("계백", 29);
            htPosition.Add(humanA, "과장");
            htPosition.Add(humanA, "부장");
            htPosition.Add(humanA, "대리");
            htPosition.Add(humanA, "대리");
            Console.WriteLine("직급은 {0} 입니다.", htPosition[humanA]);
        }

        public void SetStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            for(int i=0; i<stack.Count; i++)
            {
                Console.WriteLine(stack.Pop());//3 => 2 => 1 (LIFO)
            }
        }

        public void SetQueue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue.Dequeue());//1 => 2 => 3 (FIFO)
            }
        }

        
    }

    // is a 상속
    // 모든 클래스는 하나의 기반클래스만 가짐(생략하면 object클래스 상속). 인터페이스는 제한없이 상속가능.
    // 구조체는 상속 불가.
    // Student is a Human (IS A 관계 : 학생은 사람의 일종) ==> [is a 상속] 은 클래스 계층을 형성하여 다형성의 이점
    class Student : Human
    {
        protected int Hakbeon { get; set; }
        //:base(...) : 부모클래스의 생성자 호출
        public Student(string name, int age, int hakbeon) : base(name, age)
        {
            Hakbeon = hakbeon;
        }
        // override : 부모 클래스와 다르게 구현함을 표시
        public override string Intro()
        {
            return String.Format("{0}\r\n학번: {1}", base.Intro(), Hakbeon);
        }
        public void Study()
        {
            //
        }
    }

    class Professor : Human
    {
        protected int Course { get; set; }
        //:base(...) : 부모클래스의 생성자 호출
        public Professor(string name, int age, int course) : base(name, age)
        {
            Course = course;
        }
        // override : 부모 클래스와 다르게 구현함을 표시
        public override string Intro()
        {
            return String.Format("{0}\r\n담당과목코드: {1}", base.Intro(), Course);
        }
        public void Teach()
        {
            //
        }
    }

    class Assistant : Human
    {
        protected int Administrative { get; set; }
        //:base(...) : 부모클래스의 생성자 호출
        public Assistant(string name, int age, int job) : base(name, age)
        {
            Administrative = job;
        }
        // override : 부모 클래스와 다르게 구현함을 표시
        public override string Intro()
        {
            return String.Format("{0}\r\n담당업무코드: {1}", base.Intro(), Administrative);
        }
        public void Job()
        {
            //
        }
    }

    class Guard : Human
    {
        protected int Area { get; set; }
        //:base(...) : 부모클래스의 생성자 호출
        public Guard(string name, int age, int area) : base(name, age)
        {
            Area = area;
        }
        // new : 상속받은 부모의 동명멤버를 완전히 숨기고 자식클래스가 동명의 새 멤버로 정의 ==> 이후 상속받는 클래스는 재정의 불가
        public new string Intro()
        {
            return String.Format("{0}\r\n담당영역코드: {1}", base.Intro(), Area);
        }
        public void Security()
        {
            //
        }
    }



    class Graduate : Student
    {
        protected DateTime Graduated { get; set; }
        public Graduate(string name, int age, int hakbeon, DateTime graduated) : base(name, age, hakbeon)
        {
            Graduated = graduated;
        }
        // override : 부모 클래스와 다르게 구현함을 표시. ==> 자식의 자식 클래스에서도 재정의 가능
        public override string Intro()
        {
            return String.Format("{0}\r\n졸업년도: {1}", base.Intro(), Graduated.Year);
        }
        public void WriteThesis()
        {
            //
        }
    }

    // has a 포함
    // Graduate has a Human (HAS A 관계 : 졸업생은 사람을 포함) ==> [has a 포함] 은 코드의 재사용 정도
    //class Graduate
    //{
    //    public Human H { get; set; }
    //    protected int Hakbeon { get; set; }

    //    public Graduate(string name, int age, int hakbeon)
    //    {
    //        Hakbeon = hakbeon;
    //        H = new Human(name, age);
    //    }
    //    public string Intro()
    //    {
    //        return String.Format("{0}\r\n학번: {1}", H.Intro(), Hakbeon);
    //    }
    //    public void Study()
    //    {
    //        //
    //    }
    //}
}
