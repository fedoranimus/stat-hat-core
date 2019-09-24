using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("StatHat.Tests")]
namespace StatHat
{
    internal sealed class EZStat {
        public EZStat(string stat, double? count = null, double? value = null) {
            Stat = stat;
            Count = count;
            Value = value;
        }

        public string Stat { get; }
        public double? Count { get; }
        public double? Value { get; }

        public override string ToString() {
            string statDatum = "";

            if(Count != null)
            {
                statDatum = $@"""count"": {Count}";
            }
            else if(Value != null)
            {
                statDatum = $@"""value"": {Value}";
            }
            
            return $@"{{ ""stat"": ""{Stat}"", {statDatum} }}";
        }
    }
}