using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class HIndexCalculator : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 3, 0, 6, 1, 5 });
        }

        private void RunWith(int[] input)
        {
            var result = HIndex(input);
            Logger.LogLine($"Input: [{string.Join(',', input)}]");
            Logger.LogLine($"Result: {result}");
        }

        public int HIndex(int[] citations)
        {
            var orderedCit = citations.OrderByDescending(c => c);
            var citCount = 0;

            foreach(var cit in orderedCit)
            {
                citCount = orderedCit.Count(c => c >= cit);
                if (citCount == cit)
                    break;
            }

            return citCount;
            //return citations.Sum(c => c) > 0 ? 1 : 0;
        }
    }
}
