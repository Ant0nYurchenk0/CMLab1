using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLab1
{
    internal class Newton : ICalculator
    {
        private string _precision;
        private int _intPrecision;

        public decimal Solve(int precision)
        {
            _precision = "n" + precision;
            _intPrecision = precision;
            return SolveForRoot();
        }

        private decimal SolveForRoot()
        {
            int counter = 0;
            Console.WriteLine("n\tx\tf(x)");
            decimal x = -2; //any point left to the left most extremum of the same sign as extremum
            //Console.WriteLine("Minimum number of iterations: " + NumOfIterations(a, b));
            Console.WriteLine(counter + "\t" + x + "\t" + ToNSigns(GetFuncValue(x)));
            while (ToNSigns(GetFuncValue(x)) != 0)
            {
                x = x - GetFuncValue(x)/GetDerivativeValue(x);
                x = ToNSigns(x);
                counter++;
                Console.WriteLine(counter + "\t" + x + "\t" + ToNSigns(GetFuncValue(x)));

            }
            return x;

        }

        private decimal GetFuncValue(decimal x)
        {
            return x * x * x - 4 * x * x - 15 * x + 18;
        }
        private decimal GetDerivativeValue(decimal x)
        {
            return 3 * x * x - 8 * x - 15;
        }
        private decimal ToNSigns(decimal x)
        {
            return Convert.ToDecimal(x.ToString(_precision));
        }
        private int NumOfIterations(decimal a, decimal b)
        {
            return (int)Math.Floor(Math.Log(((double)Math.Abs(a - b) / Math.Pow(10, -_intPrecision)), 2));
        }

    }
}
