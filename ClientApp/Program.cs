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
            CallBll();

            Console.ReadLine();
        }

        static void CallBll()
        {
            ReferenceBll bll = new ReferenceBll();
            bll.CallServerLib();
        }
    }
}
