using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public delegate int ArthmeticDelegate(int a, int b);
    public delegate void PrintInfoDelegate(string str);
    public delegate void WhoAreYouDelegae();

    public class Arithmetic
    {
        public int Add(int a, int b) { return a + b; }
        public int Sub(int a, int b) { return a - b; }
        public int Mul(int a, int b) { return a * b; }
        public int Div(int a, int b)
        {
            if (a == 0 || b == 0) return 0;

            return a / b;
        }
        public void PrintInfo(string str)
        {
            Console.WriteLine(str);
        }

        public static void AreYouStatic()
        {
            Console.WriteLine("I am a static method.");
        }

        public void AreYouNormal()
        {
            Console.WriteLine("I am a normal method.");
        }
    }
}
