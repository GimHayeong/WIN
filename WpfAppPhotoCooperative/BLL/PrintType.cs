using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPhotoCooperative.BLL
{
    public class PrintType
    {
        public string Description { get; set; }
        public double Price { get; set; }

        public PrintType(string description, double price)
        {
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
