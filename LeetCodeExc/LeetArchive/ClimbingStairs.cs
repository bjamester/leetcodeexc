using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class ClimbingStairs : IRunnable
    {
        public void Run()
        {
            var stairs = 45;
            Logger.LogLine($"Climbing {stairs} stairs...");

            for(var i = 0; i <= stairs; i++)
                RunWith(i);
        }

        private void RunWith(int stairs)
        {
            Logger.Log($"Stairs: {stairs} => ");
            Console.WriteLine(ClimbStairs(stairs));
        }
        public int ClimbStairs(int n)
        {
            var results = new List<int>();
            results.Add(0);
            results.Add(1);

            for (int i = 2; i <= n + 1; i++)
            {
                results.Add(GetNextStepCount(results));
            }

            return n >= 2 ? results.Last() : n;
        }

        private int GetNextStepCount(IList<int> results)
        {
            var prevValue = results.Last();
            var subValue = results.Count > 2 ? results[results.Count - 3] : 1;
            return prevValue * 2 - subValue;
        }
    }
}
