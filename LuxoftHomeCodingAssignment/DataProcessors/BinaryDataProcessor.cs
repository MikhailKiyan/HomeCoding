using System;
using System.IO;
using System.Threading.Tasks;

namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public class BinaryDataProcessor : BaseDataProcessor
    {
        const int MaxResultLenth = 5;

        public override async Task<string> ProcessData(Stream strem)
        {
            byte[] buffer = new byte[MaxResultLenth];
            var numberByteRead = await strem.ReadAsync(buffer, 0, buffer.Length);
            return BitConverter.ToString(buffer, 0, numberByteRead);
        }
    }
}
