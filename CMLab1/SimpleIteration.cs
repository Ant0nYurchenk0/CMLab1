using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLab1
{
    internal class SimpleIteration : ICalculator
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
            decimal a = -3m;
            decimal b = -1m;
            var q = GetK(a, b);
            Console.WriteLine("Min number of iterations: " + GetNumOfIterations(a, b));
            decimal xp = a;
            decimal xn = b;
            decimal res = xn - xp;
            int counter  = 0;
            Console.WriteLine("n\tx\tf(x)");
            Console.WriteLine(counter + "\t" + xn + "\t" + ToNSigns(GetFuncValue(xn))+"\t"+res);
            while (Math.Abs(res) > GetPrecision())
            {
                xn = ToNSigns(GetPhiValue(xn, a, b));
                res = xn - xp;
                xp = xn;
                counter++;
                Console.WriteLine(counter + "\t" + xn + "\t" + ToNSigns(GetFuncValue(xn))+"\t"+res);

            }
            return ToNSigns(xn);
        }


        private decimal GetFuncValue(decimal x)
        {
            return x * x * x - 10 * x * x + 11 * x + 70;
        }
        private decimal ToNSigns(decimal x)
        {
            return Convert.ToDecimal(x.ToString(_precision));
        }
        private decimal GetPhiValue(decimal x, decimal a, decimal b)
        {
            return x-GetFuncValue(x)/GetK(a, b);
            
        }
        private decimal GetPhiDerivativeValue(decimal x)
        {
            return 1 - 2 * (3 * x * x - 20 * x + 11) / 147;
        }
        private decimal GetFuncDerivativeValue(decimal x)
        {
            return 3 * x * x - 20 * x + 11;
        }
        private decimal GetQ(decimal a, decimal b)
        {
            return Math.Max(GetFuncDerivativeValue(a), GetFuncDerivativeValue(b));
        }
        private decimal GetK(decimal a,decimal b)
        {
            return 3m / 4 * Math.Abs(GetQ(a, b));
        }
        private decimal GetPrecision()
        {
            return (decimal)Math.Pow(10, -_intPrecision);
        }
        
        private decimal GetNumOfIterations(decimal a, decimal b)
        {
            var q = GetPhiDerivativeValue(b);
            var a1 = b - a;
            var b1 = (1 - q);
            var c = b1 * GetPrecision();
            var d = a1 / c;
            var e = Math.Log((double)Math.Abs(d));
            var f = 1m/q;
            var g = Math.Log((double)f);
            var h = e / g;
            return (decimal)Math.Floor(h) + 1;
        }
    }
}
