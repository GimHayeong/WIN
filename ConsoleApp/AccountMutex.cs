using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class AccountMutex : AccountMonitor
    {
        /// <summary>
        /// Mutex 개체 생성
        /// </summary>
        /// <remarks>
        ///   + Mutex 객체 생성(초기 소유권 소유여부, 뮤텍스별명)
        ///   + Mutex 요청
        ///        ==> 공유자원에 대한 신규 프로세스의 접근 요청 
        ///        ==> 다른 프로세스가 공유자원 사용중이면 뮤텍스는 요청 프로세스에 대기신호 보냄 
        ///        ==> 공유자원 사용종료하면 뮤텍스는 프로세스에 공유자원 사용가능신호 보냄
        ///        ==> 공유자원 사용
        ///   + Mutex 해제
        /// </remarks>
        private static Mutex m_Mutex = new Mutex(false, "AccountMutex");

        private object lockThis = new object();

        /// <summary>
        /// 계좌초기화
        /// </summary>
        /// <param name="money">현재 계좌잔액</param>
        public AccountMutex(int money)
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
            m_Mutex.WaitOne();
            try
            {
                Console.WriteLine($"***** {Thread.CurrentThread.Name} 님이 {amount} 원을 입금하려 합니다.");
                Console.WriteLine($"입금전 예금 잔액: \\{m_money}");
                Console.WriteLine($"입금 금액 : \\{amount}");
                m_money += amount;
                Console.WriteLine($"입금후 예금 잔액: \\{m_money}\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"입금중 예외발생 {ex.Message}");
            }
            finally
            {
                m_Mutex.ReleaseMutex();
            }


            return amount;
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

            // Mutex 사용권한 요청
            m_Mutex.WaitOne();

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
            catch(Exception ex)
            {
                Console.WriteLine($"출금중 예외발생 {ex.Message}");
            }
            finally
            {
                // Mutex 해제
                m_Mutex.ReleaseMutex();
            }

            return rtn;
        }

        public override void ShowData()
        {
            // Mutex 사용권한 요청
            m_Mutex.WaitOne();

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"전역 Mutex인스턴스 계좌 조회 요청 스레드: {Thread.CurrentThread.Name} ==> {i}");
                    Console.WriteLine($"계좌 잔액: \\{m_money}\n");
                    Thread.Sleep(100);
                    if (maxCnt == i) throw (new Exception());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외발생 >>> {ex.Message}");
            }
            finally
            {
                // Mutex 해제
                m_Mutex.ReleaseMutex();
            }

        }
    }
}
