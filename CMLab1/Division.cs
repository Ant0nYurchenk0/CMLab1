using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLab1
{
    internal class Division : ICalculator
    {
        private string _precision;
        private int _intPrecision;
        public decimal Solve(int precision)
        {
            _intPrecision = precision;
            _precision = "n" + _intPrecision;
            return SolveForRootBetween(-1.5m, 7);
        }
        private decimal SolveForRootBetween(decimal a_, decimal b_)
        {
            var counter = 1;
            Console.WriteLine("n\tx\tf(x)");
            decimal a = ToNSigns(a_);
            decimal b = ToNSigns(b_);
            decimal x = ToNSigns((a + b) / 2);
            Console.WriteLine("Minimum number of iterations: " + NumOfIterations(a, b));
            Console.WriteLine(counter + "\t" + x + "\t" + Convert.ToDecimal(GetFuncValue(x).ToString(_precision)));
            while (ToNSigns(GetFuncValue(x)) != 0)
            {
                a = ToNSigns(Next(a, x));
                b = Convert.ToDecimal(Next(b, x).ToString(_precision));
                x = ToNSigns((a + b) / 2);
                counter++;
                Console.WriteLine(counter + "\t" + x + "\t" + ToNSigns(GetFuncValue(x)));
            }
            return x;
        }
        private decimal Next(decimal a, decimal x)
        {
            if (Math.Sign(GetFuncValue(a)) == Math.Sign(GetFuncValue(x)))
                return x;
            return a;
        }

        private decimal GetFuncValue(decimal x)
        {
            return x * x * x - 8 * x * x + 9 * x + 18;
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
