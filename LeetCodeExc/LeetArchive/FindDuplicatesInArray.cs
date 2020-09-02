using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class FindDuplicatesInArray : IRunnable
    {
        public void Run()
        {
            RunWith(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
        }

        private void RunWith(int[] nums)
        {
            var result = FindDuplicates(nums);
            Logger.LogLine($"Input: {string.Join(',', nums)}");
            Logger.LogLine($"Result: {string.Join(',',result)}");
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            var elements = new Dictionary<int, int>(nums.Length / 2);
            foreach(var num in nums)
            {
                if (!elements.ContainsKey(num))
                    elements.Add(num, 1);
                else
                    elements[num]++;
            }

            return elements
                .Where(n => n.Value == 2)
                .Select(n => n.Key)
                .ToList();
        }
    }
}