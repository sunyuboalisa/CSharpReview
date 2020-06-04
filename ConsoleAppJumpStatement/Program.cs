using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleAppJumpStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGotoStatement();
            TestBreakeStatement();
            TestContinueStatement();
            ReadKey();
            return;
        }

        #region goto语句
        static void TestGotoStatement()
        {
            goto Lable1;
            WriteLine("执行不到...");
            Lable1: WriteLine("jump！");
        }
        #endregion

        #region breake语句
        /// <summary>
        /// 测试break，循环跳出的不在举例。选择一个选项
        /// </summary>
        static void TestBreakeStatement()
        {
            WriteLine("you answer is:");
            ConsoleKeyInfo answer = ReadKey();
            switch (answer.KeyChar)
            {
                case 'A':
                    WriteLine("correct!");
                    break;
                case 'B':
                    WriteLine("incorrect!");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region continue语句
        /// <summary>
        /// 测试continue，输出0-9之间的奇数
        /// </summary>
        static void TestContinueStatement()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i%2==0)
                {
                    continue;
                }
                WriteLine(i);
            }
        }
        #endregion
    }
}
