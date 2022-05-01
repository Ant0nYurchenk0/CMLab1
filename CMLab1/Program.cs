using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var precision = 3;
            ICalculator calculator;

            calculator = new Division();
            Console.WriteLine("Method of Division");
            Console.WriteLine("Min solution: " + calculator.Solve(precision));
            Console.WriteLine(new string('-', 50));

            calculator = new Newton();
            Console.WriteLine("Method of Newton");
            Console.WriteLine("Min solution: " + calculator.Solve(precision));
            Console.WriteLine(new string('-', 50));

            calculator = new SimpleIteration();
            Console.WriteLine("Method of Simple Iteration");
            Console.WriteLine("Min solution: " + calculator.Solve(precision));
            Console.WriteLine(new string('-', 50));

            Console.ReadKey();
        }
    }
}
