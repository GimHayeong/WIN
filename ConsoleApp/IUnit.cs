using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // 인터페이스 : 메서드의 목록만을 가짐. 
    //              멤버들은 구현코드를 가지지 않음. 
    //              상속받은 클래스는 인터페이스의 모든 멤버들을 구현해야 함.
    //              객체생성불가. 변수선언 가능.
    interface IUnit
    {
        void Move(int x, int y);
        void Attack(int x, int y);
        void Die();
    }

    class Marine : IUnit
    {
        private int m_Life = 200;
        public int Energy
        {
            get { return m_Life; }
        }
        public void Attack(int x, int y)
        {
            //
        }

        public void Die()
        {
            //
        }

        public void Move(int x, int y)
        {
            //
        }
    }

    class Zealot : IUnit
    {
        private int m_Life = 200;
        private int m_Shield = 50;
        public int Energy
        {
            get { return m_Life + m_Shield; }
        }
        public void Attack(int x, int y)
        {
            //
        }

        public void Die()
        {
            //
        }

        public void Move(int x, int y)
        {
            //
        }
    }

    class SCV : IUnit
    {
        public void Attack(int x, int y)
        {
            //
        }

        public void Die()
        {
            //
        }

        public void Move(int x, int y)
        {
            //
        }
    }
}
