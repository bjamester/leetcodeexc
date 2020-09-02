using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class PascalsTriangle : IRunnable
    {
        public void Run()
        {
            //RunWith(1);
            //RunWith(2);
            //RunWith(3);
            //RunWith(4);
            //RunWith(5);
            //RunWith(12);

            ShowTrianle(19, 5);
        }

        private void RunWith(int input)
        {
            var result = GetRow(input);
            Logger.LogLine($"Trangle: {input,3} --> [{string.Join(',', result)}]");
        }

        private void ShowTrianle(int level, int numWidth)
        {
            var triangle = GetTriangle(level);

            for (int i = 0; i < triangle.Count; i++)
            {
                var row = triangle[i];
                var convRow = row.Select(r => CenteredString(r.ToString(), numWidth));
                var rowLeftPadding = new string(' ', (numWidth + 1) * (level - i) / 2);
                Logger.LogLine($" {rowLeftPadding}{string.Join(' ', convRow)}");
            }
        }

        private string CenteredString(string s, int width)
        {
            int left = (width - s.Length) / 2;
            int right = width - s.Length - left;
            return new string(' ', left) + s + new string(' ', right);
        }

        public IList<int> GetRow(int rowIndex)
        {
            var triangle = GetTriangle(rowIndex);
            return triangle.Last().ToList();
        }

        private IList<int[]>GetTriangle(int level)
        {
            var triangle = new List<int[]>();
            var row = new int[] { 1 };
            triangle.Add(row);

            for (int i = 0; i < level; i++)
            {
                row = GetNextRow(row);
                triangle.Add(row);
            }
            return triangle;
        }

        private int[] GetNextRow(int[] prevRow)
        {
            int left, right;
            var currRow = new int[prevRow.Length + 1];
            currRow[currRow.Length - 1] = 1;

            for(int i = 0; i < prevRow.Length; i++)
            {
                left = i > 0 ? prevRow[i - 1] : 0;
                right = prevRow[i];
                currRow[i] = left + right;
            }
            return currRow;
        }
    }
}
