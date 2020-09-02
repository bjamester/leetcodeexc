using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LeetCodeExc
{
    public class SumOfZero : IRunnable
    {
        public void Run()
        { 
            //RunWith(new int [] {-1, 0, 1, 2, -1, -4});
            // RunWith(new int [] { 0, 3, 0, 1, 1, -1, -5, -5, 3, -3, -3, 0 });

            int numCount = 2000;
            Logger.LogLine($"Generating {numCount} numbers");
            RunWith(GenerateRandomNumbers(numCount, -1000000, 1000000));
        }

        public void RunWith(int[] input)
        {
            Logger.LogLine("ThreeSum started");

            var watch = Stopwatch.StartNew();
            var result = ThreeSum_Opt(input.ToArray());
            Logger.LogLine($"1. Optimized, {result.Count} items found in {watch.ElapsedMilliseconds} ms");

            watch = Stopwatch.StartNew();
            result = ThreeSum_Orig(input.ToArray());
            Logger.LogLine($"2. Original, {result.Count} items found in {watch.ElapsedMilliseconds} ms");
            Logger.LogLine("Press a key to list");
            Console.ReadKey();

            PrintResult(input, result);
        }

        private void PrintResult(int[] input, IList<IList<int>> result)
        {
            const int MaxInputPrintCount = 30;
            const int MaxOutputPrintCount = 100;

            var output = new List<string>();
            var i = -1;
            while (++i < result.Count && i < MaxOutputPrintCount)
            {
                var row = result[i];
                output.Add(string.Format("[{0}]", string.Join(',', row.ToArray())));
            }

            if (i < result.Count)
                output.Add($"[ ...{result.Count - i} items are not listed ]");

            Logger.LogLine($"Input:  [{string.Join(',', input.ToArray().Take(MaxInputPrintCount))}]");
            Logger.LogLine($"Output: [{string.Join(',', output.ToArray())}]");
        }

        private int[] GenerateRandomNumbers(int count, int min, int max)
        {
            var nums = new List<int>(count);
            var rnd = new Random();

            for(int i = 0;  i < count; i++)
            {
                nums.Add(rnd.Next(min, max));
            }

            return nums.ToArray();
        }

        public IList<IList<int>> ThreeSum_Opt(int[] nums)
        {
            var results = new List<IList<int>>();
            Array.Sort(nums);
            var hashedNumbers = nums.ToHashSet();

            for (int i = 0; i < nums.Length - 2 && nums[i] <= 0; i++)
            {
                for (int j = i + 1; j < nums.Length - 1 && nums[j] <= nums[i] * -1; j++)
                {
                    var targeted = 0 - (nums[i] + nums[j]);
                    if (hashedNumbers.Contains(targeted) && nums.Skip(j + 1).Any(n => n == targeted))
                    {
                        AddIfNotExists(new List<int> { nums[i], nums[j], targeted }, results);
                    }
                }
            }

            return results;
        }

        public IList<IList<int>> ThreeSum_Orig(int[] nums)
        {
            var results = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for(int k = j + 1; k < nums.Length; k++)
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        if(sum == 0)
                        {
                            var numbers = new List<int> { nums[i], nums[j], nums[k] };
                            numbers = numbers.OrderBy(n => n).ToList();
                            AddIfNotExists(numbers, results);
                        }
                    }
                }
            }

            return results;
        }

        private void AddIfNotExists(IList<int> numbers, IList<IList<int>> list)
        {
            if(!list.Any(row => row[0] == numbers[0] && row[1] == numbers[1] && row[2] == numbers[2]))
            {
                list.Add(numbers);
            }
        }
    }
}
