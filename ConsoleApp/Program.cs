//#define DISPLAYARRAY
//#define ENVIRONMENT
//#define TRYCATCH
//#define RUNNOTEPADBYWINEXEC
//#define RUNNOTEPADBYPROCESSSTART
//#define GETPROCESS
//#define GETPROCESSTHREADSBYPROCESSID
//#define GETPROCESSMODULESBYPROCESSID
//#define LINQ
//#define THREADSTART
//#define THREADSTARTBYPARAMS
//#define SYNCTHREAD
//#define WEBAPI

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using System.Net.Http.Headers;
using System.Net;
using System.Xml;

namespace ConsoleApp
{
    class Program
    {
#if RUNNOTEPADBYWINEXEC

        [DllImport("Kernel32.dll")]
        public static extern int WinExec(string Path, uint nCmdShow);

#elif SYNCTHREAD

        // 공유자원
        private static Site m_site = new Site("www.winapi.co.kr");

#elif WEBAPI

#else

#endif

        static void Main(string[] args)
        {

#if DISPLAYARRAY

            DisplayArray();

#elif ENVIRONMENT

            GetEnvironment();

#elif TRYCATCH

            NestTry();

#elif RUNNOTEPADBYWINEXEC

            RunNotepad();

#elif RUNNOTEPADBYPROCESSSTART

            ProcessNotepad();

#elif GETPROCESS

            DisplayProcess();

#elif GETPROCESSTHREADSBYPROCESSID

            DisplayProcessThread();

#elif GETPROCESSTHREADSBYPROCESSID

            DisplayProcessModule();

#elif LINQ
            People[] peoples = { new People("정우성", 36, true)
                                , new People("고소영", 32, false)
                                , new People("배용준", 37, true)
                                , new People("김태희", 29, false)
            };

            Sale[] sales = { new Sale("정우성", "면도기", new DateTime(2008, 1, 1))
                            , new Sale("고소영", "화장품", new DateTime(2008, 1, 2))
                            , new Sale("김태희", "핸드폰", new DateTime(2008, 1, 3))
                            , new Sale("김태희", "휘발유", new DateTime(2008, 1, 4))
            };

            LinqGroupBy(peoples);
            LinqJoin(peoples, sales);

#elif THREADSTART

            ThreadByThreadStart();

#elif THREADSTARTBYPARAMS

            ThreadByParameterizedThreadStart(5);

#elif SYNCTHREAD

            SyncThread();

#elif WEBAPI

            

#else

#endif
            
            Console.ReadLine();
        }

#if WEBAPI
        
        
#endif



#if SYNCTHREAD
        private static void SyncThread()
        {
            Thread thread = new Thread(new ThreadStart(DownloadingFile)); // 공유자원을 사용하는 메서드 ==> DownloadingFile()
            thread.Start(); // 스레드 시작
            Thread.Sleep(2000);

            lock (m_site) // 공유자원 잠금
            {
                // 주 스레드가 공유자원(m_site)을 독점하여 잠금을 하면 주 스레드가 작업을 완료할 동안 다른 스레드는 공유자원 접근이 불가하여 대기상태.
                DownloadingFileFromApi();
            }
            // 주 스레드가 독점했던 공유자원을 잠금 해지하면 공유자원을 사용하는 대기상태의 다른 스레드에서 공유자원에 접근하여 하던 작업을 계속함.
        }
#endif

#if SYNCTHREAD
        /// <summary>
        /// 주 스레드에서 공유자원 잠금없이 호출
        /// </summary>
        private static void DownloadingFile()
        {
            for(int i=0; i<=100; i += 10)
            {
                lock (m_site)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("{0}에서 {1}% 다운로드 중", m_site.Name, i);
                }
                Thread.Sleep(1000);
            }
        }
#endif

#if SYNCTHREAD
        /// <summary>
        /// 주 스레드에서 공유자원 잠금상태로 호출
        /// </summary>
        private static void DownloadingFileFromApi()
        {
            // 1. 보관 : 공유자원 기존정보 보관
            string old = m_site.Name;

            // 2. 사용 : 공유자원 사용
            m_site.Name = "www.loseapi.co.kr";//
            for (int i = 0; i <= 100; i += 10)
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("{0}에서 {1}% 다운로드 중", m_site.Name, i);
                Thread.Sleep(500);
            }

            // 3. 복원 : 공유자원 기존정보 복원
            m_site.Name = old;
        }
#endif

#if THREADSTART
        private static void ThreadByThreadStart()
        {
            // Thread : 코드의 실행흐름
            //  + Name: 스레드명
            //  + IsAlive : 스레드 생존여부
            //  + IsBackground : 중요하지 않은 스레드인 경우 true(배경스레드), 파일입출력이나 인쇄 같은 중요 스레드인경우 false(전경스레드). 배경스레드는 응용프로그램종료시 즉시 중단됨.
            //  + Priority : 중요도(ThreadPriority 열거형: Highest, AboveNormal, Normal, BelowNormal, Lowest)
            //  + ThreadState : 스레드 현재 상태
            //  + CurrentThread : 현재 실행중인 스레드

            Thread thread = new Thread(new ThreadStart(DisplayNumber)); //0 ~ 9 까지 출력하는 메서드 ==> DisplayNumber()
            thread.IsBackground = false; //백그라운드 스레드로 설정
            thread.Start(); // 스레드 시작 ==> DisplayNumber()
            for (;;)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.A)
                {
                    Console.Beep();
                }
                else if (keyInfo.Key == ConsoleKey.B)
                {
                    break;
                }
            }
            thread.Abort();
            Console.WriteLine("주 스레드 종료");
        }
