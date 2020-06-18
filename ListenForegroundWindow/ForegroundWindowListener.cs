using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ListenForegroundWindow
{
    public class ForegroundWindowListener
    {
        private static string _currentForegroundWin;
        public static void PrintForegroundWindowInfo()
        {
            IntPtr handle = NativateMethods.GetForegroundWindow();
            StringBuilder caption = new StringBuilder(0x1000);
            NativateMethods.GetWindowText(handle, caption, caption.Capacity);

            if (_currentForegroundWin != caption.ToString())
            {
                _currentForegroundWin = caption.ToString();
                Console.WriteLine(_currentForegroundWin);
                File.AppendAllText(@"./log.txt", _currentForegroundWin+"\n",Encoding.UTF8);
            }
        }
    }
}
