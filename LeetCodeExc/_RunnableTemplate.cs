using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class _RunnableTemplate : IRunnable
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
}
