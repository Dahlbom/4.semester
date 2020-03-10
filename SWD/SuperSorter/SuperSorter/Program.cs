using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort bubbleSort = new BubbleSort();
            ArrayGenerator myArrayGenerator = new ArrayGenerator(10000, 1000, 89);
            Console.WriteLine("Generating array...");
            myArrayGenerator.GenerateArray();
            Console.WriteLine("Sorting array...");
            long Time = bubbleSort.sortArray(myArrayGenerator.MyArray);
            Console.WriteLine($"The amount of time it took to sort array: {Time} Miliseconds" );
            

        }
    }
}
