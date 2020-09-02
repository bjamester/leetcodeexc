using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class ContainsDuplicate3 : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 1, 2, 3, 1 }, 3, 0);
            RunWith(new int[] { 1, 0, 1, 1 }, 1, 2);
            RunWith(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3);
            RunWith(new int[] { 1, 0, 1, 1 }, 1, 2);
            RunWith(new int[] { -1, 2147483647 }, 1, 2147483647);
        }

        private void RunWith(int[] nums, int k, int t)
        {
            var result = ContainsNearbyAlmostDuplicate(nums, k, t);
            Logger.LogLine($"Numbers: [{string.Join(',', nums)}]; k: {k}; t:{t}");
            Logger.LogLine($"Result: {result}");
            Console.WriteLine();
        }

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            for(int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j <= i + k && j < nums.Length; j++)
                {
                    if (Math.Abs((long)nums[i] - (long)nums[j]) <= t)
                    {
                        Logger.LogLine($"Found valid diff: ({i}, {j})");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