#endif

#if THREADSTARTBYPARAMS
        private static void ThreadByParameterizedThreadStart(int count)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(DisplayNumber)); //0 ~ N 까지 출력하는 메서드 ==> DisplayNumber(n)
            thread.IsBackground = false; //백그라운드 스레드로 설정
            thread.Start(count); // 매개변수를 전달하는 스레드 시작 ==> DisplayNumber(count)
            for (;;)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if(keyInfo.Key == ConsoleKey.A)
                {
                    Console.Beep();
                }
                else if(keyInfo.Key == ConsoleKey.B)
                {
                    break;
                }
            }
            thread.Abort();
            Console.WriteLine("주 스레드 종료");
        }
#endif

#if THREADSTART
        /// <summary>
        /// 0 ~ 9 까지 출력
        /// </summary>
        private static void DisplayNumber()
        {
            for(int i=0; i<10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
            Console.WriteLine("작업스레드 종료");
        }
#endif

#if THREADSTARTBYPARAMS
        /// <summary>
        /// 0 ~ N 까지 출력
        /// </summary>
        /// <param name="count"></param>
        private static void DisplayNumber(object count)
        {
            Console.WriteLine("매개변수: {0}", count);
            for (int i = 0; i < (int)count; i++)
            {
                Console.WriteLine("==>" + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("작업스레드 종료");
        }
#endif

#if DISPLAYARRAY
        private static void DisplayArray()
        {
            int[] arr = { 3, 4, 5 };
            Console.WriteLine("1 + 2 = {0}", AddAll(new int[2] { 1, 2 }));
            Console.WriteLine("3 + 4 + 5 = {0}", AddAll(arr));
            Console.WriteLine("6 + 7 + 8 + 9 = {0}", AddAll(6, 7, 8, 9));

            double[] arrFloat = { -3.6, 3.6, -3.4, 3.4 };//-3.6 = -3 ==> 3.6 = 4 ==> -3.4 = -3 ==> 3.4 ==> 4
            for (int i = 0; i < arrFloat.Length; i++)
            {
                //Console.WriteLine("Celling({0}) = {1}", arrFloat[i], Math.Ceiling(arrFloat[i]));//-3.6 = -3 ==> 3.6 = 4 ==> -3.4 = -3 ==> 3.4 ==> 4
                Console.WriteLine("Floor({0}) = {1}", arrFloat[i], Math.Floor(arrFloat[i]));    //-3.6 = -4 ==> 3.6 = 3 ==> -3.4 = -4 ==> 3.4 ==> 3
            }

            int result;
            int mok = Math.DivRem(5, 3, out result);
            Console.WriteLine("5 / 3 : 목: {0}, 나머지: {1}", mok, result);//1, 2
        }
#endif

#if LINQ
        private static void LinqJoin(People[] peoples, Sale[] sales)
        {
            Console.WriteLine("\r\n::전체회원명단 (조인)::");
            var query = from p in peoples
                        join s in sales on p.Name equals s.Customer
                        select new { p.Name, p.Age, s.Item, s.SaleDate };

            foreach(var q in query)
            {
                Console.WriteLine("{0}세 {1} 판매사원이 {2}(을)를 {3}에 구입함", q.Age, q.Name, q.Item, q.SaleDate);
            }
        }
#endif

#if LINQ
        private static void LinqGroupBy(People[] peoples)
        {
            Console.WriteLine("\r\n::전체회원명단 (이름역순/성별그룹)::");
            var queryGroup = from p in peoples
                             orderby p.Name descending
                             group p by p.IsMale;
            //IEnuerable<IGrouping<bool, People>> 결과셋
            foreach (var grp in queryGroup)
            {
                Console.WriteLine("성별: {0}", grp.Key ? "남성" : "여성");
                foreach (var q in grp)
                {
                    Console.WriteLine(q.Name);
                }
            }

            queryGroup = from p in peoples
                         orderby p.Name descending
                         group p by p.IsMale
                         into gp
                         where gp.Key == false
                         select gp;

            Console.WriteLine("::여성회원::");
            foreach (var grp in queryGroup)
            {
                foreach (var q in grp)
                {
                    Console.WriteLine(q.Name);
                }
            }

            var queryGroupAge = from p in peoples
                                let a = p.Age / 10
                                orderby a, p.Name
                                group p by a;

            //IEnuerable<IGrouping<int, People>> 결과셋
            foreach (var grp in queryGroupAge)
            {
                Console.WriteLine("{0} 대", grp.Key * 10);
                foreach (var q in grp)
                {
                    Console.WriteLine(q.Name);
                }
            }

            // 중첩쿼리문 : 내부 쿼리부터 외부 쿼리쪽으로 쿼리문 실행
            Console.WriteLine("::회원최고연장자::");
            var query = from p in peoples
                        where p.Age == (from a in peoples select a.Age).Max()
                        select p.Name;

                foreach (var q in query)
                {
                    Console.WriteLine(q);
                }
        }
#endif

#if RUNNOTEPADBYWINEXEC
        private static void RunNotepad()
        {
            Console.Write("메모장을 실행할까요?(Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                WinExec("notepad.exe", 1);
            }
        }
#endif

#if RUNNOTEPADBYPROCESSSTART
        private static void ProcessNotepad()
        {
            Process proc = Process.Start("notepad.exe");
            Thread.Sleep(5000);
            if (!proc.HasExited)
            {
                proc.Kill();
                Console.WriteLine("메모장을 정해진 실행시간 후 종료하였습니다.");
            }
            else
            {
                Console.WriteLine("메모장은 이미 종료되었습니다.");
            }
        }
#endif

#if GETPROCESS
        private static void DisplayProcess()
        {
            Process[] processes = Process.GetProcesses();
            foreach(Process proc in processes)
            {
                Console.WriteLine("ID = {0, 5}, 이름 = {1}", proc.Id, proc.ProcessName);
            }
        }
#endif

#if GETPROCESSTHREADSBYPROCESSID
        private static void DisplayProcessThread()
        {
            Process proc = Process.GetProcessById(24052);
            ProcessThreadCollection collection = proc.Threads;
            foreach(ProcessThread thread in collection)
            {
                Console.WriteLine("스레드 ID = {0}, 우선순위 = {1}", thread.Id, thread.PriorityLevel);
            }
        }
#endif

#if GETPROCESSMODULESBYPROCESSID
        private static void DisplayProcessModule()
        {
            Process proc = Process.GetProcessById(18552);
            ProcessModuleCollection collection = proc.Modules;
            foreach (ProcessModule module in collection)
            {
                Console.WriteLine("모듈 ID = {0}", module.ModuleName);
            }
        }
#endif

#if TRYCATCH
        // try 블록에서 발생하는 예외는 대응되는 catch 문에서 처리.
        // try 블록에서 처리하지 않은 예외는 바깥쪽 try 문의 대응되는 catch 문에서 처리
        private static void NestTry()
        {
            short Price, Num, Total = 0;

            // 널 가능 타입 : System.Nullable<T> 변수명
            //    + HasValue : 값이 정의되어 있으면 true. (변수.HasValue ==> 변수 != null 동일표현)
            //    + Value    : 실제 값. (변수.Value ==> 변수 동일표현) (널이면 InvalidOperationException 예외 발생)
            //    + 내장형타입과 널가능타입은 형이 같아도 다른 타입으로 대입연산 불가능 (byte b; byte? c; b = c; 에러발생)
            //byte b;                   //0 ~ 255
            //Nullable<byte> bA;        //0 ~ 255, null
            //byte? bB;                 //0 ~ 255, null
            //bool isH;                 //true, false
            //Nullable<bool> isHA;      //true, false, null
            //bool? isHB;               //true, false, null
            //int age;
            //int? ageNull = null;
            //age = ageNull ?? 25;      //if(ageNull == null) { return 25; } else { return ageNull; }

            try
            {
                Console.Write("단가를 입력하시오:");
                Price = Convert.ToInt16(Console.ReadLine());
                Console.Write("개수를 입력하시오:");
                try
                {
                    Num = Convert.ToInt16(Console.ReadLine());
                    checked
                    {
                        Total = (short)(Price * Num);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Console.WriteLine(ex.Message);
                }

                Console.WriteLine("총 가격은 {0}원 입니다.", Total);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format: " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ex: " + ex.Message);
            }
        }
#endif

#if ENVIRONMENT
        private static void GetEnvironment()
        {
            Console.WriteLine("Machine Name: {0}", Environment.MachineName);
            Console.WriteLine("User Name: {0}", Environment.UserName);
            Console.WriteLine("Version: {0}", Environment.Version);
            Console.WriteLine("Working Set: {0}", Environment.WorkingSet);
            Console.WriteLine("Current Directory: {0}", Environment.CurrentDirectory);
            Console.WriteLine("System Directory {0}", Environment.SystemDirectory);
            Console.WriteLine("OS Version: {0}", Environment.OSVersion);
            Console.WriteLine("Processor Count: {0}", Environment.ProcessorCount);
            Console.WriteLine("Tick Count: {0}", Environment.TickCount);
            Console.WriteLine("User Domain Name: {0}", Environment.UserDomainName);
            Console.WriteLine("내문서: {0}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }
#endif

#if WEBAPI
#else
        private static int AddAll(params int[] nums)
        {
            var sum = nums.Sum();
            return sum;
        }
#endif



    }
}
