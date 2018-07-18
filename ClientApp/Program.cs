using ServerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3, b = 2;
            Console.WriteLine("{0} + {1} = {2}", a, b, IntCalc.Add(a, b));
            Console.WriteLine("{0} - {1} = {2}", a, b, IntCalc.Sub(a, b));

            Console.ReadLine();
        }
    }
}
