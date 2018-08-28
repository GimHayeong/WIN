using CSCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    /// <summary>
    /// C#으로 작성된 라이브러리를 VB와 공용으로 사용하는 예
    /// </summary>
    class ReferenceBll
    {
        public void CallServerLib()
        {
            int a = 3, b = 2;
            Console.WriteLine("{0} + {1} = {2}", a, b, IntCalc.Add(a, b));
            Console.WriteLine("{0} - {1} = {2}", a, b, IntCalc.Sub(a, b));
        }
    }
}
