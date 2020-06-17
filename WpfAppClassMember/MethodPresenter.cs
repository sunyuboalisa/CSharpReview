using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppClassMember
{
    class MethodPresenter
    {
        private static MethodPresenter _instance;
        public static MethodPresenter Instance
        {
            get
            {
                _instance = _instance ?? new MethodPresenter();
                return _instance;
            }
        }

        public void SayHello()
        {
            MessageBox.Show("Hello");
        }
        public void Say(string message)
        {
            MessageBox.Show(message);
        }
        public DateTime GetDate() => DateTime.Now;
        public void PrintSomething(params string[] messages)
        {
            foreach (var item in messages)
            {
                Console.WriteLine(item);
            }
        }
    }

    //扩展方法
    public static class Extend
    {
        public static string GetString(this string s)
        {
            return "";
        }
    }
}
