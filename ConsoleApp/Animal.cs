using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // static 정적클래스 : 인스턴스 생성없이 정적멤버만을 담은 클래스. 객체생성 불가. 상속 불가
    static class Message
    {
        // 정적메서드: 객체없이 호출가능
        public static void Warning()
        {
            //
        }

        public static void Error()
        {
            //
        }

        public static void Advice()
        {
            //
        }
    }

    // 추상클래스: 대표타입
    //             너무 일반적이라 인스턴스를 생성할 수 없는 클래스
    //             추상메서드가 하나라도 있으면 추상클래스여야 하며 비추상메서드도 포함가능.
    abstract class Animal
    {
        // 추상메서드: 자식메서드에서 재정의해야 하는 메서드의 시그니처만을 정의해 놓고자 할 경우
        //public abstract int MoMo(int a, double b);
        public abstract string Sound();
        public void MoMo()
        {
            // 추상클래스는 일반메서드도 포함 가능ㄴ
        }
    }

    // 자식클래스가 추상메서드를 재정의하지 않으면 자식클래스도 추상클래스
    abstract class Mammal : Animal
    {
        public string pregnant(int n)
        {
            return String.Format("임신 {0}주째", n);
        }
    }

    // 상속받은 추상메서드를 재정의해야만 구체 클래스가 된다.
    class Dog : Mammal
    {
        public override string Sound()
        {
            return "멍멍";
        }
    }

    class Cat : Mammal
    {
        public override string Sound()
        {
            return "야옹";
        }
    }

    class Cow : Mammal
    {
        // sealed: 하위 클래스에서 재정의 할 수 없게 봉인
        public sealed override string Sound()
        {
            return "음메";
        }
    }

    // sealed : 봉인된 클래스는 기반클래스로 사용불가. ==> class Bull : Dirty { } 불가
    sealed class Dirty : Cow
    {
        // new: 봉인되어 재정의할 수 없게 된 메서드를 재정의하려면 new를 사용하여 완전히 다른 동명의 메서드로 정의.
        public new string Sound()
        {
            return "음메";
        }
    }

    
}
