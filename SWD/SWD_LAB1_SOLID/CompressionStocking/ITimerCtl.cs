using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public interface ITimerCtl
    {
        void Timeout(int time_);
    }

    public class StubTimerCtl
    {
        public void Timeout(int time_)
        {
            Console.WriteLine($"Action will stop in {time_}");
        }
    }
}
