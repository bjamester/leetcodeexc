using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class PowerOfFour : IRunnable
    {
        public void Run()
        {
            RunWith(5);
            RunWith(16);
            RunWith(64);
            RunWith(1024);
            RunWith(80);
            RunWith(1162261466);
        }


        private void RunWith(int input)
        {
            Logger.LogLine($"{input} is power of 4: {IsPowerOfFour(input)}");
        }

        private bool IsPowerOfFour(int num)
        {
            if (num == 0)
                return false;

            if (num == 1)
                return true;

            var exp = 1;
            long sum = 0;
            while (true)
            {
                sum = Convert.ToInt64(Math.Pow(4, exp));

                if (sum >= num)
                    break;

                exp += 2;
            }

            if (sum == num)
                return true;

            exp--;
            sum = Convert.ToInt64(Math.Pow(4, exp));

            return sum == num;
        }
    }
}
