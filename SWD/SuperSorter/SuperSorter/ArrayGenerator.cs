using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSorter
{
    public class ArrayGenerator
    {
        private int[] _myArray;
        private int _size;
        private int _max;
        private int _seed;

        public int Size
        {
            private set => _size = value; 
            get => _size;
        }

        public int Max
        {
            private set => _max = value; 
            get => _max;
        }

        public int Seed
        {
            private set => _seed = value; 
            get => _seed;
        }

        public ArrayGenerator(int size, int max, int seed)
        {
            Size = size;
            Max = max;
            Seed = seed;
            GenerateArray();
        }

        public int[] MyArray
        {
            get => _myArray;
            set => GenerateArray();
        }

        public void GenerateArray()
        {
            int[] output = new int[Size];
            Random rand = new Random(Seed);
            for (int i = 0; i < Size; i++)
            {
                output[i] = rand.Next(0, Max);
            }

            _myArray = output;

        }

    }
}
