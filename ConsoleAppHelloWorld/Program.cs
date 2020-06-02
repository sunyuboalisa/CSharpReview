using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleAppHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Hello World!");
            Test();
        }

        /// <summary>
        /// test var 
        /// </summary>
        static void Test()
        {
            var name = "Bugs Bunny";
            var age = 25;
            var isRabbit = true;
            Type nameType = name.GetType();
            Type ageType = age.GetType();
            Type isRabbitType = isRabbit.GetType();
        }
    }
}
