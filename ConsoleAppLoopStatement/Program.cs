using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleAppLoopStatement
{
    class Program
    {
        

        static void Main(string[] args)
        {
            TestForLoop();
            TestWhileLoop();
            TestDoWhileLoop();
            TestForeachLoop();
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        #region for循环
        /// <summary>
        /// 测试for循环,输出一个9*9乘法表
        /// </summary>
        static void TestForLoop()
        {
            for (int i = 1; i < 10; i++)//外循环9次
            {
                for (int j = 1; j <= i; j++)//内循环i次
                {
                    Write($"{i}x{j}={i*j}\t");
                }
                WriteLine();
            }
        }
        #endregion

        #region while循环
        private static int absenteeism = 0;//缺勤次数
        /// <summary>
        /// 测试while循环
        /// </summary>
        static void TestWhileLoop()
        {
            double interval = 5*1000;
            System.Timers.Timer alertTimer = new System.Timers.Timer(interval);
            alertTimer.Elapsed += AlertTimer_Elapsed;
            alertTimer.Start();
        }

        /// <summary>
        /// 当缺勤次数超过三次，开始警告。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void AlertTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            absenteeism++;
            while (absenteeism>=3)
            {
                Beep();
                ((System.Timers.Timer)sender).Stop();
            }
        }
        #endregion

        #region do while循环
        static int remaining=5;//假定汽车开始有5升汽油。
        static void TestDoWhileLoop()
        {
            do
            {
                WriteLine("drive car");
                remaining--;//假设一次用1升的油
            } while (remaining > 0);

            WriteLine("there no gasline!!");
        }
        #endregion

        #region for循环
        static void TestForeachLoop()
        {
            List<string> MyRoommates = new List<string>
            { 
                "Ruan Yangyang",
                "Fu Xiuwei",
                "Sheng Rumeng"
            };

            foreach (var roommate in MyRoommates)
            {
                WriteLine(roommate);
            }
        }
        #endregion
    }
}
