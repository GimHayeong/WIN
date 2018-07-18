using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Sale
    {
        public int OrderNo { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public DateTime OrderDate { get; set; }
        public Sale(string customer, string item, DateTime orderDate)
        {
            Customer = customer;
            Item = item;
            OrderDate = orderDate;
        }
    }
}
