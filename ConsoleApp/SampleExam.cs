//#define CHECKED
//#define PARAMS
//#define RECURSIVE_CALL
//#define INDEXER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// 오버로딩 (Overloading) : 독일 객체 안에서 동명 메서드를 매개변수의 타입과 개수를 달리하여 정의.
    /// 오라바이딩 (Overriding) : 부모클래스의 동명(매개변수 타입 모두 일치) 메서드를 자식클래스에서 재정의.
    /// 캡슐화 : 객에체 데이터와 메서드를 숨겨두고 인터페이스 통로를 통해 값을 입력하고 결과를 받는 것.
    /// 클래스 : 객체의 개념을 담고 있는 최소단위
    ///          + abstract : 추상클래스 선언(추상메서드 포함하는 클래스)
    ///          + sealed : 상속중단 선언(자식클래스를 가질 수 없음)
    ///          
    /// ref : 변수를 전달하기 전에 초기화 필수
    /// out : 호출되는 메서드의 반환 이전에 값할당 필수
    /// params {가변 배열 매개변수} : 임의의 매개변수를 인자로 전달
    /// 
    /// readonly : 객체인스턴스를 통해 접근. 생성자에서 초기화 가능
    /// const : 상수는 선언시 초기화 필수
    /// 
    /// static : 메모리 힙 영역에 데이터가 저장되며 프로그램 실행 중 유일값. 
    ///          (클래스명.정적변수/ 클래스명.정적메서드 형태로 접근)
    ///          
    /// struct : 구조체는 값 타입. 상속 불가.
    ///          데이터가 작고 내부에 단순한 메서드만 있는 경우 클래스보다 메모리 소비를 줄일 수 있다.
    ///          
    /// new : 기반클래스의 멤버 재정의. 부모 클래스에서 상속받은 멤버에 대해 파생 클래스에서 새로운 용도로 활용하겠다고 선언.
    /// base : 파생 클래스에서 오버로이드한 기반 클래스의 멤버에 접근할 때 사용.
    /// 
    /// 델리게이트 : 대리할 메서드와 이름은 달라도 반환형과 매개변수 타입 및 개수는 동일해야 함.
    /// </summary>
    class SampleExam
    {
        enum Ranbow { red, orange, yellow, green, blue, indigo, violet };//0, 1, 2, 3, 4, 5, 6
        enum RanbowStart { red = 2, orange, yellow, green, blue, indigo, violet };//2, 3, 4, 5, 6, 7, 8
        enum RanbowDynamic { red, orange, yellow = 5, green, blue = 9, ingigo, violet };//0, 1, 5, 6, 9, 10, 11

        enum RangeMinMax : long {  Max = 2147483648L, Min = 255L };
        enum RangeTopBottom : byte { Top = 255, Bottom = 0 };


#if CHECKED
        private void GetShort(int val)
        {
            //형변환 중 오버플로우 발생시, 디버깅 시점에 에러 발견
            //컴파일시점에 checked 무시하고 컴파일하려면, csc/unchecked 파일명.cs 옵션으로 컴파일.
            //short data2 = checked(Convert.ToInt16(val));
        }
#endif

#if PARAMS
        private void GetMonth(params int[] args)
        {
            foreach(var n in args)
            {
                //
            }
        }
#endif

#if RECURSIVE_CALL
        private int GetFactorial(int num)
        {
            if(num > 1)
            {
                return GetFactorial(num - 1);
            }
            else
            {
                return 1;
            }
        }
#endif

    }

#if INDEXER

    class IndexerExam
    {
        private int mSize;
        public string[] mArray;

        public string this[int index]
        {
            get
            {
                if(index > -1 && index < mSize)
                {
                    return mArray[index];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                mArray[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return mArray.Length;
            }
        }

        public IndexerExam(int size)
        {
            mSize = size;
            mArray = new string[mSize];
        }
    }
#endif


#if STRUCT

    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"x = {X}, y = {Y}";
        }
    }

    struct ColorStruct
    {
        public byte R;
        public byte G;
        public byte B;

        public ColorStruct(byte red, byte green, byte blue)
        {
            R = red;
            G = green;
            B = blue;
        }
    }

    struct ColorPointStruct
    {
        public int mX { get; set; }
        public int mY { get; set; }
        public ColorStruct mColor { get; set; }
        public ColorPointStruct(int x, int y, byte red, byte green, byte blue)
        {
            mX = x;
            mY = y;
            mColor = new ColorStruct(red, green, blue);
        }
    }
#endif

}
