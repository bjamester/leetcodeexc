using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class DetectCapital : IRunnable
    {
        public void Run()
        {
            RunWith("USA");
            RunWith("MalaCka");
            RunWith("kiskacsa");
            RunWith("Nagykacsa");
        }

        private void RunWith(string word)
        {
            var result = DetectCapitalUse2(word);
            Logger.LogLine($"{word} -> {result}");
        }

        public bool DetectCapitalUse(string word)
        {
            var match = Regex.Match("lkj", "ppp");
            var pattern = "(^[a-z]+$)|(^[A-Z]+$)|(^[A-Z][a-z]+$)";
            return Regex.IsMatch(word.Trim(), pattern);
        }

        public bool DetectCapitalUse2(string word)
        {
            return
                char.IsUpper(word[0]) && word.Skip(1).All(l => char.IsLower(l)) ||
                word.All(l => char.IsUpper(l)) ||
                word.All(l => char.IsLower(l));
        }
    }
}
