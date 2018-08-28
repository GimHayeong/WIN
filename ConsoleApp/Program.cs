//#define DISPLAYARRAY
//#define ENVIRONMENT
//#define TRYCATCH
//#define RUNNOTEPADBYWINEXEC
//#define RUNNOTEPADBYPROCESSSTART
//#define GETPROCESS
//#define GETPROCESSTHREADSBYPROCESSID
//#define GETPROCESSMODULESBYPROCESSID
//#define LINQ
//#define THREAD_START
//#define THREAD_START_BYPARAMS
//#define THREAD_START_BYCALLBACK
//#define THREAD_POOL
//#define THREAD_TIMER
//#define PROCESS_INFO
//#define THREAD_INFO
//#define THREAD_STATE
//#define THREAD_PRIORITY
//#define THREAD_START_LOCK
//#define THREAD_MONITOR
//#define THREAD_MUTEX
//#define SYNCTHREAD
//#define WEBAPI
//#define DELEGATE
//#define ATTRIBUTE_DLLIMPORT
//#define ATTRIBUTE_OBSOLETE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
#if ATTRIBUTE_DLLIMPORT || ATTRIBUTE_OBSOLETE
using System.Runtime.InteropServices;
#endif
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

#elif THREAD_TIMER

        private static int cntStaticTimer = 0;
        private int cntTimer = 0;
        private const int MAX_COUNT = 3;

#elif SYNCTHREAD

        // 공유자원
        private static Site m_site = new Site("www.winapi.co.kr");

#elif WEBAPI
#elif DELEGATE
#elif ATTRIBUTE_DLLIMPORT

        [DllImport("User32.dll")]
        public static extern int MessageBox(int hWnd, string lpText, string lpCaption, int uType);

#elif THREAD_START_BYCALLBACK

        private static int s_Data = 0;

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

#elif THREAD_START

            ThreadByThreadStart();

#elif THREAD_START_BYPARAMS

            //ThreadByParameterizedThreadStart(5);
            ThreadByParameterizedThreadStart(100, "안녕하세요");


#elif THREAD_POOL

            ThreadByThreadPool();

#elif THREAD_TIMER

            ThreadTimer();

#elif PROCESS_INFO

            ProcessList();

#elif THREAD_INFO

            DisplayThreadList();

#elif THREAD_STATE

            DisplayThreadState();

#elif THREAD_PRIORITY

            DisplayThreadPriority();

#elif SYNCTHREAD

            SyncThread();

#elif WEBAPI

            
#elif DELEGATE

            DelegateExam(20, 10);

            EventExam();

#elif ATTRIBUTE_DLLIMPORT

            MessageBox.Show(0, "Win32 MessageBox 호출", "DllImport 사용하기", 3);

#elif ATTRIBUTE_OBSOLETE
            //구메서드 사용하면 컴파일시 경고메시지로 안내
            //OldMessage();
            NewMessage();
#elif THREAD_START_LOCK

            ThreadStartForLock();

#elif THREAD_MONITOR

            //ThreadStartForLockByMonitor();
            ThreadStartForLockByMonitor(5, 7);

#elif THREAD_MUTEX

            //ThreadStartForLockByMutex();
            ThreadStartForLockByMutex(5, 7);

#elif THREAD_START_BYCALLBACK

            ThreadParamByCallback();
#else
#endif

            Console.ReadLine();
        }

#if WEBAPI
        
        
#endif

#if ATTRIBUTE_OBSOLETE
        [Obsolete("OldMessage 메서드는 NewMessage 메서드로 대체되었습니다.")]
        public static void OldMessage()
        {
            Console.WriteLine("지금은 20세기");
        }

        public static void NewMessage()
        {
            Console.WriteLine("지금은 21세기");
        }
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

