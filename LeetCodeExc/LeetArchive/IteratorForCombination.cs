using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class IteratorForCombination : IRunnable
    {
        public void Run()
        {
            RunWith(0);
        }

        private void RunWith(int input)
        {
            var result = TheMethod(input);
            Logger.LogLine($"Input: {input}");
            Logger.LogLine($"Result: {result}");
        }

        public int TheMethod(int input)
        {
            return 0;
        }
    }

    public class CombinationIterator
    {
        private string _characters = null;
        private int _combinationLength = 0;
        private int[] _positions = null;

        public CombinationIterator(string characters, int combinationLength)
        {
            _characters = characters;
            _combinationLength = combinationLength;
            _positions = new int[combinationLength];

            for (int i = 0; i < _positions.Length; i++)
                _positions[i] = i;
        }

        public string Next()
        {
            if(HasNext())
            {
                
            }
            return "";
        }

        public bool HasNext()
        {
            var hasNext = false;
            var index = 1;
            while(index < _positions.Length)
            {
                hasNext |= _positions[_positions.Length - index] < _characters.Length - index;
                index++;
            }
            return hasNext;
        }

        private bool MoveWindow()
        {
            var index = 0;
            while(index < _positions.Length)
            {
                var maxVal = _characters.Length - index - 1;
                var current = _positions.Length - index - 1;
                if(_positions[current] < maxVal)
                {
                    _positions[current]++;
                    return true;
                }

                if(current > 0)
                {
                    _positions[current] = _positions[current - 1] + 2;
                }
                index++;
            }
            return false;
        }
    }
}
