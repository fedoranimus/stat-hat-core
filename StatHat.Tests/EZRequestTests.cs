using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StatHat.Tests
{
    public class EZRequestTests
    {
        [Fact]
        public void SerializeSingleEZStat()
        {
            var ezStatCount = new EZStat("TestStat", 1);
            var ezStatValue = new EZStat("TestStat", value: 1);

            Assert.Equal("{ \"stat\": \"TestStat\", \"count\": 1 }", ezStatCount.ToString());
            Assert.Equal("{ \"stat\": \"TestStat\", \"value\": 1 }", ezStatValue.ToString());
        }

        [Fact]
        public void SerializeSingleEZRequest()
        {
            var ezRequestCount = new EZRequest("ApiKey", new EZStat("TestStat", 1));
            var ezRequestValue = new EZRequest("ApiKey", new EZStat("TestStat", value: 1));

            Assert.Equal("{ \"ezkey\": \"ApiKey\", \"data\": [{ \"stat\": \"TestStat\", \"count\": 1 }]}", ezRequestCount.ToString());
            Assert.Equal("{ \"ezkey\": \"ApiKey\", \"data\": [{ \"stat\": \"TestStat\", \"value\": 1 }]}", ezRequestValue.ToString());
        }

        [Fact]
        public void SerializeMultipleEZStatsAsRequest()
        {
            var statList = new List<EZStat>() {
                new EZStat("TestStat", 1),
                new EZStat("TestStat", value: 1)
            };

            var ezRequest = new EZRequest("APIKey", statList);

            Assert.Equal("{ \"ezkey\": \"APIKey\", \"data\": [{ \"stat\": \"TestStat\", \"count\": 1 },{ \"stat\": \"TestStat\", \"value\": 1 }]}", ezRequest.ToString());
        }
    }
}
