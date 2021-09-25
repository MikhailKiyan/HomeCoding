using System.IO;
using System.Threading.Tasks;

namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public abstract class BaseDataProcessor
    {
        public abstract Task<string> ProcessData(Stream strem);
    }
}
