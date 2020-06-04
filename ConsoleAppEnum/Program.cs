using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppEnum
{
    class Program
    {
        /// <summary>
        /// 一天的阶段
        /// </summary>
        public enum TimeOfDay
        {
            Morning,
            Afternoon,
            Evening
        }

        static void Main(string[] args)
        {
            Greeting(TimeOfDay.Morning);
            Console.ReadKey();
        }

        /// <summary>
        /// greet.
        /// </summary>
        /// <param name="morning"></param>
        private static void Greeting(TimeOfDay morning)
        {
            Console.WriteLine("Good "+morning.ToString());
        }
    }
}
