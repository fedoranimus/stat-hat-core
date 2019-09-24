using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StatHat
{
    internal sealed class EZRequest
    {
        public EZRequest(string ezKey, IEnumerable<EZStat> values) 
        {
            EzKey = ezKey;
            Data = values;
        }

        public EZRequest(string ezKey, EZStat value)
        {
            EzKey = ezKey;
            Data = new List<EZStat>() {
                value
            };
        }

        private string EzKey { get; }
        private IEnumerable<EZStat> Data { get; }

        public override string ToString()
        {
            using(var stringWriter = new StringWriter())
            {
                stringWriter.Write($@"{{ ""ezkey"": ""{EzKey}"",");
                stringWriter.Write(@" ""data"": [");
                stringWriter.Write(string.Join(",", Data.Select(datum => $"{datum.ToString()}")));
                stringWriter.Write("]}");
                //stringWriter.Write(@"""vb"": 1");

                return stringWriter.ToString();
            }
        }
    }
}