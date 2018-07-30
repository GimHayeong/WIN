using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public delegate void ThreadParamCallback(int lineCount);

    /// <summary>
    /// 콜백 : 스레드 간에 데이터 교환에 사용
    /// </summary>
    public class ThreadStartCallback
    {
        private ThreadParamCallback m_dgtCallback;

        public ThreadStartCallback(ThreadParamCallback dgt)
        {
            m_dgtCallback = dgt;
        }

        public void ThreadProc()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} : ThreadProc() 호출");
            Thread.Sleep(1000);

            if(m_dgtCallback != null)
            {
                m_dgtCallback(1000);
            }
        }
    }
}
