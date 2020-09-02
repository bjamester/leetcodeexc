using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class GoatLatin : IRunnable
    {
        public void Run()
        {
            RunWith("I speak Goat Latin");
            RunWith("The quick brown fox jumped over the lazy dog");
        }

        private void RunWith(string input)
        {
            var result = ToGoatLatin(input);
            Logger.LogLine($"Input: {input}");
            Logger.LogLine($"Result: {result}");
        }

        public string ToGoatLatin(string S)
        {
            var vowels = "aeiouAEIOU";
            var sentence = new List<string>();
            var index = 1;
            foreach(var word in S.Split(' '))
            {
                var newWord = vowels.Contains(word[0])
                    ? word
                    : word.Substring(1) + word[0];

                sentence.Add(newWord + "ma" + new string('a', index++));
            }

            return string.Join(' ', sentence);
        }
    }
}
