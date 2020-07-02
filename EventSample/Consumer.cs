using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventSample
{
    public class Consumer:IWeakEventListener
    {
        private string _name;

        public Consumer(string name)
        {
            _name = name;
        }

        public void NewCarIsHere(object sender,CarInfoEventArgs e)
        {
            Console.WriteLine($"{_name}: car {e.Car} is new");
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventArgs);
            return true;
        }
    }
}
