using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ThreadStartParam
    {
        public static void WriteInt(object data)
        {
            Console.WriteLine(data);
        }

        public void WriteString(object data)
        {
            Console.WriteLine(data);
        }
    }
}
