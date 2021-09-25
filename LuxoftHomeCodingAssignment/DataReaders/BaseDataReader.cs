using System;
using System.IO;
using System.Threading.Tasks;
using LuxoftHomeCodingAssignment.DataReadParameters;

namespace LuxoftHomeCodingAssignment.DataReaders
{
    public abstract class BaseDataReader : IDisposable
    {
        protected Stream stream;

        public virtual void Dispose()
        {
            stream?.Dispose();
        }

        public abstract ValueTask<Stream> ReadData(DataReadParameter parameter);
    }
}
