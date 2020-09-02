using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class TestingStuffs : IRunnable
    {
        private int _count = 0;
        
        public void Run()
        {
            var input = "ABCDEFG".ToArray();
            Console.WriteLine("My permutations: {0}", Util.Time(() => PermutationTest(input)));
            Console.WriteLine("Swapper permutations: {0}", Util.Time(() => GetPer(input)));
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

        private void PermutationTest(char[] letters)
        {
            _count = 0;
            Logger.LogLine($"Permute: [{string.Join(',', letters)}]");
            Permute(letters, string.Empty);
            Console.WriteLine($"{Environment.NewLine}Found: {_count}");
        }

        private void Permute(char[] letters, string result)
        {
            if (letters.Length == 1)
            {
                Console.Write(result, letters[0]);
                _count++;
            }
            else
            {
                foreach (var ch in letters)
                {
                    var remainings = letters.Where(l => l != ch).ToArray();
                    Permute(remainings, result + ch);
                }
            }
        }

        private void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public void GetPer(char[] list)
        {
            _count = 0;
            int x = list.Length - 1;
            GetPer(list, 0, x);
            Console.WriteLine($"{Environment.NewLine}Found: {_count}");
        }

        private void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
                _count++;
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }
    }
}
