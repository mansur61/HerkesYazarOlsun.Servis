using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.BLL.Helper
{

    public class LimitedStream : Stream
    {
        private Stream _innerStream;
        private long _bytesRemaining;

        public LimitedStream(Stream innerStream, long length)
        {
            _innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
            _bytesRemaining = length;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_bytesRemaining <= 0) return 0;

            int bytesToRead = (int)Math.Min(count, _bytesRemaining);
            int bytesRead = _innerStream.Read(buffer, offset, bytesToRead);
            _bytesRemaining -= bytesRead;

            return bytesRead;
        }

        public override bool CanRead => _innerStream.CanRead;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public override void Flush() => _innerStream.Flush();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && _innerStream.CanRead)
                {
                    _innerStream.Dispose();
                }
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Stream dispose edilmiş.");
            }
        }
    }
}
