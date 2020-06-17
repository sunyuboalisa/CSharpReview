using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClassMember
{
    class PropertyPresenter
    {
        public string Property1 { get; set; }
        public string Property2
        {
            get;
        }
        private string _property3;
        public string Property3
        {
            get
            {
                return _property3;
            }
            set
            {
                _property3 = value;
            }
        }
        public string Property4 => $"property4";
    }
}
