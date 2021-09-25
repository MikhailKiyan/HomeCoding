using System;
using System.IO;
using System.Threading.Tasks;
using LuxoftHomeCodingAssignment.DataReadParameters;
using LuxoftHomeCodingAssignment.Helpers;

namespace LuxoftHomeCodingAssignment.DataReaders
{
    public class FileDataReader : BaseDataReader
    {
        public override ValueTask<Stream> ReadData(DataReadParameter parameter)
        {
            var fileReaderParameter = parameter as FileDataReadParameter
                ?? throw new ArgumentException("Wrong parameter type.", nameof(parameter));

            var filePath = fileReaderParameter.FilePath;
            if (   string.IsNullOrWhiteSpace(filePath)
                || filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                throw new ArgumentException("Wrong the file path.", ParametersHelper.Parameter.FilePath);
            }

            if(!File.Exists(filePath))
            {
                throw new ArgumentException("A file does not exist.", ParametersHelper.Parameter.FilePath);
            }

            stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            return  new ValueTask<Stream>(stream);
        }
    }
}