#if THREAD_START
        /// <summary>
        /// ==========================================================================================================================================================================
        /// 스레드 : 프로세서가 프로세스 작업을 처리하기 위해 할당한 퀀텀시간(프로세스 수행시간)을 나누어 한 주기동안 여러 개의 작업을 수행할 수 있도록 만든 기법.
        ///    방법1) Thread 클래스를 이용해 스레드 생성
        ///    방법2) ThreadPool 클래스를 이용해 스레드 생성
        ///    방법3) Timer 클래스를 이용해 생성
        /// ==========================================================================================================================================================================
        /// 
        ///   + Name: 스레드명
        ///   + IsAlive : 스레드 생존여부
        ///   + IsBackground : 중요하지 않은 스레드인 경우 true(배경스레드), 파일입출력이나 인쇄 같은 중요 스레드인경우 false(전경스레드). 배경스레드는 응용프로그램종료시 즉시 중단됨.
        ///   + Priority : 중요도(ThreadPriority 열거형: Highest, AboveNormal, Normal, BelowNormal, Lowest)
        ///   + ThreadState : 스레드 현재 상태
        ///   + CurrentThread : 현재 실행중인 스레드
        /// 
        /// </summary>
        private static void ThreadByThreadStart()
        {
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

#if THREAD_START_BYPARAMS

        /// <summary>
        /// ParameterizedThreadStart를 이용한 인자전달
        /// </summary>
        /// <remarks>
        ///  ParameterizedThreadStart 델리게이트 : Object 형의 매개변수를 스레드에 전달
        /// </remarks>
        /// <param name="count"></param>
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

        /// <summary>
        /// ParameterizedThreadStart를 이용한 인자전달
        /// </summary>
        /// <param name="num"></param>
        /// <param name="msg"></param>
        private static void ThreadByParameterizedThreadStart(int num, string msg)
        {
            // 스레드를 통해 정적메서드에 인자 전달
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadStartParam.WriteInt));
            thread.Start(num);

            // 스레드를 통해 일반메서드에 인자 전달
            ThreadStartParam dp = new ThreadStartParam();
            thread = new Thread(new ParameterizedThreadStart(dp.WriteString));
            thread.Start(msg);
        }

        

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

#if THREAD_START_BYCALLBACK

        private static void ThreadParamByCallback()
        {
            ThreadStartCallback callback = new ThreadStartCallback(ResultCallback);
            Thread thread = new Thread(new ThreadStart(callback.ThreadProc));
            thread.Name = "스레드 A";
            Console.WriteLine($"{thread.Name} Start() 메서드 실행 전");
            ShowData();

            thread.Start();

            Console.WriteLine($"{thread.Name} Start() 메서드 실행 후");
            thread.Join();
            ShowData();
        }

        public static void ResultCallback(int data)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} 스레드가 실행한 ResultCallback : {data}");
            s_Data = data;
        }

        public static void ShowData()
        {
            Console.WriteLine($"ShowData() => {s_Data}");
        }
#endif


#if THREAD_POOL

        /// <summary>
        /// ThreadPool 클래스 : 프로세스별로 일정량의 스레드를 수용할 수 있는 풀을 만들어 스레드풀 내에서 스레드을 이용하는 방법으로 스레드 수를 유지.
        ///                     상대적으로 높은 안정성과 성능 제공
        ///                    
        ///   + QueueUserWorkItem (WaitCallback 델리게이트) : 스레드풀에 스레드 등록.
        ///                       등록한 스레드가 호출될 때 WaitCallback 델리게이트의 메서드 실행
        /// </summary>
        private static void ThreadByThreadPool()
        {
            // 스테틱메서드(PrintStatic) 를 ThreadPool을 이용해 작업요청 등록
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintStatic), "첫");

            // 일반메서드(PrintNotStatic) 를 ThreadPool을 이용해 작업요청 등록
            ThreadPool.QueueUserWorkItem(new WaitCallback((new ConsoleApp.Program()).PrintNotStatic), "두");

            for(int i=0; i<10; i++)
            {
                Console.WriteLine($"메인 스레드: {i}");
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 스레드가 호출될때 실행되는 메서드
        /// </summary>
        /// <param name="obj">"첫": 스레드가 호출될때 전달받은 인자</param>
        private static void PrintStatic(object obj)
        {
            for(int i=0; i<3; i++)
            {
                Console.WriteLine($">>> {obj}번째 스레드: {i}");
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 스레드가 호출될때 실행되는 메서드
        /// </summary>
        /// <param name="obj">"두": 스레드가 호출될때 전달받은 인자</param>
        private void PrintNotStatic(object obj)
        {
            for(int i=0; i<3; i++)
            {
                Console.WriteLine($"::: {obj}번째 스레드: {i}");
                Thread.Sleep(100);
            }
        }

#endif


#if THREAD_TIMER

        /// <summary>
        /// 스레드 풀처럼 동작하지 않음
        /// </summary>
        private static void ThreadTimer()
        {
            var autoEvent = new AutoResetEvent(false);
            Timer timer;

            // 스테틱 메서드 스레드 등록. 0.2초마다 호출 (전달인자, 스레드지연시간, 콜백 호출사이 시간간격)
            timer = new Timer(new TimerCallback(PrintStaticTimer), autoEvent, 300, 100);
            Thread.Sleep(700);//타이머가 실행될 시간
            timer.Dispose();

            // 일반 메서드 스레드 등록. 0.2초마다 호출 (전달인자, 스레드지연시간, 콜백 호출사이 시간간격
            timer = new Timer(new TimerCallback((new ConsoleApp.Program()).PrintTimer), autoEvent, 200, 100);

            Thread.Sleep(500);
            timer.Change(100, 0);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"메인 스레드: {i}");
                Thread.Sleep(100);
            }

            // 타이머 해제
            timer.Dispose();
        }

        private static void PrintStaticTimer(object obj)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)obj;

            Console.WriteLine($"::: 첫번째 스레드 {cntStaticTimer}: >>>>>");

            if (cntStaticTimer < MAX_COUNT)
            {
                cntStaticTimer++;
                autoEvent.Reset();
            }
        }

        private void PrintTimer(object obj)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)obj;
            
            Console.WriteLine($"::: 두번째 스레드 {cntTimer} *****");

            if (cntTimer < MAX_COUNT)
            {
                cntTimer++;
                autoEvent.Set();
            }
        }

        



