using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Account : IAccount
    {
        private object lockThis = new object();
        /// <summary>
        /// 계좌잔액 (멀티스레드 공용필드)
        /// </summary>
        protected int m_money;
        protected Random m_rnd = new Random();

        /// <summary>
        /// 계좌초기화
        /// </summary>
        /// <param name="money">현재 계좌잔액</param>
        public Account(int money)
        {
            m_money = money;
        }

        /// <summary>
        /// 입금
        /// </summary>
        /// <param name="amount">요청한 입금 금액</param>
        /// <returns>실입금액</returns>
        protected virtual int Deposit(int amount)
        {
            lock (lockThis)//lock(this)
            {
                Console.WriteLine($"***** {Thread.CurrentThread.Name} 님이 {amount} 원을 입금하려 합니다.");
                Console.WriteLine($"입금전 예금 잔액: \\{m_money}");
                Console.WriteLine($"입금 금액 : \\{amount}");
                m_money += amount;
                Console.WriteLine($"입금후 예금 잔액: \\{m_money}\n");
            }

            return amount;
        }

        /// <summary>
        /// 출금
        /// </summary>
        /// <remarks>
        ///   + lock(this) : 멀티스레딩 환경에서 데드락 발생요인이 되므로 사용지양. 
        ///              서로 다른 스레드가 동일 시점에 각기 다른 필드를 사용하려 할때 액세스 불가 ==> lock(오브젝트인스턴스)로 해결
        /// </remarks>
        /// <param name="amount">요청한 출금 금액</param>
        /// <returns>실출금액 (0이면 잔액부족)</returns>
        protected virtual int Withdraw(int amount)
        {
            if(m_money <= 0)
            {
                throw new Exception("인출 잔액이 없거나 부족합니다");
            }

            lock (lockThis)//lock(this)
            {
                if(m_money >= amount)
                {
                    Console.WriteLine($">>>>> {Thread.CurrentThread.Name} 님이 {amount} 원을 인출하려 합니다.");
                    Console.WriteLine($"인출전 예금 잔액: \\{m_money}");
                    Console.WriteLine($"인출 금액 : \\{amount}");
                    m_money -= amount;
                    Console.WriteLine($"인출후 예금 잔액: \\{m_money}\n");

                    return amount;
                }
                else
                {
                    return 0;
                }
            }

        }

        /// <summary>
        /// 회사계좌의 10회 연속 입출금 처리 프로세스 테스트
        ///   ==> 10개의 임의의 수를 발생시킨다. 그 수가 음의 난수이면 (-난수액 * -1) 입금, 양의 난수이면 (+난수액) 출금처리
        /// </summary>
        public virtual void Transactions()
        {
            for(int i=0; i<10; i++)
            {
                int money = m_rnd.Next(-3000, 3000);
                if (money > 0)
                {
                    if (Withdraw(money) == 0)
                    {
                        Console.WriteLine("## Err : 인출 금액이 계좌 잔액보다 많습니다.");
                    }
                }
                else
                {
                    Deposit(money * -1);
                }
            }
        }

        
    }
}
