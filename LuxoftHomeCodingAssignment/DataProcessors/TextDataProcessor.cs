using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public class TextDataProcessor : BaseDataProcessor
    {
        const int MaxResultLenth = 7;
        public override async Task<string> ProcessData(Stream strem)
        {
            var buffer = new byte[MaxResultLenth * 2];
            await strem.ReadAsync(buffer, 0, buffer.Length);
            var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            return text.Length > MaxResultLenth ? text.Substring(0, MaxResultLenth) : text;
        }
    }
}
