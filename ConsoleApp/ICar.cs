using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface ICar
    {
        void Run();
        void Back();
    }

    // 인터페이스 상속 : 구현해야 할 메서드 목록만 상속받음. 종속성이 없음. 다중상속 지원.
    // 인터페이스 상속시 인터페이스의 모든 메서드 구현 필수
    class Sedan : ICar
    {
        public virtual void Back()
        {
            //
        }

        public virtual void Run()
        {
            //
        }
    }

    // 클래스 상속시 상위 클래스의 메서드 재정의 선택
    class Grandeur : Sedan
    {
        public override void Run()
        {
            //
        }

        public void Booking()
        {
            //
        }
    }

    // 클래스 상속시 상위 클래스의 메서드 재정의 선택
    class Matiz : Sedan
    {
        public void FrogParking()
        {
            //
        }
    }

    abstract class Suv : ICar
    {
        public abstract void Back();
        public void Run()
        {
            //
        }
        public abstract void Run4Wd();
    }

    // 추상클래스 상속시 상위 추상클래스의 모든 메서드 구현 필수
    class Korando : Suv
    {
        public override void Back()
        {
            //
        }

        public override void Run4Wd()
        {
            //
        }
    }
}
