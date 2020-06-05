using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppObject
{
    class Customer
    {
        public string Name { get; set; }
        public void Consume()
        {
            Console.WriteLine("consume!!");
        }
    }
}
