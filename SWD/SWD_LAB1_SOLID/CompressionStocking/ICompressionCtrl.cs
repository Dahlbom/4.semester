namespace CompressionStocking
{
    public interface ICompressionCtrl
    {
        void Compress();
        void Decompress();
    }

    public class StubCompressionCtl : ICompressionCtrl
    {
        private readonly ITimerCtl _timer;
        private readonly ICompressor _compressor;
        public void Compress()
        {
            _compressor.Compress();
        }

        public void Decompress()
        {
            _compressor.DeCompress();
        }
    }
}