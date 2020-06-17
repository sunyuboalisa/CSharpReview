using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClassMember
{
    class ConstructorPresenter:MainWindow
    {
        private static ConstructorPresenter _instance;
        public static ConstructorPresenter Instance
        {
            get
            {
                return _instance?? (_instance = new ConstructorPresenter());
            }
        }

        public ConstructorPresenter():this("param1","param2")
        {

        }
        public ConstructorPresenter(string param1) : base()
        {

        }
        public ConstructorPresenter(string param1,string param2)
        {

        }
        static ConstructorPresenter()
        {

        }
    }
}
