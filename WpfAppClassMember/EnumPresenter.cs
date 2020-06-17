using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClassMember
{
    class EnumPresenter
    {
        [Flags]
        public enum Color
        {
            Red=0x55,
            Green,
            Blue
        }
    }
}
