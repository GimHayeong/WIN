using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // Delegate : 메서드를 가리키는 참조형. 
    //            타입안전성이 높고 객체지향적이다.
    //            메서드의 번지를 저장하거나 다른 메서드의 인수로 메서드 자체를 전달할 용도.
    //            System.Delegate로부터 파생되는 하나의 클래스 타입으로 클래스에 소속되지 않아도 됨.
    //            클래스 내부에 선언될 때는 일종의 내부 타입으로 취급되며 절당한 액세스 한정자를 붙여야 한다.
    //            델리게이트 인스턴스 생성후 특정 메서드를 가리키도록 초기화 필수.

    delegate void dlgt(int a);

    delegate Base dlgtBase();
    delegate Derived dlgtDerived();

    delegate void dlgtLong(long a);
    delegate void dlgtInt(int a);

    delegate int dlgtOperator(int a, int b);

    delegate bool CompressCallback(int file);

    delegate void dlgtRent(string book);// 멀티캐스트용 델리게이트는 반환형이 void 이다.


    // 이벤트 델리게이트
    delegate void dlgtNotice();
    delegate void dlgtClick();

    delegate int dlgtAnonymous(int a, int b);

    delegate void dlgtOut(int a, out int b);

    class DelegateTest
    {
        public static void AA(int a)
        {
            Console.WriteLine("{0}의 제곱 = {1}", a, a * a);
        }

        public static void AAA(int a)
        {
            Console.WriteLine("{0}의 세제곱 = {1}", a, a * a * a);
        }

        public static Base GetBase()
        {
            return new Base();
        }

        public static Derived GetDerived()
        {
            return new Derived();
        }

        public static void GetLong(long a)
        {
            //
        }

        public static void GetInt(int a)
        {
            //
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Mul(int a, int b)
        {
            return a * b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="callback"></param>
        /// <returns>압축완료: true / 압축중단: false</returns>
        public static bool Compress(int file, CompressCallback callback)
        {
            for(int i=0; i<file; i++)
            {
                if (callback(i) == false)
                {
                    return false;
                }
                System.Threading.Thread.Sleep(500);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>계속: true / 취소: false</returns>
        public static bool Progress(int file)
        {
            Console.WriteLine("{0}번째 파일 압축하는 중입니다.(취소시 ESC)", file + 1);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(false);
                if(input.Key == ConsoleKey.Escape)
                {
                    return false;
                }
            }

            return true;
        }

        public static void GameStart()
        {
            Console.WriteLine("게임시작");
            for(int i=0; i<50; i++)
            {
                Console.Write('.');
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine("게임종료");
        }

        public static int Calc(dlgtAnonymous dlgt)
        {
            return dlgt(2, 3);
        }

        public static void SetDelegate(out dlgtAnonymous dlgt)
        {
            int k = 5;
            dlgt = delegate (int x, int y) { return x + y + k; };
        }

        void Main()
        {
            dlgt d;
            d = new dlgt(AA);//인수로 메서드 전달
            d(12);//12의 제곱 = 144
            d = new dlgt(AAA);
            d(12);//12의 세제곱 = 1728

            // 공변성 : 메서드의 리턴타입이 델리게이트의 리턴타입보다 더 자식 타입일 떄 이 메서드를 델리게이트가 가리킬 수 있는 성질.
            // 메서드의 매개변수가 더 부모여야 하며 반환되는 형이 더 부모여야 공변성 허용.
            dlgtBase db;
            db = GetBase;
            db = GetDerived;

            // 내장형 타입은 부모 자식관계가 성립하지 않으므로 정확하게 일치해야 한다.
            dlgtLong dl;
            dl = GetLong;
            dlgtInt di;
            di = GetInt;

            dlgtOperator dot;
            int a = 3, b = 5;
            dot = new dlgtOperator(Add);
            Console.WriteLine("더하기 {0} + {1} = {2}", a, b, dot(a, b));
            dot = new dlgtOperator(Mul);
            Console.WriteLine("곱하기 {0} + {1} = {2}", a, b, dot(a, b));

            if(Compress(10, Progress) == true)
            {
                Console.WriteLine("모든 파일을 압축하였습니다.");
            }
            else
            {
                Console.WriteLine("취소되었습니다.");
            }

            Book[] books = new Book[10];
            for(int i=0; i<books.Length; i++)
            {
                books[i] = new Book(i);
            }

            // 반환형이 void 인 델리게이트의 멀티케스트를 위해 null로 초기화한 후, += 연산자를 이용해 멀티캐스트 가능.
            dlgtRent rentCall = null;
            rentCall += books[1].Rend;
            rentCall += books[4].Rend;
            rentCall += books[6].Rend;
            rentCall += books[9].Rend;

            rentCall("운명");//1{4, 6, 9)번 고객이 운명을 빌려간다.

            Printer prt = new Printer();
            Receiver rcv = new Receiver();
            rcv.Complete += prt.Print;
            rcv.Receive();

            Button btnStart = new Button();
            btnStart.Draw();
            btnStart.Click += GameStart;
            Console.WriteLine("S: 게임시작, E: 게임종료");

            for (;;)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input;
                    input = Console.ReadKey();
                    if(input.Key == ConsoleKey.S)
                    {
                        btnStart.OnClick();
                    }else if(input.Key == ConsoleKey.E)
                    {
                        break;
                    }
                }

                System.Threading.Thread.Sleep(100);
            }

            // 익명메서드 : 한번만 사용할 경우
            //              익명메서드에서는 외부변수와 같은 이름의 지역변수를 선언해서는 안된다.
            dlgtAnonymous da = delegate(int x, int y) { return x + y; };
            int k = da(2, 3);
            Console.WriteLine("익명메서드 실행결과: {0}", k);//5

            k = Calc(delegate (int x, int y) { return x + y; });
            Console.WriteLine("익명메서드 실행결과: {0}", k);//5

            k = Calc(delegate (int x, int y) { return x * y; });
            Console.WriteLine("익명메서드 실행결과: {0}", k);//6

            dlgtOut dout = delegate (int x, out int y) { y = 0; };

            dlgtAnonymous dRtn;
            SetDelegate(out dRtn);
            int z = dRtn(2, 3);
            Console.WriteLine(z);//10
        }

    }

    class Base { }
    class Derived : Base { }

    class Book
    {
        public int Id { get; private set; }
        public Book(int id)
        {
            Id = id;
        }

        public void Rend(string book)
        {
            Console.WriteLine("{0}번 고객이 {1}을 빌려간다.", Id, book);
        }
    }

    class Printer
    {
        public void Print()
        {
            Console.WriteLine("수신된 데이터를 인쇄합니다.");
        }
    }

    class Receiver
    {
        public event dlgtNotice Complete;
        public void Receive()
        {
            for(int i=0; i<100; i += 10)
            {
                Console.WriteLine("{0}% 수신중", i);
                System.Threading.Thread.Sleep(200);
            }

            if (Complete != null) Complete();//0{10~90}% 수신중 / 수신된 데이터를 인쇄합니다.
        }
    }

    class Button
    {
        public event dlgtClick Click;
        public void Draw()
        {
            Console.WriteLine("나는 버튼입니다.");
        }

        public void OnClick()
        {
            if (Click != null) Click();
        }
    }
}
