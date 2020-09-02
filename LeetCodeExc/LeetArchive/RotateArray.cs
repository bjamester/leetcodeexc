using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class RotateArray : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);
        }

        private void RunWith(int[] nums, int k)
        {
            var orig = nums.ToArray();
            Rotate4(nums, k);
            Logger.LogLine($"Input : [{string.Join(',', orig)}]");
            Logger.LogLine($"Output: [{string.Join(',', nums)}]");
        }

        public void Rotate2(int[] nums, int k)
        {
            var tmpNums = nums;
            int length = nums.Length;

            while (k-- > 0)
                tmpNums = tmpNums.TakeLast(1).Concat(tmpNums.Take(length - 1)).ToArray();

            for (int i = 0; i < nums.Length; i++)
                nums[i] = tmpNums[i];
        }

        public void Rotate4(int[] nums, int k)
        {
            var tmpNums = nums;
            int length = nums.Length;

            if (k >= nums.Length)
            {
                while (k-- > 0)
                    tmpNums = tmpNums.TakeLast(1).Concat(tmpNums.Take(length - 1)).ToArray();
            }
            else
            {
                tmpNums = tmpNums.TakeLast(k).Concat(tmpNums.Take(length - k)).ToArray();
            }

            for (int i = 0; i < nums.Length; i++)
                nums[i] = tmpNums[i];
        }

        public void Rotate3(int[] nums, int k)
        {
            var queue = new Queue<int>(nums.Reverse());
            while (k-- > 0)
                queue.Enqueue(queue.Dequeue());

            var result = queue.Reverse();
            for (int i = 0; i < nums.Length; i++)
                nums[i] = result.ElementAt(i);
        }

        public void Rotate(int[] nums, int k)
        {
            var left = 0;
            var right = nums.Length - k - 1;
            while (left < right && k-- >= 0)
            {
                var tmp = nums[left];
                nums[left++] = nums[right];
                nums[right++] = tmp;
            }
        }


    }
}
