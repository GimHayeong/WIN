using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // IDisposable 인터페이스를 상속받아 객체가 사라질때 비관리 자원을 직접 해제할 수 있게 구현
    class Socket : IDisposable
    {
        public int SocketPort { get; private set; }
        public bool Disposed { get; set; }

        public Socket(int port)
        {
            SocketPort = port;
        }

        // Dispose()메서드 : 관리자원과 비관리자원을 모두 해제하여 객체가 생성되지 전의 상태로 복구. GC.SuppressFinalize 메서드로 파괴자를 호출하지 않도록 가비지컬렉터에 지시.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool bManage)
        {
            if (Disposed) return;
            Disposed = true;

            if (bManage)
            {
                // 관리 자원 해제
            }
            //비관리 자원 해제
            SocketPort = 0;
        }

        // 파괴자 : 자신이 직접 할당한 비관리 자원만 해제해야 함(because 가비지컬렉터에 의해 호출되며 시기와 순서 예측불가하므로 관리자원의 파괴는 가비지컬렉터에 일임)
        ~Socket()
        {
            Dispose(false);
        }
    }

    class SocketTest
    {
        void Main()
        {
            Socket socket = new Socket(1234);
            // 어떤 작업들
            socket.Dispose();//모든 자원 해제

            //using(Socket s = new Socket(1234))
            //{
            //    //어떤 작업들
            //}// Dispose 메서드를 호출하지 않아도 using 블록에서 자동호출
        }


    }
}