#endif

#if PROCESS_INFO

        private static void DisplayProcessList()
        {
            try
            {
                Console.WriteLine("***** 현재 프로세스 정보 *****");
                DisplayProcessInfo(Process.GetCurrentProcess());

                Console.WriteLine("***** 전체 프로세스 정보 *****");
                Process[] procList = Process.GetProcesses();
                Console.WriteLine($"\t 시스템에서 사용중인 프로세스 수:  {procList.Length} 개");

                for(int i=0; i<procList.Length; i++)
                {
                    Console.WriteLine($"\t\t{i} 번째 프로세스 ============");
                    DisplayProcessInfo(procList[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"프로세스 검사도중 예외발생\r\n{ex.Message}");
            }
        }

        private static void DisplayProcessInfo(Process proc)
        {
            string procName = proc.ProcessName;
            int procId = proc.Id;
            long procMemorySize = proc.VirtualMemorySize64;
            try
            {
                DateTime procStartTime = proc.StartTime;
                Console.WriteLine($"Process; {procName}\nID: {procId}\n시작시간: {procStartTime}\n메모리: {procMemorySize}\n");
           }
            catch
            {
                Console.WriteLine($"Process; {procName}\nID: {procId}\n시작시간: 확인불가\n메모리: {procMemorySize}\n");
            }
        }

#endif

#if THREAD_INFO
        private static void DisplayThreadList()
        {
            try
            {
                Console.WriteLine("***** 현재 프로세스 정보 *****");
                ProcessThreadCollection threadList = Process.GetCurrentProcess().Threads;

                Console.WriteLine($"\t 시스템에서 사용중인 스레드 수:  {threadList.Count} 개");

                for (int i = 0; i < threadList.Count; i++)
                {
                    Console.WriteLine($"\t\t{i} 번째 스레드 ============");
                    DisplayThreadInfo(threadList[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"프로세스 검사도중 예외발생\r\n{ex.Message}");
            }
        }

        private static void DisplayThreadInfo(ProcessThread procTrd)
        {
            Console.WriteLine($"ID: {procTrd.Id}\n시작 시간: {procTrd.StartTime}\n우선 순위: {procTrd.BasePriority}\n상태: {procTrd.ThreadState}");
        }

#endif

#if THREAD_STATE

        private static void DisplayThreadState()
        {
            Thread thread = new Thread(new ThreadStart(Print));

            // UnStarted
            DisplayThreadInfo(thread);

            // 스레드 시작
            thread.Start();

            Thread.Sleep(100);

            // Running
            DisplayThreadInfo(thread);

            Thread.Sleep(100);

            // 스레드 일시정지
            //thread.Suspend();
            //Thread.Sleep(100);
            //DisplayThreadInfo(thread);

            // Suspend 상태 스레드 재시작
            //thread.Resume();
            //Thread.Sleep(100);
            //DisplayThreadInfo(thread);

            // 스레드 종료
            thread.Abort();
            // 스레드가 완전정지할 때까지 대기
            thread.Join();

            // Aborted
            DisplayThreadInfo(thread);
        }

        private static void Print()
        {
            try
            {
                for(int i=0; i<1000; i++)
                {
                    Console.WriteLine($"Print 스레드: {i}");
                }
            }
            catch(ThreadAbortException ex)
            {
                Console.WriteLine($"스레드 에러: {ex.Message}");
            }
        }

        public static void DisplayThreadInfo(Thread thread)
        {
            Console.WriteLine($"Thread ID: {thread.GetHashCode()}\t상태: {thread.ThreadState}");
        }

#endif

#if THREAD_PRIORITY

        private static void DisplayThreadPriority()
        {
            Thread threadA = new Thread(new ThreadStart(PrintA));
            Thread threadB = new Thread(new ThreadStart(PrintB));
            Thread threadC = new Thread(new ThreadStart(PrintC));
            Thread threadD = new Thread(new ThreadStart(PrintD));
            Thread threadE = new Thread(new ThreadStart(PrintE));

            threadA.Priority = ThreadPriority.Highest;
            threadE.Priority = ThreadPriority.Lowest;

            threadB.Start();
            threadE.Start();
            threadC.Start();
            threadD.Start();
            threadA.Start();
        }

        private static void PrintA() { Console.WriteLine("스레드 *"); }
        private static void PrintB() { Console.WriteLine("스레드 **"); }
        private static void PrintC() { Console.WriteLine("스레드 ***"); }
        private static void PrintD() { Console.WriteLine("스레드 ****"); }
        private static void PrintE() { Console.WriteLine("스레드 *****"); }

#endif

#if THREAD_START_LOCK

        /// <summary>
        /// 스레드 동기화
        ///  : 각기 다른 영업장에서 회사 계좌로 입출금 연속처리
        /// </summary>
        private static void ThreadStartForLock()
        {
            // 3개의 영업장
            Thread[] threads = new Thread[3];
            // 회사 계좌
            Account obj = new Account(10000);

            for (int i=0; i< threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(obj.Transactions));
                threads[i].Name = $"지점 [{i}]";
            }

            for(int i=0; i< threads.Length; i++)
            {
                threads[i].Start();
            }

            //foreach(var t in threads)
            //{
            //    t.Join();
            //}
        }
#endif

#if THREAD_MONITOR
        /// <summary>
        /// 스레드 동기화
        ///  : 각기 다른 영업장에서 회사 계좌로 입출금 연속처리
        /// </summary>
        private static void ThreadStartForLockByMonitor()
        {
            // 3개의 영업장
            Thread[] threads = new Thread[3];
            // 회사 계좌
            AccountMonitor obj = new AccountMonitor(10000);

            for (int i=0; i< threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(obj.Transactions));
                threads[i].Name = $"지점 [{i}]";
            }

            for(int i=0; i< threads.Length; i++)
            {
                threads[i].Start();
            }
        }

        /// <summary>
        /// 동일 자원을 여러 스레드가 공유자원에 접근가능할 때, 공유자원 사용허가를 받은 임의의 스레드가 공유자원을 사용한다.
        /// (스레드 Start 순서가 아닌, 공유자원이 사용허가 신청을 하고 허가를 받은 스레드)
        /// </summary>
        /// <remarks>
        ///   + 모든 스레드에 동일 객체인스턴스 할당 : 동일 객체인스턴스이므로, 스레드마다 객체인스턴스의 멤버변수에 다른 값을 가질 수 없음.
        ///   + 스레드에 각기 다른 객체인스턴스 할당 : 초기값이 공유자원이면 공유되지 않음.(공유자원이 초기값인 경우, 공유자원이 매번 초기값으로 초기화)
        /// </remarks>
        /// <param name="args"></param>
        private static void ThreadStartForLockByMonitor(params int[] args)
        {
            Thread[] threads = new Thread[args.Length];
            AccountMonitor obj = new AccountMonitor(10000);
            for(int i=0; i<args.Length; i++)
            {
                //AccountMonitor obj = new AccountMonitor(10000);
                obj.maxCnt = args[i];
                threads[i] = new Thread(obj.ShowData);
                threads[i].Name = "Thread - " + Convert.ToChar(65 + i);
            }

            foreach(var t in threads)
            {
                t.Start();
            }
        }
#endif

#if THREAD_MUTEX

        /// <summary>
        /// 동일 자원을 여러 스레드가 공유자원에 접근가능할 때
        /// </summary>
        private static void ThreadStartForLockByMutex(){
            // 3개의 영업장
            Thread[] threads = new Thread[3];
            // 회사 계좌
            AccountMutex obj;
            obj = new AccountMutex(10000);
            
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(obj.Transactions));
                threads[i].Name = $"지점 [{i}]";
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
        }

        /// <summary>
        /// 동일 자원을 여러 스레드가 공유자원에 접근가능할 때, 공유자원 사용허가를 받은 임의의 스레드가 공유자원을 사용한다.
        /// (스레드 Start 순서가 아닌, 공유자원이 사용허가 신청을 하고 허가를 받은 스레드)
        /// </summary>
        /// <remarks>
        ///   + 모든 스레드에 동일 객체인스턴스 할당 : 동일 객체인스턴스이므로, 스레드마다 객체인스턴스의 멤버변수에 다른 값을 가질 수 없음.
        ///   + 스레드에 각기 다른 객체인스턴스 할당 : 초기값이 공유자원이면 공유되지 않음.(공유자원이 초기값인 경우, 공유자원이 매번 초기값으로 초기화)
        /// </remarks>
        /// <param name="args"></param>
        private static void ThreadStartForLockByMutex(params int[] args)
        {
            Thread[] threads = new Thread[args.Length];
            AccountMutex obj = new AccountMutex(10000);//모든 스레드에 동일 객체인스턴스 할당
            for (int i = 0; i < args.Length; i++)
            {
                //AccountMutex obj = new AccountMutex(10000);//스레드에 각기 다른 객체 인스턴스 할당. 
                obj.maxCnt = args[i];//모든 스레드에 동일객체 인스턴스 할당의 경우, 스레드마다 다른 maxCnt 설정 안됨.
                threads[i] = new Thread(obj.ShowData);
                threads[i].Name = "Thread - " + Convert.ToChar(65 + i);
            }

            foreach (var t in threads)
            {
                t.Start();
            }
        }
#endif

#if THREAD_BACKGROUND

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

#if DELEGATE
        static void DelegateExam(int a, int b)
        {
            Arithmetic obj = new Arithmetic();
            ArthmeticDelegate dgtCalc;
            PrintInfoDelegate dgtPrint = new PrintInfoDelegate(obj.PrintInfo);
            WhoAreYouDelegae dgtStatic, dgtNormal, dgtCommon;

            dgtCalc = new ArthmeticDelegate(obj.Add);
            int sum = dgtCalc(a, b);
            dgtPrint($"{a} + {b} = {sum}");

            dgtCalc = new ArthmeticDelegate(obj.Sub);
            int sub = dgtCalc(a, b);
            dgtPrint($"{a} - {b} = {sub}");

            dgtCalc = new ArthmeticDelegate(obj.Mul);
            int mul = dgtCalc(a, b);
            dgtPrint($"{a} * {b} = {mul}");

            dgtCalc = new ArthmeticDelegate(obj.Div);
            int div = dgtCalc(a, b);
            dgtPrint($"{a} / {b} = {div}");

            // 정적 델리게이트 호출시 [클래스명.델리게이트명]으로 호출
            dgtStatic = new WhoAreYouDelegae(Arithmetic.AreYouStatic);
            dgtNormal = new WhoAreYouDelegae(obj.AreYouNormal);
            dgtStatic();
            dgtNormal();

            Console.WriteLine("+/-연산자를 통한 대리자등록");
            dgtCommon = dgtStatic;
            dgtCommon();

            Console.WriteLine("기존(static)의 대리자에 또 하나(normal)의 대리자 등록 ==>");
            dgtCommon += dgtNormal;
            dgtCommon();

            Console.WriteLine("기존(static/normal)의 대리자 중 하나(static)의 대리자 제거");
            dgtCommon -= dgtStatic;
            dgtCommon();

        }

        static void EventExam()
        {
            EventDelegateExam obj = new EventDelegateExam();
            obj.OnUserDefineEvent(10);
        }
#endif

    }
}
