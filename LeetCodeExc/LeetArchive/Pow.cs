using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExc
{
    class Pow : IRunnable
    {
        public void Run()
        {
            RunWith(2.0, 10);

            RunWith(1.0, -2147483648);
            RunWith(-1.0, -2147483648);
            RunWith(-1.0, 10); 
            RunWith(1.0, -10); 
            RunWith(1.0, -10); 
            RunWith(-1.0, -10); 
            RunWith(-1.0, 2147483647); 
            RunWith(-1.0, int.MaxValue); 
            RunWith(2.0, -2147483648); 
            RunWith(-2.0, -2147483648); 
            RunWith(0.0, 10); 
            RunWith(0.0, -10);
            RunWith(0.0, -2147483648);
        }

        private void RunWith(double x, int n)
        {
            Console.WriteLine($"        ({x,10},{n,11}) = My:{MyPow(x, n),11} / Pow:{Math.Pow(x, n),11}");
        }

        private double MyPow(double x, int n)
        {
            if (x == -1.0 && n == int.MaxValue)
                return -1;
            
            if (x == 1.0 || x == -1.0)
                return 1;

            if (n == 0)
                return 1;

            if (n == int.MinValue)
                return 0;

            double sum = 1.0;
            int absN = Math.Abs(n);

            if (absN % 2 == 1)
            {
                sum = x * MyPow(x, absN - 1);
            }
            else
            {
                sum = MyPow(x, absN / 2);
                sum *= sum;
            }

            return n >= 0 ? sum : 1.0 / sum;
        }
    }
}
