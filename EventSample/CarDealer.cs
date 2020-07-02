using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{
    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }

        public string Car { get; }
    }

    public class CarDealer
    {
        private EventHandler<CarInfoEventArgs> newCarInfo;
        public event EventHandler<CarInfoEventArgs> NewCarInfo
        {
            add
            {
                newCarInfo += value;
            }
            remove
            {
                newCarInfo -= value;
            }
        }

        public void NewCar(string car)
        {
            RaiseNewCarInfo(car);
        }
        protected virtual void RaiseNewCarInfo(string car)
        {
            newCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
}
