using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExc
{
    class AddBinary : IRunnable
    {
        public void Run()
        {
            RunWith("1101010", "110000110001");
            RunWith("11", "1");
            RunWith("0", "0");
        }

        private void RunWith(string a, string b)
        {
            var result = AddDigits(a, b);
            Console.WriteLine($"         {a} + {b} = {result}");
        }

        public string AddDigits(string a, string b)
        {
            var sum = new Stack<char>(Math.Max(a.Length, b.Length));
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;

            while(i >= 0 || j >= 0)
            {
                var valA = i >= 0 ? a[i] : '0';
                var valB = j >= 0 ? b[j] : '0';

                var digit = AddDigits(valA, valB, ref carry);
                sum.Push(digit);
                i--;
                j--;
            }

            if (carry > 0)
                sum.Push('1');

            return new string(sum.ToArray());
        }

        private char AddDigits(char a, char b, ref int carry)
        {
            int intA = a - '0';
            int intB = b - '0';
            int sum = intA + intB + carry;

            carry = sum / 2;
            return (char)(sum % 2 + '0');
        }
    }
}
