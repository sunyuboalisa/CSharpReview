using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer() { Name = "Ruan Yangyang" };
            customer.Consume();
            Console.ReadKey();
        }
    }
}
