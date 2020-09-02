using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace LeetCodeExc
namespace LeetCodeExc
{
    public class LargestTime : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 1, 2, 3, 4 });
            RunWith(new int[] { 5, 5, 5, 5 });
            RunWith(new int[] { 2, 0, 6, 6 });
        }

        private void RunWith(int[] input)
        {
            var result = LargestTimeFromDigits(input);
            Logger.LogLine($"Input: [{string.Join(',', input)}]");
            Logger.LogLine($"Result: {result}");
        }

        public string LargestTimeFromDigits(int[] A)
        {
            var maxStart = 2;
            var result = "";
            while (maxStart >= 0 && result == string.Empty)
                result = GetLargestTime(A, maxStart--);

            return result;
        }

        public string GetLargestTime(int[] A, int maxStart)
        {
            var nums = A.OrderByDescending(n => n).ToList();

            var time = new List<string>();
            var current = 0;

            if (!TryPullMax(nums, maxStart, out current))
                return string.Empty;

            time.Add(current.ToString());

            var max = current == 2 ? 3 : 9;
            if (!TryPullMax(nums, max, out current))
                return string.Empty;

            time.Add(current.ToString());
            time.Add(":");

            if (!TryPullMax(nums, 5, out current))
                return string.Empty;

            time.Add(current.ToString());

            if (!TryPullMax(nums, 9, out current))
                return string.Empty;

            time.Add(current.ToString());

            return string.Join("", time);
        }

        private bool TryPullMax(IList<int> nums, int max, out int num)
        {
            num = -1;
            for (var i = 0; i < nums.Count; i++)
            {
                if (nums[i] <= max)
                {
                    num = nums[i];
                    nums.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
    }
}
