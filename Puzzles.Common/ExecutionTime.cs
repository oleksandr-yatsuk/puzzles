using System;
using System.Diagnostics;

namespace Puzzles.Common
{
    public struct ExecutionTime
    {
        readonly Action _action;

        public ExecutionTime(Action action)
        {
            _action = action;
        }

        public TimeSpan ExecuteAndMeasure()
        {
            var time = new Stopwatch();
            time.Start();

            _action.Invoke();

            time.Stop();

            return TimeSpan.FromMilliseconds(time.ElapsedMilliseconds);
        }
    }
}