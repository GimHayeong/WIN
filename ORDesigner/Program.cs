﻿//#define LINQFORM
#define ACCESSFILEFORM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORDesigner
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if ACCESSFILEFORM
            Application.Run(new AccessForm());
#else
            Application.Run(new LINQForm());
#endif
        }
    }
}