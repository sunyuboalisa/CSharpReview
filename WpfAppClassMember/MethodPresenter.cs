using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
