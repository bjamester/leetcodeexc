using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class ExcelSheetColumnNumber : IRunnable
    {
        public void Run()
        {
            RunWith("B");
            RunWith("AB");
            RunWith("ZY");
        }

        private void RunWith(string input)
        {
            var result = TitleToNumber(input);
            Logger.LogLine($"Excel column: {input} => {result}");
        }

        public int TitleToNumber(string s)
        {
            var sum = 0;
            var placeValue = 0;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                sum += (s[i] - 'A' + 1) * (int)Math.Pow(26, placeValue++); 
            }

            return sum;
        }
    }
}
