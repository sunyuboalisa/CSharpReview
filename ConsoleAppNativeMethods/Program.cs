using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNativeMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            LinkedList<int> listGeneric = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                listGeneric.AddLast(i);
            }
            foreach (var item in listGeneric)
            {
                Console.WriteLine(item);
            }
            NativeMethods.FileUtility.CreateHardLink(@"C:\log.txt", @"C:\tt.txt");
        }
    }
}
