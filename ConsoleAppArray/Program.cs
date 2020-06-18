using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppArray
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 255;
            //checked
            //{
            //    b++;
            //}
            Console.WriteLine(b);
            Method(b);
            string sss = "ddd";
            Console.WriteLine(nameof(sss));
        }

        public static void Method(object o)
        {
            if (o==null)
            {
                throw new ArgumentNullException(nameof(o));
            }
        }
    }
}
