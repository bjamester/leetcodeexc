using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class RottingOranges : IRunnable
    {
        public void Run()
        {
            RunWith(new int[][] { 
                new int[] { 2, 1, 1 }, 
                new int[] { 1, 1, 0 }, 
                new int[]{ 0, 1, 1 } });
        }

        private void RunWith(int[][] grid)
        {
            var result = OrangesRotting(grid);
            Logger.LogLine($"Input cells: {grid.SelectMany(r => r).Count()}");
            Logger.LogLine($"Result: {result}");
        }

        public int OrangesRotting(int[][] grid)
        {
            // no fresh orange
            if (GetStatusCount(grid, 1) == 0)
                return 0;

            // no rotten orange
            if (GetStatusCount(grid, 2) == 0)
                return -1;

            Action<int[][], int, int> rottingOrange = (grid, row, col) =>
            {
                if (grid[row][col] == 2)
                {
                    RottingIfValid(grid, row, col + 1);
                    RottingIfValid(grid, row + 1, col);
                    RottingIfValid(grid, row, col - 1);
                    RottingIfValid(grid, row - 1, col);
                }
            };

            Action<int[][], int, int> postProcessOrange = (grid, row, col) =>
            {
                if (grid[row][col] == 3)
                    grid[row][col] = 2;
            };

            var rottingMinutes = -1;
            var rottingCount = int.MaxValue;
            while (rottingCount > 0)
            {
                var prevRottenCount = GetStatusCount(grid, 2);
                RunOnGrid(grid, rottingOrange);
                RunOnGrid(grid, postProcessOrange);
                rottingCount = GetStatusCount(grid, 2) - prevRottenCount;
                rottingMinutes++;
            }

            return GetStatusCount(grid, 1) == 0 
                ? rottingMinutes
                : -1;
        }

        private void RunOnGrid(int[][] grid, Action<int[][], int, int>action)
        {
            for(int row = 0; row < grid.Length; row++)
            {
                for(int col = 0; col < grid[row].Length; col++)
                {
                    action(grid, row, col);
                }
            }
        }

        private void RottingIfValid(int[][] grid, int row, int col)
        {
            var isValidIndex = row >= 0 && row < grid.Length && col >= 0 && col < grid[row].Length;

            if (isValidIndex && grid[row][col] == 1)
                grid[row][col] = 3;
        }

        private int GetStatusCount(int[][] grid, int status)
        {
            return grid.SelectMany(r => r).Count(c => c == status);
        }
    }
}
