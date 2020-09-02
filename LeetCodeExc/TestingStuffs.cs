using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class TestingStuffs : IRunnable
    {
        public void Run()
        {
            
        }

        public bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);
            
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i])
                    return true;
            }

            return false;
        }
    }
}
