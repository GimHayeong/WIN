using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf
{
    public class CommonResBrush
    {
        public object CommonResBrushKey
        {
            get { return new ComponentResourceKey(this.GetType(), "OrangeBrush"); }
        }
    }
}
