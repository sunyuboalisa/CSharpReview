using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    delegate double DoubleOp(double value);
    class MathOperations
    {
        public static double MultiplyByTwo(double value) => value * 2;
        public static double Square(double value) => value * value;
    }
}
