using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class ValidPalindrome : IRunnable
    {
        public void Run()
        {
            RunWith("A man, a plan, a canal: Panama");
            RunWith("race a car");
        }

        private void RunWith(string input)
        {
            var result = IsPalindrome(input);

            Logger.LogLine($"Input: {input}");
            Logger.LogLine($"Result: {result}");
            Console.WriteLine();
        }

        public bool IsPalindrome(string s)
        {
            s = Regex.Replace(s, "[\\W,_]", "").ToLower();
            if (s.Length == 0)
                return true;

            int left, right;
            for (left = 0, right = s.Length - 1; left < right && s[left] == s[right]; left++, right--);

            return s[left] == s[right];
        }
    }
}
