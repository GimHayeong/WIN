using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Util
    {
        //Math
        // Celling : 크거나 같은 최소의 정수. 수직선 상의 바로 오른쪽 정수. -3.6 = -3 ==> 3.6 = 4 ==> -3.4 = -3 ==> 3.4 ==> 4
        // Floor   : 작거나 같은 최대의 정수. 수직선상의 바로 왼쪽 정수.    -3.6 = -4 ==> 3.6 = 3 ==> -3.4 = -4 ==> 3.4 ==> 3
        // DivRem  : 두 수의 몫을 리턴하고 out 변수로 나머지를 리턴.
        // Pow : 거듭제곱
        // Round : 반올림
        // Sqrt : 제곱근
        // Truncate : 소수부분을 버리고 정수부분만 취한다.
        public void DrawCircleByDot()
        {
            for(double angle = 0; angle < 360; angle += 10)
            {
                Console.CursorLeft = 40 + (int)(Math.Cos(angle * Math.PI / 180) * 20);
                Console.CursorTop = 12 + (int)(Math.Sin(angle * Math.PI / 180) * 10);
                Console.Write('.');
            }
        }

        public void GetRandom()
        {
            Random rand = new Random();
            for(int i=0; i<100; i++)
            {
                Console.CursorLeft = rand.Next(80);// 0 ~ 80 미만
                Console.CursorTop = rand.Next(3, 24); // 3 ~ 24 미만
            }

            double d = rand.NextDouble();//0 ~ 1.0 미만
            byte[] randBytes = new byte[10];
            rand.NextBytes(randBytes);//randBytes 는 난수로 채워진 배열로 반환된다.
            for(int i=0; i<randBytes.Length; i++)
            {
                Console.WriteLine(randBytes[i]);
            }
        }

        
    }
}
