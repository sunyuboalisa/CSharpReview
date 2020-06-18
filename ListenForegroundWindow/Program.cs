using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListenForegroundWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            DeleteLog();

            int i = 0;
            Timer timer = new Timer((obj) =>
            {
                i += 100;
            });
            timer.Change(100, 0);

            while (i%100==0)
            {
                ForegroundWindowListener.PrintForegroundWindowInfo();
            }
        }
        static void DeleteLog()
        {
            if (File.Exists(@"./log.txt"))
            {
                File.Delete(@"./log.txt");
            }
        }
    }
}
