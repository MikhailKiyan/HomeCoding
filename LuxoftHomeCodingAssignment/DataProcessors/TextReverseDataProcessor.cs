using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public class TextReverseDataProcessor : BaseDataProcessor
    {
        const int MaxResultLenth = 6;
        public override async Task<string> ProcessData(Stream strem)
        {
            var buffer = new byte[MaxResultLenth * 2];
            await strem.ReadAsync(buffer, 0, buffer.Length);
            var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            text = text.Length > MaxResultLenth ? text.Substring(0, MaxResultLenth) : text;
            return new string(text.Reverse().ToArray());
        }
     }
}
