using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Infrastructure.Models
{
    public class Sale
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

    }
}
