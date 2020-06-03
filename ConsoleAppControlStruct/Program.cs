using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Console;

namespace ConsoleAppControlStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSwitch();
            WriteLine("Type in a string");
            string input;
            input = ReadLine();

            if (input=="")
            {
                WriteLine("you typed in an empty string.");
            }
            else if (input.Length<5)
            {
                WriteLine("The string had less than 5 characters.");
            }
            else
            {
                WriteLine($"The string was {input}");
            }

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        static void TestSwitch()
        {
            string country;
            WriteLine("Type in a city");
            country = ReadLine();
            switch (country)
            {
                case "Hangzhou":
                    MessageBox.Show("Hangzhou");
                    break;
                default:
                    break;
            }
        }
    }
}
