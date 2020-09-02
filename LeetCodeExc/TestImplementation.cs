using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExc
{
    class TestImplementation : IRunnable
    {
        public void Run()
        {
            var numbers = new int[] { 2, 3, 2, 6, 0, 0, 77, 43, 77, 42, 77 };
            var result = TopKFrequent(numbers, 2);

            Console.WriteLine("Result: " + String.Join(',', result));
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            var numbers = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                IncrementCount(numbers, nums[i]);
            }

            return numbers
                .OrderByDescending(n => n.Value)
                .Select(n => n.Key)
                .Take(k)
                .ToArray();
        }

        private void IncrementCount(Dictionary<int, int> dict, int number)
        {
            if (!dict.ContainsKey(number))
                dict[number] = 0;

            dict[number]++;
        }
    }
}
