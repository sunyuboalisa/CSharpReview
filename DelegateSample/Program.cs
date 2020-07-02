using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Program
    {
        Action action = () => Console.WriteLine("lambda");
        static void Main(string[] args)
        {
            int x = 40;
            GetAString getAString = new GetAString(x.ToString);
            Console.WriteLine(getAString());

            var balance=new Currency(34, 50);
            getAString = balance.ToString;
            Console.WriteLine(getAString());

            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };

            for (int i = 0; i < operations.Length; i++)
            {
                ProcessAndDisplayNumber(operations[i], 3);
            }
            Func< string, string> actions;

            Employee[] employees =
            {
                new Employee("Bugs Bunny",12000),
                new Employee("Bird man",1300),
                new Employee("Bugs Bunny",454),
                new Employee("Bugs Bunny",12154),
                new Employee("Bugs Bunny",365)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            //当调用多播委托的时候，调用其放啊的委托。
        }

        static void ProcessAndDisplayNumber(DoubleOp action,double value)
        {
            double result = action(value);
            Console.WriteLine($"value is {value},result of operation is {result}");
        }

        #region 委托
        delegate string GetAString();

        struct Currency
        {
            public uint Dollars;
            public ushort Cents;

            public Currency(uint dollars,ushort cents)
            {
                this.Dollars = dollars;
                this.Cents = cents;
            }

            public override string ToString()
            {
                return $"{Dollars}.{Cents,2:00}";
            }

            public static string GetCurrencyUnit() => "Dollars";
            public static explicit operator Currency(float value)
            {
                checked
                {
                    uint dollars = (uint)value;
                    ushort cents = (ushort)((value - dollars) * 100);
                    return new Currency(dollars, cents);
                }
            }
            public static implicit operator float(Currency value)=>value.Dollars+(value.Cents/100.0f);
            public static implicit operator uint(Currency value)=>value.Dollars;
        }
        #endregion
    }
}
