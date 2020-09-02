using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class Singles : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 1, 2, 1, 3, 2, 5 });
        }

        public void RunWith(int[] numbers)
        {
            Logger.LogLine($"Input:  [{string.Join(',', numbers)}]");
            var result = SingleNumber(numbers);
            Logger.LogLine($"Result: [{string.Join(',', result)}]");
        }

        public int[] SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            var singles = new List<int>();
            int i = 0;

            while (i < nums.Length - 1)
            {
                while (i < nums.Length - 1 && nums[i] != nums[i + 1])
                {
                    singles.Add(nums[i]);
                    i++;
                }

                if (singles.Count >= 2)
                    return singles.ToArray();

                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    i += 2;
                }
            }

            if(singles.Count == 1 && i == nums.Length - 1 && nums[i-1] != nums[i])
            {
                singles.Add(nums[i]);
            }

            return singles.ToArray();
        }
    }
}
