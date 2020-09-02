using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class GraphAllPath : IRunnable
    {
        private IList<IList<int>> _pathes = new List<IList<int>>();
        private int[][] _graph = null;
        private int _target = 0;

        public void Run()
        {
            var graph1 = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3 },
                new int[] { 3 },
                new int[] { },
            };


            var graph2 = new int[][]
            {
                new int[] { 4, 3, 1 },
                new int[] { 3, 2, 4 },
                new int[] { 3 },
                new int[] { 4 },
                new int[] {   },
            };

            var graph3 = new int[][]
            {
                new int[] { 3, 1 },           // 0
                new int[] { 4, 6, 7, 2, 5 },  // 1 
                new int[] { 4, 6, 3 },        // 2
                new int[] { 6, 4 },           // 3
                new int[] { 7, 6, 5  },       // 4
                new int[] { 6 },              // 5
                new int[] { 7 },              // 6
                new int[] { },                // 7
            };

            RunWith(graph1);
            RunWith(graph2);
            RunWith(graph3);
        }

        private void RunWith(int[][] graph)
        {
            AllPathsSourceTarget(graph);
            Console.WriteLine();
        }

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            _graph = graph;
            _target = graph.SelectMany(n => n).Max();
            _pathes = new List<IList<int>>();
            var firstPath = new List<int>();
            firstPath.Add(0);

            MoveNext(0, 0, firstPath);

            Logger.LogLine("Input : " + string.Join(',', _graph.Select(r => $"[{string.Join(',', r)}]")));
            Logger.LogLine("Result: " + string.Join(',', _pathes.Select(r => $"[{string.Join(',', r)}]")));
            return _pathes;
        }

        private void MoveNext(int row, int col, IList<int> path)
        {
            var value = _graph[row][col];
            path.Add(value);

            if (col < _graph[row].Length - 1)
                MoveNext(row, col + 1, path.SkipLast(1).ToList());

            if (_graph.Length > value && _graph[value].Length > 0)
                MoveNext(value, 0, path);

            if (value == _target)
                _pathes.Add(path);
        }
    }
}
