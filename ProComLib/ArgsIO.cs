using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ProComLib
{
    public class ArgsIO
    {
        
    }
    public class Messenger
    {
        public static void SendMessage()
        {
            using (ServiceHost serviceHost=new ServiceHost(typeof(Message)))
            {
                try
                {
                    serviceHost.Open();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
