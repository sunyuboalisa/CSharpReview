using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Employee
    {
        public Employee(string name,decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name},{Salary:C}";
        }
        public static bool CompareSalary(Employee e1, Employee e2) => e1.Salary < e2.Salary;
    }
}
