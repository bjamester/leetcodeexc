using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class Util
    {
        public static TimeSpan Time(Action action)
        {
            var watcher = Stopwatch.StartNew();
            action();
            watcher.Stop();
            return watcher.Elapsed;
        }
    }
}
