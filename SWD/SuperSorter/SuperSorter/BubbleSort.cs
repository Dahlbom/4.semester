using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSorter
{
    public class BubbleSort : ISorter
    {
        public long sortArray(int[] arr)
        {
            var watch = Stopwatch.StartNew();
            watch.Start();
            int[] output = arr;
            int temp;
            for (int j = 0; j <= output.Length - 2; j++)
            {
                for (int i = 0; i <= output.Length - 2; i++)
                {
                    if (output[i] > output[i + 1])
                    {
                        temp = output[i + 1];
                        output[i + 1] = output[i];
                        output[i] = temp;
                    }
                }
            }
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
