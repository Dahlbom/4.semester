using System;
using System.Diagnostics;
using Pipelines;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SequentialStringCompression SSC = new SequentialStringCompression("ABC", 100000, 25000);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            double totaltime = SSC.Run();

            stopwatch.Stop();

            Console.WriteLine($"The time it took was: {stopwatch.ElapsedMilliseconds}");

        }
    }
}
