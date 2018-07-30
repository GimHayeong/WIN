using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// Monitor 클래스 : lock 키워드보다 정교한 동기화 방법 제공하는 봉인클래스.
    ///                  임계영역의 시작점과 끝점 조정가능.
    ///                  Monitor.Enter() 로 지정한 동기화 시작점부터 Monitor.Exit()로 지정한 동기화 끝점 안에서 임계영역 처리 적용.
    ///                  
    ///   + Enter() / TryEnter() : 개체 잠금을 가져오고, 임계 영역의 시작을 표시.
    ///   + Wait() : 잠금해제 (다른 스레드의 개체 잠금 및 액세스 허용).
    ///   + Pulse(신호), PulseAll() : 하나 이상의 대기중인 스레드에 신호를 보냄.
    ///   + Exit() : 개체 잠금을 해제하고 잠겨있는 개체에서 보호하는 임계 영역의 끝을 표시.
    ///   
    /// </summary>
    class AccountMonitor : Account
    {

        private static object lockThisStatic = new object();
        /// <summary>
        /// 계좌잔액 (멀티스레드 공용필드)
        /// </summary>
        //int m_money;
        //Random m_rnd = new Random();
        public int maxCnt { get; set; }

        /// <summary>
        /// 계좌초기화
        /// </summary>
        /// <param name="money">현재 계좌잔액</param>
        public AccountMonitor(int money)
            : base(money)

        {
        }

        /// <summary>
        /// 입금
        /// </summary>
        /// <param name="amount">요청한 입금 금액</param>
        /// <returns>실입금액</returns>
        protected override int Deposit(int amount)
        {
            int rtn = 0;

            Monitor.Enter(lockThisStatic);
            //Monitor.TryEnter(lockThis, 1000);

            try
            {
                Console.WriteLine($"***** {Thread.CurrentThread.Name} 님이 {amount} 원을 입금하려 합니다.");
                Console.WriteLine($"입금전 예금 잔액: \\{m_money}");
                Console.WriteLine($"입금 금액 : \\{amount}");
                m_money += amount;
                Console.WriteLine($"입금후 예금 잔액: \\{m_money}\n");

                rtn = amount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"입금중 예외발생 {ex.Message}");
            }
            finally
            {
                Monitor.Exit(lockThisStatic);
            }

            return rtn;
        }

        /// <summary>
        /// 출금
        /// </summary>
        /// <param name="amount">요청한 출금 금액</param>
        /// <returns>실출금액 (0이면 잔액부족)</returns>
        protected override int Withdraw(int amount)
        {
            if (m_money <= 0)
            {
                throw new Exception("인출 잔액이 없거나 부족합니다");
            }

            int rtn = 0;

            Monitor.Enter(lockThisStatic);
            //Monitor.TryEnter(lockThis, 1000);

            try
            {
                if (m_money >= amount)
                {
                    Console.WriteLine($">>>>> {Thread.CurrentThread.Name} 님이 {amount} 원을 인출하려 합니다.");
                    Console.WriteLine($"인출전 예금 잔액: \\{m_money}");
                    Console.WriteLine($"인출 금액 : \\{amount}");
                    m_money -= amount;
                    Console.WriteLine($"인출후 예금 잔액: \\{m_money}\n");

                    rtn = amount;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"출금중 예외발생 {ex.Message}");
            }
            finally
            {
                // Monitor 해제
                Monitor.Exit(lockThisStatic);
            }

            return rtn;
        }

        public virtual int GetData()
        {
            return m_money;
        }

        public virtual void ShowData()
        {
            Monitor.Enter(lockThisStatic);
            //Monitor.TryEnter(lockThis, 1000);

            try
            {
                for(int i=0; i<10; i++)
                {
                    Console.WriteLine($"Monitor클래스 계좌 조회 요청 스레드: {Thread.CurrentThread.Name} ==> {i}");
                    Console.WriteLine($"계좌 잔액: \\{m_money}\n");
                    Thread.Sleep(100);
                    if (maxCnt == i) throw (new Exception());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"예외발생 >>> {ex.Message}");
            }
            finally
            {
                Monitor.Exit(lockThisStatic);
            }
        }

    }
}
