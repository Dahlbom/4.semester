using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    public interface ICompressor
    {
        void Compress();
        void DeCompress();
    }

    public class Compressor
    {
        public void Compress()
        {
            Console.WriteLine("Compressor have been called");
        }

        public void DeCompress()
        {
            Console.WriteLine("DeCompressor have been called");
        }
    }
}
